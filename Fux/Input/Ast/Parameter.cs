using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public sealed class ParameterDecl : Decl.DeclImpl
    {
        public ParameterDecl(Expr expression)
        {
            Expression = expression;
        }

        public ParameterDecl(Identifier identifier)
        {
            Expression = identifier;
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
