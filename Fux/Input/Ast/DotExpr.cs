namespace Fux.Input.Ast
{
    internal class DotExpr : Expression
    {
        public DotExpr(Expression rhs)
        {
            Rhs = rhs;
        }

        public Expression Rhs { get; }

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
