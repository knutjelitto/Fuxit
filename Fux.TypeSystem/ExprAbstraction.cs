using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class ExprAbstraction : Expr, IEquatable<ExprAbstraction>
    {
        public ExprAbstraction(ExprVariable x, Expr e)
        {
            this.x = x;
            this.e = e;
        }

        public ExprVariable x { get; }
        public Expr e { get; }

        public bool Equals(ExprAbstraction? other)
        {
            return other != null && x.Equals(other.x) && e.Equals(other.e);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ExprAbstraction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, e);
        }
    }
}
