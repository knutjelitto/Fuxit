using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class InfixPower : Expression
    {
        public InfixPower(Token number)
        {
            Assert(number.Lex == Lex.Number);

            Number = number;
        }

        public Token Number { get; }

        public override bool IsAtomic => true;

        public override string ToString() => $"{Number}";
    }
}
