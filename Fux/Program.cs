using Fux.Building;
using Fux.ElmPackages;
using Fux.Tests;

using Semver;

using Phases = Fux.Building.Phases;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable IDE0051 // Remove unused private members

namespace Fux
{
    internal class Program : Runner
    {
        static void Main(string[] args)
        {
            try
            {
                Test();

                var builder = new Builder();

                if (false)
                {
                    builder.Load(ElmPackage.Latest("elm-explorations/markdown"));
                }
                else
                {
                    builder.Load(ElmPackage.Latest("elm/browser"));
                    builder.Load(ElmPackage.Latest("elm/bytes"));
                    builder.Load(ElmPackage.Latest("elm/core"));
                    builder.Load(ElmPackage.Latest("elm/file"));
                    builder.Load(ElmPackage.Latest("elm/html"));
                    builder.Load(ElmPackage.Latest("elm/http"));
                    builder.Load(ElmPackage.Latest("elm/json"));
                    builder.Load(ElmPackage.Latest("elm/parser"));
                    builder.Load(ElmPackage.Latest("elm/project-metadata-utils"));
                    builder.Load(ElmPackage.Latest("elm/random"));
                    builder.Load(ElmPackage.Latest("elm/regex"));
                    builder.Load(ElmPackage.Latest("elm/svg"));
                    builder.Load(ElmPackage.Latest("elm/url"));
                    builder.Load(ElmPackage.Latest("elm/virtual-dom"));

                    //builder.Load(ElmPackage.Latest("elm-explorations/benchmark")); // 404
                    builder.Load(ElmPackage.Latest("elm-explorations/linear-algebra"));
                    builder.Load(ElmPackage.Latest("elm-explorations/markdown"));
                    //builder.Load(ElmPackage.Latest("elm-explorations/test")); // .facts
                    builder.Load(ElmPackage.Latest("elm-explorations/webgl"));
                }

                builder.Build();
            }
            catch (DiagnosticException diagnostics)
            {
                foreach (var diagnostic in diagnostics.Diagnostics)
                {
                    foreach (var line in diagnostic.Report())
                    {
                        Console.WriteLine($"{line}");
                    }
                }
            }

            WaitForKey();
        }

        private static void Test()
        {
            var builder = new Builder();
            var collector = new Phases.Collector();

            var parse = new Phases.Phase0Parse(builder.Errors, collector, new Package(new ElmPackage("test", new SemVersion(0))));

            foreach (var source in Tester.All())
            {
                parse.Make(source);
            }
#if false
            var x = Catalog.Instance.Where(p => p.Name.StartsWith("elm/")).Select(p => p.Name).Distinct();
            foreach (var package in x)
            {
                Console.WriteLine($"{package}");
                builder.Build(ElmPackage.Latest(package));
            }
#endif

        }
    }
}
