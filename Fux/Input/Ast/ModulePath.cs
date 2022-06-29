namespace Fux.Input.Ast
{
    public sealed class ModulePath : Expr.ExprImpl
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
