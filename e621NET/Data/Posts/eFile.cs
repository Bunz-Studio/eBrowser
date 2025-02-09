using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class eFile
    {
        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("ext")]
        public string? Ext { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("md5")]
        public string? Md5 { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
