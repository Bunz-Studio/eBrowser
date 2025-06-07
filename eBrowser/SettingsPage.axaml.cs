using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using e621NET;

namespace eBrowser
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public void RefreshSettings()
        {
            UsernameBox.Text = ListPage.Settings.Username;
            ApiKeyBox.Text = ListPage.Settings.APIKey;
            
            HideToTrayBox.IsChecked = ListPage.Settings.HideToTray;
            AutoplayVideosBox.IsChecked = ListPage.Settings.AutoplayVideos;
            AutomuteVideosBox.IsChecked = ListPage.Settings.AutomuteVideos;
            AutoDownloadImagesBox.IsChecked = ListPage.Settings.AutoDownloadImages;
            AutoDownloadVideosBox.IsChecked = ListPage.Settings.AutoDownloadVideos;
        }

        void SaveButton_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.Username = UsernameBox.Text;
            ListPage.Settings.APIKey = ApiKeyBox.Text;
            ListPage.Instance.SaveSettings();
            
            if (ListPage.Settings.Username == null || string.IsNullOrWhiteSpace(ListPage.Settings.Username) || ListPage.Settings.APIKey == null || string.IsNullOrWhiteSpace(ListPage.Settings.APIKey))
                return;
            
            e621Client.Current.AddCredentials(new e621APICredentials(ListPage.Settings.Username, ListPage.Settings.APIKey));
        }
        
        void BackButton_OnClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.Instance.BackFromSettings();
        }
        
        void HideToTrayBox_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.HideToTray = HideToTrayBox.IsChecked.HasValue && HideToTrayBox.IsChecked.Value;
            ListPage.Instance.SaveSettings();
        }
        
        void AutoplayVideosBox_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.AutoplayVideos = AutoplayVideosBox.IsChecked.HasValue && AutoplayVideosBox.IsChecked.Value;
            ListPage.Instance.SaveSettings();
        }
        
        void AutomuteVideosBox_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.AutomuteVideos = AutomuteVideosBox.IsChecked.HasValue && AutomuteVideosBox.IsChecked.Value;
            ListPage.Instance.SaveSettings();
        }
        
        void AutoDownloadImagesBox_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.AutoDownloadImages = AutoDownloadImagesBox.IsChecked.HasValue && AutoDownloadImagesBox.IsChecked.Value;
            ListPage.Instance.SaveSettings();
        }
        
        void AutoDownloadVideosBox_OnClick(object? sender, RoutedEventArgs e)
        {
            ListPage.Settings.AutoDownloadVideos = AutoDownloadVideosBox.IsChecked.HasValue && AutoDownloadVideosBox.IsChecked.Value;
            ListPage.Instance.SaveSettings();
        }
    }
}

