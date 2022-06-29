using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class ExprApplication : Expr, IEquatable<ExprApplication>
    {
        public ExprApplication(Expr e1, Expr e2)
        {
            this.e1 = e1;
            this.e2 = e2;
        }

        public Expr e1 { get; }
        public Expr e2 { get; }

        public bool Equals(ExprApplication? other)
        {
            return other != null && e1.Equals(other.e1) && e2.Equals(other.e2);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ExprApplication);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(e1, e2);
        }
    }
}
