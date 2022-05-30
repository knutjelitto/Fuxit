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
#if true
            //ProvideTest();

            var builder = new Builder();
            //builder.Build(new Package("check/check", "1.0.0"));
            //builder.Build(Package.Latest("elm/browser"));
            builder.Build(Package.Latest("elm/url"));
#else
            var errors = new ErrorBag();

            if (args.Length == 1 && args[0] == "repl")
            {
                //RunRepl(errors, new ConsoleSource());
            }
            else
            {
                RunModule(errors, "src/core/Tester.elm");

                RunModule(errors, "src/core/Array.elm");
                RunModule(errors, "src/core/Basics.elm");
                RunModule(errors, "src/core/Bitwise.elm");
                RunModule(errors, "src/core/Char.elm");
                RunModule(errors, "src/core/Debug.elm");
                RunModule(errors, "src/core/Dict.elm");
                RunModule(errors, "src/core/List.elm");
                RunModule(errors, "src/core/Maybe.elm");
                RunModule(errors, "src/core/Platform.elm");
                RunModule(errors, "src/core/Platform/Cmd.elm");
                RunModule(errors, "src/core/Platform/Sub.elm");
                RunModule(errors, "src/core/Process.elm");
                RunModule(errors, "src/core/Result.elm");
                RunModule(errors, "src/core/Set.elm");
                RunModule(errors, "src/core/String.elm");
                RunModule(errors, "src/core/Task.elm");
                RunModule(errors, "src/core/Tuple.elm");


                if (!errors.Ok)
                {
                    using (var writer = Writer.Console())
                    {
                        writer.WriteLine("=== errors ===");
                        errors.ReportFirstFew(writer);
                    }
                }
            }
#endif

            WaitForKey();
        }
    }
}