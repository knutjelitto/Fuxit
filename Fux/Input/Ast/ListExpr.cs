namespace Fux.Input.Ast
{
    internal class ListExpr : ListOf<Expression>
    {
        public ListExpr(Token left, Token right, IReadOnlyList<Expression> expressions)
            : base(expressions)
        {
            Left = left;
            Right = right;
        }

        public Token Left { get; }
        public Token Right { get; }

        public override string ToString()
        {
            if (Count == 0)
            {
                return $"{Left} {Right}";
            }
            var joined = string.Join(", ", this);
            return $"{Left} {joined} {Right}";
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
