using System.Reflection;

namespace Fux.Tools
{
    public static class Temp
    {
        private static string GetPath(string which, params string[] paths)
        {
            var path = IO.Path.Combine(Environment.CurrentDirectory, $"../../../../{which}");
            Assert(IO.Path.GetFileName(IO.Path.GetDirectoryName(new IO.DirectoryInfo(path).FullName)) == "Fux");
            IO.Directory.CreateDirectory(path);
            var outPath = IO.Path.GetFullPath(IO.Path.Combine(path, IO.Path.Combine(paths)));
            if (!IO.Directory.Exists(outPath))
            {
                _ = IO.Directory.CreateDirectory(outPath);
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

        public static string FuxPath(string paths)
        {
#if true
            return GetPath("Fux/Fux", paths);
#else
            var path = IO.Path.Combine(IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, paths).Replace('\\', '/');

            return path;
#endif
        }
    }
}
