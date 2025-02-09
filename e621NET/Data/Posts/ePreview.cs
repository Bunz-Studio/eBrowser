using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class ePreview
    {
        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
