using Fux.Tools;

namespace Fux.Input.Ast
{
    internal class NativeDecl : Declaration
    {
        public NativeDecl(Identifier moduleName, Identifier name)
            : base(name)
        {
            ModuleName = moduleName;
        }

        public Type? Type { get; set; } = null;
        public Identifier ModuleName { get; }

        public override string ToString()
{
            return $"{ModuleName}.{Name}";
        }

        public override void PP(Writer writer)
        {
            var type = Type == null ? "<???>" : $"{Type}";
            writer.Write($"{ModuleName}.{Name} : {type}");
        }
    }
}
