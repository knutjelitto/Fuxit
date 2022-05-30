using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class TypeDefinition : Expression
    {
        public TypeDefinition(Expression expression)
        {
            Expression = expression;
        }

        public override bool IsAtomic => true;

        public Expression Expression { get; }

        public override string ToString()
        {
            return $"type {Expression}";
        }
    }
}
