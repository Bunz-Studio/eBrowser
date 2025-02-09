using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using e621NET;
using e621NET.Data.Posts;

namespace eBrowser.Panels
{
    public partial class PostPanel : UserControl
    {
        public Themer Themer { get; set; } = new Themer();
        public ePost Post { get; set; }
        public string PreviewImagePath =>
            Path.Combine("previews".ToPersistPath(), $"{Post.Id}{Path.GetExtension(Post.Preview.Url)}");
        public string PreviewUrl;

        public PostPanel(ePost post)
        {
            this.Post = post;
            InitializeComponent();

            votesLabel.Text = post.Score.Total == 0 ? "↕0" : post.Score.Total > 0 ? $"↑{post.Score.Total}" : $"↓{post.Score.Total}";
            votesLabel.ForeColor = post.Score.Total == 0 ? Themer.Scheme.Foreground : post.Score.Total > 0 ? Themer.Scheme.Success : Themer.Scheme.Failed;

            favoritesLabel.Text = $"♥{post.FavCount}";

            if (post.Rating != null)
            {
                ratingLabel.Text = $"{post.Rating.ToUpper()}";
                ratingLabel.ForeColor =
                    post.Rating.StartsWith("e") ? Themer.Scheme.Explicit :
                    post.Rating.StartsWith("q") ? Themer.Scheme.Questionable : Themer.Scheme.Safe;
            }
            else
            {
                ratingLabel.Text = "?";
            }

            PreviewUrl = SettingsPanel.Main.ThumbnailQuality == 0 ? (post.Preview.Url ?? string.Empty) : (post.Sample.Url ?? string.Empty);

            if (File.Exists(PreviewImagePath))
            {
                previewPictureBox.LoadAsync(PreviewImagePath);
                loadingBar.Visible = true;
            }
            else if (!string.IsNullOrWhiteSpace(PreviewUrl))
            {
                previewPictureBox.LoadAsync(PreviewUrl);
                loadingBar.Visible = true;
            }
        }

        private void previewPictureBox_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingBar.Value = e.ProgressPercentage;
        }

        private void previewPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            GlobalStorage.CreateForceDirectory(Path.GetDirectoryName(PreviewImagePath));
            if (!File.Exists(PreviewImagePath))
            {
                if (previewPictureBox.Image != previewPictureBox.ErrorImage)
                {
                    previewPictureBox.Image.Save(PreviewImagePath);
                }
            }

            if (!SettingsPanel.Main.PlayGIFsOnList)
            {
                var image = previewPictureBox.Image;
                foreach (var guid in image.FrameDimensionsList)
                {
                    if (image.GetFrameCount(new FrameDimension(guid)) > 1)
                    {
                        _ = image.SelectActiveFrame(new FrameDimension(guid), 0);
                        previewPictureBox.Image = new Bitmap(image);
                    }
                }
            }
            loadingBar.Visible = false;
        }

        private void previewPictureBox_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
