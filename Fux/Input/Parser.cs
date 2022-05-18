using Fux.Ast;

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(Layouter layouter)
        {
            Layouter = layouter;

            Previous = Layouter.Lexer.Bof();
            Current = Previous;
            Advance();
        }

        public Layouter Layouter { get; }

        private Token Previous { get; set; }
        private Token Current { get; set; }

        public Expr Expression()
        {
            return OperatorExpression();
        }

        private Expr OperatorExpression()
        {
            var first = PrefixExpression();

            while (Current.IsOperator())
            {
                var op = new Operator(Advance());

                var next = PrefixExpression();

                first = new Apply(op, first, next);
            }

            return first;
        }

        private Expr PrefixExpression()
        {
            Expr app;

            if (Current.IsOperator())
            {
                var op = new Operator(Advance());
                var argument = PrefixExpression();

                app = new Apply(op, argument);
            }
            else
            {
                app = ApplicationExpression();
            }

            return app;
        }

        private Expr ApplicationExpression()
        {
            var expr = AtomExpression();

            return expr;
        }

        private Expr AtomExpression()
        {
            if (Current.Lex == Lex.Number)
            {
                return new Number(Advance());
            }
            else if (Current.Lex == Lex.LowerId || Current.Lex == Lex.UpperId)
            {
                return new Identifier(Advance());
            }
            else if (Current.Lex == Lex.LParent)
            {
                return ParentExpression();
            }

            throw new InvalidOperationException();
        }

        private Expr ParentExpression()
        {
            Assert(Current.Lex == Lex.LParent);

            Advance();

            while (Current.Lex != Lex.RParent)
            {
                var expr = Expression();
            }
        }

        private Token Advance()
        {
            var current = Current;

            Previous = Current;
            Current = Layouter.Next();

            return current;
        }
    }
}
