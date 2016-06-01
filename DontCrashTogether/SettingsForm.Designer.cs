namespace DontCrashTogether
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.Label_SaveDirectory = new System.Windows.Forms.Label();
            this.TextBox_SaveDirectory = new System.Windows.Forms.TextBox();
            this.Label_AutomaticBackups = new System.Windows.Forms.Label();
            this.TextBox_NumberOfBackups = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.FolderBrowserDialog_BrowseSaveDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Label_SaveDirectory
            // 
            this.Label_SaveDirectory.AutoSize = true;
            this.Label_SaveDirectory.Location = new System.Drawing.Point(12, 9);
            this.Label_SaveDirectory.Name = "Label_SaveDirectory";
            this.Label_SaveDirectory.Size = new System.Drawing.Size(77, 13);
            this.Label_SaveDirectory.TabIndex = 0;
            this.Label_SaveDirectory.Text = "Save Directory";
            // 
            // TextBox_SaveDirectory
            // 
            this.TextBox_SaveDirectory.Location = new System.Drawing.Point(95, 6);
            this.TextBox_SaveDirectory.Name = "TextBox_SaveDirectory";
            this.TextBox_SaveDirectory.Size = new System.Drawing.Size(481, 20);
            this.TextBox_SaveDirectory.TabIndex = 1;
            // 
            // Label_AutomaticBackups
            // 
            this.Label_AutomaticBackups.AutoSize = true;
            this.Label_AutomaticBackups.Location = new System.Drawing.Point(12, 35);
            this.Label_AutomaticBackups.Name = "Label_AutomaticBackups";
            this.Label_AutomaticBackups.Size = new System.Drawing.Size(99, 13);
            this.Label_AutomaticBackups.TabIndex = 2;
            this.Label_AutomaticBackups.Text = "Automatic Backups";
            // 
            // TextBox_NumberOfBackups
            // 
            this.TextBox_NumberOfBackups.Location = new System.Drawing.Point(117, 32);
            this.TextBox_NumberOfBackups.Name = "TextBox_NumberOfBackups";
            this.TextBox_NumberOfBackups.Size = new System.Drawing.Size(59, 20);
            this.TextBox_NumberOfBackups.TabIndex = 3;
            this.TextBox_NumberOfBackups.Leave += new System.EventHandler(this.TextBox_NumberOfBackups_Leave);
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(214, 58);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(295, 58);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Browse
            // 
            this.Button_Browse.Location = new System.Drawing.Point(582, 4);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(75, 23);
            this.Button_Browse.TabIndex = 6;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(666, 90);
            this.ControlBox = false;
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.TextBox_NumberOfBackups);
            this.Controls.Add(this.Label_AutomaticBackups);
            this.Controls.Add(this.TextBox_SaveDirectory);
            this.Controls.Add(this.Label_SaveDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_SaveDirectory;
        private System.Windows.Forms.TextBox TextBox_SaveDirectory;
        private System.Windows.Forms.Label Label_AutomaticBackups;
        private System.Windows.Forms.TextBox TextBox_NumberOfBackups;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog_BrowseSaveDirectory;
    }
}