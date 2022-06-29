namespace Fux.Input.Ast
{
    public sealed class TypeArguments : ListOf<Type>
    {
        public TypeArguments(IEnumerable<Type> items)
            : base(items)
        {
        }

        public TypeArguments(params Type[] items)
            : this(items.AsEnumerable())
        {
        }

        public new void Add(Type type)
        {
            base.Add(type);
        }

        public override string ToString()
        {
            return String.Join(' ', this);
        }
    }
}
