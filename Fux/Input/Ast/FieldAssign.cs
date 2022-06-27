using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class FieldAssign : Field
    {
        public FieldAssign(Identifier name, Expr expression)
        {
            Name = name;
            Expression = expression;
        }

        public Identifier Name { get; }
        public Expr Expression { get; }

        public override string ToString()
        {
            return $"{Name} = {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name} = {Expression}");
        }
    }
}
