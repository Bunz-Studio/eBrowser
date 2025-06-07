using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using e621NET.Data.Posts;

namespace eBrowser
{
    public partial class PostsView : UserControl
    {
        public int Page { get; set; }
        public event EventHandler<PostClickedArgs>? PostClicked;
        public ePosts Posts { get; set; }
        public List<PostItem> Items { get; set; } = [];
        public int Sorting { get; set; }
        
        public PostsView()
        {
            InitializeComponent();
            Posts = new ePosts();
            Sorting = 0;
        }

        public PostsView(ePosts posts, int sorting)
        {
            InitializeComponent();
            Posts = posts;
            Sorting = sorting;
        }

        public async Task LoadAll()
        {
            PostList.Children.Clear();
            Items.Clear();
            
            switch (Sorting)
            {
                case 0:
                    Posts.Posts.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));
                    break;
                case 1:
                    Posts.Posts.Sort((a, b) => b.FavCount.CompareTo(a.FavCount));
                    break;
                case 2:
                    Posts.Posts.Sort((a, b) => b.Score.Total.CompareTo(a.Score.Total));
                    break;
            }
            
            var loadTasks = new List<Task>();
            int index = 0;
            foreach (var post in Posts.Posts)
            {
                var item = new PostItem();
                item.Index = index;
                item.Posts = Posts;
                PostList.Children.Add(item);
                loadTasks.Add(item.SetPost(post));
                item.OnClicked += (_, _) => 
                    PostClicked?.Invoke(this, new PostClickedArgs(Posts, PostList.Children.IndexOf(item)));
                Items.Add(item);
                index++;
            }

            await Task.WhenAll(loadTasks);
        }
        
        public void UpdateSorting(int index)
        {
            if (index == Sorting) return;
            Sorting = index;
            switch (index)
            {
                case 0:
                    Posts.Posts.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));
                    Items.Sort((a, b) => b.Post.CreatedAt.CompareTo(a.Post.CreatedAt));
                    break;
                case 1:
                    Posts.Posts.Sort((a, b) => b.FavCount.CompareTo(a.FavCount));
                    Items.Sort((a, b) => b.Post.FavCount.CompareTo(a.Post.FavCount));
                    break;
                case 2:
                    Posts.Posts.Sort((a, b) => b.Score.Total.CompareTo(a.Score.Total));
                    Items.Sort((a, b) => b.Post.Score.Total.CompareTo(a.Post.Score.Total));
                    break;
            }
            
            PostList.Children.Clear();
            for (var i = 0; i < Items.Count; i++)
            {
                PostList.Children.Add(Items[i]);
                Items[i].Index = i;
            }
        }
    }
}

