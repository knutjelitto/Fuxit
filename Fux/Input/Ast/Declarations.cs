namespace Fux.Input.Ast
{
    internal class Declarations : ListOf<Expression>
    {
        public Declarations(IEnumerable<Expression> items)
            : base(items)
        {
        }
    }
}
