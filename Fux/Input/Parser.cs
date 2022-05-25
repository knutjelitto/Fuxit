using System.Collections.Generic;

using Fux.Ast;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(ErrorBag errors, Line line)
        {
            Error = new ParserErrors(errors);
            Line = line;
        }

        public ParserErrors Error { get; }
        public Line Line { get; private set; }

        public Expression Outer(LineCursor cursor)
        {
            Expression? outer = null;

            if (cursor.Is(Lex.KwModule))
            {
                outer = Header(cursor);
            }
            else if (cursor.Is(Lex.KwImport))
            {
                outer = Import(cursor);
            }
            else if (cursor.Is(Lex.KwType))
            {
                outer = Type(cursor);
            }
            else
            {
                var lhs = Expression(cursor);

                if (cursor.Is(Lex.Colon))
                {
                    outer = Annotation(cursor, lhs);
                }
                else if (cursor.Is(Lex.Assign))
                {
                    outer = Definition(cursor, lhs);
                }
            }

            if (outer == null)
            {
                throw Error.NotImplemented(cursor.At());
            }

            if (cursor.More())
            {
                throw Error.Internal(cursor.At(), "continuation with token not implemented");
            }

            return outer;
        }

        private Expression Header(LineCursor cursor)
        {
            var kwModule = Swallow(cursor, Lex.KwModule);
            var name = new Identifier(Swallow(cursor, Lex.UpperId));
            var kwExposing = Swallow(cursor, Lex.KwExposing);

            var tuple = Tuple(cursor);

            return new Header(name, tuple);

        }

        public Import Import(LineCursor cursor)
        {
            var kwImport = Swallow(cursor, Lex.KwImport);
            var path = Expression(cursor);

            Expression? alias = null;

            if (cursor.More() && cursor.At().Text == "as")
            {
                cursor.Advance();

                alias = Expression(cursor);
            }

            Expression? exposed = null;

            if (cursor.More() && cursor.At().Text == "exposing")
            {
                cursor.Advance();

                exposed = Expression(cursor);
            }

            return new Import(path, alias, exposed);
        }

        public TypeDefinition Type(LineCursor cursor)
        {
            var kwType = Swallow(cursor, Lex.KwType);

            var lhs = Expression(cursor);

            var kwDefine = Swallow(cursor, Lex.Assign);

            var rhs = Expression(cursor);

            return new TypeDefinition(kwType, lhs, kwDefine, rhs);
        }

        public Definition Definition(LineCursor cursor, Expression lhs)
        {
            var kwDefine = Swallow(cursor, Lex.Assign);

            Expression rhs;

            if (cursor.More())
            {
                rhs = Expression(cursor);
            }
            else
            {
                rhs = Inner(cursor);
            }

            return new Definition(kwDefine, lhs, rhs);
        }

        public Annotation Annotation(LineCursor cursor, Expression lhs)
        {
            var kwColon = Swallow(cursor, Lex.Colon);

            var rhs = Expression(cursor);

            return new Annotation(kwColon, lhs, rhs);
        }

        public Expression Inner(LineCursor cursor)
        {
            if (cursor.More())
            {
                throw Error.Internal(cursor.At(), "expected end in token sequence");
            }

            Assert(cursor.LineCount > 0);

            var first = cursor[0];

            if (first.Is(Lex.KwLet))
            {
                return Let(cursor);
            }
            else if (first.Is(Lex.KwIf))
            {
                return If(cursor);
            }

            throw Error.NotImplemented(first.At());
        }

        public Expression If(LineCursor cursor)
        {
            if (cursor.LineCount == 0)
            {
                throw Error.Internal(cursor.Last(), "expected inner lines");
            }

            var iff = cursor[0];

            throw Error.NotImplemented(iff.At());
        }

        public Expression Let(LineCursor cursor)
        {
            if (cursor.LineCount != 2)
            {
                throw Error.Internal(cursor.Last(), "expected two inner lines");
            }

            var let = cursor[0];
            var inn = cursor[1];

            if (!let.Is(Lex.KwLet) || let.TokenCount != 1)
            {
                throw Error.Internal(let.At(), $"expected '{Lex.KwLet}' as sole token on line");
            }

            var letExpressions = new List<Expression>();

            for (var i = 0; i < let.LineCount; ++i)
            {
                var letLine = let[i];

                var expression = Expression(letLine);

                letExpressions.Add(expression);
            }

            var inExpression = KwIn(inn);

            return new LetExpression(letExpressions, inExpression);
        }

        private Expression KwIn(LineCursor inn)
        {
            var kwIn = Swallow(inn, Lex.KwIn);

            Expression expression;

            if (inn.More())
            {
                if (inn.LineCount > 0)
                {
                    throw Error.Internal(inn.At(), $"continuation on inner lines not implemented");
                }

                expression = Expression(inn);
            }
            else
            {
                if (inn.LineCount != 1)
                {
                    throw Error.Internal(kwIn, $"only one inner line implemented");
                }

                expression = Expression(inn[0]);
            }

            return expression;
        }

        private TupleExpression Tuple(LineCursor cursor)
        {
            var left = Swallow(cursor, Lex.LParent);

            var expressions = new List<Expression>();

            while (cursor.At().Lex != Lex.RParent)
            {
                expressions.Add(Expression(cursor));

                if (cursor.At().Lex == Lex.Comma)
                {
                    cursor.Advance();

                    continue;
                }
            }

            var right = Swallow(cursor, Lex.RParent);

            return new TupleExpression(left, right, expressions);
        }

        private Expression Expression(LineCursor cursor)
        {
            if (cursor.Is(Lex.KwIf))
            {
                return InlineIf(cursor);
            }
            return Operator(cursor);
        }

        private Expression InlineIf(LineCursor cursor)
        {
            var kwIf = Swallow(cursor, Lex.KwIf);
            var condition = Expression(cursor);
            var kwThen = Swallow(cursor, Lex.KwThen);
            var whenTrue = Expression(cursor);
            var kwElse = Swallow(cursor, Lex.KwElse);
            var whenFalse = Expression(cursor);

            return new IfExpression(condition, whenTrue, whenFalse);
        }

        private Expression Operator(LineCursor cursor)
        {
            var lhs = Prefix(cursor);

            var rest = new List<OpExpr>();

            while (cursor.Is(Lex.Operator))
            {
                var op = Infix.Instance.Create(cursor.Advance());

                var rhs = Prefix(cursor);

                var opExpr = new OpExpr(op, rhs);

                rest.Add(opExpr);
            }

            if (rest.Count == 0)
            {
                return lhs;
            }

            return new OpChain(lhs, rest).Resolve();
        }

        private Expression Prefix(LineCursor cursor)
        {
            Expression app;

            if (cursor.At().IsOperator())
            {
                var op = new Operator(cursor.Advance());
                var argument = Prefix(cursor);

                app = new ApplicationExpression(op, argument);
            }
            else
            {
                app = Sequence(cursor);
            }

            return app;
        }

        private Expression Sequence(LineCursor cursor)
        {
            var first = Atom(cursor);

            var rest = new List<Expression>();
            while (IsAtomStart(cursor))
            {
                rest.Add(Atom(cursor));
            }

            if (rest.Count > 0)
            {
                return new ApplicationExpression(first, rest.ToArray());
            }

            return first;
        }

        private Expression Atom(LineCursor cursor)
        {
            if (cursor.Is(Lex.LowerId))
            {
                return new Identifier(cursor.Advance());
            }
            else if (cursor.Is(Lex.UpperId))
            {
                return new Identifier(cursor.Advance());
            }
            else if (cursor.Is(Lex.Wildcard))
            {
                return new Wildcard(cursor.Advance());
            }
            else if (cursor.Is(Lex.Number))
            {
                return new NumberLiteral(cursor.Advance());
            }
            else if (cursor.Is(Lex.GroupOpen))
            {
                var open = Swallow(cursor, Lex.GroupOpen);
                var expression = Expression(cursor);
                var close = Swallow(cursor, Lex.GroupClose);
                return expression;
            }
            else if (cursor.Is(Lex.LParent))
            {
                return Tuple(cursor);
            }

            throw Error.NotImplemented(cursor.At());
        }


        private bool IsAtomStart(LineCursor cursor)
        {
            return cursor.More() &&
                (  cursor.Is(Lex.Number)
                || cursor.Is(Lex.String)
                || cursor.Is(Lex.LowerId)
                || cursor.Is(Lex.UpperId)
                || cursor.Is(Lex.Wildcard)
                || cursor.Is(Lex.LParent)
                || cursor.Is(Lex.LBracket)
                || cursor.Is(Lex.LBrace)
                || cursor.Is(Lex.GroupOpen)
                );
        }


        private Token Swallow(LineCursor cursor, Lex lexKind)
        {
            if (cursor.Is(lexKind))
            {
                return cursor.Advance();
            }

            throw Error.Unexpected(lexKind, cursor.At());
        }
    }
}
