using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class ExposedModule
    {
        public ExposedModule(Package package, string name)
        {
            Package = package;
            Name = name;
            FileName = $"src/{Name.Replace('.', '/')}.elm";
            FullFileName = Folder.Combine(Package.Root, FileName);
        }

        public Package Package { get; }
        public string Name { get; }
        public string FileName { get; }
        public string FullFileName { get; }

        public override string ToString() => Name;
    }
}
