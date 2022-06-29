using System.Collections;

using Fux.ElmPackages;

using Semver;

namespace Fux.Building
{
    public sealed class Loaded : IEnumerable<Package>
    {
        public readonly SemVersion CurrentElmVersion = new(0, 19, 0);
        private readonly Dictionary<string, Package> index = new();
        private readonly List<Package> packages = new();

        public IEnumerator<Package> GetEnumerator() => packages.GetEnumerator();

        public Package Register(ElmPackage elm)
        {
            if (index.TryGetValue(elm.FullName, out var package))
            {
                return package;
            }

            var pak = elm.Elm as ElmPak;

            if (pak != null)
            {
                package = new Package(elm);

                foreach (var dependency in pak.Dependencies)
                {
                    var found = Catalog.Instance.Find(dependency);

                    package.AddDependency(Register(found));
                }

                foreach (var exposed in pak.ExposedModules)
                {
                    package.AddExposed(new Module(package, exposed.Name));
                }

                var root = Folder.Combine(package.RootPath, "src");

                foreach (var file in IO.Directory.GetFiles(root, "*.elm", IO.SearchOption.AllDirectories).Select(f => f.Replace('\\', '/')))
                {
                    if (file.Contains("/src/Examples/") || file.Contains("/src/DEPRECATED/"))
                    {
                        continue;
                    }

                    var name = file[(root.Name.Length + 1)..^4].Replace('/', '.');

                    var module = package.TryGetExposed(name);

                    if (module != null)
                    {
                        continue;
                    }
                    else
                    {
                        package.AddIntern(new Module(package, name));
                        Assert(true);
                    }
                }

                foreach (var file in IO.Directory.GetFiles(root, "*.js", IO.SearchOption.AllDirectories))
                {
                    var name = file[(root.Name.Length + 1)..^3].Replace('\\', '.');

                    var module = package.TryGetExposed(name);

                    if (module != null)
                    {
                        continue;
                    }
                    else
                    {
                        package.AddIntern(new Module(package, name, js: true));
                        Assert(true);
                    }
                }

                return Add(package);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private Package Add(Package package)
        {
            if (!index.ContainsKey(package.FullName))
            {
                //Console.WriteLine($"adding package {package.FullName}");

                index.Add(package.FullName, package);
                packages.Add(package);
            }

            return package;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
