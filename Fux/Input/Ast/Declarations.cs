namespace Fux.Input.Ast
{
    internal class Declarations : ListOf<Expr>
    {
        public Declarations(IEnumerable<Expr> items)
            : base(items)
        {
        }
    }
}
