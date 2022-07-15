namespace Fux.Input.Ast
{
    public interface Type : Node
    {
        Func<Type>? Resolver { get; set; }
        Type Resolved { get; }

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

            public Type InType { get; set; }
            public Type OutType { get; set; }

            public override string ToString()
            {
                return Protected($"{InType} → {OutType}");
            }
        }

        public abstract class Tuple : TypeImpl
        {
            public Tuple(params Type[] types)
            {
                Types = types.ToList();

                Assert(Types.Count >= 2 && Types.Count <= 3);
            }

            public List<Type> Types { get; }

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
            }

            public Type Type1 => Types[0];
            public Type Type2 => Types[1];
        }

        public sealed class Tuple3 : Tuple
        {
            public Tuple3(Type type1, Type type2, Type type3)
                : base(type1, type2, type3)
            {
            }

            public Type Type1 => Types[0];
            public Type Type2 => Types[1];
            public Type Type3 => Types[2];
        }

        public sealed class Unit : TypeImpl
        {
            public override string ToString()
            {
                return Lex.Symbol.Unit;
            }
        }

        public sealed class Alias : TypeImpl
        {
            public Alias(Identifier name, Decl.TypeParameterList parameters, Decl.Alias decl)
            {
                Name = name;
                Parameters = parameters;
                Decl = decl;
            }

            public Identifier Name { get; }
            public Decl.TypeParameterList Parameters { get; }
            public Decl.Alias Decl { get; }

            public override string ToString()
            {
                if (Parameters.Count > 0)
                {
                    return $"{Name}<{string.Join(",", Parameters)}>";
                }
                return $"{Name}";
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
                    return $"{Name}<{string.Join(",", Parameters)}>";
                }
                return $"{Name}";
            }
        }

        public sealed class Ctor : TypeImpl
        {
            public Ctor(Identifier name)
                : this(name, new List<Type>())
            {
            }

            public Ctor(Identifier name, List<Type> arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }
            public List<Type> Arguments { get; }

            public override void PP(Writer writer)
            {
                writer.Write(ToString());
            }

            public override string ToString()
            {
                return Protected($"{Name}{Arguments.Join(" ")}");
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

        public sealed class Field : NodeImpl
        {
            public Field(Identifier name, Type type)
            {
                Name = name;
                Type = type;
            }

            public Identifier Name { get; }
            public Type Type { get; set; }

            public override string ToString()
            {
                return $"{Name} : {Type}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Name} : {Type}");
            }
        }

        public sealed class Record : TypeImpl
        {
            public Record(Type? baseRecord, List<Field> fields)
            {
                BaseRecord = baseRecord;
                Fields = fields;
            }

            public Type? BaseRecord { get; set; }

            public List<Field> Fields { get; }

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
    }
}
