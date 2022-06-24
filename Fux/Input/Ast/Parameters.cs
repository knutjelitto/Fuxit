namespace Fux.Input.Ast
{
    internal class Parameters : ListOf<Parameter>
    {
        public Parameters(IEnumerable<Parameter> items)
            : base(items)
        {
        }

        public Parameters()
            : this(Enumerable.Empty<Parameter>())
        {
        }

        public override string ToString()
        {
            return $"{string.Join(' ', this)}";
        }
    }
}
