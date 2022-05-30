using Fux.Input;

namespace Fux.Ast
{
    internal class AnnotateExpression : InfixExpression
    {
        public AnnotateExpression(OperatorSymbol op, Expression lhs, Expression rhs)
            : base(op, lhs, rhs)
        {
            Assert(op.Token.Lex == Lex.Colon);
        }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"{Lhs} {Lex.Colon} {Rhs}";
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($" {Lex.Colon} ");
            Rhs.PP(writer);
        }
    }
}
