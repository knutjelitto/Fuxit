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

        public IEnumerable<Package> Packages => loaded;
        public IEnumerable<Module> Modules => loaded.SelectMany(p => p.Modules);

        public void Load(ElmPackage elmPackage)
        {
            var _ = loaded.Register(elmPackage);
        }

        public void Build()
        {
            const int rwidth = 5;
            const int lwidth = -rwidth;

            Terminal.ClearHome();

            var prefix = $"{"scan",lwidth}";
            Build(prefix, package => new Phase1Scan(Errors, package));
            prefix = $"{prefix}{"pars",lwidth}";
            Build(prefix, package => new Phase2Parse(Errors, package));
            prefix = $"{prefix}{"decl",lwidth}";
            Build(prefix, package => new Phase3Declare(Errors, package));
            prefix = $"{prefix}{"expo",lwidth}";
            Build(prefix, package => new Phase4Expose(Errors, package));
            prefix = $"{prefix}{"impo",lwidth}";
            Build(prefix, package => new Phase5Import(Errors, package));
            prefix = $"{prefix}{"reso",lwidth}";
            Build(prefix, package => new Phase6Resolve(Errors, package));
            prefix = $"{prefix}{"type",lwidth}";
            Build(prefix, package => new Phase7Type(Errors, package));

            Terminal.Write($"{"",53}");
            Terminal.Write($"{$"{Collector.Instance.ScanTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.ParseTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.DeclareTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.ExposeTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.ImportTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.ResolveTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.Write($"{$"{Collector.Instance.TypeTime.ElapsedMilliseconds} ",rwidth}");
            Terminal.WriteLine("ms");

            Collector.Instance.Write();
        }

        private void Build(string prefix, Func<Package, Phase> phase)
        {
            Terminal.GoHome();
            var count = 0;
            foreach (var package in loaded)
            {
                var p = phase(package);
                Build(prefix, ++count, package, p);
            }
        }

        private void Build(string prefix, int no, Package package, Phase phase)
        {
            Terminal.ClearToEol();
            Terminal.Write($"building {no,-2} {phase.Package,-40} {prefix}");

            Terminal.Write($"[");
            phase.Make();
            Terminal.WriteLine("]");
        }
    }
}
