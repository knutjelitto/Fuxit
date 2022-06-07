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
            var cases = string.Join(" ", Cases.Select(x => $"{Lex.GroupOpen} {x} {Lex.GroupClose}"));
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
                writer.Write($"{Lex.HardKwCase} ");
                Expression.PP(writer);
                writer.WriteLine($" {Lex.HardKwOf}");
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
