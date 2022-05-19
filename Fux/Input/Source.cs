using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal abstract class Source
    {
        protected Source(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract bool EOS { get; }
        public abstract bool GetNext(out char rune);
        public List<char> Text { get; }

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
            var text = File.ReadAllText(filename, Encoding.UTF8);

            return new StringSource(filename, text);
        }
    }
}
