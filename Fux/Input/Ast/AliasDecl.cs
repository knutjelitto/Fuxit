namespace Fux.Input.Ast
{
    internal class AliasDecl : Declaration
    {
        public AliasDecl(Identifier name, TypeParameters parameters, Type declaration)
            : base(name)
        {
            Parameters = parameters;
            Declaration = declaration;
        }
        public TypeParameters Parameters { get; }
        public Type Declaration { get; }

        public override string ToString()
        {
            var parameters = Parameters.Count > 0 ? $" {string.Join(' ', Parameters)}" : "";
            return $"type alias {Name}{parameters} = {Declaration}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }
}
