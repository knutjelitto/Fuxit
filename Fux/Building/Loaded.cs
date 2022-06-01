using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.ElmPackages;
using Semver;

namespace Fux.Building
{
    internal class Loaded
    {
        public readonly SemVersion CurrentElmVersion = new(0, 19, 0);
        private readonly Dictionary<string, Package> index = new();
        private readonly List<Package> packages = new();

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
                Console.WriteLine($"adding package {package.FullName}");
                
                index.Add(package.FullName, package);
                packages.Add(package);
            }

            return package;
        }
    }
}
