#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.Phases
{
    internal class Phase0Parse : Phase
    {
        public Phase0Parse(ErrorBag errors, Package package)
            : base("parse", errors, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Exposed)
            {
                Terminal.Write(".");

                if (module.Parsed)
                {
                    continue;
                }

                Make(module);
            }

            var i = 0;
            while (i < Package.Intern.Count)
            {
                var module = Package.Intern[i++];

                Assert(!module.Parsed);

                if (module.Parsed)
                {
                    continue;
                }

                Terminal.Write(".");

                Make(module);
            }
        }

        private void Make(Module module)
        {
            Collector.ParseTime.Start();
            Parse(module);
            Collector.ParseTime.Stop();
        }

        private void Parse(Module module)
        {
            if (module.IsJs)
            {
                module.Parsed = true;
                return;
            }

            var source = module.GetSource();

            module.Ast = Parse(source);
            module.Parsed = true;

            Collector.NumberOfLines += source.Lines.Count;

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
            var parser = new Parser(Errors, lexer);

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
            //var liner = new Liner(Errors, lexer);

            using (var writer = MakeWriter(source.Display + "-lines.txt"))
            {
                Tokens line;

                do
                {
                    line = lexer.GetLine();

                    DumpLine(writer, line);
                    writer.WriteLine();
                }
                while (line.Count > 0 && line[0].Lex != Lex.EOF);
            }
        }
    }
}
