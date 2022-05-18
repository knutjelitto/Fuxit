using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(Lexer lexer)
        {
            Lexer = lexer;
        }

        public Lexer Lexer { get; }
    }
}
