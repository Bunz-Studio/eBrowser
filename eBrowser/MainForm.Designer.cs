namespace eBrowser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            homePanel = new Panels.HomePanel();
            listPanel = new Panels.ListPanel();
            viewPanel = new Panels.ViewPanel();
            tabHomeBtn = new System.Windows.Forms.Button();
            tabListBtn = new System.Windows.Forms.Button();
            tabViewerBtn = new System.Windows.Forms.Button();
            tabSettingsBtn = new System.Windows.Forms.Button();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            notifyMenu = new System.Windows.Forms.ContextMenuStrip(components);
            showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsPanel = new Panels.SettingsPanel();
            notifyMenu.SuspendLayout();
            SuspendLayout();
            // 
            // homePanel
            // 
            homePanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            homePanel.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            homePanel.ForeColor = System.Drawing.Color.White;
            homePanel.IsSearchAllowed = true;
            homePanel.Location = new System.Drawing.Point(12, 42);
            homePanel.Name = "homePanel";
            homePanel.SearchQuery = "";
            homePanel.Size = new System.Drawing.Size(1022, 650);
            homePanel.TabIndex = 0;
            homePanel.OnSearchQueried += homePanel_OnSearchQueried;
            // 
            // listPanel
            // 
            listPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listPanel.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            listPanel.CurrentPosts = null;
            listPanel.ForeColor = System.Drawing.Color.White;
            listPanel.IsSearchAllowed = true;
            listPanel.Location = new System.Drawing.Point(12, 42);
            listPanel.Name = "listPanel";
            listPanel.Page = new decimal(new int[] { 1, 0, 0, 0 });
            listPanel.SearchQuery = "";
            listPanel.Size = new System.Drawing.Size(1022, 650);
            listPanel.TabIndex = 1;
            listPanel.OnPostClicked += listPanel_OnPostClicked;
            // 
            // viewPanel
            // 
            viewPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            viewPanel.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            viewPanel.CurrentIndex = -1;
            viewPanel.ForeColor = System.Drawing.Color.White;
            viewPanel.Location = new System.Drawing.Point(12, 42);
            viewPanel.Name = "viewPanel";
            viewPanel.Size = new System.Drawing.Size(1022, 650);
            viewPanel.TabIndex = 2;
            viewPanel.OnBack += viewPanel_OnBack;
            viewPanel.OnTagSearch += viewPanel_OnTagSearch;
            viewPanel.OnTagAdd += viewPanel_OnTagAdd;
            viewPanel.OnTagRemove += viewPanel_OnTagRemove;
            // 
            // tabHomeBtn
            // 
            tabHomeBtn.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            tabHomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            tabHomeBtn.Location = new System.Drawing.Point(12, 12);
            tabHomeBtn.Name = "tabHomeBtn";
            tabHomeBtn.Size = new System.Drawing.Size(75, 23);
            tabHomeBtn.TabIndex = 3;
            tabHomeBtn.Text = "Home";
            tabHomeBtn.UseVisualStyleBackColor = false;
            tabHomeBtn.Click += tabHomeBtn_Click;
            // 
            // tabListBtn
            // 
            tabListBtn.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            tabListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            tabListBtn.Location = new System.Drawing.Point(93, 12);
            tabListBtn.Name = "tabListBtn";
            tabListBtn.Size = new System.Drawing.Size(75, 23);
            tabListBtn.TabIndex = 4;
            tabListBtn.Text = "List";
            tabListBtn.UseVisualStyleBackColor = false;
            tabListBtn.Click += tabListBtn_Click;
            // 
            // tabViewerBtn
            // 
            tabViewerBtn.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            tabViewerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            tabViewerBtn.Location = new System.Drawing.Point(174, 12);
            tabViewerBtn.Name = "tabViewerBtn";
            tabViewerBtn.Size = new System.Drawing.Size(75, 23);
            tabViewerBtn.TabIndex = 5;
            tabViewerBtn.Text = "Viewer";
            tabViewerBtn.UseVisualStyleBackColor = false;
            tabViewerBtn.Click += tabViewerBtn_Click;
            // 
            // tabSettingsBtn
            // 
            tabSettingsBtn.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            tabSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            tabSettingsBtn.Location = new System.Drawing.Point(255, 12);
            tabSettingsBtn.Name = "tabSettingsBtn";
            tabSettingsBtn.Size = new System.Drawing.Size(75, 23);
            tabSettingsBtn.TabIndex = 6;
            tabSettingsBtn.Text = "Settings";
            tabSettingsBtn.UseVisualStyleBackColor = false;
            tabSettingsBtn.Click += tabSettingsBtn_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = notifyMenu;
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "eBrowser";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // notifyMenu
            // 
            notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showToolStripMenuItem, exitToolStripMenuItem });
            notifyMenu.Name = "notifyMenu";
            notifyMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsPanel
            // 
            settingsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            settingsPanel.BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            settingsPanel.ForeColor = System.Drawing.Color.White;
            settingsPanel.Location = new System.Drawing.Point(12, 42);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new System.Drawing.Size(1022, 650);
            settingsPanel.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(2, 15, 35);
            ClientSize = new System.Drawing.Size(1046, 704);
            Controls.Add(tabSettingsBtn);
            Controls.Add(tabViewerBtn);
            Controls.Add(tabListBtn);
            Controls.Add(tabHomeBtn);
            Controls.Add(viewPanel);
            Controls.Add(listPanel);
            Controls.Add(homePanel);
            Controls.Add(settingsPanel);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "eBrowser";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            notifyMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panels.HomePanel homePanel;
        private Panels.ListPanel listPanel;
        private Panels.ViewPanel viewPanel;
        private System.Windows.Forms.Button tabHomeBtn;
        private System.Windows.Forms.Button tabListBtn;
        private System.Windows.Forms.Button tabViewerBtn;
        private System.Windows.Forms.Button tabSettingsBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Panels.SettingsPanel settingsPanel;
    }
}
