using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using e621NET;
using e621NET.Data.Posts;
using eBrowser.Panels;

namespace eBrowser
{
    public partial class MainForm : Form
    {
        public static MainForm? Instance;
        public static ePosts? Posts;

        public static string PostsPath = "posts";
        public static string PreviewsPath = "previews";

        public const string LastPostsPath = "last-posts.json";
        public const string HistoryPath = "history.json";

        public const string SettingsPath = "settings.json";

        private bool preventClose = true;

        public Control[] panels = { };
        public SearchHistory history = new SearchHistory();
        public PostHistory postHistory = new PostHistory();

        public MainForm()
        {
            InitializeComponent();
            panels = [
                homePanel,
                listPanel,
                viewPanel,
                settingsPanel
            ];
            MovePanel(0);

            SettingsPanel.LoadSettings(false);
            listPanel.Initialize();

            if (LocalStorage.FileExists(LastPostsPath))
            {
                var text = LocalStorage.ReadText(LastPostsPath);
                var posts = JsonSerializer.Deserialize<ePosts>(text);
                Posts = posts;
                if (posts == null) return;
                if (posts.Mode == ListMode.Posts)
                    listPanel.LoadPosts(posts);
                else
                    listPanel.LoadPoolPosts(posts);
                MovePanel(1);
            }

            if (LocalStorage.FileExists(HistoryPath))
            {
                var text = LocalStorage.ReadText(HistoryPath);
                var history = JsonSerializer.Deserialize<SearchHistory>(text);
                if (history != null)
                    this.history = history;
                listPanel.SearchQuery = this.history.LatestHistory;
                listPanel.LoadHistory(this.history.Keywords);
            }

            Load += MainForm_Load;
            Instance = this;
        }

        private async void MainForm_Load(object? sender, System.EventArgs e)
        {
            await viewPanel.InitializeWebView();
        }

        public void MovePanel(int index)
        {
            for (int i = 0; i < panels.Length; i++)
                panels[i].Visible = i == index;
        }

        private void homePanel_OnSearchQueried(object sender, SearchArgs e)
        {
            QuerySearch(e.Query, e.Page, e.Limit);
        }

        public async void QuerySearch(string? query, int page = 1, int limit = -1)
        {
            var posts = await e621Client.Current.GetPostsAsync(query, page, limit);
            Posts = posts;
            listPanel.SearchQuery = query;
            listPanel.Page = page;
            listPanel.LoadPosts(posts);
            MovePanel(1);

            LocalStorage.WriteText(LastPostsPath, JsonSerializer.Serialize(posts, new JsonSerializerOptions() { WriteIndented = true }));
            if (query != null)
            {
                history.LatestHistory = query;

                if (!history.Keywords.Contains(query))
                {
                    history.Keywords.Add(query);
                    listPanel.AddHistory(query);
                }
                LocalStorage.WriteText(HistoryPath, JsonSerializer.Serialize(history, new JsonSerializerOptions() { WriteIndented = true }));
            }
        }
        public async void QueryPoolSearch(int id, int page = 1)
        {
            var posts = await e621Client.Current.GetPoolPostsAsync(id, page);
            Posts = posts;
            listPanel.Page = page;
            listPanel.LoadPoolPosts(posts);
            MovePanel(1);

            LocalStorage.WriteText(LastPostsPath, JsonSerializer.Serialize(posts, new JsonSerializerOptions() { WriteIndented = true }));
            history.LatestHistory = $"pool:{id}";

            if (!history.Keywords.Contains($"pool:{id}"))
            {
                history.Keywords.Add($"pool:{id}");
                listPanel.AddHistory($"pool:{id}");
            }
            LocalStorage.WriteText(HistoryPath, JsonSerializer.Serialize(history, new JsonSerializerOptions() { WriteIndented = true }));
        }

        private void listPanel_OnPostClicked(object sender, PostItemArgs e)
        {
            MovePanel(2);
            viewPanel.LoadPost(listPanel.SortedPosts, e.Index);
        }

        private void viewPanel_OnBack(object sender, System.EventArgs e) => MovePanel(1);
        private void tabHomeBtn_Click(object sender, System.EventArgs e) => MovePanel(0);
        private void tabListBtn_Click(object sender, System.EventArgs e) => MovePanel(1);
        private void tabViewerBtn_Click(object sender, System.EventArgs e) => MovePanel(2);
        private void tabSettingsBtn_Click(object sender, System.EventArgs e) => MovePanel(3);

        private void viewPanel_OnTagAdd(object sender, TagEventArgs e)
        {
            foreach (var tag in e.Tags)
            {
                if (!string.IsNullOrEmpty(tag))
                    listPanel.SearchQuery += $" {tag}";
            }
        }

        private void viewPanel_OnTagRemove(object sender, TagEventArgs e)
        {
            foreach (var tag in e.Tags)
            {
                if (!string.IsNullOrEmpty(tag))
                    listPanel.SearchQuery += $" -{tag}";
            }
        }

        private void viewPanel_OnTagSearch(object sender, SearchArgs e)
        {
            if (e.Mode == ListMode.Posts)
                QuerySearch(e.Query, e.Page, e.Limit);
            else
                QueryPoolSearch(e.PoolId, e.Page);

        }

        private void notifyIcon_Click(object sender, System.EventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            preventClose = false;
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (preventClose)
            {
                e.Cancel = true;
                Hide();
                viewPanel.PauseVideo();
            }
        }

        private void showToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Show();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
            }
        }
    }

    public class SearchHistory
    {
        public string LatestHistory { get; set; } = "";
        public List<string> Keywords { get; set; } = new List<string>();

        public SearchHistory() { }
        public SearchHistory(string latestHistory, List<string> keywords)
        {
            LatestHistory = latestHistory;
            Keywords = keywords;
        }
    }

    public class PostHistory
    {
        public ePosts Posts { get; set; }
        public int DefaultSorting { get; set; }

        public PostHistory() { Posts = new ePosts();  }
        public PostHistory(ePosts posts)
        {
            Posts = posts;
        }
    }
}
