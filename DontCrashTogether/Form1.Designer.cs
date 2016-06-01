namespace DontCrashTogether
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListBox_Worlds = new System.Windows.Forms.ListBox();
            this.Label_OpenWorld = new System.Windows.Forms.Label();
            this.TextBox_OpenWorld = new System.Windows.Forms.TextBox();
            this.Label_WorldList = new System.Windows.Forms.Label();
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenu_World = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_World_Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_World_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_World_Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Options_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileDialog_SaveWorld = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog_OpenWorld = new System.Windows.Forms.OpenFileDialog();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.Timer_SaveAppVars = new System.Windows.Forms.Timer(this.components);
            this.Timer_ProcessGuard = new System.Windows.Forms.Timer(this.components);
            this.ToolStripMenu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Help_Instructions = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_Worlds
            // 
            this.ListBox_Worlds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Worlds.FormattingEnabled = true;
            this.ListBox_Worlds.ItemHeight = 16;
            this.ListBox_Worlds.Location = new System.Drawing.Point(15, 87);
            this.ListBox_Worlds.Name = "ListBox_Worlds";
            this.ListBox_Worlds.Size = new System.Drawing.Size(481, 148);
            this.ListBox_Worlds.TabIndex = 0;
            // 
            // Label_OpenWorld
            // 
            this.Label_OpenWorld.AutoSize = true;
            this.Label_OpenWorld.Location = new System.Drawing.Point(12, 24);
            this.Label_OpenWorld.Name = "Label_OpenWorld";
            this.Label_OpenWorld.Size = new System.Drawing.Size(125, 16);
            this.Label_OpenWorld.TabIndex = 1;
            this.Label_OpenWorld.Text = "Current Open World";
            // 
            // TextBox_OpenWorld
            // 
            this.TextBox_OpenWorld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_OpenWorld.Location = new System.Drawing.Point(15, 43);
            this.TextBox_OpenWorld.Name = "TextBox_OpenWorld";
            this.TextBox_OpenWorld.ReadOnly = true;
            this.TextBox_OpenWorld.Size = new System.Drawing.Size(481, 22);
            this.TextBox_OpenWorld.TabIndex = 2;
            // 
            // Label_WorldList
            // 
            this.Label_WorldList.AutoSize = true;
            this.Label_WorldList.Location = new System.Drawing.Point(12, 68);
            this.Label_WorldList.Name = "Label_WorldList";
            this.Label_WorldList.Size = new System.Drawing.Size(67, 16);
            this.Label_WorldList.TabIndex = 3;
            this.Label_WorldList.Text = "World List";
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_World,
            this.ToolStripMenu_Options,
            this.ToolStripMenu_Help});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Size = new System.Drawing.Size(514, 24);
            this.MenuStrip_Main.TabIndex = 4;
            this.MenuStrip_Main.Text = "menuStrip1";
            // 
            // ToolStripMenu_World
            // 
            this.ToolStripMenu_World.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_World_Backup,
            this.ToolStripMenu_World_Open,
            this.ToolStripMenu_World_Restore});
            this.ToolStripMenu_World.Name = "ToolStripMenu_World";
            this.ToolStripMenu_World.Size = new System.Drawing.Size(51, 20);
            this.ToolStripMenu_World.Text = "World";
            // 
            // ToolStripMenu_World_Backup
            // 
            this.ToolStripMenu_World_Backup.Name = "ToolStripMenu_World_Backup";
            this.ToolStripMenu_World_Backup.Size = new System.Drawing.Size(211, 22);
            this.ToolStripMenu_World_Backup.Text = "Backup Selected Slot";
            this.ToolStripMenu_World_Backup.Click += new System.EventHandler(this.ToolStripMenu_World_Backup_Click);
            // 
            // ToolStripMenu_World_Open
            // 
            this.ToolStripMenu_World_Open.Name = "ToolStripMenu_World_Open";
            this.ToolStripMenu_World_Open.Size = new System.Drawing.Size(211, 22);
            this.ToolStripMenu_World_Open.Text = "Open World From Backup";
            this.ToolStripMenu_World_Open.Click += new System.EventHandler(this.ToolStripMenu_World_Open_Click);
            // 
            // ToolStripMenu_World_Restore
            // 
            this.ToolStripMenu_World_Restore.Name = "ToolStripMenu_World_Restore";
            this.ToolStripMenu_World_Restore.Size = new System.Drawing.Size(211, 22);
            this.ToolStripMenu_World_Restore.Text = "Restore To Selected Slot";
            this.ToolStripMenu_World_Restore.Click += new System.EventHandler(this.ToolStripMenu_World_Restore_Click);
            // 
            // ToolStripMenu_Options
            // 
            this.ToolStripMenu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_Options_Settings});
            this.ToolStripMenu_Options.Name = "ToolStripMenu_Options";
            this.ToolStripMenu_Options.Size = new System.Drawing.Size(61, 20);
            this.ToolStripMenu_Options.Text = "Options";
            // 
            // ToolStripMenu_Options_Settings
            // 
            this.ToolStripMenu_Options_Settings.Name = "ToolStripMenu_Options_Settings";
            this.ToolStripMenu_Options_Settings.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenu_Options_Settings.Text = "Settings";
            this.ToolStripMenu_Options_Settings.Click += new System.EventHandler(this.ToolStripMenu_Options_Settings_Click);
            // 
            // SaveFileDialog_SaveWorld
            // 
            this.SaveFileDialog_SaveWorld.Filter = "XML Files|*.xml";
            this.SaveFileDialog_SaveWorld.RestoreDirectory = true;
            this.SaveFileDialog_SaveWorld.Title = "Saving the World!";
            // 
            // OpenFileDialog_OpenWorld
            // 
            this.OpenFileDialog_OpenWorld.Filter = "XML Files|*.xml|All files|*.*";
            this.OpenFileDialog_OpenWorld.Title = "Open World Backup";
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Refresh.Location = new System.Drawing.Point(15, 241);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.Button_Refresh.TabIndex = 5;
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // Timer_SaveAppVars
            // 
            this.Timer_SaveAppVars.Enabled = true;
            this.Timer_SaveAppVars.Interval = 30000;
            this.Timer_SaveAppVars.Tick += new System.EventHandler(this.Timer_SaveAppVars_Tick);
            // 
            // Timer_ProcessGuard
            // 
            this.Timer_ProcessGuard.Interval = 2000;
            this.Timer_ProcessGuard.Tick += new System.EventHandler(this.Timer_ProcessGuard_Tick);
            // 
            // ToolStripMenu_Help
            // 
            this.ToolStripMenu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_Help_Instructions,
            this.ToolStripMenu_Help_About});
            this.ToolStripMenu_Help.Name = "ToolStripMenu_Help";
            this.ToolStripMenu_Help.Size = new System.Drawing.Size(44, 20);
            this.ToolStripMenu_Help.Text = "Help";
            // 
            // ToolStripMenu_Help_Instructions
            // 
            this.ToolStripMenu_Help_Instructions.Name = "ToolStripMenu_Help_Instructions";
            this.ToolStripMenu_Help_Instructions.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenu_Help_Instructions.Text = "Instructions";
            this.ToolStripMenu_Help_Instructions.Click += new System.EventHandler(this.ToolStripMenu_Help_Instructions_Click);
            // 
            // ToolStripMenu_Help_About
            // 
            this.ToolStripMenu_Help_About.Name = "ToolStripMenu_Help_About";
            this.ToolStripMenu_Help_About.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenu_Help_About.Text = "About";
            this.ToolStripMenu_Help_About.Click += new System.EventHandler(this.ToolStripMenu_Help_About_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 276);
            this.Controls.Add(this.Button_Refresh);
            this.Controls.Add(this.Label_WorldList);
            this.Controls.Add(this.TextBox_OpenWorld);
            this.Controls.Add(this.Label_OpenWorld);
            this.Controls.Add(this.ListBox_Worlds);
            this.Controls.Add(this.MenuStrip_Main);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(530, 315);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dont Crash Together";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Worlds;
        private System.Windows.Forms.Label Label_OpenWorld;
        private System.Windows.Forms.TextBox TextBox_OpenWorld;
        private System.Windows.Forms.Label Label_WorldList;
        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_World;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_World_Backup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_World_Open;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Options;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Options_Settings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_World_Restore;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog_SaveWorld;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_OpenWorld;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.Timer Timer_SaveAppVars;
        private System.Windows.Forms.Timer Timer_ProcessGuard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Help_Instructions;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu_Help_About;
    }
}

