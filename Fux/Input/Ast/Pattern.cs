namespace Fux.Input.Ast
{
    internal abstract class Pattern : Expression
    {
        public class List : ListOf<Pattern>
        {
            public List(IEnumerable<Pattern> items) : base(items)
            {
            }
        }

        public class Unit : Pattern
        {
            public override string ToString() => Lex.Symbol.Unit;
            public override void PP(Writer writer) => writer.Write(ToString());
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
            public override void PP(Writer writer) => writer.Write(ToString());
        }

        public class Wildcard : Pattern
        {
            public override string ToString()
            {
                return Lex.Symbol.Wildcard;
            }
            
            public override void PP(Writer writer)
            {
                writer.Write(ToString());
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

            public override void PP(Writer writer)
            {
                writer.Write(ToString());
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
            public override void PP(Writer writer) => writer.Write(ToString());
        }

        public class Record : Pattern
        {

            public Record(params Pattern[] patterns)
            {
                Patterns = patterns;
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"{{{string.Join(", ", Patterns)}}}";
            public override void PP(Writer writer) => writer.Write(ToString());
        }


        public abstract class Tuple : Pattern
        {
            protected Tuple(params Pattern[] patterns)
            {
                Patterns = patterns;
            }

            public IReadOnlyList<Pattern> Patterns { get; }

            public override string ToString() => $"({string.Join(", ", Patterns)})";
            public override void PP(Writer writer) => writer.Write(ToString());
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
    }
}
