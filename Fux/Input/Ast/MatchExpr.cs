namespace Fux.Input.Ast
{
    internal class MatchExpr : Expression
    {
        public MatchExpr(Expression expression, IEnumerable<MatchCase> cases)
        {
            Expression = expression;
            Cases = cases.ToArray(); ;
        }

        public Expression Expression { get; }
        public IReadOnlyList<MatchCase> Cases { get; }

        public override string ToString()
        {
            var cases = string.Join(" ", Cases.Select(@case => $"{Lex.GroupOpen} {@case} {Lex.GroupClose}"));
            return $"case {Expression} of {cases}";
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
                writer.Write($"{Lex.KwCase} ");
                Expression.PP(writer);
                writer.WriteLine($" {Lex.KwOf}");
                writer.Indent(() =>
                {
                    foreach (var casee in Cases)
                    {
                        casee.PP(writer);
                        if (writer.LinePending)
                        {
                            writer.WriteLine();
                        }
                    }
                });
            }
        }
    }
}
