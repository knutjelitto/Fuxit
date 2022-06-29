namespace Fux.Input.Ast
{
    public abstract class Pattern : Expr.ExprImpl
    {
        public override void PP(Writer writer) => writer.Write($"{this}");

        public class Unit : Pattern
        {
            public override string ToString() => Lex.Symbol.Unit;
        }

        public class LowerId : Pattern
        {
            public LowerId(Identifier identifier)
            {
                Assert(identifier.IsSingleLower);

                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public override string ToString() => Identifier.ToString();
        }

        public class UpperId : Pattern
        {
            public UpperId(Identifier identifier)
            {
                Assert(identifier.IsMultiUpper);

                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public override string ToString() => Identifier.ToString();
        }

        public class Wildcard : Pattern
        {
            public override string ToString() => Lex.Symbol.Wildcard;
        }

        public class Sign : Pattern
        {
            public Sign(Identifier name, List<Pattern> parameters)
            {
                Assert(name.IsSingleLower);

                Name = name;
                Parameters = parameters.ToArray();
            }

            public Identifier Name { get; }
            public IReadOnlyList<Pattern> Parameters { get; }

            public override string ToString()
            {
                var parameters = Parameters.Count == 0 ? "" : $" {string.Join(" ", Parameters)}";
                return $"({Name}{parameters})";
            }
        }

        public class Lambda : Pattern
        {
            public Lambda(List<Pattern> parameters)
            {
                Parameters = parameters.ToArray();
            }

            public IReadOnlyList<Pattern> Parameters { get; }

            public override string ToString()
            {
                return $"({string.Join(" ", Parameters)})";
            }
        }

        public class Ctor : Pattern
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
                var arguments = Arguments.Count == 0 ? "" : $" {string.Join(" ", Arguments)}";
                return $"({Name}{arguments})";
            }
        }

        public class WithAlias : Pattern
        {
            public WithAlias(Pattern pattern, LowerId alias)
            {
                Pattern = pattern;
                Alias = alias;
            }

            public Pattern Pattern { get; }
            public new LowerId Alias { get; }

            public override string ToString() => $"({Pattern} {Lex.KwAs} {Alias})";
        }

        public class Record : Pattern
        {

            public Record(params Pattern[] patterns)
            {
                Patterns = patterns;
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"{{{string.Join(", ", Patterns)}}}";
        }


        public abstract class Tuple : Pattern
        {
            protected Tuple(params Pattern[] patterns)
            {
                Patterns = patterns;
            }

            public IReadOnlyList<Pattern> Patterns { get; }

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

        public class List : Pattern
        {
            public List(List<Pattern> patterns)
            {
                Patterns = patterns.ToArray();
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"[{string.Join(", ", Patterns)}]";
        }

        public abstract class Literal : Pattern
        {
            public Literal(A.Literal lit)
            {
                Lit = lit;
            }

            public A.Literal Lit { get; }

            public override string ToString() => Lit.ToString();

            public class Integer : Literal
            {
                public Integer(IntegerLiteral literal) : base(literal) { }
            }

            public class String : Literal
            {
                public String(StringLiteral literal) : base(literal) { }
            }

            public class Char : Literal
            {
                public Char(CharLiteral literal) : base(literal) { }
            }
        }

        public class Destruct : Pattern
        {
            public Destruct(List<Pattern> patterns)
            {
                Patterns = patterns.ToArray();
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"{string.Join($" {Lex.Symbol.Cons} ", Patterns)}";
        }

    }
}
