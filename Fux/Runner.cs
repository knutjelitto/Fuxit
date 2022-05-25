using Fux.Errors;
using Fux.Input;

namespace Fux
{
    internal class Runner
    {
        protected static void RunModule(ErrorBag errors, Source source)
        {
            Console.WriteLine($"{source.Name}");
            Run(errors, source,
                (ErrorBag errors, Lexer lexer) =>
                {
                    var name = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";
                    using (var writer = name.Writer())
                    {
                        var liner = new Liner(errors, lexer);

                        while (true)
                        {
                            Line line = liner.GetLine();

                            do
                            {
                                Write(line);
                                Compile(line);
                                writer.WriteLine();

                                void Compile(Line line)
                                {
                                    var cursor = new LineCursor(line);

                                    var parser = new Parser(errors, line);

                                    try
                                    {
                                        var expr = parser.Outer(cursor);
                                    }
                                    catch (DiagnosticException diagnostic)
{
                                        writer.WriteLine("--");
                                        foreach (var error in diagnostic.Report())
                                        {
                                            writer.WriteLine(error);
                                        }
                                        writer.WriteLine("--");
                                    }
                                }

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

                                        if (token.Lex == Lex.LParent)
                                        {
                                            writer.Write($"(");
                                        }
                                        else if (token.Lex == Lex.RParent)
                                        {
                                            writer.Write($")");
                                        }
                                        else
                                        {
                                            writer.Write($"{token}");
                                        }
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

                                line = liner.GetLine();
                            }
                            while (line.Tokens.Count != 1 || line.Tokens[0].Lex != Lex.EOF);

                            break;
                        }
                    }
                });
        }

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

        private static void Run(ErrorBag errors, Source source, Action<ErrorBag, Lexer> loop)
        {
            try
            {
                var lexer = new Lexer(errors, source);

                loop(errors, lexer);
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
