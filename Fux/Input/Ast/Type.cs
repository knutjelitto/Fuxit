namespace Fux.Input.Ast
{
    internal abstract class Type : Expression
    {
        public class Concrete : Type
        {
            public Concrete(Identifier name)
            {
                Name = name;

                Assert(Name.IsMulti(Lex.UpperId));
            }

            public Identifier Name { get; }

            public override string ToString()
            {
                return $"{Name}";
            }

            public override void PP(Writer writer)
            {
                throw new NotImplementedException();
            }
        }
            
        public class Parameter : Type
        {
            public Parameter(Identifier name)
            {
                Name = name;

                Assert(Name.IsSingle(Lex.LowerId));
            }

            public Identifier Name { get; }

            public override string ToString()
            {
                return $"{Name}";
            }

            public override void PP(Writer writer)
            {
                throw new NotImplementedException();
            }
        }

        public class Function : Type
        {
            public Function(Type lhs, Type rhs)
            {
                Lhs = lhs;
                Rhs = rhs;
            }

            public Type Lhs { get; }
            public Type Rhs { get; }

            public override string ToString()
            {
                return Protected($"{Lhs} -> {Rhs}");
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{ToString()}");
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

            public override void PP(Writer writer)
            {
                throw new NotImplementedException();
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

            public override void PP(Writer writer)
            {
                throw new NotImplementedException();
            }
        }

        internal class Constructor : Type
        {
            public Constructor(Identifier name, TypeArguments arguments)
            {
                Name = name;
                Arguments = arguments;

                Assert(Name.IsMulti(Lex.UpperId));
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

            public override void PP(Writer writer)
            {
                writer.Write($"{ToString()}");
            }
        }
    }
}
