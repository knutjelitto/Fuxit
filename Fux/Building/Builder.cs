using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.ElmPackages;
using Fux.Input;

using Semver;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux.Building
{
    internal class Builder
    {
        public readonly SemVersion CurrentElmVersion = new(0, 19, 0);
        private readonly Dictionary<string, ElmPackage> index = new();
        private readonly List<ElmPackage> dependencies = new();

        private readonly ErrorBag errors;
        private readonly Loaded loaded;

        public Builder()
        {
            errors = new ErrorBag();
            Compiler = new Compiler(errors);
            loaded = new Loaded();
        }

        public Compiler Compiler { get; }

        public void Build(ElmPackage elmPackage)
        {
            var package = loaded.Register(elmPackage);

            Console.WriteLine($"building {package}");

            foreach (var dependency in package.Dependencies)
            {
                build(dependency);
            }

            build(package);

            void build(Package package)
            {
                Console.WriteLine($"  with {package}");

                Compiler.Compile(package);
            }
        }

        public ErrorBag Errors => errors;
    }
}
