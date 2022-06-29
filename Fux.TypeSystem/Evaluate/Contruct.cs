#pragma warning disable IDE1006 // Naming Styles


using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem.Evaluate
{
    public static class Contruct
    {
        public static ExprLet let(ExprVariable x, Expr e1, Expr e2)
        {
            if (e1 is null)
            {
                throw new ArgumentNullException(nameof(e1));
            }

            return new ExprLet(x, e1, e2);
        }
    }
}
