using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Apply : Expr
    {
        public Apply(Symbol symbol, params Expr[] expressions)
        {
            Symbol = symbol;
            Expressions = expressions;
        }

        public Symbol Symbol { get; }
        public IReadOnlyList<Expr> Expressions { get; }
    }
}
