using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using e621NET.Data.Posts;

namespace eBrowser.Panels
{
    public partial class ListPanel : UserControl
    {
        public ListMode listMode = ListMode.Posts;

        public ePosts? CurrentPosts { get; set; }
        public List<ePost> SortedPosts { get; set; } = new();

        [Category("Action")]
        public event EventHandler<SearchArgs> OnSearchQueried = new(SearchQueried);
        [Category("Action")]
        public event EventHandler<PostItemArgs> OnPostClicked = new(PostClicked);

        [Category("Appearance")]
        [Browsable(true)]
        public bool IsSearchAllowed
        {
            get => searchButton.Enabled;
            set => searchButton.Enabled = value;
        }

        [Category("Appearance")]
        [Browsable(true)]
        public string? SearchQuery
        {
            get => searchBox.Text;
            set => searchBox.Text = value;
        }

        [Category("Appearance")]
        [Browsable(true)]
        public decimal Page
        {
            get => pageNumericBox.Value;
            set => pageNumericBox.Value = value;
        }

        public List<PostPanel> PostControls = new List<PostPanel>();

        public ListPanel()
        {
            InitializeComponent();
            sortModeBox.SelectedIndex = 0;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                if (SearchQuery != null && SearchQuery.StartsWith("pool:"))
                {
                    listMode = ListMode.Pools;
                    MainForm.Instance?.QueryPoolSearch(int.Parse(SearchQuery.Substring(5)), (int)Page);
                    OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                }
                else
                {
                    listMode = ListMode.Posts;
                    MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                    OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                }
            }
            catch { Enabled = true; }
        }

        private static void SearchQueried(object? sender, SearchArgs e)
        {

        }
        private static void PostClicked(object? sender, PostItemArgs e)
        {

        }

