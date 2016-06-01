using System;
using System.IO;
using System.Windows.Forms;

namespace DontCrashTogether
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            TextBox_SaveDirectory.Text = AppVars.SaveDirectory;
            TextBox_NumberOfBackups.Text = AppVars.NumberOfAutoBackups.ToString();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            string saveDirectory = TextBox_SaveDirectory.Text;
            if (!Directory.Exists(saveDirectory))
            {
                GlobalMethods.ShowError("That save directory does not exist", "Directory not found");
                return;
            }
            if (!saveDirectory.IsValidSaveDirectory())
            {
                GlobalMethods.ShowError(
                    "That save directory does not contain Dont Starve Together world data; if it is the correct directory, make sure you have at least one world saved",
                    "Invalid Directory");
                return;
            }
            int n;
            if (int.TryParse(TextBox_NumberOfBackups.Text, out n))
            {
                AppVars.NumberOfAutoBackups = n;
            }
            if (saveDirectory != AppVars.SaveDirectory)
            {
                GlobalMethods.SetSaveDirectory(saveDirectory);
            }
            DialogResult = DialogResult.OK;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog_BrowseSaveDirectory.SelectedPath = AppVars.SaveDirectory;
            if (FolderBrowserDialog_BrowseSaveDirectory.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            TextBox_SaveDirectory.Text = FolderBrowserDialog_BrowseSaveDirectory.SelectedPath;
        }

        private void TextBox_NumberOfBackups_Leave(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(TextBox_NumberOfBackups.Text, out n))
            {
                TextBox_NumberOfBackups.Text = AppVars.NumberOfAutoBackups.ToString();
            }
        }
    }
}
