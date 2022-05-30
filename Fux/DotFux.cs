using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux
{
    internal class DotFux
    {
        private string? root = null;

        public static readonly DotFux Instance = new DotFux();

        private DotFux() { }

        public string Root => root ??= GetRoot();

        private static string GetRoot()
        {
            var profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var dotFux = Path.Combine(profile, ".fux").Replace('\\', '/');

            Directory.CreateDirectory(dotFux);

            return dotFux;
        }

    }
}
