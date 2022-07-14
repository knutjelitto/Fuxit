namespace Fux.Input
{
    public sealed class PatternParser
    {
        public PatternParser(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }
        public ExprParser Expr => Parser.Expr;

        public A.Pattern.Lambda Lambda(Cursor cursor)
        {
            return new A.Pattern.Lambda(CollectAtomic(cursor));
        }

        public A.Pattern Pattern(Cursor cursor)
        {
            var pattern = PatternX(cursor);

            if (cursor.Is(Lex.Operator) && cursor.IsWeak(Lex.Symbol.Cons))
            {
                cursor.Swallow(Lex.Operator);

                var rest = Pattern(cursor);

                return new A.Pattern.DeCons(pattern, rest);
            }

            return pattern;
        }

        // ----- private -----

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
            else if (cursor.Is(Lex.LeftRoundBracket))
            {
                return TupleOrCtorOrAliasPattern(cursor);
            }
            else if (cursor.Is(Lex.LeftCurlyBracket))
            {
                return RecordPattern(cursor);
            }
            else if (cursor.Is(Lex.LeftSquareBracket))
            {
                return ListPattern(cursor);
            }
            else if (cursor.Is(Lex.Integer))
            {
                return new A.Pattern.Literal.Integer(Expr.IntegerLiteral(cursor));
            }
            else if (cursor.Is(Lex.Float))
            {
                return new A.Pattern.Literal.Float(Expr.FloatLiteral(cursor));
            }
            else if (cursor.Is(Lex.String))
            {
                return new A.Pattern.Literal.String(Expr.StringLiteral(cursor));
            }
            else if (cursor.Is(Lex.Char))
            {
                return new A.Pattern.Literal.Char(Expr.CharLiteral(cursor));
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

        private A.Pattern SignPattern(Cursor cursor)
        {
            var name = Parser.Identifier(cursor).SingleLower();

            return new A.Pattern.Signature(name, CollectAtomic(cursor));
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

            var ctor = new A.Pattern.DeCtor(name, patterns.ToArray());

            return ctor;
        }

        private A.Pattern TupleOrCtorOrAliasPattern(Cursor cursor)
        {
            cursor.Swallow(Lex.LeftRoundBracket);

            if (cursor.SwallowIf(Lex.RightRoundBracket))
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

                    cursor.Swallow(Lex.RightRoundBracket);

                    return new A.Pattern.Tuple3(p1, p2, p3);
                }
                else
                {
                    cursor.Swallow(Lex.RightRoundBracket);

                    return new A.Pattern.Tuple2(p1, p2);
                }
            }
            else
            {
                cursor.Swallow(Lex.RightRoundBracket);

                return p1;
            }
        }

        private A.Pattern.List ListPattern(Cursor cursor)
        {
            cursor.Swallow(Lex.LeftSquareBracket);

            var patterns = new List<A.Pattern>();

            if (cursor.IsNot(Lex.RightSquareBracket))
            {
                do
                {
                    var pattern = Pattern(cursor);

                    patterns.Add(pattern);
                }
                while (cursor.SwallowIf(Lex.Comma));
            }

            cursor.Swallow(Lex.RightSquareBracket);

            return new A.Pattern.List(patterns);
        }

        private A.Pattern RecordPattern(Cursor cursor)
        {
            cursor.Swallow(Lex.LeftCurlyBracket);

            var patterns = new List<A.Pattern>();

            if (cursor.IsNot(Lex.RCurlyBracket))
            {
                do
                {
                    var pattern = Pattern(cursor);

                    patterns.Add(pattern);
                }
                while (cursor.SwallowIf(Lex.Comma));
            }

            cursor.Swallow(Lex.RCurlyBracket);

            return new A.Pattern.Record(patterns.ToArray());
        }
    }
}
