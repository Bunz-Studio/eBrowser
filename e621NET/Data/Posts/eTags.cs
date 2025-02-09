using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace e621NET.Data.Posts
{
    public class eTags
    {
        [JsonPropertyName("general")]
        public List<string> General { get; set; } = new List<string>();

        [JsonPropertyName("artist")]
        public List<string> Artist { get; set; } = new List<string>();

        [JsonPropertyName("copyright")]
        public List<string> Copyright { get; set; } = new List<string>();

        [JsonPropertyName("character")]
        public List<string> Character { get; set; } = new List<string>();

        [JsonPropertyName("species")]
        public List<string> Species { get; set; } = new List<string>();

        [JsonPropertyName("invalid")]
        public List<string> Invalid { get; set; } = new List<string>();

        [JsonPropertyName("meta")]
        public List<string> Meta { get; set; } = new List<string>();

        [JsonPropertyName("lore")]
        public List<string> Lore { get; set; } = new List<string>();
    }
}
