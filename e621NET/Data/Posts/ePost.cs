using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace e621NET.Data.Posts
{
    public class ePost
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("file")]
        public eFile File { get; set; } = new eFile();

        [JsonPropertyName("preview")]
        public ePreview Preview { get; set; } = new ePreview();

        [JsonPropertyName("sample")]
        public eSample Sample { get; set; } = new eSample();

        [JsonPropertyName("score")]
        public eScore Score { get; set; } = new eScore();

        [JsonPropertyName("tags")]
        public eTags Tags { get; set; } = new eTags();

        [JsonPropertyName("locked_tags")]
        public List<string> LockedTags { get; set; } = new List<string>();

        [JsonPropertyName("change_seq")]
        public int ChangeSeq { get; set; }

        [JsonPropertyName("flags")]
        public eFlags Flags { get; set; } = new eFlags();

        [JsonPropertyName("rating")]
        public string? Rating { get; set; }

        [JsonPropertyName("fav_count")]
        public int FavCount { get; set; }

        [JsonPropertyName("sources")]
        public List<string> Sources { get; set; } = new List<string>();

        [JsonPropertyName("pools")]
        public List<int> Pools { get; set; } = new List<int>();

        [JsonPropertyName("relationships")]
        public eRelationships Relationships { get; set; } = new eRelationships();

        [JsonPropertyName("approver_id")]
        public int? ApproverId { get; set; }

        [JsonPropertyName("uploader_id")]
        public int UploaderId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("is_favorited")]
        public bool IsFavorited { get; set; }

        [JsonPropertyName("has_notes")]
        public bool HasNotes { get; set; }

        [JsonPropertyName("duration")]
        public object? Duration { get; set; }

        [JsonIgnore]
        public bool IsPartial { get; set; } = false;
    }
}
