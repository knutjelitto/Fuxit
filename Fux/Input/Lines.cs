using System.Collections;

namespace Fux.Input
{
    internal class Lines : IReadOnlyList<Line>
    {
        private readonly List<Line> lines = new List<Line>();

        public void Add(Line line)
        {
            if (lines.Count > 0)
            {
                var last = lines.Last();
                if (last.IsFlat && line.IsFlat && (last.EndsWith(TailContinue) || line.StartsWith(HeadContinue)))
                {
                    Assert(last.IsFlat && line.IsFlat);
                    foreach (var token in line.Tokens)
                    {
                        last.AddToken(token);
                    }

                    return;
                }
            }

            lines.Add(line);
        }

        public Line Remove(int index)
        {
            var line = lines[index];
            lines.RemoveAt(index);
            return line;
        }

        public Line this[int index] => lines[index];
        public int Count => lines.Count;
        public IEnumerator<Line> GetEnumerator() => lines.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)lines).GetEnumerator();

        private bool TailContinue(Token token)
        {
            return token.Lex == Lex.Comma
                || token.Lex == Lex.LParent
                || token.Lex == Lex.LBrace
                || token.Lex == Lex.LBracket
                || token.Lex == Lex.KwElse
                || token.Lex == Lex.KwThen
                || token.IsOperator()
                ;
        }

        private bool HeadContinue(Token token)
        {
            return token.Lex == Lex.Comma
                || token.Lex == Lex.RParent
                || token.Lex == Lex.RBrace
                || token.Lex == Lex.RBracket
                || token.Lex == Lex.KwElse
                || token.Lex == Lex.KwThen
                || token.IsOperator();
                ;

        }
    }
}
