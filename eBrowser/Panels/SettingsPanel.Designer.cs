namespace eBrowser.Panels
{
    partial class SettingsPanel
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
            mainSettings = new System.Windows.Forms.Panel();
            label8 = new System.Windows.Forms.Label();
            postQualityBox = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            thumbnailQualityBox = new System.Windows.Forms.ComboBox();
            qualityHeader = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            adVideoBox = new System.Windows.Forms.CheckBox();
            adImageBox = new System.Windows.Forms.CheckBox();
            autoDownloadHeader = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            apiKeyBox = new System.Windows.Forms.TextBox();
            apiKeyLabel = new System.Windows.Forms.Label();
            usernameBox = new System.Windows.Forms.TextBox();
            usernameLabel = new System.Windows.Forms.Label();
            authorizationHeader = new System.Windows.Forms.Panel();
            authorizationLabel = new System.Windows.Forms.Label();
            openPostsFolderBtn = new System.Windows.Forms.Button();
            customPostsPathBox = new System.Windows.Forms.CheckBox();
            postsPathBox = new System.Windows.Forms.TextBox();
            postsLabel = new System.Windows.Forms.Label();
            fileSystemHeader = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            gifsOnListsBox = new System.Windows.Forms.CheckBox();
            muteBox = new System.Windows.Forms.CheckBox();
            autoplayVideosBox = new System.Windows.Forms.CheckBox();
            viewerHeader = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            fileFormatBox = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            hostBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            hostsHeader = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            pauseHideBox = new System.Windows.Forms.CheckBox();
            mainSettings.SuspendLayout();
            qualityHeader.SuspendLayout();
            autoDownloadHeader.SuspendLayout();
            authorizationHeader.SuspendLayout();
            fileSystemHeader.SuspendLayout();
            panel3.SuspendLayout();
            viewerHeader.SuspendLayout();
            hostsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // mainSettings
            // 
            mainSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            mainSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mainSettings.Controls.Add(label8);
            mainSettings.Controls.Add(postQualityBox);
            mainSettings.Controls.Add(label7);
            mainSettings.Controls.Add(thumbnailQualityBox);
            mainSettings.Controls.Add(qualityHeader);
            mainSettings.Controls.Add(adVideoBox);
            mainSettings.Controls.Add(adImageBox);
            mainSettings.Controls.Add(autoDownloadHeader);
            mainSettings.Controls.Add(apiKeyBox);
            mainSettings.Controls.Add(apiKeyLabel);
            mainSettings.Controls.Add(usernameBox);
            mainSettings.Controls.Add(usernameLabel);
            mainSettings.Controls.Add(authorizationHeader);
            mainSettings.Location = new System.Drawing.Point(3, 3);
            mainSettings.Name = "mainSettings";
            mainSettings.Size = new System.Drawing.Size(225, 494);
            mainSettings.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 357);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 15);
            label8.TabIndex = 18;
            label8.Text = "Posts";
            // 
            // postQualityBox
            // 
            postQualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            postQualityBox.FormattingEnabled = true;
            postQualityBox.Items.AddRange(new object[] { "Low", "Medium", "High" });
            postQualityBox.Location = new System.Drawing.Point(10, 378);
            postQualityBox.Name = "postQualityBox";
            postQualityBox.Size = new System.Drawing.Size(201, 23);
            postQualityBox.TabIndex = 17;
            postQualityBox.SelectedIndexChanged += postQualityBox_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(9, 303);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 15);
            label7.TabIndex = 16;
            label7.Text = "Thumbnails";
            // 
            // thumbnailQualityBox
            // 
            thumbnailQualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            thumbnailQualityBox.FormattingEnabled = true;
            thumbnailQualityBox.Items.AddRange(new object[] { "Low", "Medium" });
            thumbnailQualityBox.Location = new System.Drawing.Point(10, 324);
            thumbnailQualityBox.Name = "thumbnailQualityBox";
            thumbnailQualityBox.Size = new System.Drawing.Size(201, 23);
            thumbnailQualityBox.TabIndex = 14;
            thumbnailQualityBox.SelectedIndexChanged += thumbnailQualityBox_SelectedIndexChanged;
            // 
            // qualityHeader
            // 
            qualityHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            qualityHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            qualityHeader.Controls.Add(label6);
            qualityHeader.Location = new System.Drawing.Point(3, 257);
            qualityHeader.Name = "qualityHeader";
            qualityHeader.Size = new System.Drawing.Size(217, 36);
            qualityHeader.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(5, 9);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 0;
            label6.Text = "Quality";
            // 
            // adVideoBox
            // 
            adVideoBox.AutoSize = true;
            adVideoBox.Location = new System.Drawing.Point(10, 228);
            adVideoBox.Name = "adVideoBox";
            adVideoBox.Size = new System.Drawing.Size(147, 19);
            adVideoBox.TabIndex = 10;
            adVideoBox.Text = "Auto Download Videos";
            adVideoBox.UseVisualStyleBackColor = true;
            adVideoBox.CheckedChanged += adVideoBox_CheckedChanged;
            // 
            // adImageBox
            // 
            adImageBox.AutoSize = true;
            adImageBox.Location = new System.Drawing.Point(10, 203);
            adImageBox.Name = "adImageBox";
            adImageBox.Size = new System.Drawing.Size(150, 19);
            adImageBox.TabIndex = 9;
            adImageBox.Text = "Auto Download Images";
            adImageBox.UseVisualStyleBackColor = true;
            adImageBox.CheckedChanged += adImageBox_CheckedChanged;
            // 
            // autoDownloadHeader
            // 
            autoDownloadHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            autoDownloadHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            autoDownloadHeader.Controls.Add(label2);
            autoDownloadHeader.Location = new System.Drawing.Point(3, 157);
            autoDownloadHeader.Name = "autoDownloadHeader";
            autoDownloadHeader.Size = new System.Drawing.Size(217, 36);
            autoDownloadHeader.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 15);
            label2.TabIndex = 0;
            label2.Text = "Auto Download";
            // 
            // apiKeyBox
            // 
            apiKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            apiKeyBox.Location = new System.Drawing.Point(9, 119);
            apiKeyBox.Name = "apiKeyBox";
            apiKeyBox.Size = new System.Drawing.Size(202, 23);
            apiKeyBox.TabIndex = 5;
            apiKeyBox.UseSystemPasswordChar = true;
            apiKeyBox.TextChanged += apiKeyBox_TextChanged;
            // 
            // apiKeyLabel
            // 
            apiKeyLabel.AutoSize = true;
            apiKeyLabel.Location = new System.Drawing.Point(9, 98);
            apiKeyLabel.Name = "apiKeyLabel";
            apiKeyLabel.Size = new System.Drawing.Size(47, 15);
            apiKeyLabel.TabIndex = 4;
            apiKeyLabel.Text = "API Key";
            // 
            // usernameBox
            // 
            usernameBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            usernameBox.Location = new System.Drawing.Point(9, 67);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new System.Drawing.Size(202, 23);
            usernameBox.TabIndex = 3;
            usernameBox.TextChanged += usernameBox_TextChanged;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(9, 46);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(60, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username";
            // 
            // authorizationHeader
            // 
            authorizationHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            authorizationHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            authorizationHeader.Controls.Add(authorizationLabel);
            authorizationHeader.Location = new System.Drawing.Point(3, 3);
            authorizationHeader.Name = "authorizationHeader";
            authorizationHeader.Size = new System.Drawing.Size(217, 36);
            authorizationHeader.TabIndex = 1;
            // 
            // authorizationLabel
            // 
            authorizationLabel.AutoSize = true;
            authorizationLabel.Location = new System.Drawing.Point(5, 9);
            authorizationLabel.Name = "authorizationLabel";
            authorizationLabel.Size = new System.Drawing.Size(79, 15);
            authorizationLabel.TabIndex = 0;
            authorizationLabel.Text = "Authorization";
            // 
            // openPostsFolderBtn
            // 
            openPostsFolderBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            openPostsFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            openPostsFolderBtn.Location = new System.Drawing.Point(10, 198);
            openPostsFolderBtn.Name = "openPostsFolderBtn";
            openPostsFolderBtn.Size = new System.Drawing.Size(201, 23);
            openPostsFolderBtn.TabIndex = 11;
            openPostsFolderBtn.Text = "Open Posts Folder";
            openPostsFolderBtn.UseVisualStyleBackColor = true;
            openPostsFolderBtn.Click += openPostsFolderBtn_Click;
            // 
            // customPostsPathBox
            // 
            customPostsPathBox.AutoSize = true;
            customPostsPathBox.Location = new System.Drawing.Point(149, 148);
            customPostsPathBox.Name = "customPostsPathBox";
            customPostsPathBox.Size = new System.Drawing.Size(68, 19);
            customPostsPathBox.TabIndex = 8;
            customPostsPathBox.Text = "Custom";
            customPostsPathBox.UseVisualStyleBackColor = true;
            customPostsPathBox.CheckedChanged += customPostsPathBox_CheckedChanged;
            // 
            // postsPathBox
            // 
            postsPathBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            postsPathBox.Location = new System.Drawing.Point(10, 169);
            postsPathBox.Name = "postsPathBox";
            postsPathBox.ReadOnly = true;
            postsPathBox.Size = new System.Drawing.Size(202, 23);
            postsPathBox.TabIndex = 7;
            postsPathBox.TextChanged += postsPathBox_TextChanged;
            // 
            // postsLabel
            // 
            postsLabel.AutoSize = true;
            postsLabel.Location = new System.Drawing.Point(10, 149);
            postsLabel.Name = "postsLabel";
            postsLabel.Size = new System.Drawing.Size(102, 15);
            postsLabel.TabIndex = 6;
            postsLabel.Text = "Downloads Folder";
            // 
            // fileSystemHeader
            // 
            fileSystemHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileSystemHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fileSystemHeader.Controls.Add(label1);
            fileSystemHeader.Location = new System.Drawing.Point(3, 100);
            fileSystemHeader.Name = "fileSystemHeader";
            fileSystemHeader.Size = new System.Drawing.Size(217, 36);
            fileSystemHeader.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "File System";
            // 
            // panel3
            // 
            panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(pauseHideBox);
            panel3.Controls.Add(gifsOnListsBox);
            panel3.Controls.Add(muteBox);
            panel3.Controls.Add(autoplayVideosBox);
            panel3.Controls.Add(viewerHeader);
            panel3.Controls.Add(fileFormatBox);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(hostBox);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(hostsHeader);
            panel3.Controls.Add(openPostsFolderBtn);
            panel3.Controls.Add(fileSystemHeader);
            panel3.Controls.Add(postsLabel);
            panel3.Controls.Add(postsPathBox);
            panel3.Controls.Add(customPostsPathBox);
            panel3.Location = new System.Drawing.Point(234, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(225, 494);
            panel3.TabIndex = 12;
            // 
            // gifsOnListsBox
            // 
            gifsOnListsBox.AutoSize = true;
            gifsOnListsBox.Checked = true;
            gifsOnListsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            gifsOnListsBox.Location = new System.Drawing.Point(10, 378);
            gifsOnListsBox.Name = "gifsOnListsBox";
            gifsOnListsBox.Size = new System.Drawing.Size(116, 19);
            gifsOnListsBox.TabIndex = 21;
            gifsOnListsBox.Text = "Play GIFs on Lists";
            gifsOnListsBox.UseVisualStyleBackColor = true;
            gifsOnListsBox.CheckedChanged += gifsOnListsBox_CheckedChanged;
            // 
            // muteBox
            // 
            muteBox.AutoSize = true;
            muteBox.Location = new System.Drawing.Point(10, 353);
            muteBox.Name = "muteBox";
            muteBox.Size = new System.Drawing.Size(54, 19);
            muteBox.TabIndex = 20;
            muteBox.Text = "Mute";
            muteBox.UseVisualStyleBackColor = true;
            muteBox.CheckedChanged += muteBox_CheckedChanged;
            // 
            // autoplayVideosBox
            // 
            autoplayVideosBox.AutoSize = true;
            autoplayVideosBox.Checked = true;
            autoplayVideosBox.CheckState = System.Windows.Forms.CheckState.Checked;
            autoplayVideosBox.Location = new System.Drawing.Point(10, 328);
            autoplayVideosBox.Name = "autoplayVideosBox";
            autoplayVideosBox.Size = new System.Drawing.Size(74, 19);
            autoplayVideosBox.TabIndex = 19;
            autoplayVideosBox.Text = "Autoplay";
            autoplayVideosBox.UseVisualStyleBackColor = true;
            autoplayVideosBox.CheckedChanged += autoplayVideosBox_CheckedChanged;
            // 
            // viewerHeader
            // 
            viewerHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            viewerHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            viewerHeader.Controls.Add(label9);
            viewerHeader.Location = new System.Drawing.Point(3, 286);
            viewerHeader.Name = "viewerHeader";
            viewerHeader.Size = new System.Drawing.Size(217, 36);
            viewerHeader.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(5, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(42, 15);
            label9.TabIndex = 0;
            label9.Text = "Viewer";
            // 
            // fileFormatBox
            // 
            fileFormatBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileFormatBox.Location = new System.Drawing.Point(10, 254);
            fileFormatBox.Name = "fileFormatBox";
            fileFormatBox.Size = new System.Drawing.Size(202, 23);
            fileFormatBox.TabIndex = 15;
            fileFormatBox.TextChanged += fileFormatBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 233);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 15);
            label5.TabIndex = 14;
            label5.Text = "File Format";
            // 
            // hostBox
            // 
            hostBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            hostBox.FormattingEnabled = true;
            hostBox.Items.AddRange(new object[] { "e621.net", "e926.net" });
            hostBox.Location = new System.Drawing.Point(10, 67);
            hostBox.Name = "hostBox";
            hostBox.Size = new System.Drawing.Size(201, 23);
            hostBox.TabIndex = 13;
            hostBox.SelectedIndexChanged += hostBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 46);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 15);
            label4.TabIndex = 12;
            label4.Text = "Website Host";
            // 
            // hostsHeader
            // 
            hostsHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hostsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            hostsHeader.Controls.Add(label3);
            hostsHeader.Location = new System.Drawing.Point(3, 3);
            hostsHeader.Name = "hostsHeader";
            hostsHeader.Size = new System.Drawing.Size(217, 36);
            hostsHeader.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 15);
            label3.TabIndex = 0;
            label3.Text = "Hosts";
            // 
            // pauseHideBox
            // 
            pauseHideBox.AutoSize = true;
            pauseHideBox.Location = new System.Drawing.Point(10, 403);
            pauseHideBox.Name = "pauseHideBox";
            pauseHideBox.Size = new System.Drawing.Size(102, 19);
            pauseHideBox.TabIndex = 22;
            pauseHideBox.Text = "Pause on Hide";
            pauseHideBox.UseVisualStyleBackColor = true;
            pauseHideBox.CheckedChanged += pauseHideBox_CheckedChanged;
            // 
            // SettingsPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            Controls.Add(panel3);
            Controls.Add(mainSettings);
            ForeColor = System.Drawing.Color.White;
            Name = "SettingsPanel";
            Size = new System.Drawing.Size(800, 500);
            mainSettings.ResumeLayout(false);
            mainSettings.PerformLayout();
            qualityHeader.ResumeLayout(false);
            qualityHeader.PerformLayout();
            autoDownloadHeader.ResumeLayout(false);
            autoDownloadHeader.PerformLayout();
            authorizationHeader.ResumeLayout(false);
            authorizationHeader.PerformLayout();
            fileSystemHeader.ResumeLayout(false);
            fileSystemHeader.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            viewerHeader.ResumeLayout(false);
            viewerHeader.PerformLayout();
            hostsHeader.ResumeLayout(false);
            hostsHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainSettings;
        private System.Windows.Forms.Panel authorizationHeader;
        private System.Windows.Forms.Label authorizationLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox apiKeyBox;
        private System.Windows.Forms.Label apiKeyLabel;
        private System.Windows.Forms.Panel fileSystemHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox postsPathBox;
        private System.Windows.Forms.Label postsLabel;
        private System.Windows.Forms.CheckBox customPostsPathBox;
        private System.Windows.Forms.Panel autoDownloadHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox adImageBox;
        private System.Windows.Forms.CheckBox adVideoBox;
        private System.Windows.Forms.Button openPostsFolderBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel hostsHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hostBox;
        private System.Windows.Forms.TextBox fileFormatBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel qualityHeader;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox thumbnailQualityBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox postQualityBox;
        private System.Windows.Forms.Panel viewerHeader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox autoplayVideosBox;
        private System.Windows.Forms.CheckBox muteBox;
        private System.Windows.Forms.CheckBox gifsOnListsBox;
        private System.Windows.Forms.CheckBox pauseHideBox;
    }
}
