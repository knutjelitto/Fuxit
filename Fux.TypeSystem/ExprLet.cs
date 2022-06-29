#pragma warning disable IDE1006 // Naming Styles

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class ExprLet : Expr, IEquatable<ExprLet>
    {
        public ExprLet(ExprVariable x, Expr e1, Expr e2)
        {
            this.x = x;
            this.e1 = e1;
            this.e2 = e2;
        }

        public ExprVariable x { get; }
        public Expr e1 { get; }
        public Expr e2 { get; }

        public bool Equals(ExprLet? other)
        {
            return other != null && x.Equals(other.x) && e1.Equals(other.e1);
        }
    }
}
