namespace DontCrashTogether
{
    partial class ParsingForm
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
            this.ProgressBar_Loading = new System.Windows.Forms.ProgressBar();
            this.Label_PleaseWait = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBar_Loading
            // 
            this.ProgressBar_Loading.Location = new System.Drawing.Point(12, 25);
            this.ProgressBar_Loading.Name = "ProgressBar_Loading";
            this.ProgressBar_Loading.Size = new System.Drawing.Size(285, 23);
            this.ProgressBar_Loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar_Loading.TabIndex = 0;
            // 
            // Label_PleaseWait
            // 
            this.Label_PleaseWait.AutoSize = true;
            this.Label_PleaseWait.Location = new System.Drawing.Point(12, 9);
            this.Label_PleaseWait.Name = "Label_PleaseWait";
            this.Label_PleaseWait.Size = new System.Drawing.Size(131, 13);
            this.Label_PleaseWait.TabIndex = 1;
            this.Label_PleaseWait.Text = "This may take a moment...";
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(117, 54);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 2;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ParsingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 87);
            this.ControlBox = false;
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Label_PleaseWait);
            this.Controls.Add(this.ProgressBar_Loading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParsingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading Worlds";
            this.Shown += new System.EventHandler(this.ParsingForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_Loading;
        private System.Windows.Forms.Label Label_PleaseWait;
        private System.Windows.Forms.Button Button_OK;
    }
}