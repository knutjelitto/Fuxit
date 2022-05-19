using Fux.Ast;

namespace Fux.Input
{
    internal class Parser
    {
        private Token? current = null;

        public Parser(Layouter layouter)
        {
            Layouter = layouter;
        }

        public Layouter Layouter { get; }

        private Token Current
        { 
            get
            {
                if (current == null)
                {
                    current = Layouter.Next();
                }
                return current;
            }
        }

        public Expression Statement()
        {
            var expression = Expression();

            Assert(Swallow().Lex == Lex.Semicolon);

            return expression;
        }

        private Expression Expression()
        {
            return OperatorExpression();
        }

        private Expression OperatorExpression()
        {
            var first = PrefixExpression();

            var rest = new List<OpExpr>();

            while (Current.IsOperator())
            {
                var op = new Operator(Swallow());

                var expr = PrefixExpression();

                var opExpr = new OpExpr(op, expr);

                rest.Add(opExpr);
            }

            if (rest.Count == 0)
            {
                return first;
            }

            return new OpChain(first, rest).Resolve();
        }

        private Expression PrefixExpression()
        {
            Expression app;

            if (Current.IsOperator())
            {
                var op = new Operator(Swallow());
                var argument = PrefixExpression();

                app = new Application(op, argument);
            }
            else
            {
                app = ApplicationExpression();
            }

            return app;
        }

        private Expression ApplicationExpression()
        {
            var first = AtomExpression();

            var rest = new List<Expression>();
            while (IsAtomExpression())
            {
                rest.Add(AtomExpression());
            }

            if (rest.Count > 0)
            {
                return new Application(first, rest.ToArray());
            }

            return first;
        }

        private bool IsAtomExpression()
        {
            return Current.Lex == Lex.Number
                || Current.Lex == Lex.String
                || Current.Lex == Lex.LowerId
                || Current.Lex == Lex.UpperId
                || Current.Lex == Lex.LParent
                ;
        }

        private Expression AtomExpression()
        {
            if (Current.Lex == Lex.Number)
            {
                return new NumberLiteral(Swallow());
            }
            else if (Current.Lex == Lex.String)
            {
                return new StringLiteral(Swallow());
            }
            else if (Current.Lex == Lex.LowerId || Current.Lex == Lex.UpperId)
            {
                return new Identifier(Swallow());
            }
            else if (Current.Lex == Lex.LParent)
            {
                return ParentExpression();
            }

            throw new InvalidOperationException();
        }

        private Expression ParentExpression()
        {
            Assert(Current.Lex == Lex.LParent);

            var left = Swallow();

            var expressions = new List<Expression>();

            while (Current.Lex != Lex.RParent)
            {
                var expr = Expression();

                expressions.Add(Expression());

                if (Current.Lex == Lex.Comma)
                {
                    Swallow();

                    continue;
                }
            }

            Assert(Current.Lex == Lex.RParent);

            var right = Swallow();

            if (expressions.Count == 0)
            {
                return new Unit(left, right);
            }
            else if (expressions.Count == 1)
            {
                return new SubExpression(left, right, expressions[0]);
            }
            else
            {
                return new TupleExpression(left, right, expressions);
            }
        }

        private Token Swallow()
        {
            var current = Current;

            this.current = null;

            return current;
        }
    }
}
