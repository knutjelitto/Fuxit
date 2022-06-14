namespace Fux.Input
{
    internal class ConsoleSource : Source
    {
        private string line = string.Empty;
        private int lineOffset = 1;

        public ConsoleSource()
            : base("<console>", "/dev/con")
        {
        }

        public override bool EOS => false;

        public override Source Clone()
        {
            return new ConsoleSource();
        }

        public override bool GetNext(out char rune)
        {
            if (lineOffset > line.Length)
            {
                Terminal.Write("fux> ");
                line = Console.ReadLine() ?? string.Empty;
                lineOffset = 0;
            }

            if (lineOffset < line.Length)
            {
                rune = line[lineOffset++];
                return true;
            }

            Assert(lineOffset == line.Length);
            rune = '\n';
            lineOffset += 1;
            return true;
        }
    }
}
