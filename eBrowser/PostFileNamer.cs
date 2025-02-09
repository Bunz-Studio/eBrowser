using e621NET.Data.Posts;
using System;
using System.IO;
using System.Linq;

namespace eBrowser
{
    public static class PostFileNamer
    {
        public static string FileNameFormat = "{artist}-{id}{ext}";
        public static string GetPath(ePost post)
        {
            string? ext = Path.GetExtension(post.File.Url);
            string fileName = FileNameFormat.Replace("{artist}", post.Tags.Artist.FirstOrDefault()).Replace("{id}", post.Id.ToString()).Replace("{ext}", ext);
            return Path.Combine(MainForm.PostsPath.ToPersistPath(), fileName);
        }
    }
}
