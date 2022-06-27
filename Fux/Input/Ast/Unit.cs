using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class Unit : Expr
    {
        public override string ToString()
        {
            return "()";
        }

        public override void PP(Writer writer)
        {
            writer.Write("()");
        }
    }
}
