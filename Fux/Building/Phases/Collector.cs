namespace Fux.Building.Phases
{
    internal class Collector
    {
        public static readonly Collector Instance = new();

        private Collector() { }

        public int NumberOfLines = 0;

        public List<ModuleDecl> Module { get; } = new();
        public List<ImportDecl> Import { get; } = new();
        public List<TypeDecl> Type { get; } = new();
        public List<AliasDecl> Alias { get; } = new();
        public List<InfixDecl> Infix { get; } = new();
        public List<VarDecl> VarDecl { get; } = new();
        public List<TypeHint> TypeHint { get; } = new();
        public List<NativeDecl> NativeDecl { get; } = new();

        public Stopwatch ParseTime { get; } = new();
        public Stopwatch DeclareTime { get; } = new();
        public Stopwatch ExposeTime { get; } = new();
        public Stopwatch ImportTime { get; } = new();
        public Stopwatch ResolveTime { get; } = new();
        public Stopwatch TypeTime { get; } = new();

        public void Write()
        {
            Write("all-module.text", Module);
            Write("all-import.text", Import);
            Write("all-type.text", Type);
            Write("all-alias.text", Alias);
            Write("all-infix.text", Infix);
            Write("all-var.text", VarDecl);
            Write("all-hint.text", TypeHint);
            WriteNative("all-native.text", NativeDecl);

            void Write<T>(string name, IEnumerable<T> expressions)
                where T : Declaration
            {
                using (var writer = name.Writer())
                {
                    foreach (var type in expressions)
                    {
                        var location = type.Name[0].Location;
                        writer.WriteLine($"{{- {location.Name}({location.Line},{location.Column}) -}}");

                        writer.Indent(() =>
                        {
                            writer.WriteLine();
                            type.PP(writer);
                            if (writer.LinePending)
                            {
                                writer.WriteLine();
                            }
                            writer.WriteLine();
                        });
                    }
                }
            }

            void WriteNative(string name, IEnumerable<NativeDecl> expressions)
            {
                using (var writer = name.Writer())
                {
                    var loc = string.Empty;
                    foreach (var type in expressions)
                    {
                        var newLoc = type.Name[0].Location.Name;
                        if (newLoc != loc)
                        {
                            if (loc != string.Empty)
                            {
                                writer.WriteLine();
                            }
                            loc = newLoc;
                            writer.WriteLine($"{{- {loc} -}}");
                            writer.WriteLine();
                        }

                        writer.Indent(() =>
                        {
                            type.PP(writer);
                            if (writer.LinePending)
                            {
                                writer.WriteLine();
                            }
                        });
                    }
                }
            }
        }
    }
}
