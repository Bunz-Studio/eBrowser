using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using e621NET;
using e621NET.Data.Posts;

namespace eBrowser
{
    public class PostsSession
    {

        public int LastPageFromSession { get; set; } = -1;
        [JsonIgnore]
        public string? Path { get; set; }
        [JsonPropertyName("query")]
        public string? Query { get; set; }
        [JsonPropertyName("page_count")]
        public int PageCount { get; set; } = 750;
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 75;
        [JsonPropertyName("pages")]
        public List<SessionPage> Pages { get; set; } = [];

        public PostsSession() {}
        public PostsSession(string path)
        {
            Path = path;            
        }
        
        public PostsSession(string path, ePosts posts)
        {
            Path = path;
            Query = posts.Query;
            Limit = posts.Limit;
            Pages =
            [
                new SessionPage(posts)
            ];
            PageCount = posts.MaxPage;
        }

        public async Task<ePosts?> GetNextPage(int currentPage)
        {
            var nextPage = currentPage + 1;
            var posts = await GetPageAsync(nextPage);
            if (posts != null)
                AddNewSessionPage(posts);
            return posts;
        }
        
        public async Task<ePosts?> GetPreviousPage(int currentPage)
        {
            var previousPage = currentPage - 1;
            var posts = await GetPageAsync(previousPage);
            if (posts != null)
                AddNewSessionPage(posts);
            return posts;
        }

        public async Task<ePosts?> GetPageAsync(int targetPage)
        {
            var session = Pages.Find(val => val.Page == targetPage);
            if (session != null)
            {
                var posts = await session.GetPostsAsync();
                AddNewSessionPage(session);
                return posts;
            }
            var newPosts = await FetchPageAsync(targetPage);
            return newPosts;
        }

        async Task<ePosts?> FetchPageAsync(int targetPage)
        {
            if (Query == null || string.IsNullOrWhiteSpace(Query) || targetPage > PageCount) return new ePosts();
            return await e621Client.Current.GetPostsAsync(Query, targetPage, Limit);
        }
        
        public SessionPage? AddNewPendingPage(int targetPage)
        {
            if (Query == null || string.IsNullOrWhiteSpace(Query) || targetPage > PageCount) return null;
            var session = new SessionPage(targetPage, FetchPageAsync(targetPage));
            Pages.Add(session);
            return session;
        }
        
        public async void LoadFuturePages(int currentPage, int count = 2)
        {
            for (var i = 0; i < count; i++)
            {
                if (Pages.Exists(val => val.Page == currentPage + i)) continue;

                var session = AddNewPendingPage(currentPage + i);
                if (session != null)
                    await session.GetPostsAsync();
            }
        }
        
        public void AddNewSessionPage(SessionPage session)
        {
            if (Pages.Exists(val => val.Page == session.Page)) return;
            Pages.Add(session);
        }
        
        public void AddNewSessionPage(ePosts newPosts)
        {
            if (Pages.Exists(val => val.Page == newPosts.Page)) return;
            
            var page = new SessionPage(newPosts);
            Pages.Add(page);
        }

        public void Save()
        {
            if (Path == null) throw new Exception("Path is null");
            File.WriteAllText(Path, JsonSerializer.Serialize(this));
        }
        
        public static PostsSession? GetSession(string path)
        {
            return !File.Exists(path) ? null : JsonSerializer.Deserialize<PostsSession>(File.ReadAllText(path));
        }

        public class SessionPage
        {
            [JsonPropertyName("status")]
            public SessionStatus Status { get; set; } = SessionStatus.Idle;
            [JsonIgnore]
            public Task<ePosts?>? LoadingTask { get; set; }
            [JsonPropertyName("fetched_at")]
            
            public DateTime FetchedAt { get => Posts?.FetchedAt ?? DateTime.MinValue; }
            [JsonPropertyName("page")]
            public int Page { get; set; } = -1;
            [JsonPropertyName("posts")]
            public ePosts? Posts { get; set; }

            public SessionPage() {}
            public SessionPage(int page) => Page = page;
            public SessionPage(int page, Task<ePosts?> loadingTask)
            {
                Status = SessionStatus.Loading;
                LoadingTask = loadingTask;
                Page = page;
            }
            
            public SessionPage(ePosts posts)
            {
                Status = SessionStatus.Loaded;
                Posts = posts;
                Page = posts.Page;
            }
            
            public async Task<ePosts?> GetPostsAsync()
            {
                if (Posts != null) return Posts;
                if (LoadingTask == null) return null;
                
                var posts = await LoadingTask;
                if (posts == null)
                {
                    Status = SessionStatus.Error;
                    return null;
                }
                
                Page = posts.Page;
                LoadingTask = null;
                Status = SessionStatus.Loaded;
                return posts;
            }

            public enum SessionStatus
            {
                Idle,
                Loading,
                Loaded,
                Error
            }
        }
    }
}
