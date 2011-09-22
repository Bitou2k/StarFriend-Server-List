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
            this.components = new System.ComponentModel.Container();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.RefreshButton = new System.Windows.Forms.ToolStripMenuItem();
            this.chatEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lastRefresh = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.AllowWebBrowserDrop = false;
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.IsWebBrowserContextMenuEnabled = false;
            this.browser.Location = new System.Drawing.Point(0, 24);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1008, 538);
            this.browser.TabIndex = 0;
            this.browser.Url = new System.Uri("", System.UriKind.Relative);
            this.browser.WebBrowserShortcutsEnabled = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshButton,
            this.chatEnable});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // RefreshButton
            // 
            this.RefreshButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(87, 20);
            this.RefreshButton.Text = "Refresh Páge";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // chatEnable
            // 
            this.chatEnable.BackColor = System.Drawing.SystemColors.WindowText;
            this.chatEnable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLanguageEnglish,
            this.spanishToolStripMenuItem,
            this.frenchToolStripMenuItem});
            this.chatEnable.ForeColor = System.Drawing.SystemColors.Control;
            this.chatEnable.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.chatEnable.Name = "chatEnable";
            this.chatEnable.Size = new System.Drawing.Size(115, 20);
            this.chatEnable.Text = "Change Language";
            // 
            // changeLanguageEnglish
            // 
            this.changeLanguageEnglish.Name = "changeLanguageEnglish";
            this.changeLanguageEnglish.Size = new System.Drawing.Size(115, 22);
            this.changeLanguageEnglish.Text = "English";
            this.changeLanguageEnglish.Click += new System.EventHandler(this.changeLanguageEnglish_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.frenchToolStripMenuItem.Text = "French";
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // lastRefresh
            // 
            this.lastRefresh.BackColor = System.Drawing.SystemColors.WindowText;
            this.lastRefresh.ForeColor = System.Drawing.SystemColors.Control;
            this.lastRefresh.Location = new System.Drawing.Point(379, 2);
            this.lastRefresh.Name = "lastRefresh";
            this.lastRefresh.Size = new System.Drawing.Size(200, 20);
            this.lastRefresh.TabIndex = 2;
            this.lastRefresh.Text = "Last Refresh 0 Seconds Ago";
            this.lastRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.lastRefresh);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StarFriend Server List";
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RefreshButton;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.Label lastRefresh;
        private System.Windows.Forms.ToolStripMenuItem chatEnable;
        private System.Windows.Forms.ToolStripMenuItem changeLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;

    }
}

