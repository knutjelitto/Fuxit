using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Annotation : Expression
    {
        public Annotation(Token colon, Expression lhs, Expression rhs)
        {
            Colon = colon;
            Lhs = lhs;
            Rhs = rhs;
        }

        public override bool IsAtomic => true;

        public Token Colon { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            return $"{Lhs} {Colon} {Rhs}";
        }
    }
}
