namespace Fux.Input.Ast
{
    public sealed class ListExpr : ListOf<Expr>
    {
        public ListExpr(IReadOnlyList<Expr> expressions)
            : base(expressions)
        {
        }

        public override string ToString()
        {
            var joined = string.Join(", ", this);
            return $"{Lex.LBracket}{joined}{Lex.RBracket}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.LBracket}");
            var more = false;
            foreach (var expression in this)
            {
                if (more)
                {
                    writer.Write($"{Lex.Comma} ");
                }
                more = true;
                expression.PP(writer);
            }
            writer.Write($"{Lex.RBracket}");
        }
    }
}
