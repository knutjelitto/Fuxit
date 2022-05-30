using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Fux.Ast;

#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(ErrorBag errors, Liner liner)
        {
            Error = new ParserErrors(errors);
            Liner = liner;
        }

        public ParserErrors Error { get; }
        public Liner Liner { get; }

        public Module Module()
        {
            throw new NotImplementedException();
        }

        public Expression Outer()
        {
            var line = Liner.GetLine();
            var cursor = new TokensCursor(line);

            return Outer(cursor);
        }

        public Expression Outer(TokensCursor cursor)
        {
            Expression? outer = null;

            if (cursor.Is(Lex.KwModule) || cursor.Is("effect"))
            {
                outer = TopHeader(cursor);
            }
            else if (cursor.Is(Lex.KwImport))
            {
                outer = TopImport(cursor);
            }
            else if (cursor.Is(Lex.KwInfix))
            {
                outer = TopInfix(cursor);
            }
            else if (cursor.Is(Lex.KwType))
            {
                outer = TopType(cursor);
            }
            else
            {
                outer = Expression(cursor);
            }

            if (cursor.More())
            {
                throw Error.Internal(cursor.At(), $"can not continue at token '{cursor.At()}'");
            }

            return outer;
        }

        private Expression TopHeader(TokensCursor cursor)
        {
            var effect = false;
            if (cursor.Is("effect"))
            {
                //TODO: what's an effect?
                cursor.Advance();
                effect = true;
            }
            Swallow(cursor, Lex.KwModule);

            var path = Path(cursor);

            RecordExpression? where = null;
            if (cursor.Is("where"))
            {
                cursor.Advance();

                //TODO: what's a where?
                where = RecordLiteral(cursor);
            }

            TupleExpression? tuple = null;

            if (cursor.Is("exposing"))
            {
                Swallow(cursor, Lex.LowerId);
                tuple = TupleLiteral(cursor);
            }

            return new Header(path, effect, where, tuple);
        }

        public Import TopImport(TokensCursor cursor)
        {
            var importTok = Swallow(cursor, Lex.KwImport);

            var path = Path(cursor);

            Expression? alias = null;

            if (cursor.Is("as"))
            {
                cursor.Advance();

                alias = Expression(cursor);
            }

            Expression? exposed = null;

            if (cursor.Is("exposing"))
            {
                cursor.Advance();

                exposed = Expression(cursor);
            }

            return new Import(path, alias, exposed);
        }

        private ModulePath Path(TokensCursor cursor)
        {
            var names = new List<Identifier>();

            do
            {
                if (cursor.Is(Lex.LowerId) || cursor.Is(Lex.UpperId))
                {
                    var name = new Identifier(cursor.Advance());
                    names.Add(name);
                }

                if (cursor.Is("."))
                {
                    Swallow(cursor, Lex.Operator);
                }
                else
                {
                    break;
                }
            }
            while (true);

            return new ModulePath(names);
        }

        public InfixDefinition TopInfix(TokensCursor cursor)
        {
            var infixTok = Swallow(cursor, Lex.KwInfix);
            var assocTok = Swallow(cursor, Lex.LowerId);
            var assoc = InfixAssoc.From(assocTok.Text);
            if (assoc == null)
            {
                throw Error.IllegalInfixAssoc(assocTok);
            }
            var prioTok = Swallow(cursor, Lex.Number);
            var power = new InfixPower(prioTok);
            var operatorTok = Swallow(cursor, Lex.OperatorId);
            var operatorSymbol = new Identifier(operatorTok);
            var defineTok = Swallow(cursor, Lex.Define);
            var implementatioTok = Swallow(cursor, Lex.LowerId);
            var implementationSymbol = new Identifier(implementatioTok);

            return new InfixDefinition(assoc, power, operatorSymbol, implementationSymbol);
        }

        public Expression TopType(TokensCursor cursor)
        {
            var kwType = Swallow(cursor, Lex.KwType);

            var alias = false;
            if (cursor.Is("alias"))
            {
                Swallow(cursor, Lex.LowerId);
                alias = true;
            }

            var expression = Expression(cursor);

            return alias ? new AliasDefinition(expression) : new TypeDefinition(expression);
        }

        private TupleExpression TupleLiteral(TokensCursor cursor)
        {
            var left = Swallow(cursor, Lex.LParent);

            var expressions = new List<Expression>();

            while (cursor.IsNot(Lex.RParent))
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

        private RecordExpression RecordLiteral(TokensCursor cursor)
        {
            var left = Swallow(cursor, Lex.LBrace);

            var expressions = new List<Expression>();

            while (cursor.At().Lex != Lex.RBrace)
            {
                expressions.Add(Expression(cursor));

                if (cursor.IsNot(Lex.RBrace))
                {
                    Swallow(cursor, Lex.Comma);

                    continue;
                }
            }

            var right = Swallow(cursor, Lex.RBrace);

            return new RecordExpression(left, right, expressions);
        }


        private ListExpression ListLiteral(TokensCursor cursor)
        {
            var left = Swallow(cursor, Lex.LBracket);

            var expressions = new List<Expression>();

            while (cursor.At().Lex != Lex.RBracket)
{
                expressions.Add(Expression(cursor));

                if (cursor.IsNot(Lex.RBracket))
                {
                    Swallow(cursor, Lex.Comma);
                }
            }

            var right = Swallow(cursor, Lex.RBracket);

            return new ListExpression(left, right, expressions);
        }

        private Expression Expression(TokensCursor cursor)
        {
            var lhs = Definition(cursor);

            if (cursor.Is(Lex.Colon))
            {
                var colon = new OperatorSymbol(Swallow(cursor, Lex.Colon));
                var rhs = Definition(cursor);

                return new AnnotateExpression(colon, lhs, rhs);
            }

            return lhs;
        }

        private Expression Definition(TokensCursor cursor)
        {
            var lhs = Sequence(cursor);

            if (cursor.Is(Lex.Define))
            {
                var colon = new OperatorSymbol(Swallow(cursor, Lex.Define));
                var rhs = Sequence(cursor);

                return new DefineExpression(colon, lhs, rhs);
            }

            return lhs;
        }

        private Expression Sequence(TokensCursor cursor)
        {
            var first = Operator(cursor);

            var rest = new List<Expression>();
            while (IsAtomStart(cursor))
            {
                rest.Add(Operator(cursor));
            }

            if (rest.Count > 0)
            {
                return new ApplicationExpression(first, rest.ToArray());
            }

            return first;
        }

        private Expression InlineIf(TokensCursor cursor)
        {
            var kwIf = Swallow(cursor, Lex.KwIf);
            var condition = Expression(cursor);
            var kwThen = Swallow(cursor, Lex.KwThen);
            var whenTrue = Expression(cursor);
            var kwElse = Swallow(cursor, Lex.KwElse);
            var whenFalse = Expression(cursor);

            return new IfExpression(condition, whenTrue, whenFalse);
        }

        private Expression InlineLet(TokensCursor cursor)
        {
            var kwLet = Swallow(cursor, Lex.KwLet);
            var lets = new List<Expression>();
            while (cursor.IsNot(Lex.KwIn))
            {
                var let = Operator(cursor);

                lets.Add(let);
            }
            var kwIn = Swallow(cursor, Lex.KwIn);
            var expression = Expression(cursor);

            return new LetExpression(lets, expression);
        }

        private Expression InlineCase(TokensCursor cursor)
        {
            var kwCase = Swallow(cursor, Lex.KwCase);
            var pattern = Expression(cursor);
            var kwOf = Swallow(cursor, Lex.KwOf);

            var cases = new List<Expression>();

            while (IsAtomStart(cursor))
            {
                var expression = Operator(cursor);

                cases.Add(expression);
            }

            return new CaseExpression(pattern, cases);
        }

        private Expression Operator(TokensCursor cursor)
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

        private Expression Prefix(TokensCursor cursor)
        {
            Expression app;

            if (cursor.IsOperator())
            {
                var op = new OperatorSymbol(cursor.Advance());
                var argument = Prefix(cursor);

                app = new PrefixExpression(op, argument);
            }
            else
            {
                app = Atom(cursor);
            }

            return app;
        }

        private Expression Atom(TokensCursor cursor)
        {
            Assert(IsAtomStart(cursor));

            if (cursor.Is(Lex.LowerId))
            {
                return new Identifier(cursor.Advance());
            }
            else if (cursor.Is(Lex.UpperId))
            {
                return new Identifier(cursor.Advance());
            }
            else if (cursor.Is(Lex.OperatorId))
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
            else if (cursor.Is(Lex.String))
            {
                return new StringLiteral(cursor.Advance());
            }
            else if (cursor.Is(Lex.KwIf))
            {
                return InlineIf(cursor);
            }
            else if (cursor.Is(Lex.KwLet))
            {
                return InlineLet(cursor);
            }
            else if (cursor.Is(Lex.KwCase))
            {
                return InlineCase(cursor);
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
                return TupleLiteral(cursor);
            }
            else if (cursor.Is(Lex.LBrace))
            {
                return RecordLiteral(cursor);
            }
            else if (cursor.Is(Lex.LBracket))
            {
                return ListLiteral(cursor);
            }

            throw Error.NotImplemented(cursor.At());
        }


        private bool IsAtomStart(TokensCursor cursor)
        {
            return cursor.More() &&
                (  false
                || cursor.Is(Lex.LowerId)
                || cursor.Is(Lex.UpperId)
                || cursor.Is(Lex.OperatorId)
                || cursor.Is(Lex.Wildcard)
                || cursor.Is(Lex.Number)
                || cursor.Is(Lex.String)
                || cursor.Is(Lex.KwIf)
                || cursor.Is(Lex.KwLet)
                || cursor.Is(Lex.KwCase)
                || cursor.Is(Lex.LParent)
                || cursor.Is(Lex.LBracket)
                || cursor.Is(Lex.LBrace)
                || cursor.Is(Lex.GroupOpen)
                );
        }


        private Token Swallow(TokensCursor cursor, Lex lexKind, [CallerMemberName]string? member = null)
        {
            if (cursor.Is(lexKind))
            {
                return cursor.Advance();
            }

            throw Error.Unexpected(lexKind, cursor.At(), member);
        }
    }
}
