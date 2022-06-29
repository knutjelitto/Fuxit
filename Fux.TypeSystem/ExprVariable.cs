using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class ExprVariable : Expr, IEquatable<ExprVariable>
    {
        public ExprVariable(Ident ident)
        {
            Ident = ident;
        }

        public Ident Ident { get; }

        public bool Equals(ExprVariable? other)
        {
            return other != null && other.Ident == Ident;
        }
    }
}
