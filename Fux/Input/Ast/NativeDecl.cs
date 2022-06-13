namespace Fux.Input.Ast
{
    internal class NativeDecl : Declaration
    {
        public NativeDecl(Identifier moduleName, Identifier name)
            : base(name)
        {
            ModuleName = moduleName;
        }

        public TypeHint? TypeHint { get; set; } = null;
        public Identifier ModuleName { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{ModuleName}.{Name} : {TypeHint?.Type}");
        }
    }
}
