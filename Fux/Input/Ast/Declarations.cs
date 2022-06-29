namespace Fux.Input.Ast
{
    public sealed class Declarations : ListOf<Expr>
    {
        public Declarations(IEnumerable<Expr> items)
            : base(items)
        {
        }
    }
}
