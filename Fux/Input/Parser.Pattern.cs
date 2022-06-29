using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    public sealed class PatternParser
    {
        public PatternParser(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }

        public List<A.Pattern> PatternList(Cursor cursor)
        {
            var patterns = new List<A.Pattern>();

            while (cursor.More() && !cursor.TerminatesSomething)
            {
                var pattern = Pattern(cursor);

                patterns.Add(pattern);
            }

            Assert(patterns.Count >= 1);

            return patterns;
        }

        public A.Pattern Lambda(Cursor cursor)
        {
            return SignPattern(cursor, true);
        }

        public A.Pattern Pattern(Cursor cursor)
        {
            var pattern = PatternX(cursor);

            if (cursor.Is(Lex.Operator) && cursor.IsWeak(Lex.Symbol.Cons))
            {
                var patterns = new List<A.Pattern> { pattern };

                do
                {
                    cursor.Swallow(Lex.Operator);

                    var patternx = PatternX(cursor);

                    patterns.Add(patternx);
                }
                while (cursor.Is(Lex.Operator) && cursor.IsWeak(Lex.Symbol.Cons));

                return new A.Pattern.Destruct(patterns);
            }

            return pattern;
        }

        private A.Pattern PatternX(Cursor cursor)
        {
            var pattern = PatternY(cursor);

            if (cursor.SwallowIf(Lex.KwAs))
            {
                var alias = new A.Pattern.LowerId(Parser.SingleLowerIdentifier(cursor));

                pattern = new A.Pattern.WithAlias(pattern, alias);
            }

            return pattern;
        }

        private A.Pattern PatternY(Cursor cursor)
        {
            if (cursor.Is(Lex.LowerId))
            {
                var pattern = SignPattern(cursor);

                return pattern;
            }
            else if (cursor.Is(Lex.UpperId))
            {
                var pattern = CtorPattern(cursor);

                return pattern;
            }
            else
            {
                var pattern = Atomic(cursor);

                return pattern;
            }
        }

        private A.Pattern Atomic(Cursor cursor)
        {
            if (cursor.Is(Lex.LowerId))
            {
                return new A.Pattern.LowerId(Parser.Identifier(cursor).SingleLower());
            }
            else if (cursor.Is(Lex.UpperId))
            {
                return new A.Pattern.UpperId(Parser.Identifier(cursor).MultiUpper());
            }
            else if (cursor.Is(Lex.Wildcard))
            {
                cursor.Swallow(Lex.Wildcard);
                var pattern = new A.Pattern.Wildcard();

                return pattern;
            }
            else if (cursor.Is(Lex.LParent))
            {
                return TupleOrCtorOrAliasPattern(cursor);
            }
            else if (cursor.Is(Lex.LBrace))
            {
                return RecordPattern(cursor);
            }
            else if (cursor.Is(Lex.LBracket))
            {
                return List(cursor);
            }
            else if (cursor.Is(Lex.Integer))
            {
                return new A.Pattern.Literal.Integer(Parser.IntegerLiteral(cursor));
            }
            else if (cursor.Is(Lex.String))
            {
                return new A.Pattern.Literal.String(Parser.StringLiteral(cursor));
            }
            else if (cursor.Is(Lex.Char))
            {
                return new A.Pattern.Literal.Char(Parser.CharLiteral(cursor));
            }
            else
            {
                Assert(false);
                throw new NotImplementedException();
            }
        }

        private List<A.Pattern> CollectAtomic(Cursor cursor)
        {
            var patterns = new List<A.Pattern>();

            while (!cursor.TerminatesSomething && cursor.IsNot(Lex.KwAs) && !cursor.IsWeak(Lex.Symbol.Cons))
            {
                var pattern = Atomic(cursor);

                patterns.Add(pattern);
            }

            return patterns;
        }

        private A.Pattern SignPattern(Cursor cursor, bool lambda = false)
        {
            if (lambda)
            {
                return new A.Pattern.Lambda(CollectAtomic(cursor));
            }
            else
            {
                var name = Parser.Identifier(cursor).SingleLower();

                return new A.Pattern.Sign(name, CollectAtomic(cursor));
            }
        }

        private A.Pattern CtorPattern(Cursor cursor)
        {
            var name = Parser.Identifier(cursor).MultiUpper();

            var patterns = new List<A.Pattern>();

            while (!cursor.TerminatesSomething && cursor.IsNot(Lex.KwAs) && !cursor.IsWeak(Lex.Symbol.Cons))
            {
                var pattern = Atomic(cursor);

                patterns.Add(pattern);
            }

            var ctor = new A.Pattern.Ctor(name, patterns.ToArray());

            return ctor;
        }

        private A.Pattern TupleOrCtorOrAliasPattern(Cursor cursor)
        {
            cursor.Swallow(Lex.LParent);

            if (cursor.SwallowIf(Lex.RParent))
            {
                return new A.Pattern.Unit();
            }

            var p1 = Pattern(cursor);

            if (cursor.SwallowIf(Lex.Comma))
            {
                var p2 = Pattern(cursor);

                if (cursor.SwallowIf(Lex.Comma))
                {
                    var p3 = Pattern(cursor);

                    cursor.Swallow(Lex.RParent);

                    return new A.Pattern.Tuple3(p1, p2, p3);
                }
                else
                {
                    cursor.Swallow(Lex.RParent);

                    return new A.Pattern.Tuple2(p1, p2);
                }
            }
            else
            {
                cursor.Swallow(Lex.RParent);

                return p1;
            }
        }

        private A.Pattern.List List(Cursor cursor)
        {
            cursor.Swallow(Lex.LBracket);

            var patterns = new List<A.Pattern>();

            if (cursor.IsNot(Lex.RBracket))
            {
                do
                {
                    var pattern = Pattern(cursor);

                    patterns.Add(pattern);
                }
                while (cursor.SwallowIf(Lex.Comma));
            }

            cursor.Swallow(Lex.RBracket);

            return new A.Pattern.List(patterns);
        }

        private A.Pattern RecordPattern(Cursor cursor)
        {
            cursor.Swallow(Lex.LBrace);

            var patterns = new List<A.Pattern>();

            if (cursor.IsNot(Lex.RBrace))
            {
                do
                {
                    var pattern = Pattern(cursor);

                    patterns.Add(pattern);
                }
                while (cursor.SwallowIf(Lex.Comma));
            }

            cursor.Swallow(Lex.RBrace);

            return new A.Pattern.Record(patterns.ToArray());
        }
    }
}
