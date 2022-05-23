using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Import : Expression
    {
        public Import(Expression path, Expression? alias, Expression? exposed)
        {
            Path = path;
            Alias = alias;
            Exposed = exposed;
        }

        public Expression Path { get; }
        public Expression? Alias { get; }
        public Expression? Exposed { get; }

        public override bool IsAtomic => false;
    }
}
