using Fux.ElmPackages;

namespace Fux.Building
{
    internal class Package
    {
        private readonly ElmPackage elm;
        private readonly List<Package> dependencies = new();
        private readonly List<Module> exposed = new();
        private readonly Dictionary<string, Module> exposedIndex = new();
        private readonly List<Module> intern = new();
        private readonly Dictionary<string, Module> internIndex = new();

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
        public IEnumerable<Module> Modules => exposed.Concat(intern);
        public bool IsCore => Name == "elm/core";

        public void AddDependency(Package dependency)
        {
            dependencies.Add(dependency);
        }

        public void AddExposed(Module module)
        {
            exposed.Add(module);
            exposedIndex.Add(module.Name, module);
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

        private Module? FindIntern(string name)
        {
            if (exposedIndex.TryGetValue(name, out var module))
            {
                return module;
            }

            if (internIndex.TryGetValue(name, out module))
            {
                return module;
            }

            var partPath = $"src/{name.Replace('.', '/')}";

            var fullPath = Folder.Combine(RootPath, partPath) + ".elm";

            if (File.Exists(fullPath))
            {
                module = new Module(this, name);
                intern.Add(module);
                internIndex.Add(module.Name, module);
            }
            else
            {
                fullPath = Folder.Combine(RootPath, partPath) + ".js";
                if (File.Exists(fullPath))
                {
                    module = new Module(this, name, true);
                    intern.Add(module);
                    internIndex.Add(module.Name, module);
                }
            }

            return module;
        }

        private Module? FindExtern(string importPath)
        {
            if (exposedIndex.TryGetValue(importPath, out var module))
            {
                return module;
            }
            return null;
        }

        public override string ToString() => FullName;
    }
}
