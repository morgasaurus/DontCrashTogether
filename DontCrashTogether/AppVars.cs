using System.Collections.Generic;

namespace DontCrashTogether
{
    public static class AppVars
    {
        /// <summary>
        /// The directory containing Don't Starve Together world saves
        /// </summary>
        public static string SaveDirectory { get; set; }

        /// <summary>
        /// The list of world save objects
        /// </summary>
        public static Dictionary<int, WorldSave> WorldSaves { get; set; }

        /// <summary>
        /// The currently open world
        /// </summary>
        public static WorldSave CurrentWorld { get; set; }

        /// <summary>
        /// The world parser object
        /// </summary>
        public static WorldParser Parser { get; set; }

        /// <summary>
        /// The number of automatically generated backup files to keep
        /// </summary>
        public static int NumberOfAutoBackups { get; set; }

        /// <summary>
        /// Check to see if a backup is in progress
        /// </summary>
        public static bool BackupInProgress { get; set; }
    }
}
