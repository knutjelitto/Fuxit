namespace Fux.Ast
{
    internal class SequenceExpression : Expression
    {
        public SequenceExpression(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }
        public override bool IsAtomic => Expressions.Count == 1;

        public override string ToString()
        {
            var joined = string.Join(" ", Expressions);

            return $"{joined}";
        }

        public override void PP(Writer writer)
        {
            var more = false;
            foreach (var expr in Expressions)
            {
                if (more)
                {
                    writer.Write(" ");
                }
                more = true;

                expr.PP(writer);
            }
        }
    }
}
