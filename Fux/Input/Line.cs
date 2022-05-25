namespace Fux.Input
{
    internal class Line
    {
        private readonly Tokens tokens = new();
        private readonly Lines indent = new();

        public Line() { }

        public Line(Token token)
        {
            AddToken(token);
        }

        public void AddToken(Token token)
        {
            tokens.Add(token);
        }

        public void AddIndent(Line line)
        {
            if (tokens.ToString() == "case node of")
            {
                Assert(true);
            }
            indent.Add(line);
        }

        public IReadOnlyList<Token> Tokens => tokens;

        public IReadOnlyList<Line> Lines => indent;

        public bool EOF => IsFlat && tokens.Count == 1 && tokens[0].EOF;

        public void Compress()
        {
            if (indent.Count == 1)
            {
                var first = indent.First();

                if (first.IsFlat && first.StartsWith(token => token.IsOperator()))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && EndsWith(token => token.IsOperator()))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && EndsWith(token => token.Lex == Lex.Define || token.Lex == Lex.KwElse || token.Lex == Lex.KwThen))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && first.StartsWith(token => token.Lex == Lex.Define))
                {
                    PushUp(0);
                }
            }

            var i = 0;
            while (i < indent.Count)
            {
                if (indent[i].IsAtomic)
                {
                    PushUp(i);
                }
                else
                {
                    break;
                }
            }

        }

        private Token Open(Token template)
        {
            return new Token(Lex.LParent, new Location(template.Location.Source, template.Location.Offset, 0));
        }

        private Token Close(Token template)
        {
            return new Token(Lex.RParent, new Location(template.Location.Source, template.Location.Next, 0));
        }

        private void PushUp(int lineIndex)
        {
            var line = indent.Remove(lineIndex);
            foreach (var token in line.Tokens)
            {
                tokens.Add(token);
            }
        }

        public bool EndsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.Last());
        }

        public bool StartsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.First());
        }

        public bool IsFlat => indent.Count == 0;

        public bool IsAtomic => IsFlat && (
            tokens.Count == 1 ||
            IsGrouped(tokens.First(), tokens.Last())
            );

        private bool IsGrouped(Token first, Token last)
        {
            return first.Lex == Lex.LParent && last.Lex == Lex.RParent
                || first.Lex == Lex.LBrace && last.Lex == Lex.RBrace
                || first.Lex == Lex.LBracket && last.Lex == Lex.RBracket
                ;
        }
    }
}
