namespace Fux.Input.Ast
{
    internal class TupleExpr : ListOf<Expression>
    {
        public TupleExpr(IEnumerable<Expression> expressions)
            : base(expressions)
        {
            Assert(this.Count >= 1);
        }

        public override string ToString()
        {
            return $"{Lex.LParent}{string.Join(", ", this)}{Lex.RParent}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.LParent}");
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
            writer.Write($"{Lex.RParent}");
        }
    }
}
