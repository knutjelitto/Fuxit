using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class ElmModule
    {
        public ElmModule(ElmPackage package, string name)
        {
            Package = package;
            Name = name;
            NiceName = Package.FullName + "/" + Name.Replace('.', '/');
            FileName = $"src/{Name.Replace('.', '/')}.elm";
            FullFileName = Folder.Combine(Package.RootPath, FileName);
        }

        public ElmPackage Package { get; }
        public string Name { get; }

        public string NiceName { get; }
        public string FileName { get; }
        public string FullFileName { get; }

        public override string ToString() => Name;
    }
}
