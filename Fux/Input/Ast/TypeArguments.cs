namespace Fux.Input.Ast
{
    internal class TypeArguments : ListOf<Type>
    {
        public TypeArguments(IEnumerable<Type> items)
            : base(items)
        {
        }

        public TypeArguments(params Type[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return String.Join(' ', this);
        }
    }
}
