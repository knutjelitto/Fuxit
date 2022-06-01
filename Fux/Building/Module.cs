namespace Fux.Building
{
    internal class Module
    {
        public Module(Package package, string name, bool js = false)
        {
            Package = package;
            Name = name;
            Js = js;
            NickName = Package.FullName + "/" + Name.Replace('.', '/');
            var ext = js ? "js" : "elm";
            FileName = $"src/{Name.Replace('.', '/')}.{ext}";
            FullFileName = Folder.Combine(Package.RootPath, FileName);
        }

        public Package Package { get; }
        public string Name { get; }
        public bool Js { get; }
        public bool Elm => !Js;
        public string NickName { get; }
        public string FileName { get; }
        public string FullFileName { get; }

        public AstModule? Ast { get; set; } = null;

        public Source GetSource()
        {
            return new StringSource(NickName, FullFileName, File.ReadAllText(FullFileName));
        }

        public override string ToString() => Name;
    }
}
