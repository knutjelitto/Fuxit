using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Building.AlgorithmW
{
    internal class Pretty
    {
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
                case Expr.Let expr:
                    WriteLine($"{Lex.KwLet}");
                    writer.Indent(() =>
                    {
                        WriteLine($"{expr.Term} =");
                        Indent(expr.Exp1);
                    });
                    WriteLine($"{Lex.KwIn}");
                    writer.Indent(() =>
                    {
                        WriteLine($"{expr.Exp2}");
                    });
                    break;
                case Expr.Application expr:
                    WriteLine(Sugar(expr));
                    break;
                default:
                    WriteLine(top);
                    break;
            }
        }

        private Expr.MultiApplication Sugar(Expr.Application app)
        {
            return new Expr.MultiApplication(multi(app).ToArray());

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
                    yield return expr.Exp1;
                }
                yield return expr.Exp2;
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
