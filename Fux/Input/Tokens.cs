using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Tokens : IReadOnlyList<Token>
    {
        private readonly List<Token> tokens = new();

        public Tokens Add(Token token)
        {
            tokens.Add(token);

            return this;
        }

        public Token this[int index] => tokens[index];
        public int Count => tokens.Count;
        public IEnumerator<Token> GetEnumerator() => tokens.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)tokens).GetEnumerator();

        public void Begin(Token current)
        {
            Add(new OpenToken(current));
        }

        public void End()
        {
            Add(new CloseToken(tokens.Last()));
        }

        public void Append(Tokens tokens)
        {
            foreach (var token in tokens)
            {
                Add(token);
            }
        }

        public void AppendGrouped(Tokens tokens)
        {
            Assert(tokens.Count > 0);

            if (tokens.Count == 1)
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.HardKwIf))
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.HardKwThen))
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.HardKwElse))
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.Comma))
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.LBrace))
            {
                Append(tokens);
            }
            else if (tokens.StartsWith(Lex.Operator))
            {
                Append(tokens);
            }
            else if (tokens.IsAtomic)
            {
                Append(tokens);
            }
            else
            {
                Add(new OpenToken(tokens.First()));

                foreach (var token in tokens)
                {
                    Add(token);
                }

                Add(new CloseToken(tokens.Last()));
            }
        }
        public bool IsAtomic => tokens.Count == 1 || IsDotted;

        private bool IsGrouped
        {
            get
            {
                Assert(tokens.Count >= 2);
                var first = tokens.First();
                var last = tokens.Last();

                Assert(tokens[^1] == last);

                return first.Lex == Lex.LParent && last.Lex == Lex.RParent
                    || first.Lex == Lex.LBrace && last.Lex == Lex.RBrace
                    || first.Lex == Lex.LBracket && last.Lex == Lex.RBracket
                    ;
            }
        }

        private bool IsDotted
        {
            get
            {
                return tokens.Count % 2 == 1 && tokens.Count(token => token.Lex == Lex.Dot) == tokens.Count / 2;
            }
        }

        public bool StartsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.First());
        }

        public bool StartsWith(Lex lex)
        {
            return StartsWith(token => token.Lex == lex);
        }

        public bool EndsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.Last());
        }

        public bool EndsWith(Lex lex)
        {
            return EndsWith(token => token.Lex == lex);
        }

        public bool IsExactly(Lex lex)
        {
            return tokens.Count == 1 && tokens[0].Lex == lex;
        }

        public override string ToString()
        {
            return string.Join(" ", tokens);
        }
    }
}
