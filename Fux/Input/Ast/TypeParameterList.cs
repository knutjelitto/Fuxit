namespace Fux.Input.Ast
{
    public sealed class TypeParameterList : ListOf<Decl.TypeParameter>
    {
        public TypeParameterList(IEnumerable<Decl.TypeParameter> items)
            : base(items)
        {
            Assert(this.All(p => p.Name.IsSingleLower));
        }

        public TypeParameterList(params Decl.TypeParameter[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
