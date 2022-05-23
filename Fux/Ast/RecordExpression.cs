using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class RecordExpression : Atom
    {
        public RecordExpression(Token left, Token right, IReadOnlyList<Expression> expressions)
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
            var tuple = string.Join(", ", Expressions);
            if (Expressions.Count == 1 && Expressions[0].IsAtomic)
            {
                return $"{Left}{tuple}{Right}";
            }
            return $"{Left}{tuple}{Right}";
        }
    }
}
