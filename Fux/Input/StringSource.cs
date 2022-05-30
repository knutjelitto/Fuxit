using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class StringSource : Source
    {
        public StringSource(string name, string content)
            : base(name)
        {
            Content = content;
            TextOffset = 0;
        }

        public string Content { get; }
        public int TextOffset { get; private set; }

        public override bool EOS => TextOffset >= Content.Length;

        public override Source Clone()
        {
            return new StringSource(Name, Content);
        }

        public override bool GetNext(out char rune)
        {
            if (!EOS)
            {
                rune = Content[TextOffset++];
                return true;
            }
            rune = '\0';
            return false;
        }

        public override string ToString()
        {
            return $"source({Name})";
        }
    }
}
