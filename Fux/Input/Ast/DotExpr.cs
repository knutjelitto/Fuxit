namespace Fux.Input.Ast
{
    internal class DotExpr : Expr
    {
        public DotExpr(Expr rhs)
        {
            Rhs = rhs;
        }

        public Expr Rhs { get; }

        public override string ToString()
        {
            return $"{Lex.Dot}{Rhs}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.Dot}{Rhs}");
        }
    }
}
