using System.Xml.Linq;

namespace Fux.Input.Ast
{
    internal abstract class Type : Expr
    {
        public new Type Resolved { get; set; }

        protected Type()
        {
            Resolved = this;
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{this}");
        }

        public class Concrete : Type
        {
            public Concrete(Identifier name)
            {
                Name = name;

                Assert(Name.IsMultiUpper);
                //Assert(Name.Text != Lex.Primitive.Char);
            }

            public Identifier Name { get; }

            public override string ToString()
            {
                return $"{Name}";
            }
        }

        public abstract class Primitive : Type
        {
            public Primitive(Identifier name, string text)
            {
                Name = name;
                Text = text;
            }

            public Identifier Name { get; }
            public string Text { get; }

            public sealed class Int : Primitive { public Int(Identifier name) : base(name, Lex.Primitive.Int) { } }
            public sealed class Float : Primitive { public Float(Identifier name) : base(name, Lex.Primitive.Float) { } }
            public sealed class Bool : Primitive { public Bool(Identifier name) : base(name, Lex.Primitive.Bool) { } }
            public sealed class String : Primitive { public String(Identifier name) : base(name, Lex.Primitive.String) { } }
            public sealed class Char : Primitive { public Char(Identifier name) : base(name, Lex.Primitive.Char) { } }
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

            public override string ToString()
            {
                return Text;
            }
        }

        public sealed class Parameter : Type
        {
            public Parameter(Identifier name)
            {
                Name = name;

                if (name.ToString() == "number")
                {
                    Assert(true);
                }

                Assert(Name.IsSingleLower);
            }

            public Identifier Name { get; }
            public string Text => Name.Text;

            public override string ToString()
            {
                return $"{Name}";
            }
        }

        public sealed class Function : Type
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

        public abstract class Tuple : Type
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

        public sealed class Unit : Type
        {
            public override string ToString()
            {
                return $"()";
            }
        }

        public sealed class UnionType : Type
        {
            public UnionType(Identifier name, TypeParameters parameters, Constructors constructors)
            {
                Name = name;
                Parameters = parameters;
                Constructors = constructors;
            }

            public Identifier Name { get; }
            public TypeParameters Parameters { get; }
            public Constructors Constructors { get; }
        }

        public class Union : Type
        {
            public Union(Identifier name, TypeArguments arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }
            public TypeArguments Arguments { get; }

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

        public class Constructor : Expr
        {
            public Constructor(Identifier name, TypeArguments arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }
            public TypeArguments Arguments { get; }

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

        public abstract class Special : Type
        {
            protected Special(Identifier identifier)
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

        public sealed class NumberClass : Special
        {
            public NumberClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "number");
            }
        }

        public sealed class AppendableClass : Special
        {
            public AppendableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "appendable");
            }
        }

        public sealed class ComparableClass : Special
        {
            public ComparableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "comparable");
            }
        }

        internal sealed class Record : Type
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
                return $"{Lex.LBrace} {joined} {Lex.RBrace}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LBrace} ");
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
                writer.WriteLine($"{Lex.RBrace}");
            }
        }
    }
}
