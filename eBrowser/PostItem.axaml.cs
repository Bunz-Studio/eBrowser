using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class PostItem : UserControl
    {
        public PostItem()
        {
            InitializeComponent();
        }
        
        public async Task SetPost(ePost post)
        {
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
        
        public event EventHandler<EventArgs> OnClicked;
        void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            OnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
    public static class ImageExtensions
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<Bitmap?> LoadImageAsync(Uri uri, string? fileName = null, bool loadIfFileExists = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fileName) && loadIfFileExists && File.Exists(fileName))
                {
                    await using var fileStream = File.OpenRead(fileName);
                    return new Bitmap(fileStream);
                }

                var bytes = await _httpClient.GetByteArrayAsync(uri);

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

