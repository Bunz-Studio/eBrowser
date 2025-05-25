using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class ePosts
    {
        [JsonPropertyName("mode")]
        public ListMode Mode { get; set; } = ListMode.Posts;
        [JsonPropertyName("poolId")]
        public int PoolId { get; set; }
        [JsonPropertyName("posts")]
        public List<ePost> Posts { get; set; } = new List<ePost>();
        [JsonPropertyName("page")]
        public int Page { get; set; } = 1;

        [JsonPropertyName("fetchedAt")]
        public DateTime FetchedAt { get; set; } = DateTime.Now;
        [JsonPropertyName("query")]
        public string Query { get; set; } = "";
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = -1;
        [JsonPropertyName("maxPage")]
        public int MaxPage { get; set; } = 750;
    }

    public enum ListMode
    {
        Posts,
        Pools
    }
}
