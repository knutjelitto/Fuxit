namespace Fux.Input.Ast
{
    internal abstract class Type : Expression
    {
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
            }

            public Identifier Name { get; }

            public override string ToString()
            {
                return $"{Name}";
            }
        }
            
        public class Parameter : Type
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

            public override string ToString()
            {
                return $"{Name}";
            }
        }

        public class Function : Type
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

        public class Tuple : Type
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

        public class Unit : Type
        {
            public Unit()
            {
            }

            public override string ToString()
            {
                return $"()";
            }
        }

        public class Constructor : Type
        {
            public Constructor(Identifier name, TypeArguments arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMultiUpper);
            }

            public Identifier Name { get; }
            public TypeArguments Arguments { get; }

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

        public class NumberClass : Special
        {
            public NumberClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "number");
            }
        }

        public class AppendableClass : Special
        {
            public AppendableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "appendable");
            }
        }

        public class ComparableClass : Special
        {
            public ComparableClass(Identifier identifier)
                : base(identifier)
            {
                Assert(identifier.Text == "comparable");
            }
        }

        internal class Record : Type
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
