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
                        var liner = new LineParser(parser.Lexer);

                        while (true)
                        {
#if true
                            Line? line;

                            while ((line = liner.GetLine()) != null)
                            {
                                Write(line);
                                writer.WriteLine();

                                void Write(Line line)
                                {
                                    var next = false;
                                    foreach (var token in line.Tokens)
                                    {
                                        if (next)
                                        {
                                            writer.Write(" ");
                                        }
                                        next = true;

                                        writer.Write($"{token}");
                                    }
                                    writer.WriteLine();
                                    writer.Indent(() =>
                                    {
                                        foreach (var indented in line.Lines)
                                        {
                                            Write(indented);
                                        }
                                    });
                                }
                            }
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
                var layout = new Layout(lexer);
                var parser = new Parser(layout);

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
