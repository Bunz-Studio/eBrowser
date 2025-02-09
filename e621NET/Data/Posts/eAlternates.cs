using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace e621NET.Data.Posts
{
    public class eAlternates
    {
        [JsonPropertyName("720p")]
        public eQuality? Quality720 { get; set; }
        [JsonPropertyName("480p")]
        public eQuality? Quality480 { get; set; }
        [JsonPropertyName("original")]
        public eQuality? Original { get; set; }
    }

    public class eQuality
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("urls")]
        public List<string> Urls { get; set; } = new List<string>();
    }
}