namespace Fux.Input
{
    internal class Whites
    {
        private readonly List<Token> whites = new();
        private bool transparent = true;

        public void Add(Token white)
        {
            Assert(white.White);

            if (white.Lex == Lex.BlockComment || white.Lex == Lex.LineComment)
            {
                transparent = false;
            }
            else if (white.Lex == Lex.Newline)
            {
                transparent = true;
            }
            else
            {
                transparent = transparent && white.Lex == Lex.Space;
            }

            whites.Add(white);
        }

        public bool IsTransparent => transparent;

        public override string ToString()
        {
            return string.Join("", whites);
        }
    }
}
