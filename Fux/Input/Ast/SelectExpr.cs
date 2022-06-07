namespace Fux.Input.Ast
{
    internal class SelectExpr : Expression
    {
        public SelectExpr(Expression lhs, Expression rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            return $"{Lhs}{Lex.Dot}{Rhs}";
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($"{Lex.Dot}{Rhs}");
        }
    }
}
