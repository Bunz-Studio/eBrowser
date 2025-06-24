using e621NET.Data.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eBrowser
{
    public static class PostFileNamer
    {
        public static string FileNameFormat = "{artist}-{id}{ext}";
        public static List<string> blacklistTags = [
            "conditional_dnp",
            "sound_warning"
        ];
        public static string GetPath(ePost post)
        {
            string? ext = Path.GetExtension(post.File.Url);
            var properArtists = new List<string>(post.Tags.Artist);
            foreach (var tag in blacklistTags) {
                if (properArtists.Contains(tag))
                    properArtists.Remove(tag);
            }
                
            string fileName = FileNameFormat
                .Replace("{artist}", properArtists.FirstOrDefault())
                .Replace("{id}", post.Id.ToString()).Replace("{ext}", ext);
            return Path.Combine("full".ToPersistPath(), fileName);
        }
    }
}