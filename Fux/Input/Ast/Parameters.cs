namespace Fux.Input.Ast
{
    public sealed class Parameters : ListOf<Decl.Parameter>
    {
        public Parameters(IEnumerable<Decl.Parameter> items)
            : base(items)
        {
        }

        public Parameters()
            : this(Enumerable.Empty<Decl.Parameter>())
        {
        }

        public override string ToString()
        {
            return $"{string.Join(' ', this)}";
        }
    }
}
