using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class ElmCache
    {
        public static readonly ElmCache Instance = new ElmCache();

        private ElmCache()
        {
            Root = Temp.ElmPath(".cache");
        }

        protected string Root { get; }

        public string FilePath(params string[] paths)
        {
            var path = Path.Combine(Root, Path.Combine(paths)).Replace('\\', '/');
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            return path;
        }
    }
}
