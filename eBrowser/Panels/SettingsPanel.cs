using e621NET;

using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace eBrowser.Panels
{
    public partial class SettingsPanel : UserControl
    {
        public static SettingsPanel Instance = new SettingsPanel();
        public static Settings Main = new Settings();

        private static bool isAppending = false;

        public SettingsPanel()
        {
            Instance = this;
            InitializeComponent();
        }

        public static void LoadSettings()
        {
            if (LocalStorage.FileExists(MainForm.SettingsPath))
            {
                var result = JsonSerializer.Deserialize<Settings>(LocalStorage.ReadText(MainForm.SettingsPath));
                Main = result ?? Main;

                UpdateAuthorizationOnComplete();

                isAppending = true;

                Instance.usernameBox.Text = Main.Username;
                Instance.apiKeyBox.Text = Main.ApiKey;

                Instance.postQualityBox.SelectedIndex = Main.PostQuality;
                Instance.thumbnailQualityBox.SelectedIndex = Main.ThumbnailQuality;

                Instance.postsPathBox.Text = Main.PostsPath;
                MainForm.PostsPath = Main.PostsPath ?? MainForm.PostsPath;

                e621Client.Current.Host = Main.UseE926 ? "https://e926.net/" : "https://e621.net/";

                isAppending = false;
            }
            else
            {
                SaveSettings();
            }

            Instance.hostBox.SelectedIndex = Main.UseE926 ? 1 : 0;
            e621Client.Current.Host = Main.UseE926 ? "https://e926.net/" : "https://e621.net/";
            Instance.customPostsPathBox.Checked = !string.IsNullOrWhiteSpace(Main.PostsPath);
            Instance.fileFormatBox.Text = Main.FileFormat;
            Instance.postsPathBox.BackColor = Instance.customPostsPathBox.Checked ? Color.White : Color.Gray;

            Instance.adVideoBox.Checked = Main.AutoDownloadVideo;
            Instance.adImageBox.Checked = Main.AutoDownloadImage;
            Instance.muteBox.Checked = Main.Mute;
            Instance.autoplayVideosBox.Checked = Main.AutoplayVideos;
            Instance.gifsOnListsBox.Checked = Main.PlayGIFsOnList;
            Instance.pauseHideBox.Checked = Main.PauseOnHide;
        }

        public static void SaveSettings()
        {
            LocalStorage.CreateForceDirectory(Path.GetDirectoryName(MainForm.SettingsPath));
            LocalStorage.WriteText(MainForm.SettingsPath, JsonSerializer.Serialize(Main, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.Username = usernameBox.Text;
            UpdateAuthorizationOnComplete();
            SaveSettings();
        }

        private void apiKeyBox_TextChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.ApiKey = apiKeyBox.Text;
            UpdateAuthorizationOnComplete();
            SaveSettings();
        }

        private static void UpdateAuthorizationOnComplete()
        {
            if (isAppending) return;

            if (!string.IsNullOrWhiteSpace(Main.Username) && !string.IsNullOrWhiteSpace(Main.ApiKey))
            {
                if (Main.Username != null && Main.ApiKey != null)
                    e621Client.Current.AddCredentials(new e621APICredentials(Main.Username, Main.ApiKey));
            }
        }

        private void customPostsPathBox_CheckedChanged(object sender, EventArgs e)
        {
            postsPathBox.BackColor = customPostsPathBox.Checked ? Color.White : Color.Gray;
            if (isAppending) return;

            postsPathBox.ReadOnly = !customPostsPathBox.Checked;
            if (!customPostsPathBox.Checked)
                Main.PostsPath = null;
            else if (!string.IsNullOrWhiteSpace(postsPathBox.Text))
                Main.PostsPath = postsPathBox.Text;
            SaveSettings();
        }

        private void postsPathBox_TextChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            if (customPostsPathBox.Checked)
            {
                Main.PostsPath = postsPathBox.Text;
                MainForm.PostsPath = Main.PostsPath;
                SaveSettings();
            }
        }

        private void adImageBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.AutoDownloadImage = adImageBox.Checked;
            SaveSettings();
        }

        private void adVideoBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.AutoDownloadVideo = adVideoBox.Checked;
            SaveSettings();
        }

        private void openPostsFolderBtn_Click(object sender, EventArgs e)
        {
            LocalStorage.OpenDirectoryInExplorer(MainForm.PostsPath);
        }

        private void hostBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.UseE926 = hostBox.SelectedIndex != 0;
            e621Client.Current.Host = Main.UseE926 ? "https://e926.net/" : "https://e621.net/";
            SaveSettings();
        }

        private void fileFormatBox_TextChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.FileFormat = fileFormatBox.Text;
            PostFileNamer.FileNameFormat = Main.FileFormat;
            SaveSettings();
        }

        private void thumbnailQualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.ThumbnailQuality = thumbnailQualityBox.SelectedIndex;
            SaveSettings();
        }

        private void postQualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.PostQuality = postQualityBox.SelectedIndex;
            SaveSettings();
        }

        private void autoplayVideosBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.AutoplayVideos = autoplayVideosBox.Checked;
            SaveSettings();
        }

        private void muteBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.Mute = muteBox.Checked;
            SaveSettings();
        }

        private void gifsOnListsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.PlayGIFsOnList = gifsOnListsBox.Checked;
            SaveSettings();
        }

        private void pauseHideBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAppending) return;

            Main.PauseOnHide = pauseHideBox.Checked;
            SaveSettings();
        }
    }

    public class Settings
    {
        // Authorization
        public string? Username { get; set; }
        public string? ApiKey { get; set; }

        // Files
        public string? PostsPath { get; set; }
        public string FileFormat { get; set; } = "{artist}-{id}{ext}";

        // Quality
        public int ThumbnailQuality { get; set; } = 1;
        public int PostQuality { get; set; } = 2;

        // Auto Download
        public bool AutoDownloadImage { get; set; } = true;
        public bool AutoDownloadVideo { get; set; }

        // Hosts
        public bool UseE926 { get; set; }

        // Posts
        public bool AutoplayVideos { get; set; } = true;
        public bool Mute { get; set; }
        public bool PlayGIFsOnList { get; set; } = true;
        public bool PauseOnHide { get; set; } = true;
    }
}
