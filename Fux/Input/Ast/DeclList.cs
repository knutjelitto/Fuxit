namespace Fux.Input.Ast
{
    public sealed class DeclList : ListOf<Expr>
    {
        public DeclList(IEnumerable<Expr> items)
            : base(items)
        {
        }
    }
}
