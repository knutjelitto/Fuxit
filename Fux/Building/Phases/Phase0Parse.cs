#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.Phases
{
    internal class Phase0Parse : Phase
    {
        public Collector Collector { get; }

        public Phase0Parse(ErrorBag errors, Collector collector, Package package)
            : base("parse", errors, package)
        {
            Collector = collector;
        }

        public override void Make()
        {
            foreach (var module in Package.Exposed)
            {
                Console.Write(".");

                if (module.Parsed)
                {
                    continue;
                }

                MakeModule(module);
            }

            var i = 0;
            while (i < Package.Intern.Count)
            {
                var module = Package.Intern[i++];

                if (module.Parsed)
                {
                    continue;
                }

                Console.Write(".");

                MakeModule(module);
            }
        }

        private void MakeModule(Module module)
        {
            Collector.ParseTime.Start();
            ParseModule(module);
            Collector.ParseTime.Stop();
        }

        private void ParseModule(Module module)
        {
            if (module.IsJs)
            {
                module.Parsed = true;
                return;
            }

            var source = module.GetSource();

            module.Ast = Parse(source);
            module.Parsed = true;

            DumpAst(module);

            if (module.Ast != null)
            {
                Collector.Module.Add(module.Ast.Header);

                if (!Errors.Ok)
                {
                    return;
                }

                PrepareImported(module);
            }

        }


        private static void PrepareImported(Module module)
        {
            Assert(module.Ast != null);

            foreach (var import in module.Ast.Imports)
            {
                var _ = module.Package.FindImport($"{import.Name}");
            }
        }

        public ModuleAst? Parse(Source source)
        {
            var lexer = new Lexer(Errors, source);
            var liner = new Liner(Errors, lexer);
            var parser = new Parser(Errors, liner);

            try
            {
                DumpLines(source);

                if (!Errors.Ok)
                {
                    return null;
                }

                var ast = parser.Module();

                return ast;
            }
            catch (DiagnosticException diagnostic)
            {
                Errors.Add(diagnostic);

                throw;
            }
        }

        private void DumpAst(Module module)
        {
            if (module.Ast != null)
            {
                using (var writer = MakeWriter(module, "parse"))
                {
                    module.Ast.PP(writer);
                }
            }
        }

        private void DumpLine(Writer writer, Tokens line)
        {
            foreach (var token in line)
            {
                if (token.First)
                {
                    while (writer.IndentationLevel < token.Indent)
                    {
                        writer.Plus();
                    }
                    while (writer.IndentationLevel > token.Indent)
                    {
                        writer.Minus();
                    }
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                    }
                }

                writer.Write($"{token} ");

                if (token.Last)
                {
                    while (writer.IndentationLevel < token.Indent)
                    {
                        writer.Plus();
                    }
                    while (writer.IndentationLevel > token.Indent)
                    {
                        writer.Minus();
                    }
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                    }
                }
            }
            if (writer.LinePending)
            {
                writer.WriteLine();
            }
        }

        private void DumpLines(Source source)
        {
            var lexer = new Lexer(Errors, source.Clone());
            var liner = new Liner(Errors, lexer);

            using (var writer = MakeWriter(source.Display + "-lines.txt"))
            {
                Tokens line;

                do
                {
                    line = liner.GetLine();

                    DumpLine(writer, line);
                    writer.WriteLine();
                }
                while (line.Count > 0 && line[0].Lex != Lex.EOF);
            }
        }
    }
}
