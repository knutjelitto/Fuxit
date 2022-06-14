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
            const int width = -8;

            Terminal.ClearHome();

            var prefix = $"{"parse__",width}";
            Build(prefix, package => new Phase0Parse(Errors, package));
            prefix = $"{prefix}{"declare",width}";
            Build(prefix, package => new Phase1Declare(Errors, package));
            prefix = $"{prefix}{"expose_",width}";
            Build(prefix, package => new Phase2Expose(Errors, package));
            prefix = $"{prefix}{"import_",width}";
            Build(prefix, package => new Phase3Import(Errors, package));
            prefix = $"{prefix}{"resolve",width}";
            Build(prefix, package => new Phase4Resolve(Errors, package));

            Terminal.Write($"{"",50}");
            Terminal.Write($"{$"{Collector.Instance.ParseTime.ElapsedMilliseconds} ms",width}");
            Terminal.Write($"{$"{Collector.Instance.DeclareTime.ElapsedMilliseconds} ms",width}");
            Terminal.Write($"{$"{Collector.Instance.ExposeTime.ElapsedMilliseconds} ms",width}");
            Terminal.Write($"{$"{Collector.Instance.ImportTime.ElapsedMilliseconds} ms",width}");
            Terminal.Write($"{$"{Collector.Instance.ResolveTime.ElapsedMilliseconds} ms",width}");
            Terminal.WriteLine();

            Collector.Instance.Write();
        }

        private void Build(string prefix, Func<Package, Phase> phase)
        {
            Terminal.GoHome();
            foreach (var package in loaded)
            {
                var p = phase(package);
                Build(prefix, package, p);
            }
        }

        private void Build(string prefix, Package package, Phase phase)
        {
            Terminal.ClearToEol();
            Terminal.Write($"building {phase.Package,-40} {prefix}");

            Terminal.Write($"[");
            phase.Make();
            Terminal.WriteLine("]");
        }
    }
}
