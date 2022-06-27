using System.Text;

namespace Fux.Input
{
    public abstract class Source : ISource
    {
        protected Source(string display, string path)
        {
            Display = display;
            Path = path;
            Text = new List<char>();
            Lines = new List<int> { 0 };
        }

        public string Display { get; }
        public string Path { get; }
        public abstract bool EOS { get; }
        public abstract bool GetNext(out char rune);
        public List<char> Text { get; }
        public List<int> Lines { get; }

        public abstract Source Clone();

        public char Ensure(int offset)
        {
            while (offset >= Text.Count)
            {
                if (GetNext(out var rune))
                {
                    Text.Add(rune);
                }
                else
                {
                    Text.Add('\0');
                }
            }
            return offset >= 0 ? Text[offset] : '\0';
        }


        public static Source FromFile(string filename)
        {
            var text = IO.File.ReadAllText(filename, Encoding.UTF8);

            return new StringSource(System.IO.Path.GetFileName(filename), filename, text);
        }

        public void NextLine(int offset)
        {
            Assert(offset <= Text.Count);
            Assert(offset > Lines.Last());

            Lines.Add(offset);
        }

        public (int line, int column) GetLineColumn(int offset)
        {
            var lineNo = GetLineNoFromIndex(offset);
            var colNo = offset - GetIndexFromLineNo(lineNo) + 1;

            return (lineNo, colNo);
        }

        public string GetText(ILocation location)
        {
            return new Runes(Text.Skip(location.Offset).Take(location.Length)).ToString();
        }

        private int GetIndexFromLineNo(int lineNo)
        {
            var lineIdx = Math.Max(0, Math.Min(lineNo - 1, Lines.Count - 1));

            return Lines[lineIdx];
        }

        private int GetLineNoFromIndex(int index)
        {
            var line = Lines.BinarySearch(Math.Max(0, index));
            if (line < 0)
            {
                return ~line;
            }
            return line + 1;
        }
    }
}
