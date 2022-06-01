using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.ElmPackages;

namespace Fux.Building
{
    internal class Package
    {
        private readonly ElmPackage elm;
        private readonly List<Package> dependencies = new();
        private readonly List<Module> exposed = new();
        private readonly List<Module> intern = new();

        public Package(ElmPackage elm)
        {
            this.elm = elm;
        }

        public string Name => elm.Name;
        public string FullName => elm.FullName;
        public string RootPath => Temp.ElmPath(FullName);


        public IReadOnlyList<Package> Dependencies => dependencies;
        public IReadOnlyList<Module> Exposed => exposed;
        public IReadOnlyList<Module> Intern => intern;

        public void AddDependency(Package dependency)
        {
            dependencies.Add(dependency);
        }

        public void AddExposed(Module module)
        {
            exposed.Add(module);
        }

        public Module? FindImport(string importPath)
        {
            var module = FindIntern(importPath);

            if (module == null)
            {
                foreach (var dependency in dependencies)
                {
                    module = dependency.FindExtern(importPath);

                    if (module != null)
                    {
                        break;
                    }
                }

                if (module == null)
                {
                    foreach (var dependency in dependencies)
                    {
                        module = dependency.FindIntern(importPath);

                        if (module != null)
                        {
                            break;
                        }
                    }
                }
            }

            return module;
        }

        private Module? FindIntern(string importPath)
        {
            Module? module = null;

            var name = importPath.Replace('.', '/');

            module = exposed.FirstOrDefault(m => m.Name == name);

            if (module == null)
            {
                module = intern.FirstOrDefault(m => m.Name == name);

                if (module == null)
                {
                    var partPath = $"src/{name}";

                    var fullPath = Folder.Combine(RootPath, partPath) + ".elm";

                    if (File.Exists(fullPath))
                    {
                        module = new Module(this, name);
                        intern.Add(module);
                    }
                    else
                    {
                        fullPath = Folder.Combine(RootPath, partPath) + ".js";
                        if (File.Exists(fullPath))
                        {
                            module = new Module(this, name, true);
                            intern.Add(module);
                        }
                    }
                }
            }

            return module;
        }
        
        private Module? FindExtern(string importPath)
        {
            var name = importPath.Replace('.', '/');

            var module = exposed.FirstOrDefault(m => m.Name == name);

            return module;
        }

        public override string ToString() => FullName;
    }
}
