using Fux.Building;

namespace Fux.Input.Ast
{
    internal class LetExpr : Expression
    {
        public LetExpr(IReadOnlyList<Expression> letExpressions, Expression inExpression)
        {
            LetExpressions = letExpressions;
            InExpression = inExpression;
        }

        public IReadOnlyList<Expression> LetExpressions { get; }
        public Expression InExpression { get; }

        public LetScope Scope { get; set; } = new();

        public override string ToString()
        {
            string joined = string.Join(" ", LetExpressions.Select(x => $"{Lex.GroupOpen} {x} {Lex.GroupClose}"));

            return $"let {joined} in {InExpression}";
        }

        public override void PP(Writer writer)
        {
            if (writer.LinePending)
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
                writer.WriteLine(Lex.KwLet);
                writer.Indent(() =>
                {
                    foreach (var expr in LetExpressions)
                    {
                        expr.PP(writer);
                        if (writer.LinePending)
                        {
                            writer.WriteLine();
                        }
                    }
                });
                writer.WriteLine(Lex.KwIn);
                writer.Indent(() =>
                {
                    InExpression.PP(writer);
                });
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
            }
        }
    }
}
