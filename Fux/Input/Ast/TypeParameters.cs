namespace Fux.Input.Ast
{
    internal class TypeParameters : ListOf<Identifier>
    {
        public TypeParameters(IEnumerable<Identifier> items)
            : base(items)
        {
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
