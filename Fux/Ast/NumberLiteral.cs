using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class NumberLiteral : Literal
    {
        public NumberLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Number);
        }
    }
}
