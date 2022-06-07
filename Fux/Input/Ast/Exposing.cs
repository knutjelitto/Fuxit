using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal abstract class Exposing : Expression
    {
    }

    internal class ExposingAll : Exposing
    {
        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public override string ToString()
        {
            return $"{Lex.Weak.Exposing} {Lex.Weak.ExposeAll}";
        }
    }
    
    internal class ExposingSome : Exposing
    {
        public ExposingSome(IEnumerable<Exposed> exposed)
        {
            Exposed = exposed.ToArray();
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
            return $"{Lex.Weak.Exposing} ({string.Join(", ", Exposed)})";
        }
    }
}
