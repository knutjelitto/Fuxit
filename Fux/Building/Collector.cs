namespace Fux.Building
{
    public sealed class Collector
    {
        public static readonly Collector Instance = new();

        private Collector() { }

        public int NumberOfLines = 0;

        public int NumberOfExceptions = 0;

        public List<A.Decl.Header> Module { get; } = new();
        public List<A.Decl.Import> Import { get; } = new();
        public List<A.Decl.Custom> Custom { get; } = new();
        public List<A.Decl.Alias> Alias { get; } = new();
        public List<A.Decl.Infix> Infix { get; } = new();
        public List<A.Decl.Var> Var { get; } = new();
        public List<A.Decl.TypeAnnotation> Annotation { get; } = new();
        public List<A.Decl.Native> Native { get; } = new();
        public List<A.Expr> VarPattern { get; } = new();
        public List<A.Pattern> LetPattern { get; } = new();
        public List<A.Pattern> MatchPattern { get; } = new();

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
            WriteCompact("all-decl-type.text", Custom, writePP);
            Write("all-decl-alias.text", Alias);
            Write("all-decl-infix.text", Infix);
            WriteCompact("all-decl-var.text", Var, writeStr);
            WriteCompact("all-decl-hint.text", Annotation, writeStr);
            WriteNatives("all-native.text");

            WriteVarPatterns("all-pattern-var.text");
            WriteMatchPatterns("all-pattern-match.text");
            WriteLetPatterns("all-pattern-let.text");

            void WriteNatives(string name)
            {
                WriteAll(name, StringsFrom(Native));
            }

            void WriteVarPatterns(string name)
            {
                WriteAll(name, StringsFrom(VarPattern));
            }

            void WriteMatchPatterns(string name)
            {
                WriteAll(name, StringsFrom(MatchPattern));
            }

            void WriteLetPatterns(string name)
            {
                WriteAll(name, StringsFrom(LetPattern));
            }

            IEnumerable<string> StringsFrom(IEnumerable<A.Node> exprs)
            {
                return exprs
                    .Select(p => p.ToString()!)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .OrderBy(s => s)
                    .Distinct()
                    .ToList();
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
                where T : A.Decl
            {
                using (var writer = name.Writer())
                {
                    foreach (var type in expressions)
                    {
                        var location = type.Location;
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

            void writePP(Writer writer, A.Decl expr)
            {
                expr.PP(writer);
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
            }

            void writeStr(Writer writer, A.Decl expr)
            {
                writer.WriteLine($"{expr}");
            }

            void WriteCompact(string name, IEnumerable<A.Decl> expressions, Action<Writer, A.Decl> write)
            {
                using (var writer = name.Writer())
                {
                    var loc = string.Empty;
                    foreach (var type in expressions)
                    {
                        var newLoc = type.Location.Name;
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
