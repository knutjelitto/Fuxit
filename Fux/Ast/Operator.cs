using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Operator : Symbol
    {
        public Operator(Token token) : base(token)
        {
        }

        public string Text => Token.ToString();

        public override string ToString()
        {
            return $"({Token})";
        }
    }
}
