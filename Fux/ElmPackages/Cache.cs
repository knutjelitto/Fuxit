﻿namespace Fux.ElmPackages
{
    public sealed class Cache
    {
        static Cache()
        {
            Root = Temp.ElmPath(".cache");
        }

        private static string Root { get; }

        public static string FilePath(params string[] paths)
        {
            var path = IO.Path.Combine(Root, IO.Path.Combine(paths)).Replace('\\', '/');
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path)!);
            return path;
        }
    }
}
