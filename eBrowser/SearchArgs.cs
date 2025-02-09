using e621NET.Data.Posts;
using System;

namespace eBrowser
{
    public class SearchArgs : EventArgs
    {
        public ListMode Mode { get; set; } = ListMode.Posts;
        public int PoolId { get; set; }
        public string? Query { get; set; }
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = -1;

        public SearchArgs() { }
        public SearchArgs(string? query, int page = 1, int limit = -1)
        {
            Query = query;
            Page = page;
            Limit = limit;
        }
    }
}
