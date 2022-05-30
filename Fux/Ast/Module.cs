using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Module : Expression
    {
        public Module(Header header, Imports imports, IEnumerable<Expression> declaration)
        {
            Header = header;
            Imports = imports;
            Declarations = declaration;
        }

        public Header Header { get; }
        public Imports Imports { get; }
        public IEnumerable<Expression> Declarations { get; }
        public override bool IsAtomic => false;

        public override string ToString()
        {
            return $"{Header}";
        }
    }
}
