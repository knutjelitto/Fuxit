using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class LetExpr : Expr.ExprImpl
    {
        public LetExpr(List<Declaration> letExpressions, Expr inExpression)
        {
            LetDecls = letExpressions.ToArray();
            InExpression = inExpression;
        }

        public IReadOnlyList<Declaration> LetDecls { get; }
        public Expr InExpression { get; }

        public LetScope Scope { get; set; } = new();

        public override string ToString()
        {
            string joined = string.Join(" ", LetDecls.Select(x => $"{Lex.GroupOpen} {x} {Lex.GroupClose}"));

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
                    foreach (var expr in LetDecls)
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
