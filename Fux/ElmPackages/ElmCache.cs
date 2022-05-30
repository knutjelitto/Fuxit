namespace Fux.ElmPackages
{
    internal class ElmCache
    {
        static ElmCache()
        {
            Root = Temp.ElmPath(".cache");
        }

        private static string Root { get; }

        public static string FilePath(params string[] paths)
        {
            var path = Path.Combine(Root, Path.Combine(paths)).Replace('\\', '/');
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            return path;
        }
    }
}
