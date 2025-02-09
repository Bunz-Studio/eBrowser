using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class eRelationships
    {
        [JsonPropertyName("parent_id")]
        public object? ParentId { get; set; }

        [JsonPropertyName("has_children")]
        public bool HasChildren { get; set; }

        [JsonPropertyName("has_active_children")]
        public bool HasActiveChildren { get; set; }

        [JsonPropertyName("children")]
        public List<int> Children { get; set; } = new List<int>();
    }
}
