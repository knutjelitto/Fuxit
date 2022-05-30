namespace Fux.Ast
{
    internal class SelectExpression : Expression
    {
        public SelectExpression(OperatorSymbol op, Expression lhs, Expression rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public override bool IsAtomic => true;

        public OperatorSymbol Op { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            var from = Lhs.IsAtomic ? Lhs.ToString() : $"({Lhs})";
            var to = Rhs.IsAtomic ? Rhs.ToString() : $"({Rhs})";
            return $"{from} . {to}";
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($".{Rhs}");
        }
    }
}
