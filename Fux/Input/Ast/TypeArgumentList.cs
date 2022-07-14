namespace Fux.Input.Ast
{
    public sealed class TypeArgumentList : ListOf<Type>
    {
        public TypeArgumentList(IEnumerable<Type> items)
            : base(items)
        {
        }

        public TypeArgumentList(params Type[] items)
            : this(items.AsEnumerable())
        {
        }

        public new void Add(Type type)
        {
            base.Add(type);
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
