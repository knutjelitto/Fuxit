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
                RunModule(Source.FromFile(@"src/core/Array.fux"));
                //RunModule(Source.FromFile(@"src/core/Basics.fux"));
                //RunModule(Source.FromFile(@"src/core/Bitwise.fux"));

                //RunModule(Source.FromFile(@"src/core/Tester.fux"));
            }

            WaitForKey();
        }
    }
}