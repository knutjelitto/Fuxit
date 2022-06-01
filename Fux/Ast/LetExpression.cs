using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Fux.Input;

namespace Fux.Ast
{
    internal class LetExpression : Expression
    {
        public LetExpression(IReadOnlyList<Expression> letExpressions, Expression inExpression)
        {
            LetExpressions = letExpressions;
            InExpression = inExpression;
        }

        public IReadOnlyList<Expression> LetExpressions { get; }
        public Expression InExpression { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            string joined = string.Join(" ", LetExpressions.Select(x => $"{Lex.GroupOpen} {x.ToString()} {Lex.GroupClose}"));

            return $"let {joined} in {InExpression}";
        }

        public override void PP(Writer writer)
        {
            if (writer.LineRunning)
            {
                writer.WriteLine();
                writer.Indent(Write);
            }
            else
            {
                Write();
            }

            void Write()
            {
                writer.WriteLine(Lex.HardKwLet);
                writer.Indent(() =>
                {
                    foreach (var expr in LetExpressions)
                    {
                        expr.PP(writer);
                        if (writer.LineRunning)
                        {
                            writer.WriteLine();
                        }
                    }
                });
                writer.WriteLine(Lex.HardKwIn);
                writer.Indent(() =>
                {
                    InExpression.PP(writer);
                });
                if (writer.LineRunning)
                {
                    writer.WriteLine();
                }
            }
        }
    }
}
