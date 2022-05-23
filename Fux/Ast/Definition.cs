using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Definition : Expression
    {
        public Definition(Token define, Expression lhs, Expression rhs)
        {
            Define = define;
            Lhs = lhs;
            Rhs = rhs;
        }

        public override bool IsAtomic => true;

        public Token Define { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            return $"{Lhs} {Define} {Rhs}";
        }
    }
}
