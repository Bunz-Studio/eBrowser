using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class ViewPage : UserControl
    {
        public event Action onBackPressed;
        
        public ePosts? Posts;
        public int Index;
        public ePost? CurrentPost;
        
        public string VideoHtml;
        public string ImageHtml;
        
        public string? FileUrl;
        public string FilePath => PostFileNamer.GetPath(CurrentPost!);
        public ViewPage()
        {
            InitializeComponent();
            VideoHtml = ToString(AssetLoader.Open(new Uri("avares://eBrowser/Assets/video-view.html")));
            ImageHtml = ToString(AssetLoader.Open(new Uri("avares://eBrowser/Assets/image-view.html")));
            webView.Navigated += WebViewOnNavigated;
            webView.ShowDeveloperTools();
        }

        async void WebViewOnNavigated(string url, string framename)
        {
            if (CurrentPost == null) return;

            PageLabel.Text = "Loaded " + framename;
            await Task.Delay(1000);
            try
            {
                var ext = CurrentPost.File.Ext ?? "png";
                if (videoFormats.Contains(ext.ToLower()))
                {
                    webView.ExecuteScript("document.getElementById(\"vid\").play();");
                }
                PageLabel.Text = "Playing " + framename;
            } catch (Exception e)
            {
                Debug.WriteLine(e);
                PageLabel.Text = "Failed to play " + framename + ": " + e.Message;
            }

        }

        public static string ToString(Stream stream)
        {
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public void LoadPost(ePosts posts, int index)
        {
            var post = posts.Posts[index];
            Index = index;
            Posts = posts;
            CurrentPost = post;
            
            TagsList.Items.Clear();
            ArtistsList.Items.Clear();
            CharactersList.Items.Clear();
            PoolsList.Items.Clear();

            foreach (var tag in post.Tags.Artist)
                ArtistsList.Items.Add(tag);
            foreach (var tag in post.Tags.Character)
                CharactersList.Items.Add(tag);
            foreach (var tag in post.Tags.Species)
                CharactersList.Items.Add(tag);
            foreach (var tag in post.Tags.Copyright)
                TagsList.Items.Add(tag);
            foreach (var tag in post.Tags.General)
                TagsList.Items.Add(tag);
            foreach (var tag in post.Tags.Invalid)
                TagsList.Items.Add(tag);
            foreach (var tag in post.Tags.Meta)
                TagsList.Items.Add(tag);
            
            foreach (var id in post.Pools)
                PoolsList.Items.Add(id);
            
            var quality = 2;
            if (post.File.Ext != null && videoFormats.Contains(post.File.Ext)) {
                // Low
                if (quality == 0) {
                    if (post.Sample.Alternates!.Quality480 != null) {
                        FileUrl = post.Sample.Alternates.Quality480.Urls[0];
                    } else {
                        FileUrl = post.File.Url ?? string.Empty;
                    }
                }
                // Medium
                else if (quality == 1) {
                    if (post.Sample.Alternates!.Quality720 != null) {
                        FileUrl = post.Sample.Alternates.Quality720.Urls[0];
                    } else if (post.Sample.Alternates!.Quality480 != null) {
                        FileUrl = post.Sample.Alternates.Quality480.Urls[0];
                    } else {
                        FileUrl = post.File.Url ?? string.Empty;
                    }
                }
                // High
                else {
                    FileUrl = post.File.Url ?? string.Empty;
                }
            } else {
                // Low
                if (quality == 0) {
                    FileUrl = post.Preview.Url ?? string.Empty;
                }
                // Medium
                else if (quality == 1) {
                    FileUrl = post.Sample.Url ?? string.Empty;
                }
                // High
                else {
                    FileUrl = post.File.Url ?? string.Empty;
                }
            }
            
            string ext = post.File.Ext == null ? "png" : post.File.Ext;
            if (videoFormats.Contains(ext.ToLower())) {
                if (File.Exists(FilePath))
                    OpenHTMLStringToFile(
                        VideoHtml
                            .Replace("{VIDEO_URL}", "file:///" + FilePath.Replace("\\", "/"))
                            .Replace("{ADDITIONAL_PARAM}", "")
                    );
                else
                    OpenHTMLStringToFile(
                        VideoHtml
                            .Replace("{VIDEO_URL}", FileUrl)
                            .Replace("{ADDITIONAL_PARAM}", ""));
            } else {
                if (File.Exists(FilePath))
                    OpenHTMLStringToFile(ImageHtml.Replace("{IMAGE_URL}", "file:///" + FilePath.Replace("\\", "/")));
                else
                    OpenHTMLStringToFile(ImageHtml.Replace("{IMAGE_URL}", FileUrl));
            }
        }
        
        List<string> videoFormats = new List<string>() {
            "mp4",
            "webm",
            "m4a"
        };
        
        public void OpenHTMLStringToFile(string text) {
            File.WriteAllText("temporary.html".ToPersistPath(), text);
            webView.Address = "file://" + "temporary.html".ToPersistPath();
        }
        
        void BackButton_OnClick(object? sender, RoutedEventArgs e)
        {
            onBackPressed?.Invoke();
        }
        
        void PreviousPageButton_OnClick(object? sender, RoutedEventArgs e)
        {
            Index--;
            if (Index < 0)
            {
                Index = 0;
                return;
            }

            LoadPost(Posts!, Index);
        }
    }
}

