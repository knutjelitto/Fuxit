using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public sealed class Parameter : Expr.ExprImpl
    {
        public Parameter(Expr expression)
        {
            Expression = expression;
        }

        public Expr Expression { get; }

        public override string ToString()
        {
            return $"{Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
