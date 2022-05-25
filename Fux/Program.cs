using Fux.Input;

namespace Fux
{
    internal class Program : Runner
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "repl")
            {
                RunRepl(new ConsoleSource());
            }
            else
            {
                //RunModule(Source.FromFile(@"src/core/Array.elm"));
                RunModule(Source.FromFile(@"src/core/Basics.elm"));
                RunModule(Source.FromFile(@"src/core/Bitwise.elm"));
                RunModule(Source.FromFile(@"src/core/Char.elm"));

                //RunModule(Source.FromFile(@"src/core/Tester.fux"));
            }

            WaitForKey();
        }
    }
}