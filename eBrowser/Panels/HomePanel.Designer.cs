namespace eBrowser.Panels
{
    partial class HomePanel
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
            mascotPictureBox = new System.Windows.Forms.PictureBox();
            searchPanel = new System.Windows.Forms.Panel();
            searchButton = new System.Windows.Forms.Button();
            searchBox = new System.Windows.Forms.TextBox();
            titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)mascotPictureBox).BeginInit();
            searchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mascotPictureBox
            // 
            mascotPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            mascotPictureBox.Location = new System.Drawing.Point(250, 100);
            mascotPictureBox.Name = "mascotPictureBox";
            mascotPictureBox.Size = new System.Drawing.Size(300, 400);
            mascotPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            mascotPictureBox.TabIndex = 0;
            mascotPictureBox.TabStop = false;
            // 
            // searchPanel
            // 
            searchPanel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchPanel.Controls.Add(searchButton);
            searchPanel.Controls.Add(searchBox);
            searchPanel.Location = new System.Drawing.Point(100, 280);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new System.Drawing.Size(600, 100);
            searchPanel.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            searchButton.Location = new System.Drawing.Point(475, 52);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(75, 23);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchBox
            // 
            searchBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchBox.BackColor = System.Drawing.Color.FromArgb(2, 15, 35);
            searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchBox.ForeColor = System.Drawing.Color.White;
            searchBox.Location = new System.Drawing.Point(50, 23);
            searchBox.Name = "searchBox";
            searchBox.Size = new System.Drawing.Size(500, 23);
            searchBox.TabIndex = 0;
            searchBox.KeyUp += searchBox_KeyUp;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            titleLabel.Location = new System.Drawing.Point(325, 190);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(150, 50);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "eBrowser";
            // 
            // HomePanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            Controls.Add(titleLabel);
            Controls.Add(searchPanel);
            Controls.Add(mascotPictureBox);
            ForeColor = System.Drawing.Color.White;
            Name = "HomePanel";
            Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)mascotPictureBox).EndInit();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox mascotPictureBox;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label titleLabel;
    }
}
