#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Input.Ast
{
    public interface Pattern : Node
    {
        public abstract class PatternImpl : NodeImpl, Pattern
        {
            public override void PP(Writer writer) => writer.Write($"{this}");
        }

        public class Unit : PatternImpl
        {
            public override string ToString() => Lex.Symbol.Unit;
        }

        public class LowerId : PatternImpl
        {
            public LowerId(Identifier identifier)
            {
                Assert(identifier.IsSingleLower);

                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public void Deconstruct(out Identifier identifier)
            {
                identifier = Identifier;
            }

            public override string ToString() => Identifier.ToString();
        }

        public class UpperId : PatternImpl
        {
            public UpperId(Identifier identifier)
            {
                Assert(identifier.IsMultiUpper);

                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public override string ToString() => Identifier.ToString();
        }

        public class Wildcard : PatternImpl
        {
            public override string ToString() => Lex.Symbol.Wildcard;
        }

        public class Signature : PatternImpl
        {
            public Signature(Identifier name, List<Pattern> parameters)
            {
                Assert(name.IsSingleLower);

                Name = name;
                Parameters = parameters.ToArray();
            }

            public Identifier Name { get; }
            public IReadOnlyList<Pattern> Parameters { get; }

            public override string ToString()
            {
                if (Parameters.Count == 0)
                {
                    return $"{Name}";
                }

                return $"({Name} {string.Join(" ", Parameters)})";
            }
        }

        public class Lambda : PatternImpl
        {
            public Lambda(List<Pattern> parameters)
            {
                Parameters = parameters;
            }

            public List<Pattern> Parameters { get; }

            public override string ToString()
            {
                return $"({string.Join(" ", Parameters)})";
            }
        }

        public class Ctor : PatternImpl
        {
            public Ctor(Identifier name, params Pattern[] arguments)
            {
                Assert(name.IsMultiUpper);

                Name = name;
                Arguments = arguments;
            }

            public Identifier Name { get; }
            public IReadOnlyList<Pattern> Arguments { get; }

            public override string ToString()
            {
                if (Arguments.Count == 0)
                {
                    return $"{Name}";
                }

                return $"({Name} {string.Join(" ", Arguments)})";
            }
        }

        public class WithAlias : PatternImpl
        {
            public WithAlias(Pattern pattern, LowerId alias)
            {
                Pattern = pattern;
                Alias = alias;
            }

            public Pattern Pattern { get; }
            public LowerId Alias { get; }

            public override string ToString() => $"({Pattern} {Lex.KwAs} {Alias})";
        }

        public class Record : PatternImpl
        {

            public Record(params Pattern[] patterns)
            {
                Patterns = patterns;
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"{{{string.Join(", ", Patterns)}}}";
        }


        public abstract class Tuple : PatternImpl
        {
            protected Tuple(params Pattern[] patterns)
            {
                Patterns = patterns.ToList();
            }

            public List<Pattern> Patterns { get; }

            public override string ToString() => $"({string.Join(", ", Patterns)})";
        }

        public class Tuple2 : Tuple
        {
            public Tuple2(Pattern pattern1, Pattern pattern2)
                : base(pattern1, pattern2)
            {
            }

            public Pattern Pattern1 => Patterns[0];
            public Pattern Pattern2 => Patterns[1];

            public void Deconstruct(out Pattern pattern1, out Pattern pattern2)
            {
                pattern1 = Patterns[0];
                pattern2 = Patterns[1];
            }
        }

        public class Tuple3 : Tuple
        {
            public Tuple3(Pattern pattern1, Pattern pattern2, Pattern pattern3)
                : base(pattern1, pattern2, pattern3)
            {
            }

            public Pattern Pattern1 => Patterns[0];
            public Pattern Pattern2 => Patterns[1];
            public Pattern Pattern3 => Patterns[2];
        }

        public class List : PatternImpl
        {
            public List(List<Pattern> patterns)
            {
                Patterns = patterns;
            }

            public List<Pattern> Patterns { get; }

            public override string ToString() => $"[{string.Join(", ", Patterns)}]";
        }

        public abstract class Literal : PatternImpl
        {
            public Literal(Expr.Literal lit)
            {
                Lit = lit;
            }

            public Expr.Literal Lit { get; }

            public override string ToString() => Lit.ToString();

            public class Integer : Literal
            {
                public Integer(Expr.Literal.Integer literal) : base(literal)
                {
                    Value = literal.Value;
                }

                public long Value { get; }
            }

            public class Float : Literal
            {
                public Float(Expr.Literal.Float literal) : base(literal) { }
            }

            public class String : Literal
            {
                public String(Expr.Literal.String literal) : base(literal) { }
            }

            public class Char : Literal
            {
                public Char(Expr.Literal.Char literal) : base(literal) { }
            }
        }

        public class Cons : PatternImpl
        {
            public Cons(Pattern first, Pattern rest)
            {
                First = first;
                Rest = rest;
            }
            public Pattern First { get; set; }
            public Pattern Rest { get; set; }

            public override string ToString() => $"{First} {Lex.Symbol.Cons} {Rest}";
        }

    }
}
