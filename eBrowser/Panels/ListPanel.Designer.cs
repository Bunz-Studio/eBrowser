namespace eBrowser.Panels
{
    partial class ListPanel
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
            postsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            sidePanel = new System.Windows.Forms.Panel();
            sortModeBox = new System.Windows.Forms.ComboBox();
            sortModeLbl = new System.Windows.Forms.Label();
            boxSizesLabel = new System.Windows.Forms.Label();
            boxSizeWidth = new System.Windows.Forms.NumericUpDown();
            boxSizeHeight = new System.Windows.Forms.NumericUpDown();
            historyBox = new System.Windows.Forms.ListView();
            queryHeader = new System.Windows.Forms.ColumnHeader();
            itemsMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            historyLabel = new System.Windows.Forms.Label();
            topPanel = new System.Windows.Forms.Panel();
            previousPageBtn = new System.Windows.Forms.Button();
            maxPageLbl = new System.Windows.Forms.Label();
            nextPageBtn = new System.Windows.Forms.Button();
            searchButton = new System.Windows.Forms.Button();
            pageNumericBox = new System.Windows.Forms.NumericUpDown();
            searchLabel = new System.Windows.Forms.Label();
            searchBox = new System.Windows.Forms.TextBox();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)boxSizeWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxSizeHeight).BeginInit();
            itemsMenuStrip.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumericBox).BeginInit();
            SuspendLayout();
            // 
            // postsLayoutPanel
            // 
            postsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            postsLayoutPanel.AutoScroll = true;
            postsLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            postsLayoutPanel.Location = new System.Drawing.Point(209, 3);
            postsLayoutPanel.Name = "postsLayoutPanel";
            postsLayoutPanel.Size = new System.Drawing.Size(588, 494);
            postsLayoutPanel.TabIndex = 0;
            // 
            // sidePanel
            // 
            sidePanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sidePanel.Controls.Add(sortModeBox);
            sidePanel.Controls.Add(sortModeLbl);
            sidePanel.Controls.Add(boxSizesLabel);
            sidePanel.Controls.Add(boxSizeWidth);
            sidePanel.Controls.Add(boxSizeHeight);
            sidePanel.Controls.Add(historyBox);
            sidePanel.Controls.Add(historyLabel);
            sidePanel.Location = new System.Drawing.Point(3, 109);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new System.Drawing.Size(200, 388);
            sidePanel.TabIndex = 1;
            // 
            // sortModeBox
            // 
            sortModeBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sortModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sortModeBox.FormattingEnabled = true;
            sortModeBox.Items.AddRange(new object[] { "Default", "Date", "Score", "Favorite Count" });
            sortModeBox.Location = new System.Drawing.Point(3, 353);
            sortModeBox.Name = "sortModeBox";
            sortModeBox.Size = new System.Drawing.Size(192, 23);
            sortModeBox.TabIndex = 6;
            sortModeBox.SelectedIndexChanged += sortModeBox_SelectedIndexChanged;
            // 
            // sortModeLbl
            // 
            sortModeLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            sortModeLbl.AutoSize = true;
            sortModeLbl.Location = new System.Drawing.Point(3, 335);
            sortModeLbl.Name = "sortModeLbl";
            sortModeLbl.Size = new System.Drawing.Size(62, 15);
            sortModeLbl.TabIndex = 5;
            sortModeLbl.Text = "Sort Mode";
            // 
            // boxSizesLabel
            // 
            boxSizesLabel.AutoSize = true;
            boxSizesLabel.Location = new System.Drawing.Point(5, 8);
            boxSizesLabel.Name = "boxSizesLabel";
            boxSizesLabel.Size = new System.Drawing.Size(55, 15);
            boxSizesLabel.TabIndex = 4;
            boxSizesLabel.Text = "Box Sizes";
            // 
            // boxSizeWidth
            // 
            boxSizeWidth.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            boxSizeWidth.Location = new System.Drawing.Point(5, 30);
            boxSizeWidth.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            boxSizeWidth.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            boxSizeWidth.Name = "boxSizeWidth";
            boxSizeWidth.Size = new System.Drawing.Size(87, 23);
            boxSizeWidth.TabIndex = 3;
            boxSizeWidth.Value = new decimal(new int[] { 160, 0, 0, 0 });
            boxSizeWidth.ValueChanged += boxSizeWidth_ValueChanged;
            // 
            // boxSizeHeight
            // 
            boxSizeHeight.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            boxSizeHeight.Location = new System.Drawing.Point(98, 30);
            boxSizeHeight.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            boxSizeHeight.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            boxSizeHeight.Name = "boxSizeHeight";
            boxSizeHeight.Size = new System.Drawing.Size(96, 23);
            boxSizeHeight.TabIndex = 2;
            boxSizeHeight.Value = new decimal(new int[] { 180, 0, 0, 0 });
            boxSizeHeight.ValueChanged += boxSizeHeight_ValueChanged;
            // 
            // historyBox
            // 
            historyBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            historyBox.BackColor = System.Drawing.Color.FromArgb(0, 35, 65);
            historyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            historyBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { queryHeader });
            historyBox.ContextMenuStrip = itemsMenuStrip;
            historyBox.ForeColor = System.Drawing.Color.White;
            historyBox.FullRowSelect = true;
            historyBox.Location = new System.Drawing.Point(3, 78);
            historyBox.Name = "historyBox";
            historyBox.Size = new System.Drawing.Size(192, 250);
            historyBox.TabIndex = 1;
            historyBox.UseCompatibleStateImageBehavior = false;
            historyBox.View = System.Windows.Forms.View.Details;
            historyBox.DoubleClick += historyBox_DoubleClick;
            // 
            // queryHeader
            // 
            queryHeader.Text = "Query";
            queryHeader.Width = 180;
            // 
            // itemsMenuStrip
            // 
            itemsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { searchToolStripMenuItem, appendToolStripMenuItem, removeToolStripMenuItem });
            itemsMenuStrip.Name = "itemsMenuStrip";
            itemsMenuStrip.Size = new System.Drawing.Size(118, 70);
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // appendToolStripMenuItem
            // 
            appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            appendToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            appendToolStripMenuItem.Text = "Append";
            appendToolStripMenuItem.Click += appendToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // historyLabel
            // 
            historyLabel.AutoSize = true;
            historyLabel.Location = new System.Drawing.Point(2, 60);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new System.Drawing.Size(45, 15);
            historyLabel.TabIndex = 0;
            historyLabel.Text = "History";
            // 
            // topPanel
            // 
            topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            topPanel.Controls.Add(previousPageBtn);
            topPanel.Controls.Add(maxPageLbl);
            topPanel.Controls.Add(nextPageBtn);
            topPanel.Controls.Add(searchButton);
            topPanel.Controls.Add(pageNumericBox);
            topPanel.Controls.Add(searchLabel);
            topPanel.Controls.Add(searchBox);
            topPanel.Location = new System.Drawing.Point(3, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new System.Drawing.Size(200, 100);
            topPanel.TabIndex = 2;
            // 
            // previousPageBtn
            // 
            previousPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            previousPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            previousPageBtn.Location = new System.Drawing.Point(8, 66);
            previousPageBtn.Name = "previousPageBtn";
            previousPageBtn.Size = new System.Drawing.Size(44, 23);
            previousPageBtn.TabIndex = 6;
            previousPageBtn.Text = "<";
            previousPageBtn.UseVisualStyleBackColor = true;
            previousPageBtn.Click += previousPageBtn_Click;
            // 
            // maxPageLbl
            // 
            maxPageLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            maxPageLbl.AutoSize = true;
            maxPageLbl.Location = new System.Drawing.Point(110, 70);
            maxPageLbl.Name = "maxPageLbl";
            maxPageLbl.Size = new System.Drawing.Size(33, 15);
            maxPageLbl.TabIndex = 5;
            maxPageLbl.Text = "/ 750";
            // 
            // nextPageBtn
            // 
            nextPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            nextPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            nextPageBtn.Location = new System.Drawing.Point(150, 66);
            nextPageBtn.Name = "nextPageBtn";
            nextPageBtn.Size = new System.Drawing.Size(44, 23);
            nextPageBtn.TabIndex = 4;
            nextPageBtn.Text = ">";
            nextPageBtn.UseVisualStyleBackColor = true;
            nextPageBtn.Click += nextPageBtn_Click;
            // 
            // searchButton
            // 
            searchButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            searchButton.Location = new System.Drawing.Point(8, 37);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(186, 23);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // pageNumericBox
            // 
            pageNumericBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pageNumericBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 65);
            pageNumericBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pageNumericBox.ForeColor = System.Drawing.Color.White;
            pageNumericBox.Location = new System.Drawing.Point(61, 66);
            pageNumericBox.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            pageNumericBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pageNumericBox.Name = "pageNumericBox";
            pageNumericBox.Size = new System.Drawing.Size(46, 23);
            pageNumericBox.TabIndex = 2;
            pageNumericBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new System.Drawing.Point(5, 12);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new System.Drawing.Size(42, 15);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "Search";
            // 
            // searchBox
            // 
            searchBox.BackColor = System.Drawing.Color.FromArgb(0, 25, 65);
            searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchBox.ForeColor = System.Drawing.Color.White;
            searchBox.Location = new System.Drawing.Point(53, 8);
            searchBox.Name = "searchBox";
            searchBox.Size = new System.Drawing.Size(141, 23);
            searchBox.TabIndex = 0;
            searchBox.KeyUp += searchBox_KeyUp;
            // 
            // ListPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 45, 85);
            Controls.Add(topPanel);
            Controls.Add(sidePanel);
            Controls.Add(postsLayoutPanel);
            ForeColor = System.Drawing.Color.White;
            Name = "ListPanel";
            Size = new System.Drawing.Size(800, 500);
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)boxSizeWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxSizeHeight).EndInit();
            itemsMenuStrip.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumericBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel postsLayoutPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.NumericUpDown pageNumericBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView historyBox;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.ColumnHeader queryHeader;
        private System.Windows.Forms.ContextMenuStrip itemsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label boxSizesLabel;
        private System.Windows.Forms.NumericUpDown boxSizeWidth;
        private System.Windows.Forms.NumericUpDown boxSizeHeight;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.Label maxPageLbl;
        private System.Windows.Forms.Button previousPageBtn;
        private System.Windows.Forms.Label sortModeLbl;
        private System.Windows.Forms.ComboBox sortModeBox;
    }
}
