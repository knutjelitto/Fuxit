namespace Fux.Input.Ast
{
    internal abstract class Type : Expression
    {
        public override void PP(Writer writer)
        {
            writer.Write($"{this}");
        }

        public sealed class Concrete : Type
        {
            public Concrete(Identifier name)
            {
                Name = name;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }

            public override string ToString()
            {
                return $"{Name}";
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
            public Function(Type typeIn, Type typeOut)
            {
                TypeIn = typeIn;
                TypeOut = typeOut;
            }

            public Type TypeIn { get; }
            public Type TypeOut { get; }

            public override string ToString()
            {
                return Protected($"{TypeIn} → {TypeOut}");
            }
        }

        public sealed class Tuple : Type
        {
            public Tuple(IEnumerable<Type> types)
            {
                Types = types.ToArray();

                Assert(Types.Count >= 2);
            }

            public IReadOnlyList<Type> Types { get; }

            public override string ToString()
            {
                return $"({string.Join(", ", Types)})";
            }
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

        public class Constructor : Expression
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
