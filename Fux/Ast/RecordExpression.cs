using Fux.Input;

namespace Fux.Ast
{
    internal class RecordExpression : Atom
    {
        public RecordExpression(Token left, Token right, IReadOnlyList<Expression> expressions)
        {
            Left = left;
            Right = right;
            Expressions = expressions;
        }

        public Token Left { get; }
        public Token Right { get; }
        public IReadOnlyList<Expression> Expressions { get; }

        public override string ToString()
        {
            var joined = string.Join(" , ", Expressions);
            if (Expressions.Count == 1 && Expressions[0].IsAtomic)
            {
                return $"{Left} {joined} {Right}";
            }
            return $"{Left} {joined} {Right}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.LBrace} ");
            var more = false;
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    writer.WriteLine();
                    writer.Write($"{Lex.Comma} ");
                }
                more = true;
                expression.PP(writer);
            }
            if (writer.LineRunning)
            {
                writer.WriteLine();
            }
            writer.WriteLine($"{Lex.RBrace}");
        }
    }
}
