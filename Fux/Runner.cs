using Fux.Ast;
using Fux.Input;

namespace Fux
{
    internal class Runner
    {
#if false
        protected static void RunRepl(ErrorBag errors, Source source)
        {
            Run(errors, source, 
                parser =>
                {
                    while (true)
                    {
                        var expr = parser.Statement();
                        Console.WriteLine($"{expr}");
                    }
                });
        }


        private static void Run(ErrorBag errors, Source source, Action<Parser2> loop)
        {
            try
            {
                var lexer = new Lexer(errors,source);
                var layout = new Layout(lexer);
                var parser = new Parser2(errors, layout);

                loop(parser);
            }
            catch (DiagnosticException diagnostic)
            {
                foreach (var line in diagnostic.Report())
                {
                    Console.WriteLine(line);
                }
            }
        }
#endif

        private static void Run(ErrorBag errors, Source source, Action<ErrorBag, Liner> loop)
        {
            try
            {
                var lexer = new Lexer(errors, source);
                var liner = new Liner(errors, lexer);

                loop(errors, liner);
            }
            catch (DiagnosticException diagnostic)
            {
                foreach (var line in diagnostic.Report())
                {
                    Console.WriteLine(line);
                }
            }
        }
        protected static void WaitForKey()
        {
            Console.Write("any key ...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}
