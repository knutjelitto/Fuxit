using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal sealed class Parameter : Expression
    {
        public Parameter(Expression expression)
        {
            Expression = expression;
        }

        public Expression Expression { get; }

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
