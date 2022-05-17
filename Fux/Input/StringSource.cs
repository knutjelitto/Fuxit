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
        public StringSource(string text)
        {
            Text = text;
            TextOffset = 0;
        }

        public string Text { get; }
        public int TextOffset { get; private set; }

        public override bool EOS => TextOffset >= Text.Length;

        public override bool GetNext(out Rune rune)
        {
            if (!EOS)
            {
                var result = Rune.DecodeFromUtf16(Text[TextOffset..], out rune, out var consumed);
                Assert(result == OperationStatus.Done);
                TextOffset += consumed;
                return true;
            }
            rune = Rune.ReplacementChar;
            return false;
        }
    }
}
