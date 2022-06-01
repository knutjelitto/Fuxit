using Fux.Building;
using Fux.ElmPackages;

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

#if false
                var x = Catalog.Instance.Where(p => p.Name.StartsWith("elm/")).Select(p => p.Name).Distinct();
                foreach (var package in x)
                {
                    Console.WriteLine($"{package}");
                    builder.Build(ElmPackage.Latest(package));
                }
#endif

                builder.Build(ElmPackage.Latest("elm/core"));
                //builder.Build(ElmPackage.Latest("elm/json"));
                //builder.Build(ElmPackage.Latest("elm/html"));
                //builder.Build(ElmPackage.Latest("elm/browser"));
                //builder.Build(ElmPackage.Latest("elm/url"));
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
            const string test = @"module test

test =
    ( { model
        | history = newHistory
        , expandoMsg = Expando.merge userMsg model.expandoMsg
      }
    )

test =
  case test of
    test ->
        case test of
          test ->
            ( { model
                | history = newHistory
                , expandoMsg = Expando.merge userMsg model.expandoMsg
              }
            , Cmd.batch [ commands, scroll model.popout ]
            )
";
        
            var builder = new Builder();

            var s = new StringSource("test", "test", test);

            builder.Compiler.ParseModule(s);
        }
    }
}