        public void LoadPosts(ePosts? posts)
        {
            if (posts == null) return;
            CurrentPosts = posts;

            Page = posts.Page;
            SearchQuery = posts.Query;
            maxPageLbl.Text = $"/{posts.MaxPage}";

            postsLayoutPanel.SuspendLayout();
            foreach (var item in PostControls)
                item.Dispose();

            int index = 0;
            switch (sortModeBox.SelectedIndex)
            {
                // Default sorting
                case 0:
                    SortedPosts = posts.Posts;
                    break;
                // Date sorting
                case 1:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.CreatedAt)];
                    break;
                // Favorite count sorting
                case 2:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.FavCount)];
                    break;
                // Score sorting
                case 3:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.Score)];
                    break;
            }

            foreach (var post in SortedPosts)
            {
                int i = index;
                var item = new PostPanel(post);
                item.Click += (s, e) =>
                {
                    OnPostClicked.Invoke(this, new PostItemArgs(i, post));
                };
                item.Width = (int)boxSizeWidth.Value;
                item.Height = (int)boxSizeHeight.Value;
                postsLayoutPanel.Controls.Add(item);
                PostControls.Add(item);
                index++;
            }
            postsLayoutPanel.ResumeLayout();
            Enabled = true;
        }

        public void LoadPoolPosts(ePosts? posts)
        {
            if (posts == null) return;
            CurrentPosts = posts;

            Page = 1;
            SearchQuery = "pool:" + posts.PoolId;
            maxPageLbl.Text = $"/{posts.MaxPage}";

            postsLayoutPanel.SuspendLayout();
            foreach (var item in PostControls)
                item.Dispose();

            /*
            switch (sortModeBox.SelectedIndex)
            {
                // Default sorting
                case 0:
                    SortedPosts = posts.Posts;
                    break;
                // Date sorting
                case 1:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.CreatedAt)];
                    break;
                // Favorite count sorting
                case 2:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.FavCount)];
                    break;
                // Score sorting
                case 3:
                    SortedPosts = [.. posts.Posts.OrderByDescending(x => x.Score)];
                    break;
            }*/

            SortedPosts = posts.Posts;

            int index = 0;
            foreach (var post in SortedPosts)
            {
                int i = index;
                var item = new PostPanel(post);
                item.Click += (s, e) =>
                {
                    OnPostClicked.Invoke(this, new PostItemArgs(i, post));
                };
                item.Width = (int)boxSizeWidth.Value;
                item.Height = (int)boxSizeHeight.Value;
                postsLayoutPanel.Controls.Add(item);
                PostControls.Add(item);
                index++;
            }

            postsLayoutPanel.ResumeLayout();
            Enabled = true;
        }

        public void LoadHistory(List<string> history)
        {
            foreach (var str in history)
                historyBox.Items.Add(str);
        }

        public void AddHistory(string history)
        {
            historyBox.Items.Add(history);
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchButton_Click(sender, e);
        }

        private void historyBox_DoubleClick(object sender, EventArgs e)
        {
            if (historyBox.SelectedItems.Count > 0)
            {
                var item = historyBox.SelectedItems[0];
                SearchQuery = item.Text;
                Page = 1;
                Enabled = false;
                try
                {
                    MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                    OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                }
                catch { Enabled = true; }
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItems.Count > 0)
            {
                var item = historyBox.SelectedItems[0];
                SearchQuery = item.Text;
                Page = 1;
                Enabled = false;
                try
                {
                    MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                    OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                }
                catch { Enabled = true; }
            }
        }

        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItems.Count > 0)
            {
                var item = historyBox.SelectedItems[0];

                var oldQueries = new List<string>(SearchQuery!.Split(' '));
                var newQueries = new List<string>(item.Text.Split(' '));

                foreach (var query in newQueries)
                {
                    if (!oldQueries.Contains(query))
                        oldQueries.Add(query);
                }

                SearchQuery = string.Join(' ', oldQueries);

                Page = 1;
                Enabled = false;
                try
                {
                    MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                    OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                }
                catch { Enabled = true; }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItems.Count > 0)
            {
                var item = historyBox.SelectedItems[0];

                MainForm.Instance!.history.Keywords.Remove(item.Text);
                historyBox.Items.Remove(item);
            }
        }

        private void boxSizeWidth_ValueChanged(object sender, EventArgs e)
        {
            postsLayoutPanel.SuspendLayout();
            foreach (var item in PostControls)
            {
                item.Width = (int)boxSizeWidth.Value;
                item.Height = (int)boxSizeHeight.Value;
            }
            postsLayoutPanel.ResumeLayout();
        }

        private void boxSizeHeight_ValueChanged(object sender, EventArgs e)
        {
            postsLayoutPanel.SuspendLayout();
            foreach (var item in PostControls)
            {
                item.Width = (int)boxSizeWidth.Value;
                item.Height = (int)boxSizeHeight.Value;
            }
            postsLayoutPanel.ResumeLayout();
        }

        private void previousPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPosts != null)
            {
                if (Page > 1)
                {
                    Page -= 1;
                    Enabled = false;
                    try
                    {
                        if (SearchQuery != null && SearchQuery.StartsWith("pool:"))
                        {
                            MainForm.Instance?.QueryPoolSearch(int.Parse(SearchQuery.Substring(5)), (int)Page);
                            OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                        }
                        else
                        {
                            MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                            OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                        }
                    }
                    catch { Enabled = true; }
                }
            }
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentPosts != null)
            {
                if (Page < CurrentPosts.MaxPage)
                {
                    Page += 1;
                    Enabled = false;
                    try
                    {
                        if (SearchQuery != null && SearchQuery.StartsWith("pool:"))
                        {
                            MainForm.Instance?.QueryPoolSearch(int.Parse(SearchQuery.Substring(5)), (int)Page);
                            OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                        }
                        else
                        {
                            MainForm.Instance?.QuerySearch(SearchQuery, (int)Page);
                            OnSearchQueried.Invoke(this, new SearchArgs(SearchQuery, (int)Page));
                        }
                    }
                    catch { Enabled = true; }
                }
            }
        }

        private void sortModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPosts != null)
            {
                postsLayoutPanel.SuspendLayout();
                foreach (var item in PostControls)
                    item.Dispose();

                int index = 0;
                switch (sortModeBox.SelectedIndex)
                {
                    // Default sorting
                    case 0:
                        SortedPosts = CurrentPosts.Posts;
                        break;
                    // Date sorting
                    case 1:
                        SortedPosts = [.. CurrentPosts.Posts.OrderByDescending(x => x.CreatedAt)];
                        break;
                    // Favorite count sorting
                    case 2:
                        SortedPosts = [.. CurrentPosts.Posts.OrderByDescending(x => x.FavCount)];
                        break;
                    // Score sorting
                    case 3:
                        SortedPosts = [.. CurrentPosts.Posts.OrderByDescending(x => x.Score.Total)];
                        break;
                }

                foreach (var post in SortedPosts)
                {
                    int i = index;
                    var item = new PostPanel(post);
                    item.Click += (s, e) =>
                    {
                        OnPostClicked.Invoke(this, new PostItemArgs(i, post));
                    };
                    item.Width = (int)boxSizeWidth.Value;
                    item.Height = (int)boxSizeHeight.Value;
                    postsLayoutPanel.Controls.Add(item);
                    PostControls.Add(item);
                    index++;
                }
                postsLayoutPanel.ResumeLayout();
            }
        }
    }
}
