﻿#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0051 // Remove unused private members

namespace Fux.Building.AlgorithmW
{
    public sealed class Pretty
    {
        const int maxWidth = 40;

        public Pretty(Writer writer)
        {
            this.writer = writer;
        }

        public Writer writer { get; }

        public void Print(Expr top)
        {
            switch (top)
            {
                case Expr.Unify expr:
                    Print(expr.Expr);
                    break;
                case Expr.Iff expr:
                    WriteLine($"{Lex.KwIf}");
                    Indent(expr.Cond);
                    WriteLine($"{Lex.KwThen}");
                    Indent(expr.Then);
                    WriteLine($"{Lex.KwElse}");
                    Indent(expr.Else);
                    break;
                case Expr.Let expr:
                    WriteLine($"{Lex.KwLet}");
                    Indent(() =>
                    {
                        WriteLine($"{expr.Term} =");
                        Indent(Sugar(expr.Exp1));
                    });
                    WriteLine($"{Lex.KwIn}");
                    Indent(() =>
                    {
                        WriteLine(Sugar(expr.Exp2));
                    });
                    break;
                case Expr.Application expr:
                    Print(SugarApp(expr));
                    break;
                case Expr.Abstraction expr:
                    Write($"{expr.Term} => ");
                    Print(expr.Exp);
                    break;
                case Expr.Sugar.Application expr:
                    if (expr.ToString().Length <= maxWidth)
                    {
                        WriteLine(expr);
                    }
                    else
                    {
                        Write($"($ ");
                        Print(expr.Exprs[0]);
                        Indent(() =>
                        {
                            foreach (var arg in expr.Exprs.Skip(1))
                            {
                                Print(arg);
                            }
                        });
                        WriteLine($")");
                    }
                    break;
                default:
                    WriteLine(top);
                    break;
            }
        }

        private Expr Sugar(Expr expr)
        {
            switch (expr)
            {
                case Expr.Application app:
                    return SugarApp(app);
                default:
                    return expr;
            }
        }

        private Expr.Sugar.Application SugarApp(Expr.Application app)
        {
            return new Expr.Sugar.Application(multi(app).ToArray());

            IEnumerable<Expr> multi(Expr.Application expr)
            {
                if (expr.Exp1 is Expr.Application app)
                {
                    foreach (var inner in multi(app).ToList())
                    {
                        yield return inner;
                    }
                }
                else
                {
                    yield return Sugar(expr.Exp1);
                }
                
                yield return Sugar(expr.Exp2);
            }
        }

        private void Indent(Expr expr)
        {
            writer.Indent(() => Print(expr));
        }

        private void Indent(Action action)
        {
            writer.Indent(action);
        }

        private void IndentLine(string text)
        {
            writer.Indent(() => writer.WriteLine(text));
        }

        private void WriteLine(Expr expr)
        {
            writer.WriteLine($"{expr}");
        }

        private void WriteLine(string? text = null)
        {
            writer.WriteLine(text ?? string.Empty);
        }

        private void Write(Expr expr)
        {
            writer.Write($"{expr}");
        }

        private void Write(string? text = null)
        {
            writer.Write(text ?? string.Empty);
        }
    }
}
