using Fux.Ast;
using Fux.Input;

namespace Fux
{
    internal class Runner
    {
        protected static void RunModule(ErrorBag errors, string sourceFile)
        {
            Console.WriteLine($"{sourceFile}");

            var source = Source.FromFile(sourceFile);
            var lexer = new Lexer(errors, source);
            var liner = new Liner(errors, lexer);
            var parser = new Parser(errors, liner);
         
            var astName = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";
            var diffName = Path.GetFileNameWithoutExtension(source.Name) + "-diff.txt";
            
            using (var ast = astName.Writer())
            using (var diff = diffName.Writer())
            {
                var already = false;

                while (true)
                {
                    Tokens line = liner.GetLine();

                    Assert(line.Count > 0);

                    do
                    {
                        var expr = CompileOne(line);
                        if (expr != null)
                        {
                            ast.WriteLine($"{expr}");
                            ast.WriteLine();

                            var differ = line.ToString() != expr.ToString();
                            if (differ)
                            {
                                diff.WriteLine($"{line}");
                                diff.WriteLine("<!!!>");
                                if (!already)
                                {
                                    Console.WriteLine($"---diff in {source.Name}");
                                    already = true;
                                }
                                diff.WriteLine($"{expr}");
                                diff.WriteLine();
                            }
                        }

                        Expression? CompileOne(Tokens line)
                        {
                            var cursor = new TokensCursor(line);

                            try
                            {
                                return parser.Outer(cursor);
                            }
                            catch (DiagnosticException diagnostic)
                            {
                                ast.WriteLine("----");
                                foreach (var error in diagnostic.Report())
                                {
                                    ast.WriteLine(error);
                                }
                                ast.WriteLine("----");

                                return null;
                            }
                        }

                        line = liner.GetLine();
                    }
                    while (line.Count != 1 || line[0].Lex != Lex.EOF);

                    break;
                }
            }
        }

        protected static void RunModule(ErrorBag errors, Source source)
        {
            Console.WriteLine($"{source.Name}");
            Run(errors, source,
                (ErrorBag errors, Liner liner) =>
                {
                    var parser = new Parser(errors, liner);

                    var astName = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";
                    var diffName = Path.GetFileNameWithoutExtension(source.Name) + "-diff.txt";
                    using (var ast = astName.Writer())
                    using (var diff = diffName.Writer())
                    {
                        var already = false;

                        while (true)
                        {
                            Tokens line = liner.GetLine();

                            Assert(line.Count > 0);

                            do
                            {
                                var expr = Compile(line);
                                if (expr != null)
                                {
                                    ast.WriteLine($"{expr}");
                                    ast.WriteLine();

                                    var differ = line.ToString() != expr.ToString();
                                    if (differ)
                                    {
                                        diff.WriteLine($"{line}");
                                        diff.WriteLine("<!!!>");
                                        if (!already)
                                        {
                                            Console.WriteLine($"---diff in {source.Name}");
                                            already = true;
                                        }
                                        diff.WriteLine($"{expr}");
                                        diff.WriteLine();
                                    }
                                }

                                Expression? Compile(Tokens line)
                                {
                                    var cursor = new TokensCursor(line);

                                    try
                                    {
                                        var expr = parser.Outer(cursor);

                                        return expr;
                                    }
                                    catch (DiagnosticException diagnostic)
{
                                        ast.WriteLine("----");
                                        foreach (var error in diagnostic.Report())
                                        {
                                            ast.WriteLine(error);
                                        }
                                        ast.WriteLine("----");

                                        return null;
                                    }
                                }

                                line = liner.GetLine();
                            }
                            while (line.Count != 1 || line[0].Lex != Lex.EOF);

                            break;
                        }
                    }
                });
        }

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
