namespace Fux.Input.Ast
{
    public sealed class TypeParameters : ListOf<Type.Parameter>
    {
        public TypeParameters(IEnumerable<Type.Parameter> items)
            : base(items)
        {
            Assert(this.All(p => p.Name.IsSingleLower));
        }

        public TypeParameters(params Type.Parameter[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
