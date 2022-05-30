using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class TupleExpression : Atom
    {
        public TupleExpression(Token left, Token right, IReadOnlyList<Expression> expressions)
        {
            Left = left;
            Right = right;
            Expressions = expressions;
        }

        public Token Left { get; }
        public Token Right { get; }
        public IReadOnlyList<Expression> Expressions { get; }

        public override string ToString()
        {
            var tuple = string.Join(" , ", Expressions);
            if (Expressions.Count == 0)
            {
                return $"{Left} {Right}";
            }
            return $"{Left} {tuple} {Right}";
        }
    }
}
