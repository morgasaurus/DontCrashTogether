using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontCrashTogether
{
    public partial class ParsingForm : Form
    {
        private bool IsRestoreRun;
        private int SelectedSlot;

        public ParsingForm()
        {
            InitializeComponent();
            Button_OK.Enabled = false;
            AppVars.Parser.OnWorldParseProgress += new WorldParseProgressHandler(OnWorldParseProgress);
            IsRestoreRun = false;
        }

        public ParsingForm(int selectedSlot)
        {
            InitializeComponent();
            Button_OK.Enabled = false;
            AppVars.Parser.OnWorldParseProgress += new WorldParseProgressHandler(OnWorldParseProgress);
            IsRestoreRun = true;
            SelectedSlot = selectedSlot;
            Text = "Restoring World";
        }

        private async void ParsingForm_Shown(object sender, EventArgs e)
        {
            bool success = await Task.Run(() =>
            {
                try
                {
                    GlobalMethods.WaitForBackup();
                    if (IsRestoreRun)
                    {
                        AppVars.WorldSaves = AppVars.Parser.RestoreWorld(AppVars.CurrentWorld, SelectedSlot);
                    }
                    else
                    {
                        AppVars.WorldSaves = AppVars.Parser.ParseWorlds();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    GlobalMethods.ShowError(ex.Message, "Error");
                    return false;
                }
            });
            ProgressBar_Loading.Value = ProgressBar_Loading.Maximum;
            Button_OK.Enabled = true;
            Label_PleaseWait.Text = Label_PleaseWait.Text + (success ? " ...done!" : "...error!");
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnWorldParseProgress(object sender, WorldParseProgressEventArgs e)
        {
            if (ProgressBar_Loading.InvokeRequired)
            {
                ProgressBar_Loading.Invoke(new WorldParseProgressHandler(OnWorldParseProgress), sender, e);
            }
            else
            {
                ProgressBar_Loading.SetProgressNoAnimation((int)(ProgressBar_Loading.Maximum * e.PercentComplete));
            }
        }
    }
}
