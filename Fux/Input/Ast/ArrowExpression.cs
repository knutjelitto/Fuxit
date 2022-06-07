namespace Fux.Input.Ast
{
    internal class ArrowExpression : Expression
    {
        public ArrowExpression(Expression lhs, Expression rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expression Lhs { get; }
        public Expression Rhs { get; }

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
