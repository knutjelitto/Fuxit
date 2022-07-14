namespace Fux.Input.Ast
{
    public interface Type : Node
    {
        Func<Type>? Resolver { get; set; }
        public Type Resolved { get; }

        public abstract class TypeImpl : NodeImpl, Type
        {
            private Type? resolved;

            protected TypeImpl()
            {
                Resolver = () => this;
                //Resolver = null;
            }

            public Func<Type>? Resolver { get; set; }

            public Type Resolved => resolved ??= GetResolved();

            private Type GetResolved()
            {
                Assert(Resolver != null);
                return Resolver();
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{this}");
            }

        }

        public class Concrete : TypeImpl
        {
            public Concrete(Identifier name)
            {
                Name = name;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }

            public override string ToString() => $"{Name}";
        }

        public abstract class Primitive : TypeImpl
        {
            public Primitive(Identifier name, string text)
            {
                Name = name;
                Text = text;
            }

            public Identifier Name { get; }
            public string Text { get; }
            public override string ToString() => Text;
        }


        public sealed class Integer : Primitive
        {
            public Integer(Identifier name) : base(name, Lex.Primitive.Int)
            { }
        }

        public sealed class Float : Primitive
        {
            public Float(Identifier name) : base(name, Lex.Primitive.Float)
            { }
        }

        public sealed class Bool : Primitive
        {
            public Bool(Identifier name) : base(name, Lex.Primitive.Bool)
            { }
        }

        public sealed class String : Primitive
        {
            public String(Identifier name) : base(name, Lex.Primitive.String)
            { }
        }

        public sealed class Char : Primitive
        {
            public Char(Identifier name) : base(name, Lex.Primitive.Char)
            { }
        }

        public sealed class List : Primitive
        {
            public List(Identifier name, Type argument)
                : base(name, Lex.Primitive.List)
            {
                Argument = argument;
            }

            public Type Argument { get; }

            public override string ToString()
            {
                return $"{Name}<{Argument}>";
            }
        }

        public sealed class Parameter : TypeImpl
        {
            public Parameter(Identifier name)
            {
                Name = name.SingleLower();
            }

            public Identifier Name { get; }
            public string Text => Name.Text;

            public override string ToString()
            {
                return $"{Name}";
            }
        }

        public sealed class Function : TypeImpl
        {
            public Function(Type inType, Type outType)
            {
                InType = inType;
                OutType = outType;
            }

            public Type InType { get; }
            public Type OutType { get; }

            public override string ToString()
            {
                return Protected($"{InType} → {OutType}");
            }
        }

        public abstract class Tuple : TypeImpl
        {
            public Tuple(params Type[] types)
            {
                Types = types;

                Assert(Types.Count >= 2 && Types.Count <= 3);
            }

            public IReadOnlyList<Type> Types { get; }

            public override string ToString()
            {
                return $"({string.Join(", ", Types)})";
            }
        }

        public sealed class Tuple2 : Tuple
        {
            public Tuple2(Type type1, Type type2)
                : base(type1, type2)
            {
                Type1 = type1;
                Type2 = type2;
            }

            public Type Type1 { get; }
            public Type Type2 { get; }
        }

        public sealed class Tuple3 : Tuple
        {
            public Tuple3(Type type1, Type type2, Type type3)
                : base(type1, type2, type3)
            {
                Type1 = type1;
                Type2 = type2;
                Type3 = type3;
            }

            public Type Type1 { get; }
            public Type Type2 { get; }
            public Type Type3 { get; }
        }

        public sealed class Unit : TypeImpl
        {
            public override string ToString()
            {
                return Lex.Symbol.Unit;
            }
        }

        public sealed class Custom : TypeImpl
        {
            public Custom(Identifier name, Decl.TypeParameterList parameters)
            {
                Name = name;
                Parameters = parameters;
            }

            public Identifier Name { get; }
            public Decl.TypeParameterList Parameters { get; }

            public override string ToString()
            {
                if (Parameters.Count > 0)
                {
                    var parameters = string.Join(",", Parameters);
                    return $"{Name}<{Parameters}>";
                }
                return $"{Name}";
            }
        }

        public class Ctor : TypeImpl
        {
            public Ctor(Identifier name, TypeArgumentList arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }
            public TypeArgumentList Arguments { get; }

            public override void PP(Writer writer)
            {
                writer.Write(ToString());
            }

            public override string ToString()
            {
                if (Arguments.Count == 0)
                {
                    return Protected($"{Name}");
                }
                return Protected($"{Name} {Arguments}");
            }
        }

        public abstract class TypeClass : TypeImpl
        {
            protected TypeClass(Identifier identifier)
            {
                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public string Text => Identifier.Text;

            public override string ToString()
            {
                return Identifier.ToString();
            }
        }

        public sealed class NumberClass : TypeClass
        {
            public NumberClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "number");
            }
        }

        public sealed class AppendableClass : TypeClass
        {
            public AppendableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "appendable");
            }
        }

        public sealed class ComparableClass : TypeClass
        {
            public ComparableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "comparable");
            }
        }

        public sealed class Record : TypeImpl
        {
            public Record(Type? baseRecord, IEnumerable<FieldDefine> fields)
            {
                BaseRecord = baseRecord;
                Fields = fields.ToArray();
            }

            public Type? BaseRecord { get; }

            public IReadOnlyList<FieldDefine> Fields { get; }

            public override string ToString()
            {
                var joined = string.Join(", ", Fields);
                return $"{Lex.LeftCurlyBracket} {joined} {Lex.RCurlyBracket}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LeftCurlyBracket} ");
                var more = false;
                foreach (var field in Fields)
                {
                    if (more)
                    {
                        writer.WriteLine();
                        writer.Write($"{Lex.Comma} ");
                    }
                    more = true;
                    field.PP(writer);
                }
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
                writer.WriteLine($"{Lex.RCurlyBracket}");
            }
        }

        public sealed class Argument : TypeImpl
        {
            public override void PP(Writer writer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
