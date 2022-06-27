using System.Xml.Linq;

namespace Fux.Building.AlgorithmW
{
    internal abstract record Type
    {
        internal record Variable(TypeVariable TypeVar) : Type
        {
            public override string ToString() => $"var({TypeVar})";
        }

        internal sealed record Function(Type InType, Type OutType) : Type
        {
            public override string ToString() => $"({InType} → {OutType})";
        }

        internal abstract record Tuple(IReadOnlyList<Type> Types) : Type;

        internal sealed record Tuple2(Type Type1, Type Type2) : Tuple(new Type[] { Type1, Type2 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2})";
            }
        }

        internal sealed record Tuple3(Type Type1, Type Type2, Type Type3) : Tuple(new Type[] { Type1, Type2, Type3 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2}, {Type3})";
            }
        }

        internal record List(Type Type) : Type
{
            public override string ToString() => $"{Lex.Primitive.List}<{Type}>";
        }

        internal record Concrete(string Name, IReadOnlyList<Type>? Arguments = null) : Type
        {
            public override string ToString() => $"{Name}{arguments}";

            private string arguments
            {
                get
                {
                    if (Arguments != null && Arguments.Count > 0)
                    {
                        return $"<{string.Join(", ", Arguments)}>";
                    }
                    return "";
                }
            }
        }

        internal abstract record Primitive(string Name) : Type
        {
            public override string ToString() => Name;
        }

        internal sealed record Integer() : Primitive(Lex.Primitive.Int)
        {
            public override string ToString() => Name;
        }

        internal sealed record Float() : Primitive(Lex.Primitive.Float)
        {
            public override string ToString() => Name;
        }

        internal sealed record Bool() : Primitive(Lex.Primitive.Bool)
        {
            public override string ToString() => Name;
        }

        internal sealed record String() : Primitive(Lex.Primitive.String)
        {
            public override string ToString() => Name;
        }

        internal sealed record Char() : Primitive(Lex.Primitive.Char)
        {
            public override string ToString() => Name;
        }
    }
}
