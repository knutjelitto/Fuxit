namespace Fux.Input.Ast
{
    internal class TypeHint : Declaration
    {
        public TypeHint(Identifier name, Type type)
            : base(name)
        {
            TypeDef = type;
        }

        public Type TypeDef { get; }

        public override string ToString()
        {
            return Protected($"{Name} {Lex.Colon} {TypeDef}");
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name} {Lex.Colon} ");
            TypeDef.PP(writer);
        }
    }
}
