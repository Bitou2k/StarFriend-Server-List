namespace Client
{
    partial class Main
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
            this.Start = new System.Windows.Forms.Button();
            this.sfpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.playerLabel = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IPOverride = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(286, 92);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(106, 41);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start Sync";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // sfpath
            // 
            this.sfpath.Location = new System.Drawing.Point(98, 6);
            this.sfpath.Name = "sfpath";
            this.sfpath.Size = new System.Drawing.Size(294, 20);
            this.sfpath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starfriend Path:";
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(15, 32);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(265, 98);
            this.Log.TabIndex = 3;
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.SynchronizingObject = this;
            this.fileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileWatcher_Changed);
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(286, 32);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(20, 20);
            this.browser.TabIndex = 4;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(314, 76);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(53, 13);
            this.playerLabel.TabIndex = 5;
            this.playerLabel.Text = "Players: 0";
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(286, 32);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(106, 41);
            this.Settings.TabIndex = 6;
            this.Settings.Text = "Open Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "---------------------------------------------------------------------------------" +
                "--------------------------------------------------";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Override IP:";
            this.label3.Visible = false;
            // 
            // IPOverride
            // 
            this.IPOverride.Location = new System.Drawing.Point(98, 149);
            this.IPOverride.MaxLength = 15;
            this.IPOverride.Name = "IPOverride";
            this.IPOverride.Size = new System.Drawing.Size(294, 20);
            this.IPOverride.TabIndex = 8;
            this.IPOverride.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Description:";
            this.label4.Visible = false;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(98, 175);
            this.Description.MaxLength = 20;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(294, 20);
            this.Description.TabIndex = 10;
            this.Description.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 142);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPOverride);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sfpath);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerList Client";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox sfpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Log;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IPOverride;
    }
}

