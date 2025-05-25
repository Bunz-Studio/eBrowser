using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class PostItem : UserControl
    {
        public ePosts Posts { get; set; } = new();
        public int Index { get; set; } = -1;
        public ePost Post { get; set; } = new();
        public event EventHandler<EventArgs>? OnClicked;
        
        public PostItem()
        {
            InitializeComponent();
        }
        
        public async Task SetPost(ePost post)
        {
            Post = post;
            try
            {
                var favorites = post.FavCount;
                var score = post.Score.Total;
            
                var symbol = favorites > 0 ? "↑" : (favorites < 0 ? "↓" : "!");
                PostCondition.Content = $"{symbol} {score} ❤️ {favorites}";
            
                var imageLink = post.Preview.Url;
                if (imageLink != null)
                    PostImage.Source = await ImageExtensions.LoadImageAsync
                    (new Uri(imageLink), 
                        LocalStorage.GetPersistPath("previews", $"{post.Id.ToString()}.{Path.GetExtension(post.Preview.Url)}"), 
                        true);
            }
            catch (Exception e)
            {
                // TODO handle exception
                Debug.WriteLine(e);
                PostCondition.Content = "Error";
            }
        }
        
        void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            OnClicked?.Invoke(this, EventArgs.Empty);
            ListPage.Instance.ItemClicked(new PostClickedArgs(Posts, Index));
        }
        
        void InputElement_OnKeyDown(object? sender, KeyEventArgs e)
        {
            MainWindow.Instance.OnKeyDownHere(sender, e);
        }
    }
    public static class ImageExtensions
    {
        public static async Task<Bitmap?> LoadImageAsync(Uri uri, string? fileName = null, bool loadIfFileExists = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fileName) && loadIfFileExists && File.Exists(fileName))
                {
                    await using var fileStream = File.OpenRead(fileName);
                    return new Bitmap(fileStream);
                }

                var bytes = await e621Client.HttpClient.GetByteArrayAsync(uri);

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName)!);
                    await File.WriteAllBytesAsync(fileName, bytes);
                }

                using var memoryStream = new MemoryStream(bytes);
                return new Bitmap(memoryStream);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to load image: " + uri.AbsoluteUri);
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}

