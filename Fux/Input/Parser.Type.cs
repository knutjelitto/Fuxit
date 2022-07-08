using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    public partial class Parser
    {
        private A.Type TypeArgument(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LowerId))
                {
                    var name = Identifier(cursor).SingleLower();

                    return new A.Type.Parameter(name);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    var name = Identifier(cursor).MultiUpper();

                    return new A.Type.Concrete(name);
                }
                else if (cursor.Is(Lex.LParent))
                {
                    return BaseType(cursor);
                }
                else if (cursor.Is(Lex.LBrace))
                {
                    return Type(cursor);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Type.Ctor Construction(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var name = Identifier(cursor).MultiUpper();

                var arguments = new A.TypeArgumentList();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        arguments.Add(TypeArgument(cursor));
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

                return new A.Type.Ctor(name, arguments);
            });
        }

        private A.Type Type(Cursor cursor)
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

        private A.Type BaseType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LParent))
                {
                    cursor.Swallow(Lex.LParent);

                    var types = new List<A.Type>();

                    if (cursor.IsNot(Lex.RParent))
                    {
                        do
                        {
                            var type = Type(cursor);

                            types.Add(type);
                        }
                        while (cursor.SwallowIf(Lex.Comma));
                    }

                    cursor.Swallow(Lex.RParent);

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
                }
                else if (cursor.Is(Lex.LBrace))
                {
                    return RecordType(cursor);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    return Construction(cursor);
                }
                else if (cursor.Is(Lex.LowerId))
                {
                    var name = Identifier(cursor).SingleLower();

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
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Type RecordType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LBrace);

                var fields = new List<A.FieldDefine>();

                A.Type? baseType = null;

                if (cursor.IsNot(Lex.RBrace))
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

                cursor.Swallow(Lex.RBrace);

                return new A.Type.Record(baseType, fields.Cast<A.FieldDefine>());

                A.FieldDefine Field(Cursor cursor)
                {
                    var name = Identifier(cursor);
                    cursor.Swallow(Lex.Colon);
                    var type = Type(cursor);

                    return new A.FieldDefine(name, type);
                }
            });
        }
    }
}
