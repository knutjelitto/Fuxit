namespace Fux.Input.Ast
{
    internal class ArrowExpression : Expr
    {
        public ArrowExpression(Expr lhs, Expr rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expr Lhs { get; }
        public Expr Rhs { get; }

        public override string ToString()
        {
            return $"{Lhs} {Lex.Arrow} {Rhs}";
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($" {Lex.Arrow} ");
            Rhs.PP(writer);
        }
    }
}
