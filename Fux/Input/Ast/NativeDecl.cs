using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class NativeDecl : Declaration
    {
        public NativeDecl(Identifier name)
            : base(name)
        {
        }

        public override void PP(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
