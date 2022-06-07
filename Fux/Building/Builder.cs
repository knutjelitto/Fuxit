using Fux.Building.Phases;
using Fux.ElmPackages;
using Fux.Input;
using Fux.Tools;

using Semver;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux.Building
{
    internal class Builder
    {
        public readonly SemVersion CurrentElmVersion = new(0, 19, 0);

        private readonly ErrorBag errors;
        private readonly Loaded loaded;

        public Builder()
        {
            errors = new ErrorBag();
            loaded = new Loaded();
        }

        public ErrorBag Errors => errors;

        public void Load(ElmPackage elmPackage)
        {
            var _ = loaded.Register(elmPackage);
        }

        public void Build()
        {
            var collector = new Collector();

            Build(package => new Parse(Errors, collector, package));
            Build(package => new Declare(Errors, collector, package));

            collector.Write();
        }

        private void Build(Func<Package, Phase> phase)
        {
            foreach (var package in loaded)
            {
                Build(package, phase(package));
            }
        }

        private void Build(Package package, Phase phase)
        {
            Console.Write($"building {phase.Package,-40}");

            Console.Write($"{phase.Name,-10} [");
            phase.Make();
            Console.WriteLine("]");
        }
    }
}
