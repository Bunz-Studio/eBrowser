using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class ListPage : UserControl
    {
        public event EventHandler<PostClickedArgs> PostClicked;
        
        public ListPage()
        {
            InitializeComponent();
        }
        
        public async void SetPosts(ePosts posts)
        {
            PostList.Children.Clear();
            File.WriteAllText("posts.json".ToPersistPath(), JsonSerializer.Serialize(posts));

            var loadTasks = new List<Task>();
            foreach (var post in posts.Posts)
            {
                var item = new PostItem();
                PostList.Children.Add(item);
                loadTasks.Add(item.SetPost(post)); // run in parallel
                item.OnClicked += (s, e) => 
                    PostClicked?.Invoke(this, new PostClickedArgs(posts, PostList.Children.IndexOf(item)));
            }

            await Task.WhenAll(loadTasks); // await all image loads
            SearchBox.Text = posts.Query;
        }

        
        async void SearchButton_OnClick(object? sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == null || string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                // StatusLabel.IsVisible = true;
                // StatusLabel.Content = "Please enter a search query";
                return;
            }
            
            IsEnabled = false;
            try
            {
                var posts = await e621Client.Current.GetPostsAsync(SearchBox.Text);
                SetPosts(posts);
            }
            catch (Exception ex)
            {
                // StatusLabel.Content = ex.Message;
            }
            IsEnabled = true;
        }
        
        void SearchBox_OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_OnClick(sender, e);
            }
        }
    }

    public class PostClickedArgs(ePosts posts, int index) : EventArgs
    {
        public ePosts Posts { get; set; } = posts;
        public int Index { get; set; } = index;
    }
}

