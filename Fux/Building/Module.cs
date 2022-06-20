using System.Text;

namespace Fux.Building
{
    internal class Module
    {
        public Module(Package package, string name, bool js = false)
        {
            Package = package;
            Name = name;
            IsJs = js;

            var pathName = Name.Replace('.', '/');
            var ext = js ? "js" : "elm";
            NickName = Package.FullName + "/" + pathName;
            FileName = $"src/{pathName}.{ext}";

            Scope = new ModuleScope(this);
        }

        public Package Package { get; }
        public string Name { get; }
        public bool IsJs { get; }
        public bool IsElm => !IsJs;
        public string NickName { get; }
        public string FileName { get; }

        public List<Tokens>? Lines { get; set; } = null;
        public ModuleAst? Ast { get; set; } = null;
        public ModuleScope Scope { get; }

        public List<Exposed> Exposed { get; } = new();
        
        public Source GetSource()
        {
            var fullFileName = Folder.Combine(Package.RootPath, FileName);

            return new StringSource(NickName, fullFileName, File.ReadAllText(fullFileName, Encoding.UTF8));
        }

        public override string ToString() => Name;
    }
}
