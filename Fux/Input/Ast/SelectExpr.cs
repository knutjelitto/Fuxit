namespace Fux.Input.Ast
{
    internal class SelectExpr : Expr
    {
        public SelectExpr(Expr lhs, Expr rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expr Lhs { get; }
        public Expr Rhs { get; }

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
