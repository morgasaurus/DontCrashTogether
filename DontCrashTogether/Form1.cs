using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontCrashTogether
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region TimingAndFlowEvents
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Lock the app if the game is running
            ProcessGuardMethod();

            // Load app vars
            AppVars.BackupInProgress = false;
            GlobalMethods.LoadAppVars();

            // If the loaded directory is not valid, attempt to find the valid one
            if (!AppVars.SaveDirectory.IsValidSaveDirectory())
            {
                AppVars.SaveDirectory = GlobalMethods.FindSaveDirectory();
                if (AppVars.SaveDirectory.IsValidSaveDirectory())
                {
                    MessageBox.Show(
                        string.Format("The save directory was automatically detected:{0}{1}{0}You may change this at any time under options > settings.",
                        Environment.NewLine, AppVars.SaveDirectory), "Save Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to detect save directory; you will need to set it in options > settings.",
                        "Save Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
            GlobalMethods.SetSaveDirectory(AppVars.SaveDirectory);
            GlobalMethods.SaveAppVars();
            RefreshWorldList();
            Timer_ProcessGuard.Enabled = true;
        }

        private void Timer_SaveAppVars_Tick(object sender, EventArgs e)
        {
            GlobalMethods.SaveAppVars();
        }

        private void Timer_ProcessGuard_Tick(object sender, EventArgs e)
        {
            ProcessGuardMethod();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalMethods.SaveAppVars();
        }
        #endregion

        #region HelperMethods
        private void RefreshWorldList()
        {
            ListBox_Worlds.Items.Clear();
            if (AppVars.WorldSaves != null && AppVars.WorldSaves.Count > 0)
            {
                ListBox_Worlds.Items.AddRange(AppVars.WorldSaves.Select(x => x.ToString()).ToArray());
                SetStates(true);
            }
            else
            {
                ListBox_Worlds.Items.Add("Select world save directory in options > settings");
                SetStates(false);
            }
        }

        private void SetStates(bool state)
        {
            ListBox_Worlds.Enabled = state;
            ToolStripMenu_World.Enabled = state;
        }

        private void ProcessGuardMethod()
        {
            if (GlobalMethods.CheckForGameProcess())
            {
                Timer_ProcessGuard.Stop();
                new ProcessGuardForm().ShowDialog();
                Timer_ProcessGuard.Start();
            }
        }
        #endregion

        #region UiControlEvents
        private void ToolStripMenu_World_Backup_Click(object sender, EventArgs e)
        {
            int selectedSlot = ListBox_Worlds.SelectedIndex + 1;
            if (selectedSlot == 0)
            {
                GlobalMethods.ShowError("You must select a world first.");
                return;
            }
            var world = AppVars.WorldSaves[selectedSlot];
            if (world.IsEmpty())
            {
                GlobalMethods.ShowError("That world slot is empty.");
                return;
            }
            SaveFileDialog_SaveWorld.FileName = string.Format("WorldSave_{0}_{1}.xml", world.SessionId, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            if (SaveFileDialog_SaveWorld.ShowDialog() == DialogResult.Cancel)
            {                
                return;
            }
            AppVars.Parser.SaveWorld(AppVars.WorldSaves[selectedSlot], SaveFileDialog_SaveWorld.FileName);
        }

        private async void ToolStripMenu_World_Open_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog_OpenWorld.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string worldFile = OpenFileDialog_OpenWorld.FileName;
            if (!File.Exists(worldFile))
            {
                GlobalMethods.ShowError("That file does not exist", "File not found");
                return;
            }
            TextBox_OpenWorld.Text = "Loading world...";
            bool success = await Task.Run(() =>
            {
                try
                {
                    AppVars.CurrentWorld = AppVars.Parser.LoadWorld(worldFile);
                    return true;
                }
                catch
                {
                    GlobalMethods.ShowError("The selected world file is not recognized", "Invalid World File");
                    return false;
                }
            });
            if (success)
            {
                TextBox_OpenWorld.Text = AppVars.CurrentWorld.ToString();
            }
            else
            {
                TextBox_OpenWorld.Text = string.Empty;
            }
        }

        private void ToolStripMenu_World_Restore_Click(object sender, EventArgs e)
        {
            int selectedSlot = ListBox_Worlds.SelectedIndex + 1;
            if (AppVars.CurrentWorld == null || AppVars.CurrentWorld.IsEmpty())
            {
                GlobalMethods.ShowError("Open a non-empty world backup file before attempting to restore", "No World Open");
                return;
            }
            if (selectedSlot == 0)
            {
                GlobalMethods.ShowError("You must select a world slot first", "No slot selected");
                return;
            }
            new ParsingForm(selectedSlot).ShowDialog();
            RefreshWorldList();
        }

        private void ToolStripMenu_Options_Settings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            GlobalMethods.SaveAppVars();
            RefreshWorldList();
        }

        private void ToolStripMenu_Help_Instructions_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("To backup a world: Select the slot then use world > backup selected slot");
            sb.AppendLine();
            sb.AppendLine("To restore a world: First open the world using world > open world from backup," + 
                "then select the slot you want to restore to and use world > restore to selected slot");
            sb.AppendLine();
            sb.AppendLine("Using options > settings you may change the save directory and the number of automatic backups kept");
            MessageBox.Show(sb.ToString(), "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void ToolStripMenu_Help_About_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DontCrashTogether v0.5 beta");
            sb.AppendLine("Developed by Morgasaurus");
            MessageBox.Show(sb.ToString(), "About");
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            GlobalMethods.SetSaveDirectory(AppVars.SaveDirectory);
            RefreshWorldList();
        }
        #endregion
    }
}
