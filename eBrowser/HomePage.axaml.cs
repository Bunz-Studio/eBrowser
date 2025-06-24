using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class HomePage : UserControl
    {
        public event Action<ePosts>? onSearchFinished;
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
                if (posts != null)
                {
                    StatusLabel.Content = "Found " + posts.Posts.Count + " posts";
                    onSearchFinished?.Invoke(posts);
                }
                else
                {
                    StatusLabel.Content = "No posts found";
                }
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

