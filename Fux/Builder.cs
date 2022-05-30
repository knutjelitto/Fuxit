using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.ElmPackages;
using Fux.Input;

using Semver;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux
{
    internal class Builder
    {
        public readonly SemVersion CurrentElmVersion = new(0, 19, 0);
        private readonly Dictionary<string, Package> index = new();
        private readonly List<Package> dependencies = new();

        private readonly Compiler compiler = new Compiler();

        public void Build(Package package)
        {
            Close(package);

            Console.WriteLine($"building {package}");

            foreach (var dependency in dependencies)
            {
                Console.WriteLine($"  with {dependency}");

                if (dependency.Elm is ElmPak pack)
                {
                    foreach (var file in pack.Modules)
                    {
                        Console.WriteLine($"    {file,-20} ({file.FileName})");

                        var source = new StringSource(file.FileName, file.FullFileName, File.ReadAllText(file.FullFileName));

                        compiler.Compile(source);
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void Close(Package package)
        {
            var elm = package.Elm;

            if (elm is ElmPak elmPackage)
            {
                if (elmPackage.Dependencies.Count > 0)
                {
                    foreach (var dependency in elmPackage.Dependencies)
                    {
                        var found = Catalog.Instance.Find(dependency);

                        Close(found);
                    }
                }
                AddDep(package);
            }
            else if (elm is ElmApp elmApp)
            {
                Console.WriteLine($"building application {package}");

                throw new NotImplementedException();
            }
        }

        private void AddDep(Package package)
        {
            if (!index.ContainsKey(package.Name))
            {
                index.Add(package.Name, package);
                dependencies.Add(package);
            }
        }
    }
}
