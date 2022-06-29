namespace Fux.Input.Ast
{
    public sealed class TypeParameterList : ListOf<TypeParameter>
    {
        public TypeParameterList(IEnumerable<TypeParameter> items)
            : base(items)
        {
            Assert(this.All(p => p.Name.IsSingleLower));
        }

        public TypeParameterList(params TypeParameter[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
