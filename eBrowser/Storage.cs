using System;
using System.IO;
using System.Diagnostics;

namespace eBrowser
{
    public static class LocalStorage
    {
        public static string persistentPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\eBrowser\\";
        private static string _persistentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\eBrowser\\";

        public static void PushPersistentPath(string path) => persistentPath = path;
        public static void PopPersistentPath() => persistentPath = _persistentPath;

        public static string ToPersistPathOverride(this string path) =>
            Path.IsPathRooted(path) ? Path.Combine(persistentPath, Path.GetFileName(path)) : Path.Combine(persistentPath, path);
        public static string ToPersistPath(this string path) =>
            Path.IsPathRooted(path) ? path : Path.Combine(persistentPath, path);
        public static string GetPersistPath(params string[] paths)
        {
            string[] combinable = new string[paths.Length + 1];
            combinable[0] = persistentPath;
            for (int i = 0; i < paths.Length; i++)
                combinable[i + 1] = paths[i];
            return Path.Combine(combinable);
        }
        public static string Combine(params string[] paths) => Path.Combine(paths);

        public static void WriteText(string path, string text) => GlobalStorage.WriteText(path.ToPersistPath(), text);
        public static string ReadText(string path) => GlobalStorage.ReadText(path.ToPersistPath());

        public static void WriteBytes(string path, byte[] bytes) =>
            File.WriteAllBytes(path.ToPersistPath(), bytes);
        public static byte[] ReadBytes(string path) =>
            File.ReadAllBytes(path.ToPersistPath());

        public static bool FileExists(string path) =>
            File.Exists(path.ToPersistPath());
        public static bool DirectoryExists(string path) =>
            Directory.Exists(path.ToPersistPath());
        public static void CreateForceDirectory(this string path)
        {
            if (!DirectoryExists(path))
                CreateDirectory(path);
        }
        public static void CreateDirectory(string path)
        {
            path = path.ToPersistPath();
            Directory.CreateDirectory(path);
        }

        public static string GetRelativePath(string filespec) => GetRelativePath(filespec, persistentPath);
        public static string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);

            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                folder += Path.DirectorySeparatorChar;

            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        public static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        public static void OpenDirectoryInExplorer(string directory) => GlobalStorage.OpenDirectoryInExplorer(directory.ToPersistPath());
    }

    public static class GlobalStorage
    {
        public static void WriteText(string path, string text) =>
            File.WriteAllText(path, text);
        public static string ReadText(string path) =>
            File.ReadAllText(path);

        public static void WriteBytes(string path, byte[] bytes) =>
            File.WriteAllBytes(path, bytes);
        public static byte[] ReadBytes(string path) =>
            File.ReadAllBytes(path);
        public static bool FileExists(string path) =>
            File.Exists(path);
        public static bool DirectoryExists(string path) =>
            Directory.Exists(path);

        public static void CreateForceDirectory(this string path)
        {
            if (!DirectoryExists(path))
                CreateDirectory(path);
        }

        public static void CreateDirectory(string path) => Directory.CreateDirectory(path);
        public static string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);

            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                folder += Path.DirectorySeparatorChar;

            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        public static void OpenDirectoryInExplorer(string directory)
        {
            if(!DirectoryExists(directory))
                return;

            var startInfo = new ProcessStartInfo()
            {
                FileName = "explorer",
                Arguments = directory
            };

            Process.Start(startInfo);
        }
    }
}