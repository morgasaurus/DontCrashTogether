using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontCrashTogether
{
    /// <summary>
    /// Class for program-wide methods
    /// </summary>
    public static class GlobalMethods
    {
        /// <summary>
        /// Returns the value of the application setting corresponding to the specified key
        /// </summary>
        /// <param name="key">The application setting key</param>
        /// <returns>The application setting value</returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Adds an application setting to the config file if it is not there; updates the application setting if it is
        /// </summary>
        /// <param name="key">The application setting key</param>
        /// <param name="val">The application setting value</param>
        public static void AddUpdateAppSetting(string key, string val)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, val);
            }
            else
            {
                settings[key].Value = val;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Loads Application variables from the config file
        /// </summary>
        public static void LoadAppVars()
        {
            AppVars.SaveDirectory = GetAppSetting("SaveDirectory");
            int n;
            if (int.TryParse(GetAppSetting("NumberOfAutoBackups"), out n))
            {
                AppVars.NumberOfAutoBackups = n;
            }
            else
            {
                AppVars.NumberOfAutoBackups = 10;
            }
        }

        /// <summary>
        /// Saves Application variables to the config file
        /// </summary>
        public static void SaveAppVars()
        {
            AddUpdateAppSetting("SaveDirectory", AppVars.SaveDirectory);
            AddUpdateAppSetting("NumberOfAutoBackups", AppVars.NumberOfAutoBackups.ToString());
        }

        /// <summary>
        /// Automatically detects the Don't Starve Together world save directory; returns string.Empty if it could not be found
        /// </summary>
        /// <returns>The world save directory if found otherwise an empty string</returns>
        public static string FindSaveDirectory()
        {
            string saveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Klei\DoNotStarveTogether";
            if (Directory.Exists(saveDirectory))
            {
                return saveDirectory;
            }
            return string.Empty;
        }

        /// <summary>
        /// Sets the world parser and parses all worlds if the specified save directory is valid; otherwise nulls properties and returns
        /// </summary>
        /// <param name="saveDirectory"></param>
        public static void SetSaveDirectory(string saveDirectory)
        {
            AppVars.SaveDirectory = saveDirectory;
            if (!saveDirectory.IsValidSaveDirectory())
            {
                AppVars.Parser = null;
                AppVars.WorldSaves = null;
                return;
            }
            AppVars.Parser = new WorldParser(AppVars.SaveDirectory);
            new ParsingForm().ShowDialog();
            if (!Directory.Exists(AppVars.Parser.AutomaticBackupDirectory))
            {
                Directory.CreateDirectory(AppVars.Parser.AutomaticBackupDirectory);
            }
            BackupSaveFolderBackground();
        }

        /// <summary>
        /// Starts a background thread to backup the entire save folder
        /// </summary>
        public static void BackupSaveFolderBackground()
        {
            Task.Run(() =>
            {
                AppVars.BackupInProgress = true;
                try
                {
                    AppVars.Parser.Backup();
                    AppVars.Parser.CleanBackups(AppVars.NumberOfAutoBackups);
                }
                finally
                {
                    AppVars.BackupInProgress = false;
                }
            });
        }

        /// <summary>
        /// Blocks until the background backup thread is completed
        /// </summary>
        public static void WaitForBackup()
        {
            while (AppVars.BackupInProgress == true)
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Shows the specified error message with the specified caption
        /// </summary>
        /// <param name="message">The error message to show</param>
        /// <param name="caption">The caption for the message box</param>
        public static void ShowError(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Checks to see if Don't Starve Together is running in the background
        /// </summary>
        /// <returns>True if the game is running otherwise false</returns>
        public static bool CheckForGameProcess()
        {
            if(Process.GetProcesses().Where(x => x.ProcessName.Contains("dontstarve")).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Class for extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Serializes this object instance into XML and returns it as a string
        /// </summary>
        /// <param name="obj">This object instance</param>
        /// <returns>The XML string representing the object</returns>
        public static string Serialize(this object obj)
        {
            var ser = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            var ms = new MemoryStream();
            ser.Serialize(ms, obj);
            return new string(ms.ToArray().Select(x => (char)x).ToArray());
        }

        /// <summary>
        /// Deserializes this XML string instance into an object instance of type <typeparamref name="T"/> and returns it
        /// </summary>
        /// <typeparam name="T">The type represented by the XML string</typeparam>
        /// <param name="str">The XML string</param>
        /// <returns>The type <typeparamref name="T"/> instance</returns>
        public static T Deserialize<T>(this string str)
        {
            var deser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var reader = new StringReader(str);
            return (T)deser.Deserialize(reader);
        }

        /// <summary>
        /// Converts this byte array instance to a base 64 string
        /// </summary>
        /// <param name="byteCode">This byte array instance</param>
        /// <returns>The byte array as a base 64 string</returns>
        public static string ToBase64(this byte[] byteCode)
        {
            return Convert.ToBase64String(byteCode);
        }

        /// <summary>
        /// Converts this base 64 string instance to a byte array
        /// </summary>
        /// <param name="base64String">This base 64 string instance</param>
        /// <returns>The base 64 string as a byte array</returns>
        public static byte[] ToByteCode(this string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        /// <summary>
        /// Adds the the key value pair specified by key, val to this dictionary instance or updates the value if the key already exists
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="dict">This dictionary instance</param>
        /// <param name="key">The key</param>
        /// <param name="val">The value</param>
        /// <exception cref="ArgumentNullException">Thrown if this dictionary instance is null or the key is null</exception>
        public static void AddOrUpdate<K,V>(this Dictionary<K,V> dict, K key, V val)
        {
            if (dict == null)
            {
                throw new ArgumentNullException("dict");
            }
            if (dict.ContainsKey(key))
            {
                dict[key] = val;
            }
            else
            {
                dict.Add(key, val);
            }
        }

        /// <summary>
        /// Checks to see if this string object represents a valid Don't Starve Together world save directory
        /// </summary>
        /// <param name="saveDirectory">This world save directory</param>
        /// <returns>True if this is a valid world save directory otherwise false</returns>
        public static bool IsValidSaveDirectory(this string saveDirectory)
        {
            string clientSaveDir = saveDirectory + @"\client_save";
            string saveIndexPath = clientSaveDir + @"\saveindex";
            string baseSessionDir = clientSaveDir + @"\session";

            return Directory.Exists(clientSaveDir) && File.Exists(saveIndexPath) && Directory.Exists(baseSessionDir);
        }

        public static void SetProgressNoAnimation(this ProgressBar pb, int value)
        {
            if (value == pb.Maximum)
            {
                pb.Maximum = value + 1;
                pb.Value = value + 1;
                pb.Maximum = value;
            }
            else
            {
                pb.Value = value + 1;
            }
            pb.Value = value;
        }

        public static string CleanseAlphanumeric(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            var sb = new System.Text.StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                if (char.IsLetterOrDigit(str[i]))
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }

        public static string GetFileName(this WorldSave world)
        {
            string worldName = world.WorldName.CleanseAlphanumeric();
            if (string.IsNullOrEmpty(worldName))
            {
                worldName = "World";
            }

            return string.Format("{0}_{1}_{2}", worldName, world.SessionId, world.LastSaved.ToString("yyyyMMddTHHmmss"));
        }
    }
}
