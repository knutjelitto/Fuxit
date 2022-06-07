namespace Fux.Input.Ast
{
    internal class TypeArguments : ListOf<Type>
    {
        public TypeArguments(IEnumerable<Type> items)
            : base(items)
        {
        }

        public override string ToString()
        {
            return String.Join(' ', this);
        }
    }
}
