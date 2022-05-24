using Fux.Input;

namespace Fux
{
    internal class Runner
    {
        protected static void RunModule(Source source)
        {
            Console.WriteLine($"{source.Name}");
            Run(source,
                (Lexer lexer) =>
                {
                    var name = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";
                    using (var writer = name.Writer())
                    {
                        var liner = new Liner(lexer);
                        var errors = new ParserErrors();

                        while (true)
                        {
                            Line line = liner.GetLine();

                            var parser = new Parser(errors, line);


                            do
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


        private static void Run(Source source, Action<Parser2> loop)
        {
            try
            {
                var lexer = new Lexer(source);
                var layout = new Layout(lexer);
                var parser = new Parser2(layout);

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

        private static void Run(Source source, Action<Lexer> loop)
        {
            try
            {
                var lexer = new Lexer(source);

                loop(lexer);
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
