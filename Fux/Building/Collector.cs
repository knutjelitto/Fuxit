namespace Fux.Building
{
    internal class Collector
    {
        public static readonly Collector Instance = new();

        private Collector() { }

        public int NumberOfLines = 0;

        public List<A.ModuleDecl> Module { get; } = new();
        public List<A.ImportDecl> Import { get; } = new();
        public List<A.UnionDecl> DeclareType { get; } = new();
        public List<A.AliasDecl> DeclareAlias { get; } = new();
        public List<A.InfixDecl> DeclareInfix { get; } = new();
        public List<A.VarDecl> DeclareVar { get; } = new();
        public List<A.TypeHint> DeclareHint { get; } = new();
        public List<A.NativeDecl> NativeDecl { get; } = new();
        public List<A.Expression> VarPattern { get; } = new();
        public List<A.Expression> MatchPattern { get; } = new();

        public Stopwatch ScanTime { get; } = new();
        public Stopwatch ParseTime { get; } = new();
        public Stopwatch DeclareTime { get; } = new();
        public Stopwatch ExposeTime { get; } = new();
        public Stopwatch ImportTime { get; } = new();
        public Stopwatch ResolveTime { get; } = new();
        public Stopwatch TypeTime { get; } = new();

        public void Write()
        {
            //Assert(A.OpChain.OpChains == A.OpChain.ResolvedOpChains);

            Write("all-module.text", Module);
            Write("all-import.text", Import);
            WriteCompact("all-decl-type.text", DeclareType, writePP);
            Write("all-decl-alias.text", DeclareAlias);
            Write("all-decl-infix.text", DeclareInfix);
            WriteCompact("all-decl-var.text", DeclareVar, writeStr);
            WriteCompact("all-decl-hint.text", DeclareHint, writeStr);
            WriteCompact("all-native.text", NativeDecl, writePP);

            WriteVarPatterns("all-pattern-var.text");
            WriteMatchPatterns("all-pattern-match.text");

            void WriteVarPatterns(string name)
            {
                var patterns = VarPattern
                    .Select(p => p.ToString())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .OrderBy(s => s)
                    .Distinct()
                    .ToList();

                WriteAll(name, patterns);
            }

            void WriteMatchPatterns(string name)
            {
                var patterns = MatchPattern
                    .Select(p => p.ToString())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .OrderBy(s => s)
                    .Distinct()
                    .ToList();

                WriteAll(name, patterns);
            }

            void WriteAll(string name, IEnumerable<string?> items)
            {
                using (var writer = name.Writer())
                {
                    foreach (var item in items.Where(i => i is not null))
                    {
                        writer.WriteLine($"{item}");
                    }
                }
            }

            void Write<T>(string name, IEnumerable<T> expressions)
                where T : A.Declaration
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

            void writePP(Writer writer, A.Expression expr)
            {
                expr.PP(writer);
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
            }

            void writeStr(Writer writer, A.Expression expr)
            {
                writer.WriteLine($"{expr}");
            }

            void WriteCompact(string name, IEnumerable<A.Declaration> expressions, Action<Writer, A.Expression> write)
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
