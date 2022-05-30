using System;
using System.IO;

namespace Fux.Tools
{
    public static class Temp
    {
        private static string GetPath(string which, params string[] paths)
        {
            var path = Path.Combine(Environment.CurrentDirectory, $"../../../../{which}");
            Assert(Path.GetFileName(Path.GetDirectoryName(new DirectoryInfo(path).FullName)) == "Fux");
            Directory.CreateDirectory(path);
            var outPath = Path.GetFullPath(Path.Combine(path, Path.Combine(paths)));
            if (!Directory.Exists(outPath))
            {
                _ = Directory.CreateDirectory(outPath);
            }
            return outPath.Replace('\\', '/');
        }

        public static string TempPath(string top)
        {
            return GetPath("Temp", top);
        }

        public static string ElmPath(params string[] paths)
        {
            return GetPath("Elm", paths);
        }
    }
}
