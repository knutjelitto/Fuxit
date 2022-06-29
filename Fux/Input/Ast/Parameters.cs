namespace Fux.Input.Ast
{
    public sealed class Parameters : ListOf<ParameterDecl>
    {
        public Parameters(IEnumerable<ParameterDecl> items)
            : base(items)
        {
        }

        public Parameters()
            : this(Enumerable.Empty<ParameterDecl>())
        {
        }

        public override string ToString()
        {
            return $"{string.Join(' ', this)}";
        }
    }
}
