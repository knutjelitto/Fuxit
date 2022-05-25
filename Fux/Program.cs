using Fux.Input;

namespace Fux
{
    internal class Program : Runner
    {
        static void Main(string[] args)
        {
            var errors = new ErrorBag();

            if (args.Length == 1 && args[0] == "repl")
            {
                RunRepl(errors, new ConsoleSource());
            }
            else
            {
                RunModule(errors, Source.FromFile(@"src/core/Array.elm"));
                RunModule(errors, Source.FromFile(@"src/core/Basics.elm"));
                RunModule(errors, Source.FromFile(@"src/core/Bitwise.elm"));
                RunModule(errors, Source.FromFile(@"src/core/Char.elm"));

                //RunModule(errors, Source.FromFile(@"src/core/Tester.fux"));

                if (!errors.Ok)
                {
                    using (var writer = Writer.Console())
                    {
                        writer.WriteLine("=== errors ===");
                        errors.ReportFirstFew(writer);
                    }
                }
            }

            WaitForKey();
        }
    }
}