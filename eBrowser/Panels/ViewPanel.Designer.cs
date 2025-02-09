namespace eBrowser.Panels
{
    partial class ViewPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainSplit = new System.Windows.Forms.SplitContainer();
            sidePanel = new System.Windows.Forms.Panel();
            poolsBox = new System.Windows.Forms.ListBox();
            poolsLabel = new System.Windows.Forms.Label();
            downloadButton = new System.Windows.Forms.Button();
            tagsBox = new System.Windows.Forms.ListBox();
            tagsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            addToSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeFromSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            blacklistlocallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tagsLabel = new System.Windows.Forms.Label();
            charactersBox = new System.Windows.Forms.ListBox();
            charactersLabel = new System.Windows.Forms.Label();
            sourcesBox = new System.Windows.Forms.ListBox();
            sourcesLabel = new System.Windows.Forms.Label();
            artistsBox = new System.Windows.Forms.ListBox();
            backListButton = new System.Windows.Forms.Button();
            sizeLabel = new System.Windows.Forms.Label();
            sizeBox = new System.Windows.Forms.TextBox();
            extLabel = new System.Windows.Forms.Label();
            extensionBox = new System.Windows.Forms.TextBox();
            idBox = new System.Windows.Forms.TextBox();
            idLabel = new System.Windows.Forms.Label();
            dimHeightBox = new System.Windows.Forms.TextBox();
            dimensionsLabel = new System.Windows.Forms.Label();
            dimWidthBox = new System.Windows.Forms.TextBox();
            artistLabel = new System.Windows.Forms.Label();
            downloadProgressBar = new System.Windows.Forms.ProgressBar();
            viewBrowser = new Microsoft.Web.WebView2.WinForms.WebView2();
            topPanel = new System.Windows.Forms.Panel();
            centerText = new System.Windows.Forms.Label();
            previousButton = new System.Windows.Forms.Button();
            nextButton = new System.Windows.Forms.Button();
            imageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)mainSplit).BeginInit();
            mainSplit.Panel1.SuspendLayout();
            mainSplit.Panel2.SuspendLayout();
            mainSplit.SuspendLayout();
            sidePanel.SuspendLayout();
            tagsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)viewBrowser).BeginInit();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // mainSplit
            // 
            mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            mainSplit.Location = new System.Drawing.Point(0, 0);
            mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            mainSplit.Panel1.Controls.Add(sidePanel);
            // 
            // mainSplit.Panel2
            // 
            mainSplit.Panel2.Controls.Add(downloadProgressBar);
            mainSplit.Panel2.Controls.Add(viewBrowser);
            mainSplit.Panel2.Controls.Add(topPanel);
            mainSplit.Panel2.Controls.Add(imageBox);
            mainSplit.Size = new System.Drawing.Size(978, 665);
            mainSplit.SplitterDistance = 212;
            mainSplit.TabIndex = 0;
            // 
            // sidePanel
            // 
            sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sidePanel.Controls.Add(poolsBox);
            sidePanel.Controls.Add(poolsLabel);
            sidePanel.Controls.Add(downloadButton);
            sidePanel.Controls.Add(tagsBox);
            sidePanel.Controls.Add(tagsLabel);
            sidePanel.Controls.Add(charactersBox);
            sidePanel.Controls.Add(charactersLabel);
            sidePanel.Controls.Add(sourcesBox);
            sidePanel.Controls.Add(sourcesLabel);
            sidePanel.Controls.Add(artistsBox);
            sidePanel.Controls.Add(backListButton);
            sidePanel.Controls.Add(sizeLabel);
            sidePanel.Controls.Add(sizeBox);
            sidePanel.Controls.Add(extLabel);
            sidePanel.Controls.Add(extensionBox);
            sidePanel.Controls.Add(idBox);
            sidePanel.Controls.Add(idLabel);
            sidePanel.Controls.Add(dimHeightBox);
            sidePanel.Controls.Add(dimensionsLabel);
            sidePanel.Controls.Add(dimWidthBox);
            sidePanel.Controls.Add(artistLabel);
            sidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            sidePanel.Location = new System.Drawing.Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new System.Drawing.Size(212, 665);
            sidePanel.TabIndex = 0;
            // 
            // poolsBox
            // 
            poolsBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            poolsBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            poolsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            poolsBox.ForeColor = System.Drawing.Color.White;
            poolsBox.FormattingEnabled = true;
            poolsBox.ItemHeight = 15;
            poolsBox.Location = new System.Drawing.Point(6, 614);
            poolsBox.Name = "poolsBox";
            poolsBox.Size = new System.Drawing.Size(203, 32);
            poolsBox.TabIndex = 21;
            poolsBox.DoubleClick += poolsBox_DoubleClick;
            // 
            // poolsLabel
            // 
            poolsLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            poolsLabel.AutoSize = true;
            poolsLabel.Location = new System.Drawing.Point(6, 596);
            poolsLabel.Name = "poolsLabel";
            poolsLabel.Size = new System.Drawing.Size(36, 15);
            poolsLabel.TabIndex = 20;
            poolsLabel.Text = "Pools";
            // 
            // downloadButton
            // 
            downloadButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            downloadButton.Location = new System.Drawing.Point(126, 2);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new System.Drawing.Size(79, 23);
            downloadButton.TabIndex = 19;
            downloadButton.TabStop = false;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // tagsBox
            // 
            tagsBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tagsBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            tagsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tagsBox.ContextMenuStrip = tagsContextMenu;
            tagsBox.ForeColor = System.Drawing.Color.White;
            tagsBox.FormattingEnabled = true;
            tagsBox.ItemHeight = 15;
            tagsBox.Location = new System.Drawing.Point(6, 355);
            tagsBox.Name = "tagsBox";
            tagsBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            tagsBox.Size = new System.Drawing.Size(203, 122);
            tagsBox.TabIndex = 18;
            // 
            // tagsContextMenu
            // 
            tagsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { searchToolStripMenuItem, toolStripSeparator1, addToSearchToolStripMenuItem, removeFromSearchToolStripMenuItem, toolStripSeparator2, blacklistlocallyToolStripMenuItem });
            tagsContextMenu.Name = "tagsContextMenu";
            tagsContextMenu.Size = new System.Drawing.Size(185, 104);
            tagsContextMenu.Opening += tagsContextMenu_Opening;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // addToSearchToolStripMenuItem
            // 
            addToSearchToolStripMenuItem.Name = "addToSearchToolStripMenuItem";
            addToSearchToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            addToSearchToolStripMenuItem.Text = "Add to Search";
            addToSearchToolStripMenuItem.Click += addToSearchToolStripMenuItem_Click;
            // 
            // removeFromSearchToolStripMenuItem
            // 
            removeFromSearchToolStripMenuItem.Name = "removeFromSearchToolStripMenuItem";
            removeFromSearchToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            removeFromSearchToolStripMenuItem.Text = "Remove from Search";
            removeFromSearchToolStripMenuItem.Click += removeFromSearchToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // blacklistlocallyToolStripMenuItem
            // 
            blacklistlocallyToolStripMenuItem.Name = "blacklistlocallyToolStripMenuItem";
            blacklistlocallyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            blacklistlocallyToolStripMenuItem.Text = "Blacklist (locally)";
            // 
            // tagsLabel
            // 
            tagsLabel.AutoSize = true;
            tagsLabel.Location = new System.Drawing.Point(5, 335);
            tagsLabel.Name = "tagsLabel";
            tagsLabel.Size = new System.Drawing.Size(30, 15);
            tagsLabel.TabIndex = 17;
            tagsLabel.Text = "Tags";
            // 
            // charactersBox
            // 
            charactersBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            charactersBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            charactersBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            charactersBox.ContextMenuStrip = tagsContextMenu;
            charactersBox.ForeColor = System.Drawing.Color.White;
            charactersBox.FormattingEnabled = true;
            charactersBox.ItemHeight = 15;
            charactersBox.Location = new System.Drawing.Point(5, 253);
            charactersBox.Name = "charactersBox";
            charactersBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            charactersBox.Size = new System.Drawing.Size(203, 77);
            charactersBox.TabIndex = 16;
            // 
            // charactersLabel
            // 
            charactersLabel.AutoSize = true;
            charactersLabel.Location = new System.Drawing.Point(4, 234);
            charactersLabel.Name = "charactersLabel";
            charactersLabel.Size = new System.Drawing.Size(63, 15);
            charactersLabel.TabIndex = 15;
            charactersLabel.Text = "Characters";
            // 
            // sourcesBox
            // 
            sourcesBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sourcesBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            sourcesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sourcesBox.ForeColor = System.Drawing.Color.White;
            sourcesBox.FormattingEnabled = true;
            sourcesBox.ItemHeight = 15;
            sourcesBox.Location = new System.Drawing.Point(6, 500);
            sourcesBox.Name = "sourcesBox";
            sourcesBox.Size = new System.Drawing.Size(203, 92);
            sourcesBox.TabIndex = 14;
            sourcesBox.DoubleClick += sourcesBox_DoubleClick;
            // 
            // sourcesLabel
            // 
            sourcesLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            sourcesLabel.AutoSize = true;
            sourcesLabel.Location = new System.Drawing.Point(6, 482);
            sourcesLabel.Name = "sourcesLabel";
            sourcesLabel.Size = new System.Drawing.Size(48, 15);
            sourcesLabel.TabIndex = 13;
            sourcesLabel.Text = "Sources";
            // 
            // artistsBox
            // 
            artistsBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            artistsBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            artistsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            artistsBox.ContextMenuStrip = tagsContextMenu;
            artistsBox.ForeColor = System.Drawing.Color.White;
            artistsBox.FormattingEnabled = true;
            artistsBox.ItemHeight = 15;
            artistsBox.Location = new System.Drawing.Point(5, 168);
            artistsBox.Name = "artistsBox";
            artistsBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            artistsBox.Size = new System.Drawing.Size(203, 62);
            artistsBox.TabIndex = 12;
            // 
            // backListButton
            // 
            backListButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            backListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            backListButton.Location = new System.Drawing.Point(112, 139);
            backListButton.Name = "backListButton";
            backListButton.Size = new System.Drawing.Size(95, 23);
            backListButton.TabIndex = 3;
            backListButton.TabStop = false;
            backListButton.Text = "Back to Listing";
            backListButton.UseVisualStyleBackColor = true;
            backListButton.Click += backListButton_Click;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new System.Drawing.Point(5, 95);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new System.Drawing.Size(48, 15);
            sizeLabel.TabIndex = 11;
            sizeLabel.Text = "File Size";
            // 
            // sizeBox
            // 
            sizeBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sizeBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 45);
            sizeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sizeBox.ForeColor = System.Drawing.Color.White;
            sizeBox.Location = new System.Drawing.Point(5, 110);
            sizeBox.Name = "sizeBox";
            sizeBox.ReadOnly = true;
            sizeBox.Size = new System.Drawing.Size(202, 23);
            sizeBox.TabIndex = 10;
            // 
            // extLabel
            // 
            extLabel.AutoSize = true;
            extLabel.Location = new System.Drawing.Point(88, 51);
            extLabel.Name = "extLabel";
            extLabel.Size = new System.Drawing.Size(58, 15);
            extLabel.TabIndex = 9;
            extLabel.Text = "Extension";
            // 
            // extensionBox
            // 
            extensionBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            extensionBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 45);
            extensionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            extensionBox.ForeColor = System.Drawing.Color.White;
            extensionBox.Location = new System.Drawing.Point(88, 69);
            extensionBox.Name = "extensionBox";
            extensionBox.ReadOnly = true;
            extensionBox.Size = new System.Drawing.Size(120, 23);
            extensionBox.TabIndex = 8;
            // 
            // idBox
            // 
            idBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 45);
            idBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            idBox.ForeColor = System.Drawing.Color.White;
            idBox.Location = new System.Drawing.Point(4, 69);
            idBox.Name = "idBox";
            idBox.ReadOnly = true;
            idBox.Size = new System.Drawing.Size(82, 23);
            idBox.TabIndex = 7;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(5, 51);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(17, 15);
            idLabel.TabIndex = 6;
            idLabel.Text = "Id";
            // 
            // dimHeightBox
            // 
            dimHeightBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dimHeightBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 45);
            dimHeightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dimHeightBox.ForeColor = System.Drawing.Color.White;
            dimHeightBox.Location = new System.Drawing.Point(88, 25);
            dimHeightBox.Name = "dimHeightBox";
            dimHeightBox.ReadOnly = true;
            dimHeightBox.Size = new System.Drawing.Size(118, 23);
            dimHeightBox.TabIndex = 5;
            // 
            // dimensionsLabel
            // 
            dimensionsLabel.AutoSize = true;
            dimensionsLabel.Location = new System.Drawing.Point(4, 7);
            dimensionsLabel.Name = "dimensionsLabel";
            dimensionsLabel.Size = new System.Drawing.Size(69, 15);
            dimensionsLabel.TabIndex = 4;
            dimensionsLabel.Text = "Dimensions";
            // 
            // dimWidthBox
            // 
            dimWidthBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 45);
            dimWidthBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dimWidthBox.ForeColor = System.Drawing.Color.White;
            dimWidthBox.Location = new System.Drawing.Point(4, 25);
            dimWidthBox.Name = "dimWidthBox";
            dimWidthBox.ReadOnly = true;
            dimWidthBox.Size = new System.Drawing.Size(82, 23);
            dimWidthBox.TabIndex = 3;
            // 
            // artistLabel
            // 
            artistLabel.AutoSize = true;
            artistLabel.Location = new System.Drawing.Point(4, 149);
            artistLabel.Name = "artistLabel";
            artistLabel.Size = new System.Drawing.Size(40, 15);
            artistLabel.TabIndex = 1;
            artistLabel.Text = "Artists";
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            downloadProgressBar.Location = new System.Drawing.Point(0, 642);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new System.Drawing.Size(762, 23);
            downloadProgressBar.TabIndex = 2;
            downloadProgressBar.Visible = false;
            // 
            // viewBrowser
            // 
            viewBrowser.AllowExternalDrop = true;
            viewBrowser.CreationProperties = null;
            viewBrowser.DefaultBackgroundColor = System.Drawing.Color.White;
            viewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            viewBrowser.Location = new System.Drawing.Point(0, 30);
            viewBrowser.Name = "viewBrowser";
            viewBrowser.Size = new System.Drawing.Size(762, 635);
            viewBrowser.TabIndex = 3;
            viewBrowser.ZoomFactor = 1D;
            // 
            // topPanel
            // 
            topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            topPanel.Controls.Add(centerText);
            topPanel.Controls.Add(previousButton);
            topPanel.Controls.Add(nextButton);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new System.Drawing.Size(762, 30);
            topPanel.TabIndex = 0;
            // 
            // centerText
            // 
            centerText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            centerText.Location = new System.Drawing.Point(31, 3);
            centerText.Name = "centerText";
            centerText.Size = new System.Drawing.Size(697, 23);
            centerText.TabIndex = 2;
            centerText.Text = "0/0";
            centerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousButton
            // 
            previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            previousButton.Location = new System.Drawing.Point(2, 3);
            previousButton.Name = "previousButton";
            previousButton.Size = new System.Drawing.Size(23, 23);
            previousButton.TabIndex = 1;
            previousButton.TabStop = false;
            previousButton.Text = "<";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            nextButton.Location = new System.Drawing.Point(734, 3);
            nextButton.Name = "nextButton";
            nextButton.Size = new System.Drawing.Size(23, 23);
            nextButton.TabIndex = 0;
            nextButton.TabStop = false;
            nextButton.Text = ">";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // imageBox
            // 
            imageBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            imageBox.Location = new System.Drawing.Point(0, 30);
            imageBox.Name = "imageBox";
            imageBox.Size = new System.Drawing.Size(762, 635);
            imageBox.TabIndex = 4;
            imageBox.TabStop = false;
            // 
            // ViewPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            Controls.Add(mainSplit);
            ForeColor = System.Drawing.Color.White;
            Name = "ViewPanel";
            Size = new System.Drawing.Size(978, 665);
            mainSplit.Panel1.ResumeLayout(false);
            mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplit).EndInit();
            mainSplit.ResumeLayout(false);
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            tagsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)viewBrowser).EndInit();
            topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label centerText;
        private System.Windows.Forms.TextBox dimWidthBox;
        private System.Windows.Forms.Label dimensionsLabel;
        private System.Windows.Forms.TextBox dimHeightBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label extLabel;
        private System.Windows.Forms.TextBox extensionBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.Button backListButton;
        private System.Windows.Forms.ListBox sourcesBox;
        private System.Windows.Forms.Label sourcesLabel;
        private System.Windows.Forms.ListBox artistsBox;
        private System.Windows.Forms.ListBox charactersBox;
        private System.Windows.Forms.Label charactersLabel;
        private System.Windows.Forms.ListBox tagsBox;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.ContextMenuStrip tagsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem blacklistlocallyToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 viewBrowser;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ListBox poolsBox;
        private System.Windows.Forms.Label poolsLabel;
    }
}
