using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class HomePage : UserControl
    {
        public event Action<ePosts> onSearchFinished;
        public HomePage()
        {
            InitializeComponent();
        } 
        
        async void SearchButton_Click(object? sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == null || string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                StatusLabel.IsVisible = true;
                StatusLabel.Content = "Please enter a search query";
                return;
            }
        
            SearchPanel.IsEnabled = false;
            try
            {
                StatusLabel.IsVisible = false;
            
                var posts = await e621Client.Current.GetPostsAsync(SearchBox.Text);
                StatusLabel.IsVisible = true;
                StatusLabel.Content = "Found " + posts.Posts.Count + " posts";
                onSearchFinished?.Invoke(posts);
            }
            catch (Exception ex)
            {
                StatusLabel.IsVisible = true;
                StatusLabel.Content = ex.Message;
            }
            SearchPanel.IsEnabled = true;
        }
        void SearchBox_OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }
    }
}

