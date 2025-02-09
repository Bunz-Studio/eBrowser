using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class eScore
    {
        [JsonPropertyName("up")]
        public int Up { get; set; }

        [JsonPropertyName("down")]
        public int Down { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
