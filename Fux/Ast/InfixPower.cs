using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class InfixPower
    {
        public InfixPower(Token number)
        {
            Assert(number.Lex == Lex.Number);

            Number = number;
        }

        public Token Number { get; }

        public override string ToString() => $"{Number}";
    }
}
