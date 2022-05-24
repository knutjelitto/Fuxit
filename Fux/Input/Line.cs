using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Line
    {
        private readonly Tokens tokens = new();
        private readonly Lines lines = new();

        public void Add(Token token)
        {
            tokens.Add(token);
        }

        public void Add(Line line)
        {
            if (line.IsAtomic && false)
            {
                foreach (var token in line.Tokens)
                {
                    Add(token);
                }

                return;
            }

            lines.Add(line);
        }

        public IReadOnlyList<Token> Tokens => tokens;

        public IReadOnlyList<Line> Lines => lines;

        public bool EndsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.Last());
        }

        public bool StartsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.First());
        }

        public bool IsFlat => lines.Count == 0;

        public bool IsAtomic => IsFlat && (tokens.Count == 1 || IsGrouped(tokens.First(), tokens.Last()));

        private bool IsGrouped(Token first, Token last)
        {
            return first.Lex == Lex.LParent && last.Lex == Lex.RParent
                || first.Lex == Lex.LBrace && last.Lex == Lex.RBrace
                || first.Lex == Lex.LBracket && last.Lex == Lex.RBracket
                ;
        }
    }
}
