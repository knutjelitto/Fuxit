namespace Fux.Input
{
    public class TypeParser
    {
        public TypeParser(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }

        public A.Type Type(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var type = BaseType(cursor);

                if (cursor.SwallowIf(Lex.Arrow))
                {
                    type = new A.Type.Function(type, Type(cursor));
                }

                return type;
            });
        }

        public A.Type TypeArgument(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LowerId))
                {
                    return LowerType(cursor);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    return UpperType(cursor, multi: false);
                }
                else if (cursor.Is(Lex.LeftRoundBracket))
                {
                    return RoundType(cursor);
                }
                else if (cursor.Is(Lex.LeftCurlyBracket))
                {
                    return RecordType(cursor);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Type BaseType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LowerId))
                {
                    return LowerType(cursor);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    return UpperType(cursor, true);
                }
                if (cursor.Is(Lex.LeftRoundBracket))
                {
                    return RoundType(cursor);
                }
                else if (cursor.Is(Lex.LeftCurlyBracket))
                {
                    return RecordType(cursor);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Type.Custom UpperType(Cursor cursor, bool multi)
        {
            return cursor.Scope(cursor =>
            {
                var name = Parser.Identifier(cursor).MultiUpper();

                var arguments = new List<A.Type>();

                if (multi)
                {
                    do
                    {
                        while (cursor.More() && !cursor.TerminatesSomething)
                        {
                            var argument = TypeArgument(cursor);
                            arguments.Add(argument);
                        }
                    }
                    while (cursor.More() && !cursor.TerminatesSomething);
                }

                return new A.Type.Custom(name, arguments);
            });
        }

        private A.Type LowerType(Cursor cursor)
        {
            return cursor.Scope<A.Type>(cursor =>
            {
                var name = Parser.Identifier(cursor).SingleLower();

                if (name.ToString() == "number")
                {
                    return new A.Type.NumberClass(name);
                }

                if (name.ToString() == "appendable")
                {
                    return new A.Type.AppendableClass(name);
                }

                if (name.ToString() == "comparable")
                {
                    return new A.Type.ComparableClass(name);
                }

                return new A.Type.Parameter(name);
            });
        }

        private A.Type RoundType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LeftRoundBracket);

                var types = new List<A.Type>();

                if (cursor.IsNot(Lex.RightRoundBracket))
                {
                    do
                    {
                        var type = Type(cursor);

                        types.Add(type);
                    }
                    while (cursor.SwallowIf(Lex.Comma));
                }

                cursor.Swallow(Lex.RightRoundBracket);

                if (types.Count == 0)
                {
                    return new A.Type.Unit();
                }
                else if (types.Count == 1)
                {
                    return types[0];
                }
                else if (types.Count == 2)
                {
                    return new A.Type.Tuple2(types[0], types[1]);
                }
                else if (types.Count == 3)
                {
                    return new A.Type.Tuple3(types[0], types[1], types[2]);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Type RecordType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LeftCurlyBracket);

                var fields = new List<A.Type.Field>();

                A.Type? baseType = null;

                if (cursor.IsNot(Lex.RCurlyBracket))
                {
                    var state = cursor.State;

                    baseType = Type(cursor);

                    Assert(baseType is A.Type.Parameter);

                    if (cursor.IsNot(Lex.Bar))
                    {
                        baseType = null;
                        cursor.Reset(state);
                    }
                    else
                    {
                        cursor.Swallow(Lex.Bar);
                    }

                    do
                    {
                        fields.Add(Field(cursor));
                    }
                    while (cursor.SwallowIf(Lex.Comma));
                }

                cursor.Swallow(Lex.RCurlyBracket);

                return new A.Type.Record(baseType, fields);

                A.Type.Field Field(Cursor cursor)
                {
                    var name = Parser.Identifier(cursor);
                    cursor.Swallow(Lex.Colon);
                    var type = Type(cursor);

                    return new A.Type.Field(name, type);
                }
            });
        }
    }
}
