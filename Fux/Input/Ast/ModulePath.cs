namespace Fux.Input.Ast
{
    internal class ModulePath : Expr
    {
        public ModulePath(IReadOnlyList<Identifier> names)
        {
            Names = names;
        }

        public IReadOnlyList<Identifier> Names { get; }
        public string Joined => string.Join(".", Names);

        public override string ToString()
        {
            return Joined;
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Joined}");
        }
    }
}
