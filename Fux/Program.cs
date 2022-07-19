using Fux.Building;
using Fux.Building.Phases;

using Semver;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable IDE0051 // Remove unused private members

namespace Fux
{
    public sealed class Program : Runner
    {
        static void Main(string[] args)
        {
#if true
            var (lines, columns) = Terminal.GetSize();

            var nums = "0123456789";
            var bld = new StringBuilder();
            while (bld.Length < columns)
            {
                bld.Append(nums);
            }
            var str = bld.ToString()[..columns];

            for (var line = 0; line < lines; line++)
            {
                Terminal.SetPosition(line, 0);
                Terminal.Write($"{str}");
            }
#endif

            try
            {
                //Terminal.Write("\u001B[32m"); // green
                Terminal.Write("\u001B[1m"); // bold

                var builder = new Builder();

                if (true)
                {
                    //builder.Load(ElmPackage.Latest("elm-explorations/markdown"));
                    //builder.Load(new ElmPackage("fux/fux/core", "1.0.0"));
                    builder.Load("fux/core");
                }
                else
                {
                    builder.Load(Elm.Package.Latest("elm/core"));
                    builder.Load(Elm.Package.Latest("elm/bytes"));
                    builder.Load(Elm.Package.Latest("elm/file"));
                    builder.Load(Elm.Package.Latest("elm/html"));
                    builder.Load(Elm.Package.Latest("elm/http"));
                    builder.Load(Elm.Package.Latest("elm/json"));
                    builder.Load(Elm.Package.Latest("elm/parser")); //TODO: didn't get it with scoping of (|.) (|=)
                    builder.Load(Elm.Package.Latest("elm/project-metadata-utils"));
                    builder.Load(Elm.Package.Latest("elm/random"));
                    builder.Load(Elm.Package.Latest("elm/regex"));
                    builder.Load(Elm.Package.Latest("elm/svg"));
                    builder.Load(Elm.Package.Latest("elm/url"));
                    builder.Load(Elm.Package.Latest("elm/virtual-dom"));
                    builder.Load(Elm.Package.Latest("elm/browser"));

                    builder.Load(Elm.Package.Latest("elm-explorations/benchmark"));                    
                    builder.Load(Elm.Package.Latest("elm-explorations/linear-algebra"));
                    builder.Load(Elm.Package.Latest("elm-explorations/markdown"));
                    builder.Load(Elm.Package.Latest("elm-explorations/test"));
                    builder.Load(Elm.Package.Latest("elm-explorations/webgl"));

                    builder.Load(Elm.Package.Latest("rtfeldman/elm-css"));
                    builder.Load(Elm.Package.Latest("rtfeldman/elm-iso8601-date-strings"));
                    builder.Load(Elm.Package.Latest("rtfeldman/elm-hex"));
                    builder.Load(Elm.Package.Latest("rtfeldman/elm-validate"));
                    builder.Load(Elm.Package.Latest("rtfeldman/elm-sorter-experiment"));
                    builder.Load(Elm.Package.Latest("rtfeldman/count"));
                    builder.Load(Elm.Package.Latest("rtfeldman/console-print"));

                    builder.Load(Elm.Package.Latest("elm-community/list-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/maybe-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/random-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/json-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/string-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/result-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/dict-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/html-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/array-extra"));
                    builder.Load(Elm.Package.Latest("elm-community/basics-extra"));

                    builder.Load(Elm.Package.Latest("elm-community/typed-svg"));
                    builder.Load(Elm.Package.Latest("elm-community/graph"));
                    builder.Load(Elm.Package.Latest("elm-community/easing-functions"));
                    builder.Load(Elm.Package.Latest("elm-community/intdict"));
                    builder.Load(Elm.Package.Latest("elm-community/undo-redo"));
                    builder.Load(Elm.Package.Latest("elm-community/list-split"));
                    
                    builder.Load(Elm.Package.Latest("elm-in-elm/compiler"));
                }

                var whole = new Stopwatch();
                whole.Start();

                builder.Build();

                whole.Stop();

                var locsec = Math.Round(1000m * Collector.Instance.NumberOfLines / whole.ElapsedMilliseconds);

                var mods = builder.Modules.ToList();
                var max = mods.Max(m => m.Lines != null ? m.Lines.Count : 0);

                Terminal.Write($"[{Collector.Instance.NumberOfExceptions} except, {builder.Packages.Count()} paks, {mods.Count} mods, {max} lmax, {Collector.Instance.NumberOfLines} lines, {whole.ElapsedMilliseconds} ms, {locsec} lps] ");
            }
            catch (DiagnosticException diagnostics)
            {
                foreach (var diagnostic in diagnostics.Diagnostics)
                {
                    foreach (var line in diagnostic.Report())
                    {
                        Terminal.WriteLine($"{line}");
                    }
                }
            }

            WaitForKey();
        }
    }
}
