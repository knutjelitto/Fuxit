using System.Text;

namespace Fux.Building
{
    public class Module
    {
        public Module(Package package, string name, bool builtin = false)
        {
            Package = package;
            Name = name;
            IsBuiltin = builtin;

            var pathName = Name.Replace('.', '/');
            var ext = builtin ? "wat" : "elm";
            NickName = Package.FullName + "/" + pathName;
            FileName = $"src/{pathName}.{ext}";

            Scope = new ModuleScope(this);
        }

        public Package Package { get; }
        public string Name { get; }
        public bool IsBuiltin { get; }
        public bool IsFux => !IsBuiltin;
        public bool IsCore => Package.IsCore;
        public string NickName { get; }
        public string FileName { get; }

        public ISource? Source { get; set; } = null;
        public List<Tokens>? Lines { get; set; } = null;
        public A.ModuleAst? Ast { get; set; } = null;
        public ModuleScope Scope { get; }

        public List<A.Exposed> Exposed { get; } = new();
        
        public Source GetSource()
        {
            var fullFileName = Path.Combine(Package.RootPath, FileName);

            return new StringSource(NickName, fullFileName, IO.File.ReadAllText(fullFileName, Encoding.UTF8));
        }

        public override string ToString() => Name;
    }
}
