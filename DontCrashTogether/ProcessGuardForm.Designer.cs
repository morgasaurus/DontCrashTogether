namespace DontCrashTogether
{
    partial class ProcessGuardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessGuardForm));
            this.Label_WaitForGame = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_WaitForGame
            // 
            this.Label_WaitForGame.AutoSize = true;
            this.Label_WaitForGame.Location = new System.Drawing.Point(12, 9);
            this.Label_WaitForGame.Name = "Label_WaitForGame";
            this.Label_WaitForGame.Size = new System.Drawing.Size(308, 39);
            this.Label_WaitForGame.TabIndex = 0;
            this.Label_WaitForGame.Text = "It looks like Don\'t Starve Together is running in the background.\r\nUsing this app" +
    " while the game is running is NOT recommended\r\nand may result in corrupt world s" +
    "ave data.  Close the game first.";
            // 
            // Button_OK
            // 
            this.Button_OK.Enabled = false;
            this.Button_OK.Location = new System.Drawing.Point(129, 51);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 1;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ProcessGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 81);
            this.ControlBox = false;
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Label_WaitForGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessGuard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Don\'t Corrupt Together";
            this.Shown += new System.EventHandler(this.ProcessGuard_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_WaitForGame;
        private System.Windows.Forms.Button Button_OK;
    }
}