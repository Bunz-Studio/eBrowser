using e621NET;
using e621NET.Data.Posts;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBrowser.Panels {
    public partial class ViewPanel : UserControl {
        [Category("Action")]
        public event EventHandler<EventArgs> OnBack = new EventHandler<EventArgs>(OnBacks);
        [Category("Action")]
        public event EventHandler<SearchArgs>? OnTagSearch;
        [Category("Action")]
        public event EventHandler<TagEventArgs>? OnTagAdd;
        [Category("Action")]
        public event EventHandler<TagEventArgs>? OnTagRemove;

        public List<ePost> Posts = new();
        public ePost? CurrentPost = new();
        public string? ImageUrl;
        public string ImagePath => PostFileNamer.GetPath(CurrentPost!);
        public int CurrentIndex { get => _CurrentIndex; set => ShowPost(value); }
        private int _CurrentIndex = -1;

        public ViewPanel() {
            InitializeComponent();

            PrepareWebView();
        }

        public async void PrepareWebView() {
            string? browserDirectory = null;
            if (Directory.Exists(Path.GetFullPath("Application"))) browserDirectory = Path.GetFullPath("Application");
            var environment = await CoreWebView2Environment.CreateAsync(browserDirectory);
            await viewBrowser.EnsureCoreWebView2Async(environment);
        }

        public Task InitializeWebView() {
            viewBrowser.CoreWebView2InitializationCompleted += ViewBrowser_CoreWebView2InitializationCompleted;

            GlobalStorage.CreateForceDirectory("posts".ToPersistPath());
            var controls = Themer.GetControls(this);
            foreach (var control in controls) {
                control.KeyDown += Control_KeyDown;
                control.KeyUp += Control_KeyUp;
            }

            return Task.CompletedTask;
        }

        private void ViewBrowser_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e) {
            if (!e.IsSuccess || e.InitializationException != null)
                throw e.InitializationException;
            viewBrowser.CoreWebView2InitializationCompleted -= ViewBrowser_CoreWebView2InitializationCompleted;
            viewBrowser.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
            Console.WriteLine("Initialized!");
        }

        private bool isCtrlPressed;

        private void Control_KeyDown(object? sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.LControlKey)
                isCtrlPressed = true;

            if (isCtrlPressed) {
            } else {
                if (e.KeyCode == Keys.Left)
                    previousButton_Click(this, e);
                if (e.KeyCode == Keys.Right)
                    nextButton_Click(this, e);

                if (e.KeyCode == Keys.E) {
                    downloadProgressBar.Value = 50;
                    downloadProgressBar.Visible = true;
                    ListPanel.Instance.Page++;
                    ListPanel.Instance.searchButton_Click(this, e);
                    downloadProgressBar.Visible = false;
                }

                if (e.KeyCode == Keys.Q) {
                    if (ListPanel.Instance.Page > 1) {
                        downloadProgressBar.Value = 50;
                        downloadProgressBar.Visible = true;
                        ListPanel.Instance.Page--;
                        ListPanel.Instance.searchButton_Click(this, e);
                        downloadProgressBar.Visible = false;
                    }
                }
            }
            if (e.KeyCode == Keys.D)
                downloadButton_Click(this, e);
            if (e.KeyCode == Keys.Escape)
                backListButton_Click(this, e);
        }

        private void Control_KeyUp(object? sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.LControlKey)
                isCtrlPressed = false;
        }

        private void CoreWebView2_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e) {
            Console.WriteLine("Message Received: " + e.Source);
            string message = e.TryGetWebMessageAsString();
            byte[] imageBytes = Convert.FromBase64String(message);
            File.WriteAllBytes(ImagePath, imageBytes);
        }

        public void LoadPost(List<ePost> posts, int index) {
            if (posts == null) return;

            Posts = posts;
            ShowPost(index);
        }

        List<string> videoFormats = new List<string>() {
            "mp4",
            "webm",
            "m4a"
        };

        public async Task<ePost?> LoadFullData(ePost partialData) {
            if (partialData.IsPartial) {
                var posts = await e621Client.Current.GetPostsAsync("id:" + partialData.Id);
                if (posts.Posts.Count > 0) {
                    return posts.Posts[0];
                }
            }

            return null;
        }

        public async void ShowPost(int index) {
            await viewBrowser.EnsureCoreWebView2Async();
            if (Posts.Count < 1) return;

            _CurrentIndex = index;

            var post = Posts[CurrentIndex];
            if (post.IsPartial) {
                var fullPost = await LoadFullData(post);
                if (fullPost != null) {
                    var postIndex = Posts.IndexOf(post);
                    post = fullPost;
                    Posts[postIndex] = post;
                } else {
                    MessageBox.Show("Unable to load full post data!", "eBrowser: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CurrentPost = post;

            dimWidthBox.Text = post.File.Width.ToString();
            dimHeightBox.Text = post.File.Height.ToString();

            centerText.Text = $"{CurrentIndex + 1}/{Posts.Count}";
            idBox.Text = post.Id.ToString();
            sizeBox.Text = FormatBytes(post.File.Size);
            extensionBox.Text = post.File.Ext;

            var quality = SettingsPanel.Main.PostQuality;
            if (extensionBox.Text != null && videoFormats.Contains(extensionBox.Text)) {
                // Low
                if (quality == 0) {
                    if (post.Sample.Alternates!.Quality480 != null) {
                        ImageUrl = post.Sample.Alternates.Quality480.Urls[0];
                    } else {
                        ImageUrl = post.File.Url ?? string.Empty;
                    }
                }
                // Medium
                else if (quality == 1) {
                    if (post.Sample.Alternates!.Quality720 != null) {
                        ImageUrl = post.Sample.Alternates.Quality720.Urls[0];
                    } else if (post.Sample.Alternates!.Quality480 != null) {
                        ImageUrl = post.Sample.Alternates.Quality480.Urls[0];
                    } else {
                        ImageUrl = post.File.Url ?? string.Empty;
                    }
                }
                // High
                else {
                    ImageUrl = post.File.Url ?? string.Empty;
                }
            } else {
                // Low
                if (quality == 0) {
                    ImageUrl = post.Preview.Url ?? string.Empty;
                }
                // Medium
                else if (quality == 1) {
                    ImageUrl = post.Sample.Url ?? string.Empty;
                }
                // High
                else {
                    ImageUrl = post.File.Url ?? string.Empty;
                }
            }

            artistsBox.Items.Clear();
            foreach (var tag in post.Tags.Artist)
                artistsBox.Items.Add(tag);

            charactersBox.Items.Clear();
            foreach (var tag in post.Tags.Character)
                charactersBox.Items.Add(tag);
            foreach (var tag in post.Tags.Species)
                charactersBox.Items.Add(tag);

            tagsBox.Items.Clear();
            foreach (var tag in post.Tags.Copyright)
                tagsBox.Items.Add(tag);
            foreach (var tag in post.Tags.General)
                tagsBox.Items.Add(tag);
            foreach (var tag in post.Tags.Lore)
                tagsBox.Items.Add(tag);
            foreach (var tag in post.Tags.Meta)
                tagsBox.Items.Add(tag);

            sourcesBox.Items.Clear();
            foreach (var source in post.Sources)
                sourcesBox.Items.Add(source);

            poolsBox.Items.Clear();
            foreach (var pool in post.Pools)
                poolsBox.Items.Add(pool);

            string ext = post.File.Ext == null ? "png" : post.File.Ext;
            if (videoFormats.Contains(ext.ToLower())) {
                if (File.Exists(ImagePath))
                    OpenHTMLStringToFile(
                        eBrowserResource.VideoViewHTML
                        .Replace("{VIDEO_URL}", "file:///" + ImagePath.Replace("\\", "/"))
                        .Replace("{ADDITIONAL_PARAM}", SettingsPanel.Main.Mute ? " muted" : "")
                    );
                else
                    viewBrowser.NavigateToString(
                        eBrowserResource.VideoViewHTML
                        .Replace("{VIDEO_URL}", ImageUrl)
                        .Replace("{ADDITIONAL_PARAM}", SettingsPanel.Main.Mute ? " muted" : "")
                    );

                if (SettingsPanel.Main.AutoDownloadVideo && !File.Exists(ImagePath))
                    downloadButton_Click(this, new EventArgs());
            } else {
                if (File.Exists(ImagePath))
                    OpenHTMLStringToFile(eBrowserResource.ImageViewHTML.Replace("{IMAGE_URL}", "file:///" + ImagePath.Replace("\\", "/")));
                else
                    viewBrowser.NavigateToString(eBrowserResource.ImageViewHTML.Replace("{IMAGE_URL}", ImageUrl));

                if (SettingsPanel.Main.AutoDownloadImage && !File.Exists(ImagePath))
                    downloadButton_Click(this, new EventArgs());
            }

            viewBrowser.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            viewBrowser.Focus();
            viewBrowser.Select();
        }

        private void CoreWebView2_DOMContentLoaded(object? sender, CoreWebView2DOMContentLoadedEventArgs e) {
            if (CurrentPost == null) return;

            string ext = CurrentPost.File.Ext == null ? "png" : CurrentPost.File.Ext;
            if (videoFormats.Contains(ext.ToLower()) && SettingsPanel.Main.AutoplayVideos) {
                viewBrowser.ExecuteScriptAsync("playVideo();");
            }
        }

        public void OpenHTMLStringToFile(string text) {
            File.WriteAllText("temporary.html".ToPersistPath(), text);
            viewBrowser.CoreWebView2.Navigate("temporary.html".ToPersistPath());
        }

        public async Task Download() {
            if (CurrentPost != null && CurrentPost.File != null && CurrentPost.File.Url != null)
                await DownloadFileAsync(CurrentPost.File.Url, ImagePath);
        }

        async Task DownloadFileAsync(string url, string savePath) {
            if (string.IsNullOrWhiteSpace(url)) return;

            downloadProgressBar.Value = 0;
            downloadProgressBar.Visible = true;
            using (HttpClient client = new HttpClient()) {
                try {
                    using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)) {
                        response.EnsureSuccessStatusCode();

                        using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true)) {
                            var totalSize = response.Content.Headers.ContentLength ?? -1L;
                            var downloaded = 0L;

                            using (var stream = await response.Content.ReadAsStreamAsync()) {
                                var buffer = new byte[8192];
                                int bytesRead;
                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                                    await fileStream.WriteAsync(buffer, 0, bytesRead);

                                    downloaded += bytesRead;

                                    if (totalSize > 0) {
                                        var percentage = (int)((downloaded * 100) / totalSize);
                                        downloadProgressBar.Value = percentage;
                                    }
                                }
                            }
                        }
                    }

                    downloadProgressBar.Visible = false;
                    Console.WriteLine($"File downloaded and saved to: {savePath}");
                } catch (HttpRequestException e) {
                    Console.WriteLine($"Error downloading the file: {e.Message}");
                    MessageBox.Show($"Error downloading the file: {e.Message}", $"{Application.ProductName}: Error");
                    downloadProgressBar.Visible = false;
                }
            }
        }

        public void PauseVideo() {
            if (CurrentPost == null) return;

            string ext = CurrentPost.File.Ext == null ? "png" : CurrentPost.File.Ext;
            if (videoFormats.Contains(ext.ToLower())) {
                viewBrowser.ExecuteScriptAsync("pauseVideo();");
            }
        }

        public static string FormatBytes(long bytes) {
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            int i = 0;
            double dblSByte = bytes;

            if (bytes > 1024) {
                for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024) {
                    dblSByte = bytes / 1024.0;
                }
            }

            return string.Format("{0:0.##} {1}", dblSByte, sizeSuffixes[i]);
        }

        private void previousButton_Click(object sender, EventArgs e) {
            if (CurrentIndex > 0)
                ShowPost(CurrentIndex - 1);
            else
                ShowPost(Posts.Count - 1);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (CurrentIndex + 1 < Posts.Count)
                ShowPost(CurrentIndex + 1);
            else
                ShowPost(0);
        }

        private void backListButton_Click(object sender, EventArgs e) {
            OnBack.Invoke(sender, e);
        }

        private static void OnBacks(object? sender, EventArgs e) {

        }

        private async void downloadButton_Click(object sender, EventArgs e) {
            await Download();
        }

        private void autoDownloadBox_CheckedChanged(object sender, EventArgs e) {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e) {
            var listBox = GetActiveTagBox();
            if (listBox == null) return;

            foreach (var item in listBox.SelectedItems) {
                OnTagSearch?.Invoke(this, new SearchArgs(item.ToString()));
                return;
            }
        }

        public ListBox? activeTagBox;

        private ListBox? GetActiveTagBox() {
            /*if (artistsBox.Focused) return artistsBox;
            if (charactersBox.Focused) return charactersBox;
            if (tagsBox.Focused) return tagsBox;
            return null;*/
            return activeTagBox;
        }

        private void tagsContextMenu_Opening(object sender, CancelEventArgs e) {
            activeTagBox = tagsContextMenu.SourceControl as ListBox;
        }

        private void addToSearchToolStripMenuItem_Click(object sender, EventArgs e) {
            var listBox = GetActiveTagBox();
            if (listBox == null) {
                MessageBox.Show("No tag box selected!", "eBrowser: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var items = new List<string?>();
            foreach (var item in listBox.SelectedItems) {
                items.Add(item.ToString());
            }

            OnTagAdd?.Invoke(this, new TagEventArgs(items));
        }

        private void removeFromSearchToolStripMenuItem_Click(object sender, EventArgs e) {
            var listBox = GetActiveTagBox();
            if (listBox == null) return;

            var items = new List<string?>();
            foreach (var item in listBox.SelectedItems) {
                items.Add(item.ToString());
            }

            OnTagRemove?.Invoke(this, new TagEventArgs(items));
        }

        private void sourcesBox_DoubleClick(object sender, EventArgs e) {
            foreach (var item in sourcesBox.SelectedItems) {
                if (string.IsNullOrWhiteSpace(item.ToString()) || item == null) continue;

                if (MessageBox.Show($"Do you want to open {item.ToString()}?", $"{Application.ProductName}: Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    var str = item.ToString();
                    if (str != null)
                        Process.Start(str);
                }
                return;
            }
        }

        private void poolsBox_DoubleClick(object sender, EventArgs e) {
            Console.WriteLine("Double click");
            foreach (var item in poolsBox.SelectedItems) {
                if (string.IsNullOrWhiteSpace(item.ToString()) || item == null) continue;

                if (MessageBox.Show($"Do you want to open pool {item.ToString()}?", $"{Application.ProductName}: Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    var str = item.ToString()!;
                    OnTagSearch?.Invoke(this, new SearchArgs() {
                        Mode = ListMode.Pools,
                        PoolId = int.Parse(str)
                    });
                }
                return;
            }
        }
    }

    public class TagEventArgs : EventArgs {
        public List<string?> Tags { get; private set; }
        public TagEventArgs(List<string?> tags) {
            Tags = tags;
        }
    }
}