#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0066 // Convert switch statement to expression
#pragma warning disable IDE0051 // Remove unused private members

namespace Fux.Building.AlgorithmW
{
    public sealed class Pretty
    {
        private static readonly Pretty Instance = new(Writer.Null());

        private const int maxWidth = 30;

        public static string ExprStr(Expr expr)
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
            switch (top)
            {
                case Expr.Lambda:
                case Expr.Sugar.Let:
                    break;
                default:
                    var str = Str(top);
                    if (str.Length <= maxWidth)
                    {
                        Write(str);
                        return;
                    }
                    break;
            }

            switch (top)
            {
                case Expr.Native:
                    Write(Str(top));
                    break;
                case Expr.Unify expr:
                    Print(expr.Expr);
                    break;
                case Expr.Iff expr:
                    WriteLine($"{Lex.KwIf}");
                    Indent(() => Print(expr.Cond));
                    WriteLine($"{Lex.KwThen}");
                    Indent(() => Print(expr.Then));
                    WriteLine($"{Lex.KwElse}");
                    Indent(() => Print(expr.Else));
                    break;
                case Expr.Matcher expr:
                    WriteLine($"{Lex.KwCase}");
                    Indent(() => Print(expr.Expr));
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

                case Expr.Let expr:
                    Print(SugarLet(expr));
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

                case Expr.Sugar.Let expr:
                    WriteLine($"{Lex.KwLet}");
                    Indent(() =>
                    {
                        foreach (var (term, value) in expr.Lets)
                        {
                            Write($"{term} = ");
                            Print(value);
                            EndLine();
                        }
                    });
                    WriteLine($"{Lex.KwIn}");
                    Indent(() => Print(expr.Expr));
                    break;

                case Expr.Lambda expr:
                    if (expr.Expr is Expr.Lambda)
                    {
                        Write($"{expr.Term} => ");
                        Print(expr.Expr);
                    }
                    else
                    {
                        WriteLine($"{expr.Term} =>");
                        Indent(() => Print(expr.Expr));
                    }
                    break;

                case Expr.Tuple2 tuple2:
                    Write($"(   ");
                    Indent(() => Print(tuple2.Expr1));
                    Write($",   ");
                    Indent(() => Print(tuple2.Expr2));
                    WriteLine($")");
                    break;

                case Expr.DeCons deCons:
                    Write($"<<<{Str(deCons)}>>>");
                    break;

                case Expr.DeCtor deCtor:
                    Write($"{Str(deCtor)}");
                    break;

                case Expr.Record record:
                    Write($"{Str(record)}");
                    break;

                case Expr.Variable variable:
                    Write($"{Str(variable)}");
                    break;

                case Expr.Ctor ctor:
                    Write($"{Str(ctor)}");
                    break;

                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private string Str(Expr expr, int prio = 1)
        {
            switch (expr)
            {

                case Expr.Application app:
                    {
                        return Str(SugarApp(app));
                    }

                case Expr.Sugar.Application app:
                    {
                        return Clamp($"{string.Join(" ", app.Exprs.Select(e => Str(e)))}");
                    }

                case Expr.Let let:
                    {
                        return Str(SugarLet(let));
                    }

                case Expr.Sugar.Let let:
                    {
                        var assignments = string.Join(") (", let.Lets.Select(assign => $"{assign.term} = {Str(assign.value)}"));
                        return $"(let ({assignments}) in {Str(let.Expr)})";
                    }

                case Expr.Variable var:
                    {
                        return var.Term.Name;
                    }

                case Expr.Native native:
                    {
                        return native.Nat.FullText;
                    }

                case Expr.Unit unit:
                    {
                        return Lex.Symbol.Unit;
                    }

                case Expr.Literal literal:
                    {
                        return literal.ToString();
                    }

                case Expr.Iff iff:
                    {
                        return $"(if {Str(iff.Cond)} then {Str(iff.Then)} else {Str(iff.Else)})";
                    }

                case W.Expr.Empty:
                    {
                        return Lex.Symbol.Empty;
                    }

                case W.Expr.Wildcard:
                    {
                        return Lex.Symbol.Wildcard;
                    }

                case Expr.Lambda lambda:
                    {
                        return $"({lambda.Term} => {Str(lambda.Expr)})";
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

                case Expr.Unify unify:
                    {
                        return Str(unify.Expr);
                    }

                case Expr.Cons cons:
                    {
                        return $"({Str(cons.First)} {Lex.Symbol.Cons} {Str(cons.Rest)})";
                    }

                case Expr.DeCons deCons:
                    {
                        return $"({Str(deCons.First)} {Lex.Symbol.Cons} {Str(deCons.Rest)})";
                    }

                case Expr.DeCtor deCtor:
                    {
                        if (deCtor.Arguments.Count > 0)
                        {
                            var args = string.Join(" ", deCtor.Arguments.Select(a => Str(a)));
                            return $"({Str(deCtor.First)} {args})";
                        }
                        return $"({Str(deCtor.First)})";
                    }

                case Expr.GetValue getValue:
                    {
                        return $"[{Str(getValue.Expr)}@{getValue.Index}]";
                    }

                case Expr.GetValue2 getValue:
                    {
                        return $"[{Str(getValue.Expr)}[{getValue.Index}]]";
                    }

                case Expr.DeVariable deVariable:
                    {
                        return $"{Str(deVariable.Var)}";
                    }

                case Expr.WithAlias withAlias:
                    {
                        return $"({Str(withAlias.Expr)} as {Str(withAlias.Alias)})";
                    }

                case Expr.Record record:
                    {
                        var @base = record.Base == null ? "" : $"{record.Base} | ";
                        var fields = string.Join(", ", record.Fields.Select(f => Str(f)));

                        return $"{{{@base}{fields}}}";
                    }
                case Expr.Ctor ctor:
                    {
                        if (ctor.Arguments.Count > 0)
                        {
                            var arguments = string.Join(" ", ctor.Arguments.Select(a => Str(a)));
                            return $"({Str(ctor.First)} {arguments})";
                        }
                        return $"({Str(ctor.First)})";
                    }

                case Expr.Field field:
                    {
                        if (field.Value == null)
                        {
                            return $"{field.Name}";
                        }
                        return $"{field.Name} = {Str(field.Value)}";
                    }

                default:
                    break;
            }

            Assert(false);
            throw new NotImplementedException($"not implemented expr ({expr.GetType().FullName}) - {expr}");

            string Clamp(string str)
            {
                if (prio > 0)
                {
                    return $"({str})";
                }
                return str;
            }
        }

        private Expr Sugar(Expr expr)
        {
            switch (expr)
            {
                case Expr.Application app:
                    return SugarApp(app);
                case Expr.Let let:
                    return SugarLet(let);
                default:
                    return expr;
            }
        }

        private Expr.Sugar.Application SugarApp(Expr.Application app)
        {
            return new Expr.Sugar.Application(multi(app).ToArray());

            IEnumerable<Expr> multi(Expr.Application expr)
            {
                if (expr.Expr1 is Expr.Application app)
                {
                    foreach (var inner in multi(app).ToList())
                    {
                        yield return inner;
                    }
                }
                else
                {
                    yield return Sugar(expr.Expr1);
                }
                
                yield return Sugar(expr.Expr2);
            }
        }

        private Expr.Sugar.Let SugarLet(Expr.Let let)
        {
            Expr last;
            var assignments = new List<(TermVariable, Expr)>();

            do
            {
                last = let.Expr2;
                assignments.Add((let.Term, let.Expr1));
                if (last is Expr.Let next)
                {
                    let = next;
                }
                else
                {
                    break;
                }
            }
            while (true);

            return new Expr.Sugar.Let(assignments, last);
        }

        private void PrintLine(Expr expr)
        {
            Print(expr);
            writer.EndLine();
        }

        private void Indent(Action action)
        {
            writer.Indent(action);
            writer.EndLine();
        }

        private void WriteLine(string? text = null)
        {
            writer.WriteLine(text ?? string.Empty);
        }

        private void Write(string? text = null)
        {
            writer.Write(text ?? string.Empty);
        }

        private void EndLine()
        {
            writer.EndLine();
        }
    }
}
