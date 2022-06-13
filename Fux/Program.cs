﻿using Fux.Building;
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

                //Console.Write("\u001B[32m"); // green
                Console.Write("\u001B[1m"); // bold

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
                    builder.Load(ElmPackage.Latest("elm/parser")); //TODO: didn't get it with scoping of (|.) (|=)
                    builder.Load(ElmPackage.Latest("elm/project-metadata-utils"));
                    builder.Load(ElmPackage.Latest("elm/random"));
                    builder.Load(ElmPackage.Latest("elm/regex"));
                    builder.Load(ElmPackage.Latest("elm/svg"));
                    builder.Load(ElmPackage.Latest("elm/url"));
                    builder.Load(ElmPackage.Latest("elm/virtual-dom"));

                    //TODO: resolve-error
                    //builder.Load(ElmPackage.Latest("elm-explorations/benchmark"));                    
                    builder.Load(ElmPackage.Latest("elm-explorations/linear-algebra"));
                    builder.Load(ElmPackage.Latest("elm-explorations/markdown"));
                    builder.Load(ElmPackage.Latest("elm-explorations/test"));
                    builder.Load(ElmPackage.Latest("elm-explorations/webgl"));

#if false
                    builder.Load(ElmPackage.Latest("rtfeldman/elm-css"));

                    builder.Load(ElmPackage.Latest("rtfeldman/elm-iso8601-date-strings"));
                    builder.Load(ElmPackage.Latest("rtfeldman/elm-hex"));
                    builder.Load(ElmPackage.Latest("rtfeldman/elm-validate"));
                    builder.Load(ElmPackage.Latest("rtfeldman/elm-sorter-experiment"));
                    builder.Load(ElmPackage.Latest("rtfeldman/count"));
                    builder.Load(ElmPackage.Latest("rtfeldman/console-print"));

                    builder.Load(ElmPackage.Latest("elm-community/list-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/maybe-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/random-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/json-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/string-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/result-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/dict-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/html-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/array-extra"));
                    builder.Load(ElmPackage.Latest("elm-community/basics-extra"));

                    builder.Load(ElmPackage.Latest("elm-community/typed-svg"));
                    builder.Load(ElmPackage.Latest("elm-community/graph"));
                    builder.Load(ElmPackage.Latest("elm-community/easing-functions"));
                    builder.Load(ElmPackage.Latest("elm-community/intdict"));
                    builder.Load(ElmPackage.Latest("elm-community/undo-redo"));
                    builder.Load(ElmPackage.Latest("elm-community/list-split"));
#endif
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
                parse.Parse(source);
            }
        }
    }
}
