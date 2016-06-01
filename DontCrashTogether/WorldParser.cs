using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace DontCrashTogether
{
    public class WorldParser
    {
        #region ConstructorsAndProperties
        /// <summary>
        /// Instantiates a world parser based on the specified world save directory
        /// </summary>
        /// <param name="saveDir">The world save directory</param>
        public WorldParser(string saveDir)
        {
            SaveDirectory = saveDir;
            SlotIndex = new Dictionary<int, SaveIndexSlot>();
        }
        
        /// <summary>
        /// Gets the save directory for this object
        /// </summary>
        public string SaveDirectory { get; protected set; }

        /// <summary>
        /// Gets the base server directory
        /// </summary>
        public string BaseServerDirectory { get { return SaveDirectory + @"\Cluster_"; } }

        /// <summary>
        /// Gets the client save directory
        /// </summary>
        public string ClientSaveDirectory { get { return SaveDirectory + @"\client_save"; } }

        /// <summary>
        /// Gets the path to the save index file
        /// </summary>
        public string SaveIndexPath { get { return ClientSaveDirectory + @"\saveindex"; } }

        /// <summary>
        /// Gets the base path to the session directory
        /// </summary>
        public string BaseSessionDirectory { get { return ClientSaveDirectory + @"\session"; } }

        /// <summary>
        /// Gets the automatic backup directory
        /// </summary>
        public string AutomaticBackupDirectory { get { return SaveDirectory + @"\..\DontCrashTogetherAutoBackup"; } }

        /// <summary>
        /// Event triggered when the world parser updates its progress percentage
        /// </summary>
        public event WorldParseProgressHandler OnWorldParseProgress;

        private Dictionary<int, SaveIndexSlot> SlotIndex;
        private int NumberOfSlots { get { return SlotIndex.Keys.Count; } }
        private string DateString { get { return DateTime.Now.ToString("yyyyMMdd_HHmmss"); } }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Parses world save data and returns the list of world objects
        /// </summary>
        /// <returns>The list of world save objects</returns>
        public Dictionary<int, WorldSave> ParseWorlds()
        {
            RefreshSlotIndex();

            string saveIndexText = File.ReadAllText(SaveIndexPath);

            // Parse server slot data from the index file
            var indexDataList = new List<string>();
            for(int i = 1; i <= NumberOfSlots; i++)
            {
                var slot = SlotIndex[i];
                indexDataList.Add(saveIndexText.Substring(slot.StartIndex, slot.Length));
            }

            // Get session IDs and server names
            var sessionIdList = new List<string>();
            var worldNameList = new List<string>();
            foreach(string s in indexDataList)
            {
                int index = s.IndexOf("session_id=");
                if (index == -1)
                {
                    sessionIdList.Add(string.Empty);
                    worldNameList.Add(string.Empty);
                }
                else
                {
                    sessionIdList.Add(s.Substring(index + 12, 16));
                    int nameIndex = s.IndexOf("name=");
                    worldNameList.Add(s.Substring(nameIndex + 6).Split('\"').First());
                }
            }

            // Now gather all necessary data and populate world objects
            var worldSaveDic = new Dictionary<int, WorldSave>();
            int numberOfSlots = indexDataList.Count;

            UpdateWorldParseProgress(1d / ((double)numberOfSlots + 1d));
            for(int i = 0; i < numberOfSlots; i++)
            {
                int slotNumber = i + 1;
                var world = new WorldSave();
                world.SessionId = sessionIdList[i];
                world.IndexData = indexDataList[i];
                world.WorldName = worldNameList[i];

                if (world.SessionId != string.Empty) // This means a server has data to get
                {
                    string serverDir = GetServerDirectory(slotNumber);
                    string sessionDir = GetSessionDirectory(world.SessionId);

                    if (Directory.Exists(sessionDir) && Directory.Exists(serverDir))
                    {
                        // Get the last saved time
                        var files = Directory.GetFiles(sessionDir);
                        world.LastSaved = files.Select(x => new FileInfo(x)).OrderByDescending(x => x.LastAccessTime).First().LastWriteTime;

                        // This is crude without a built-in way to archive a directory directly into memory
                        // Basically we create a temp archive file from each folder then convert the byte code to base 64
                        // The base 64 will allow painless XML serialization of the world save objects
                        if (File.Exists("temp.zip"))
                        {
                            File.Delete("temp.zip");
                        }

                        ZipFile.CreateFromDirectory(sessionDir, "temp.zip", CompressionLevel.NoCompression, false);
                        world.Base64SessionFiles = File.ReadAllBytes("temp.zip").ToBase64();
                        File.Delete("temp.zip");

                        UpdateWorldParseProgress(((double)i / 2 + 2d) / ((double)numberOfSlots + 1d));

                        ZipFile.CreateFromDirectory(serverDir, "temp.zip", CompressionLevel.NoCompression, false);
                        world.Base64ServerFiles = File.ReadAllBytes("temp.zip").ToBase64();
                        File.Delete("temp.zip");
                    }
                }

                worldSaveDic.Add(slotNumber, world);
                UpdateWorldParseProgress(((double)i + 2d) / ((double)numberOfSlots + 1d));
            }
            return worldSaveDic;
        }

        /// <summary>
        /// Restores the specified world into the specified slot and returns the new world list
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="slotNumber">The slot that will be overwritten</param>
        public Dictionary<int, WorldSave> RestoreWorld(WorldSave world, int slotNumber)
        {
            RefreshSlotIndex();
            var currentWorlds = ParseWorlds();

            // Before doing any writing, check to make sure there will not be a duplicate session ID
            for (int i = 1; i <= NumberOfSlots; i++)
            {
                if (currentWorlds[i].SessionId == world.SessionId && i != slotNumber)
                {
                    throw new InvalidOperationException("Two worlds with the same session ID must not occupy two different world slots");
                }
            }

            // Now also backup the current world automatically to the backup directory
            var oldWorld = currentWorlds[slotNumber];
            SaveWorld(oldWorld, AutomaticBackupDirectory + @"\AutoBackup_" + world.SessionId + "_" + DateString + ".xml");

            // Restore the index data
            var slotInfo = SlotIndex[slotNumber];
            var sb = new StringBuilder(File.ReadAllText(SaveIndexPath));
            sb.Remove(slotInfo.StartIndex, slotInfo.Length);
            sb.Insert(slotInfo.StartIndex, world.IndexData);
            File.WriteAllText(SaveIndexPath, sb.ToString());

            // Restore the session and server data
            string serverDir = GetServerDirectory(slotNumber);
            string sessionDir = GetSessionDirectory(world.SessionId);

            // Delete corresponding directories if necessary
            if (Directory.Exists(serverDir))
            {
                Directory.Delete(serverDir, true);
            }
            if (Directory.Exists(sessionDir))
            {
                Directory.Delete(sessionDir, true);
            }

            // Delete temp zip file if neccessary
            if (File.Exists("temp.zip"))
            {
                File.Delete("temp.zip");
            }

            // Restore the server data
            File.WriteAllBytes("temp.zip", world.Base64ServerFiles.ToByteCode());
            ZipFile.ExtractToDirectory("temp.zip", serverDir);
            File.Delete("temp.zip");

            // Restore the session data
            File.WriteAllBytes("temp.zip", world.Base64SessionFiles.ToByteCode());
            ZipFile.ExtractToDirectory("temp.zip", sessionDir);
            File.Delete("temp.zip");

            currentWorlds[slotNumber] = world.Clone();
            RefreshSlotIndex();
            return currentWorlds;
        }

        /// <summary>
        /// Save the world (but not the cheerleader)
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="path">The path to save the world</param>
        public void SaveWorld(WorldSave world, string path)
        {
            File.WriteAllText(path, world.Serialize());
        }

        /// <summary>
        /// Load the world from the specified path
        /// </summary>
        /// <param name="path">The path to the world</param>
        /// <returns>The world</returns>
        public WorldSave LoadWorld(string path)
        {
            return File.ReadAllText(path).Deserialize<WorldSave>();
        }

        /// <summary>
        /// Backs up absolutely all raw save data to a dated archive file
        /// </summary>
        public void Backup()
        {
            ZipFile.CreateFromDirectory(SaveDirectory, AutomaticBackupDirectory + @"\CompleteServerBackup_" + DateString + ".zip");
        }

        public void CleanBackups(int numberOfBackups)
        {
            var files = Directory.GetFiles(AutomaticBackupDirectory).Select(x => new FileInfo(x))
                .Where(x => x.Name.StartsWith("CompleteServerBackup") || x.Name.StartsWith("AutoBackup"))
                .OrderByDescending(x => x.LastAccessTime).Skip(numberOfBackups).Select(x => x.FullName).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }
        #endregion

        #region PrivateMethods
        private void RefreshSlotIndex()
        {
            string saveIndexText = File.ReadAllText(SaveIndexPath);

            int braceLevel = 0;
            int slotNumber = 1;
            var slot = new SaveIndexSlot();

            // This is where it gets ugly; the current level of being inside braces is the only real way to tell
            // the slots apart; this code will need updating if KLEI modifies their save file format too much
            for (int i = 0; i < saveIndexText.Length; i++)
            {
                char c = saveIndexText[i];
                if (c == '{')
                {
                    braceLevel++;
                    if (braceLevel == 3)
                    {
                        slot.StartIndex = i;
                    }
                }
                if (c == '}')
                {
                    braceLevel--;
                    if (braceLevel == 2)
                    {
                        slot.EndIndex = i;
                        SlotIndex.AddOrUpdate(slotNumber++, slot);
                        slot = new SaveIndexSlot();
                    }
                }
            }
        }

        private string GetServerDirectory(int slot)
        {
            return BaseServerDirectory + slot.ToString();
        }

        private string GetSessionDirectory(string sessionId)
        {
            return BaseSessionDirectory + @"\" + sessionId;
        }

        private void UpdateWorldParseProgress(double pct)
        {
            OnWorldParseProgress?.Invoke(this, new WorldParseProgressEventArgs(pct));
        }
        #endregion
    }
    
    /// <summary>
    /// Event handler delegate for the world parsing progress update event
    /// </summary>
    /// <param name="sender">The object from which the event originated</param>
    /// <param name="e">The event arguments for the event which contain the progress percentage</param>
    public delegate void WorldParseProgressHandler(object sender, WorldParseProgressEventArgs e);

    /// <summary>
    /// Event arguments class for the world parsing prorgress update event
    /// </summary>
    public class WorldParseProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Instantiates this class with the specified progress percentage
        /// </summary>
        /// <param name="pct">The progress percentage</param>
        public WorldParseProgressEventArgs(double pct)
        {
            PercentComplete = pct;
        }

        /// <summary>
        /// Gets or sets the progress percentage for this event argument
        /// </summary>
        public double PercentComplete { get; set; }
    }

    /// <summary>
    /// A class to keep track of where save index data lives in the saveindex file
    /// </summary>
    public class SaveIndexSlot
    {
        /// <summary>
        /// Instantiates a new save index slot object
        /// </summary>
        public SaveIndexSlot() { }

        /// <summary>
        /// Instantiates a new save index slot object having the specified start and end indices
        /// </summary>
        /// <param name="startIndex">The start index</param>
        /// <param name="endIndex">The end index</param>
        public SaveIndexSlot(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary>
        /// Gets or sets the start index of this save index slot
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// Gets or sets the end index of this save index slot
        /// </summary>
        public int EndIndex { get; set; }

        /// <summary>
        /// Gets the length of the data string for this save index slot
        /// </summary>
        public int Length { get { return EndIndex - StartIndex + 1; } }
    }
}
