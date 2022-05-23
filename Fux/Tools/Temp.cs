using System;
using System.IO;

namespace Fux.Tools
{
    public static class Temp
    {
        private static string temp = string.Empty;

        public static string TempPath(string top)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "../../../../Temp");
            Assert(Directory.Exists(path));
            var outPath = Path.GetFullPath(Path.Combine(path, top));
            if (!Directory.Exists(outPath))
            {
                _ = Directory.CreateDirectory(outPath);
            }
            return outPath;
        }
    }
}
