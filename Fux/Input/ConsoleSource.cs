using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace Fux.Input
{
    internal class ConsoleSource : Source
    {
        private string line = string.Empty;
        private int lineOffset = 1;

        public override bool EOS => false;

        public override bool GetNext(out char rune)
        {
            if (lineOffset > line.Length)
            {
                Console.Write("fux> ");
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
