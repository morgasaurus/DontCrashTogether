using System;

namespace DontCrashTogether
{
    /// <summary>
    /// A class for objectifying world save data
    /// </summary>
    public class WorldSave
    {
        /// <summary>
        /// Gets or sets the session ID of the world
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// Get or sets the index file server slot data of the world
        /// </summary>
        public string IndexData { get; set; }
        /// <summary>
        /// Gets or sets the name of the world server
        /// </summary>
        public string WorldName { get; set; }
        /// <summary>
        /// Gets or sets the base 64 encoded server config folder
        /// </summary>
        public string Base64ServerFiles { get; set; }
        /// <summary>
        /// Gets or sets the base 64 encoded server session data folder
        /// </summary>
        public string Base64SessionFiles { get; set; }
        /// <summary>
        /// Gets or sets the time the world was last saved
        /// </summary>
        public DateTime LastSaved { get; set; }
        /// <summary>
        /// Returns true if this world slot is empty otherwise false
        /// </summary>
        /// <returns>True if the world slot is empty otherwise false</returns>
        public bool IsEmpty() { return string.IsNullOrEmpty(SessionId); }

        /// <summary>
        /// Returns a new instanced copy of this world
        /// </summary>
        /// <returns></returns>
        public WorldSave Clone()
        {
            var world = new WorldSave();
            world.SessionId = SessionId;
            world.IndexData = IndexData;
            world.WorldName = WorldName;
            world.Base64ServerFiles = Base64ServerFiles;
            world.Base64SessionFiles = Base64SessionFiles;
            world.LastSaved = LastSaved;
            return world;
        }

        /// <summary>
        /// Returns a string containing session ID, name, and last save datetime
        /// </summary>
        /// <returns>A string identifying the world session ID, name, and save datetime</returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Base64SessionFiles))
            {
                return "Empty Slot";
            }
            else
            {
                return string.Format("{0}: {1} - {2}", SessionId, WorldName, LastSaved.ToString("MM-dd-yyyy hh:mm tt"));
            }
        }
    }
}
