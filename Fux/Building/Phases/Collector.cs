namespace Fux.Building.Phases
{
    internal class Collector
    {
        public static readonly Collector Instance = new();

        private Collector() { }

        public int NumberOfLines = 0;

        public List<ModuleDecl> Module { get; } = new();
        public List<ImportDecl> Import { get; } = new();
        public List<TypeDecl> DeclareType { get; } = new();
        public List<AliasDecl> DeclareAlias { get; } = new();
        public List<InfixDecl> DeclareInfix { get; } = new();
        public List<VarDecl> DeclareVar { get; } = new();
        public List<TypeHint> DeclareHint { get; } = new();
        public List<NativeDecl> NativeDecl { get; } = new();

        public Stopwatch ScanTime { get; } = new();
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
            WriteCompact("all-decl-type.text", DeclareType, writePP);
            Write("all-decl-alias.text", DeclareAlias);
            Write("all-decl-infix.text", DeclareInfix);
            WriteCompact("all-decl-var.text", DeclareVar, writeStr);
            Write("all-decl-hint.text", DeclareHint);
            WriteCompact("all-native.text", NativeDecl, writePP);

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

            void writePP(Writer writer, Expression expr)
            {
                expr.PP(writer);
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
            }


            void writeStr(Writer writer, Expression expr)
            {
                writer.WriteLine($"{expr}");
            }

            void WriteCompact(string name, IEnumerable<Declaration> expressions, Action<Writer, Expression> write)
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
                            write(writer, type);
                        });
                    }
                }
            }
        }
    }
}
