using e621NET.Data.Posts;
using System;

namespace eBrowser
{
    public class PostItemArgs : EventArgs
    {
        public int Index { get; set; } = -1;
        public ePost? Post { get; set; }

        public PostItemArgs() { }
        public PostItemArgs(int index, ePost? post)
        {
            Index = index;
            Post = post;
        }
    }
}
