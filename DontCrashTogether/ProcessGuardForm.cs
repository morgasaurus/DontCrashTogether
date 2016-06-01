using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontCrashTogether
{
    public partial class ProcessGuardForm : Form
    {
        public ProcessGuardForm()
        {
            InitializeComponent();
        }

        private async void ProcessGuard_Shown(object sender, EventArgs e)
        {
            // Prevent access to the OK button until the game is closed
            await Task.Run(() =>
            {
                while (GlobalMethods.CheckForGameProcess())
                {
                    System.Threading.Thread.Sleep(1000);
                }
            });
            Button_OK.Enabled = true;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            GlobalMethods.SetSaveDirectory(AppVars.SaveDirectory);
            DialogResult = DialogResult.OK;
        }
    }
}
