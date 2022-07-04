#pragma warning disable IDE1006 // Naming Styles
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

        public void PP(Expr top)
        {
            Print(top);
        }

        private void Print(Expr top)
        {
            var str = String(top);
            if (str.Length <= maxWidth)
            {
                Write(str);
                return;
            }

            switch (top)
            {
                case Expr.Native:
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
                    Write($"(   ");
                    PrintLine(expr.Exprs[0]);
                    Indent(() =>
                    {
                        foreach (var arg in expr.Exprs.Skip(1))
                        {
                            PrintLine(arg);
                        }
                    });
                    WriteLine($")");
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

        private string String(Expr expr)
        {
            switch (expr)
            {
                case Expr.Sugar.Application app:
                    {
                        return $"({string.Join(" ", app.Exprs.Select(e => String(e)))})";
                    }
                case Expr.Variable var:
                    {
                        return var.Term.Name;
                    }
                case Expr.Native native:
                    {
                        return native.Nat.ToString();
                    }
                case Expr.Literal literal:
                    {
                        return literal.ToString();
                    }
                case Expr.Iff iff:
                    {
                        return $"(if {String(iff.Cond)} then {String(iff.Then)} else {String(iff.Else)})";
                    }
                case Expr.Application app:
                    {
                        return String(SugarApp(app));
                    }
                case Expr.Empty:
                    {
                        return Lex.Symbol.Empty;
                    }
                case Expr.Wildcard:
                    {
                        return Lex.Symbol.Wildcard;
                    }
                case Expr.Lambda lambda:
                    {
                        return $"({lambda.Term} => {String(lambda.Exp)})";
                    }
                case Expr.Tuple2 tuple2:
                    {
                        return $"({String(tuple2.Expr1)}, {String(tuple2.Expr2)})";
                    }
                case Expr.Matcher matcher:
                    {
                        var cases = string.Join(" ", matcher.Cases.Select(e => String(e)));
                        return $"case {String(matcher.Expr)} of {cases}";
                    }
                case Expr.Case @case:
                    {
                        return $"({String(@case.Pattern)} -> {String(@case.Expr)})";
                    }
                case Expr.Let let:
                    {
                        return $"(let {let.Term} = {String(let.Expr1)} in {String(let.Expr2)})";
                    }
                case Expr.Unify unify:
                    {
                        return String(unify.Expr);
                    }
                case Expr.Cons cons:
                    {
                        return $"({String(cons.First)} {Lex.Symbol.Cons} {String(cons.Rest)})";
                    }
                case Expr.Decons decons:
                    {
                        return $"({String(decons.First)} {Lex.Symbol.Cons} {String(decons.Rest)})";
                    }
                case Expr.Get1 get1:
                    {
                        return $"[{String(get1.Expr)}.1]";
                    }
                case Expr.Get2 get2:
                    {
                        return $"[{String(get2.Expr)}.2]";
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
