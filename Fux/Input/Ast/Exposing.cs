using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public abstract class Exposing : Expr.ExprImpl
    {
    }

    public sealed class ExposingAll : Exposing
    {
        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public override string ToString()
        {
            return $"{Lex.KwExposing} {Lex.Weak.ExposeAll}";
        }
    }

    public sealed class ExposingSome : Exposing
    {
        public ExposingSome(IEnumerable<Exposed> exposed)
        {
            Exposed = exposed.ToArray();
        }

        public ExposingSome(params Exposed[] exposed)
            : this(exposed.AsEnumerable())
        {
            Assert(Exposed.Count > 0);
        }

        public IReadOnlyList<Exposed> Exposed { get; }

        public override void PP(Writer writer)
        {
            if (Exposed.Count <= 6)
            {
                writer.WriteLine($"{ToString()}");
            }
            else
            {
                writer.Indent(() =>
                {
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                    }

                    var prefix = "( ";

                    foreach (Exposed exposed in Exposed)
                    {
                        writer.WriteLine($"{prefix}{exposed}");
                        prefix = ", ";
                    }

                    writer.WriteLine(")");
                });
            }
        }

        public override string ToString()
        {
            return $"{Lex.KwExposing} ({string.Join(", ", Exposed)})";
        }
    }
}
