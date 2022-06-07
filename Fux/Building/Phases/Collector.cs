using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.Phases
{
    internal class Collector
    {
        public List<ModuleDecl> Module { get; } = new();
        public List<ImportDecl> Import { get; } = new();
        public List<TypeDecl> Type { get; } = new();
        public List<AliasDecl> Alias { get; } = new();
        public List<InfixDecl> Infix { get; } = new();
        public List<VarDecl> VarDecl { get; } = new();
        public List<TypeHint> TypeHint { get; } = new();

        public Stopwatch ParseTime { get; } = new();
        public Stopwatch DeclareTime { get; } = new();
        public Stopwatch ResolveTime { get; } = new();


        public void Write()
        {
            Console.WriteLine($"parse  : {ParseTime.ElapsedMilliseconds} ms");
            Console.WriteLine($"declare: {DeclareTime.ElapsedMilliseconds} ms");
            Console.WriteLine($"resolve: {ResolveTime.ElapsedMilliseconds} ms");

            Write("all-module.text", Module);
            Write("all-import.text", Import);
            Write("all-type.text", Type);
            Write("all-alias.text", Alias);
            Write("all-infix.text", Infix);
            Write("all-var.text", VarDecl);
            Write("all-hint.text", TypeHint);

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
        }
    }
}
