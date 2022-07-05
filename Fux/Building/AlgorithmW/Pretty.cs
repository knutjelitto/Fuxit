#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0051 // Remove unused private members

namespace Fux.Building.AlgorithmW
{
    public sealed class Pretty
    {
        private static readonly Pretty Instance = new Pretty(Writer.Null());

        private const int maxWidth = 30;

        public static string Expr(Expr expr)
        {
            return Instance.Str(expr);
        }

        public Pretty(Writer writer)
        {
            this.writer = writer;
        }

        public Writer writer { get; }

        public void PP(Expr top)
        {
            Print(top);
        }

        private void Print(Expr top)
        {
            var str = Str(top);
            if (str.Length <= maxWidth)
            {
                Write(str);
                return;
            }

            switch (top)
            {
                case AlgorithmW.Expr.Native:
                    Write(str);
                    break;
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
                        Indent(() => Print(expr.Expr1));
                    });
                    writer.EndLine();
                    WriteLine($"{Lex.KwIn}");
                    Indent(() =>
                    {
                        PrintLine(expr.Expr2);
                    });
                    break;
                case Expr.Matcher expr:
                    WriteLine($"{Lex.KwCase}");
                    Indent(() => PrintLine(expr.Expr));
                    WriteLine($"{Lex.KwOf}");
                    Indent(() =>
                    {
                        foreach (var cheese in expr.Cases)
                        {
                            PrintLine(cheese);
                        }
                    });
                    break;
                case Expr.Case cheese:
                    Print(cheese.Pattern);
                    if (writer.LinePending)
                    {
                        WriteLine(" ->");
                        Indent(() => PrintLine(cheese.Expr));
                    }
                    else
                    {
                        Indent(() =>
                        {
                            Write("-> ");
                            Print(cheese.Expr);
                        });
                    }
                    break;
                case Expr.Application expr:
                    Print(SugarApp(expr));
                    break;
                case Expr.Lambda expr:
                    WriteLine($"{expr.Term} =>");
                    Indent(() => PrintLine(expr.Exp));
                    break;
                case Expr.Sugar.Application expr:
                    PrintLine(expr.Exprs[0]);
                    Indent(() =>
                        {
                            foreach (var arg in expr.Exprs.Skip(1))
                            {
                                PrintLine(arg);
                            }
                        });
                    break;
                case Expr.Tuple2 tuple2:
                    Write($"(   ");
                    PrintLine(tuple2.Expr1);
                    Write($",   ");
                    PrintLine(tuple2.Expr2);
                    WriteLine($")");
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void PrintLine(Expr expr)
        {
            Print(expr);
            writer.EndLine();
        }

        private string Str(Expr expr)
        {
            switch (expr)
            {
                case Expr.Sugar.Application app:
                    {
                        return $"({string.Join(" ", app.Exprs.Select(e => Str(e)))})";
                    }
                case Expr.Variable var:
                    {
                        return var.Term.Name;
                    }
                case Expr.Native native:
                    {
                        return native.Nat.FullName;
                    }
                case Expr.Literal literal:
                    {
                        return literal.ToString();
                    }
                case Expr.Iff iff:
                    {
                        return $"(if {Str(iff.Cond)} then {Str(iff.Then)} else {Str(iff.Else)})";
                    }
                case Expr.Application app:
                    {
                        return Str(SugarApp(app));
                    }
                case AlgorithmW.Expr.Empty:
                    {
                        return Lex.Symbol.Empty;
                    }
                case AlgorithmW.Expr.Wildcard:
                    {
                        return Lex.Symbol.Wildcard;
                    }
                case Expr.Lambda lambda:
                    {
                        return $"({lambda.Term} => {Str(lambda.Exp)})";
                    }
                case Expr.Tuple2 tuple2:
                    {
                        return $"({Str(tuple2.Expr1)}, {Str(tuple2.Expr2)})";
                    }
                case Expr.Matcher matcher:
                    {
                        var cases = string.Join(" ", matcher.Cases.Select(e => Str(e)));
                        return $"case {Str(matcher.Expr)} of {cases}";
                    }
                case Expr.Case @case:
                    {
                        return $"({Str(@case.Pattern)} -> {Str(@case.Expr)})";
                    }
                case Expr.Let let:
                    {
                        return $"(let {let.Term} = {Str(let.Expr1)} in {Str(let.Expr2)})";
                    }
                case Expr.Unify unify:
                    {
                        return Str(unify.Expr);
                    }
                case Expr.Cons cons:
                    {
                        return $"({Str(cons.First)} {Lex.Symbol.Cons} {Str(cons.Rest)})";
                    }
                case Expr.Decons decons:
                    {
                        return $"({Str(decons.First)} {Lex.Symbol.Cons} {Str(decons.Rest)})";
                    }
                case Expr.Get1 get1:
                    {
                        return $"[{Str(get1.Expr)}.1]";
                    }
                case Expr.Get2 get2:
                    {
                        return $"[{Str(get2.Expr)}.2]";
                    }
                default:
                    break;
            }
            Assert(false);
            throw new NotImplementedException($"not implemented expr ({expr.GetType().FullName}) - {expr}");
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
            writer.Indent(() =>
            {
                Print(expr);
                writer.EndLine();
            });
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
