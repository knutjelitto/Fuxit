using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Ast;
using Fux.Input;
using Fux.Tools;

namespace Fux
{
    internal class Compiler
    {
        private readonly ErrorBag errors;
        
        public Compiler()
        {
            errors = new ErrorBag();
        }

        public void Compile(Source source)
        {
            Module(errors, source);
        }

        protected static void WithLiner2(ErrorBag errors, Source source)
        {
            source = source.Clone();
            var lexer = new Lexer(errors, source);
            var liner = new Liner2(errors, lexer);

            var tokName = Path.GetFileNameWithoutExtension(source.Name) + "-tok.txt";

            using (var writer = tokName.Writer())
            {
                Tokens line = liner.GetLine();

                do
                {
                    var count = 0;
                    foreach (var token in line)
                    {
                        if (token.Lex == Lex.GroupOpen)
                        {
                            if (count > 0)
                            {
                                writer.WriteLine();
                                count = 0;
                            }
                            WriteToken(writer, token, ref count);

                            writer.Plus();
                            if (count > 0)
                            {
                                writer.WriteLine();
                                count = 0;
                            }
                        }
                        else if (token.Lex == Lex.GroupClose)
                        {
                            if (count > 0)
                            {
                                writer.WriteLine();
                                count = 0;
                            }
                            writer.Minus();
                            WriteToken(writer, token, ref count);
                            if (count > 0)
                            {
                                writer.WriteLine();
                                count = 0;
                            }
                        }
                        else if (token.Lex == Lex.EOF)
                        {
                            writer.Write("<EOF>");
                        }
                        else
                        {
                            WriteToken(writer, token, ref count);
                        }
                    }
                    writer.WriteLine();

                    line = liner.GetLine();
                }
                while (line.Count > 1);
            }

            static void WriteToken(Writer writer, Token token, ref int count)
            {
                if (count > 0)
{
                    writer.Write("·");
                }
                writer.Write($"{token}");
                count += 1;
            }
        }

        protected static void Module(ErrorBag errors, Source source)
        {
            WithLiner2(errors, source);

            var lexer = new Lexer(errors, source);
            var liner = new Liner(errors, lexer);
            var parser = new Parser(errors, liner);

            var astName = Path.GetFileNameWithoutExtension(source.Name) + "-ast.txt";

            using (var writer = astName.Writer())
            {
                while (true)
                {
                    Tokens line = liner.GetLine();

                    Assert(line.Count > 0);

                    do
                    {
                        var expr = CompileOne(line);
                        if (expr != null)
                        {
                            writer.WriteLine($"{expr}");
                            writer.WriteLine();
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
                                writer.WriteLine("----");
                                foreach (var error in diagnostic.Report())
                                {
                                    writer.WriteLine(error);
                                }
                                writer.WriteLine("----");

                                return null;
                            }
                        }

                        line = liner.GetLine();
                    }
                    while (line.Count > 0 && (line.Count != 1 || line[0].Lex != Lex.EOF));

                    break;
                }
            }
        }
    }
}
