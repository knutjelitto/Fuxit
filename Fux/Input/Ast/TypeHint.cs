namespace Fux.Input.Ast
{
    internal class TypeHint : Declaration
    {
        public TypeHint(Identifier name, Type type)
            : base(name.SingleLower())
        {

            Type = type;
        }

        public Type Type { get; }

        public override string ToString()
        {
            return Protected($"{Name} {Lex.Colon} {Type}");
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name} {Lex.Colon} ");
            Type.PP(writer);
        }
    }
}
