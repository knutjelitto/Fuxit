using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Ast;
using Fux.Input;

namespace Fux
{
    internal class Runner
    {
        protected static void RunModule(Source source)
        {
            Console.WriteLine($"{source.Name}");
            Run(source,
                parser =>
                {
                    var name = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";
                    using (var writer = name.Writer())
                    {
                        while (true)
                        {
#if true
                            Token token;
                            do
                            {
                                token = parser.Lexer.GetNext();
                                if (token.Lex == Lex.LayoutIndent)
                                {
                                    writer.WriteLine();
                                    writer.Plus();
                                }
                                else if (token.Lex == Lex.LayoutUndent)
                                {
                                    writer.Minus();
                                    writer.WriteLine();
                                }
                                else if (token.Lex == Lex.LayoutSame)
                                {
                                    writer.Write(" • ");
                                }
                                else
                                {
                                    writer.Write($"{token}");
                                }
                            }
                            while (token.Lex != Lex.EOF);
#else
                            var expr = parser.SourceFile();
                            writer.WriteLine($"{expr}");
                            foreach (var stmt in expr.Declarations)
                            {
                                writer.WriteLine($"{stmt}");
                            }
#endif

                            break;
                        }
                    }
                });
        }

        protected static void RunRepl(Source source)
        {
            Run(source, 
                parser =>
                {
                    while (true)
                    {
                        var expr = parser.Statement();
                        Console.WriteLine($"{expr}");
                    }
                });
        }


        private static void Run(Source source, Action<Parser> loop)
        {
            try
            {
                var lexer = new Lexer(source);
                var parser = new Parser(lexer);

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

        protected static void WaitForKey()
        {
            Console.Write("any key ...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}
