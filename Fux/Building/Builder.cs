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

            const int width = -8;

            var prefix = $"{"parse__",width}";
            Build(prefix, package => new Phase0Parse(Errors, collector, package));
            prefix = $"{prefix}{"declare",width}";
            Build(prefix, package => new Phase1Declare(Errors, collector, package));
            prefix = $"{prefix}{"expose_",width}";
            Build(prefix, package => new Phase2Expose(Errors, collector, package));
            prefix = $"{prefix}{"import_",width}";
            Build(prefix, package => new Phase3Import(Errors, collector, package));
            prefix = $"{prefix}{"resolve",width}";
            Build(prefix, package => new Phase4Resolve(Errors, collector, package));

            Console.Write($"{"",50}");
            Console.Write($"{$"{collector.ParseTime.ElapsedMilliseconds} ms",width}");
            Console.Write($"{$"{collector.DeclareTime.ElapsedMilliseconds} ms",width}");
            Console.Write($"{$"{collector.ExposeTime.ElapsedMilliseconds} ms",width}");
            Console.Write($"{$"{collector.ImportTime.ElapsedMilliseconds} ms",width}");
            Console.Write($"{$"{collector.ResolveTime.ElapsedMilliseconds} ms",width}");
            Console.WriteLine();

            collector.Write();
        }

        private void Build(string prefix, Func<Package, Phase> phase)
        {
            Console.SetCursorPosition(0, 0);
            foreach (var package in loaded)
            {
                var p = phase(package);
                Build(prefix, package, p);
            }
        }

        private void Build(string prefix, Package package, Phase phase)
        {
            Console.Write($"building {phase.Package,-40} {prefix}");

            Console.Write($"[");
            phase.Make();
            Console.WriteLine("]");
        }
    }
}
