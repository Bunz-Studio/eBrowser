namespace eBrowser.Panels
{
    partial class PostPanel
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
            bottomPanel = new System.Windows.Forms.Panel();
            flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            votesLabel = new System.Windows.Forms.Label();
            favoritesLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            ratingLabel = new System.Windows.Forms.Label();
            previewPictureBox = new System.Windows.Forms.PictureBox();
            loadingBar = new System.Windows.Forms.ProgressBar();
            bottomPanel.SuspendLayout();
            flowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            SuspendLayout();
            // 
            // bottomPanel
            // 
            bottomPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            bottomPanel.BackColor = System.Drawing.Color.FromArgb(31, 60, 103);
            bottomPanel.Controls.Add(flowPanel);
            bottomPanel.Location = new System.Drawing.Point(3, 152);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new System.Drawing.Size(154, 25);
            bottomPanel.TabIndex = 0;
            // 
            // flowPanel
            // 
            flowPanel.Controls.Add(votesLabel);
            flowPanel.Controls.Add(favoritesLabel);
            flowPanel.Controls.Add(commentsLabel);
            flowPanel.Controls.Add(ratingLabel);
            flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowPanel.Location = new System.Drawing.Point(0, 0);
            flowPanel.Name = "flowPanel";
            flowPanel.Padding = new System.Windows.Forms.Padding(15, 5, 0, 0);
            flowPanel.Size = new System.Drawing.Size(154, 25);
            flowPanel.TabIndex = 2;
            // 
            // votesLabel
            // 
            votesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            votesLabel.AutoSize = true;
            votesLabel.Location = new System.Drawing.Point(18, 5);
            votesLabel.Name = "votesLabel";
            votesLabel.Size = new System.Drawing.Size(19, 15);
            votesLabel.TabIndex = 0;
            votesLabel.Text = "↑1";
            // 
            // favoritesLabel
            // 
            favoritesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            favoritesLabel.AutoSize = true;
            favoritesLabel.Location = new System.Drawing.Point(43, 5);
            favoritesLabel.Name = "favoritesLabel";
            favoritesLabel.Size = new System.Drawing.Size(21, 15);
            favoritesLabel.TabIndex = 1;
            favoritesLabel.Text = "♥2";
            // 
            // commentsLabel
            // 
            commentsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            commentsLabel.AutoSize = true;
            commentsLabel.Location = new System.Drawing.Point(70, 5);
            commentsLabel.Name = "commentsLabel";
            commentsLabel.Size = new System.Drawing.Size(21, 15);
            commentsLabel.TabIndex = 2;
            commentsLabel.Text = "C0";
            // 
            // ratingLabel
            // 
            ratingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ratingLabel.AutoSize = true;
            ratingLabel.Location = new System.Drawing.Point(97, 5);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new System.Drawing.Size(13, 15);
            ratingLabel.TabIndex = 3;
            ratingLabel.Text = "E";
            // 
            // previewPictureBox
            // 
            previewPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            previewPictureBox.Location = new System.Drawing.Point(3, 3);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new System.Drawing.Size(154, 143);
            previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            previewPictureBox.TabIndex = 1;
            previewPictureBox.TabStop = false;
            previewPictureBox.LoadCompleted += previewPictureBox_LoadCompleted;
            previewPictureBox.LoadProgressChanged += previewPictureBox_LoadProgressChanged;
            previewPictureBox.Click += previewPictureBox_Click;
            // 
            // loadingBar
            // 
            loadingBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingBar.Location = new System.Drawing.Point(3, 123);
            loadingBar.Name = "loadingBar";
            loadingBar.Size = new System.Drawing.Size(154, 23);
            loadingBar.TabIndex = 2;
            loadingBar.Visible = false;
            // 
            // PostPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(loadingBar);
            Controls.Add(previewPictureBox);
            Controls.Add(bottomPanel);
            ForeColor = System.Drawing.Color.White;
            Name = "PostPanel";
            Size = new System.Drawing.Size(160, 180);
            bottomPanel.ResumeLayout(false);
            flowPanel.ResumeLayout(false);
            flowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label favoritesLabel;
        private System.Windows.Forms.Label votesLabel;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.ProgressBar loadingBar;
    }
}
