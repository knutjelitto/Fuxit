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
            FullFileName = Folder.Combine(Package.RootPath, FileName);
        }

        public Package Package { get; }
        public string Name { get; }
        public bool IsJs { get; }
        public bool IsElm => !IsJs;
        public string NickName { get; }
        public string FileName { get; }
        public string FullFileName { get; }

        public bool Parsed { get; set; } = false;
        public ModuleAst? Ast { get; set; } = null;
        public ModuleScope Scope { get; } = new();

        public List<Exposed> Exposed { get; } = new();
        
        public Source GetSource()
        {
            return new StringSource(NickName, FullFileName, File.ReadAllText(FullFileName, Encoding.UTF8));
        }

        public override string ToString() => Name;
    }
}
