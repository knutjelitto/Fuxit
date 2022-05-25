namespace Fux.Input
{
    [DebuggerDisplay("{Dbg()}")]
    internal class Line
    {
        private readonly Tokens tokens = new();
        private readonly Lines lines = new();

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
            lines.Add(line);
        }

        public Tokens Tokens => tokens;

        public Lines Lines => lines;

        public bool EOF => IsFlat && tokens.Count == 1 && tokens[0].EOF;

        public void Compress()
        {
            if (lines.Count == 1)
            {
                var first = lines.First();

                Assert(first.IsFlat);

                if (first.IsFlat && first.StartsWith(token => token.IsOperator()))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && EndsWith(token => token.IsOperator()))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && EndsWith(token => token.Lex == Lex.Assign || token.Lex == Lex.Colon || token.Lex == Lex.KwElse || token.Lex == Lex.KwThen))
                {
                    PushUp(0);
                }
                else if (first.IsFlat && first.StartsWith(token => token.Lex == Lex.Assign))
                {
                    PushUp(0);
                }
            }

            var i = 0;
            while (i < lines.Count)
            {
                if (lines[i].IsAtomic)
                {
                    PushUp(i);
                }
                else
                {
                    PushUpGrouped(i);
                }
            }
        }

        private Token Open(Token template)
        {
            return new OpenToken(template);
        }

        private Token Close(Token template)
        {
            return new CloseToken(template);
        }

        private void PushUp(int lineIndex)
        {
            var line = lines.Remove(lineIndex);
            foreach (var token in line.Tokens)
            {
                tokens.Add(token);
            }
        }

        private void PushUpGrouped(int lineIndex)
        {
            var line = lines.Remove(lineIndex);
            tokens.Add(Open(line.tokens.First()));
            foreach (var token in line.Tokens)
            {
                tokens.Add(token);
            }
            tokens.Add(Close(line.tokens.Last()));
        }

        public bool EndsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.Last());
        }

        public bool StartsWith(Func<Token, bool> predicate)
        {
            return tokens.Count > 0 && predicate(tokens.First());
        }

        public bool IsFlat => lines.Count == 0;

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

        public string Dbg()
        {
            var joined = string.Join(" ", tokens);

            if (lines.Count > 0)
            {
                return $"{joined} +...";
            }
            return joined;
        }
    }
}
