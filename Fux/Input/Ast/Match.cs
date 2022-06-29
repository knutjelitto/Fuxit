namespace Fux.Input.Ast
{
    public abstract class Match : Node.NodeImpl
    {
        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public class Lower : Match
        {
            public Lower(Identifier identifier)
            {
                Identifier = identifier;
            }

            public Identifier Identifier { get; }

            public override string ToString() => Identifier.ToString();
        }

        public class Wildcard : Match
        {
            public override string ToString() => Lex.Symbol.Wildcard;
        }

        public class List : Match
        {
            public List(List<Match> matches)
            {
                Matches = matches.ToArray();
            }

            public IReadOnlyList<Match> Matches { get; }
        }

        public class Ctor : Match
        {
            public Ctor(Identifier name, List<Match> matches)
            {
                Name = name.MultiUpper();
                Matches = matches.ToArray();
            }

            public Identifier Name { get; }
            public IReadOnlyList<Match> Matches { get; }
        }

        public abstract class Tuple : Match
        {
            protected Tuple(params Match[] matches)
            {
                Matches = matches;
            }

            public IReadOnlyList<Match> Matches { get; }
        }

        public class Tuple2 : Tuple
        {
            public Tuple2(Match match1, Match match2)
                : base(match1, match2)
            {
            }

            public Match Match1 => Matches[0];
            public Match Match2 => Matches[1];
        }

        public class Tuple3 : Tuple
        {
            public Tuple3(Match match1, Match match2, Match match3)
                : base(match1, match2, match3)
            {
            }

            public Match Match1 => Matches[0];
            public Match Match2 => Matches[1];
            public Match Match3 => Matches[2];
        }

        public abstract class Literal : Match
        {
            protected Literal(Token token)
            {
                Token = token;
            }

            public Token Token { get; }

            public class Int : Literal
            {
                public Int(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.Integer);
                }
            }
        }

        public class Destruct : Match
        {
            public Destruct(List<Match> matches)
            {
                Matches = matches.ToArray();
            }

            public IReadOnlyList<Match> Matches { get; }
        }

        public class Unit : Match
        {
            public override string ToString() => Lex.Symbol.Unit;
        }
    }
}
