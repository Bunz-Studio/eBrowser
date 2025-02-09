using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class eSample
    {
        [JsonPropertyName("has")]
        public bool Has { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("alternates")]
        public eAlternates? Alternates { get; set; }
    }
}
