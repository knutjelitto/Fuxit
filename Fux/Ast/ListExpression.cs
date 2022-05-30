using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class ListExpression : Atom
    {
        public ListExpression(Token left, Token right, IReadOnlyList<Expression> expressions)
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
            if (Expressions.Count == 0)
            {
                return $"{Left} {Right}";
            }
            var joined = string.Join(" , ", Expressions);
            return $"{Left} {joined} {Right}";
        }
    }
}
