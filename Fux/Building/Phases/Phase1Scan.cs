#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.Phases
{
    public sealed class Phase1Scan : Phase
    {
        public Phase1Scan(Ambience ambience, Package package)
            : base("scan", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Exposed)
            {
                Terminal.Write(".");

                Make(module);
            }

            var i = 0;
            while (i < Package.Intern.Count)
            {
                var module = Package.Intern[i++];

                Terminal.Write(".");

                Make(module);
            }
        }

        private void Make(Module module)
        {
            if (module.IsElm)
            {
                Collector.ScanTime.Start();
                Scan(module);
                Collector.ScanTime.Stop();
            }
        }

        private void Scan(Module module)
        {
            var source = module.GetSource();
            var lexer = new Lexer(Errors, source);

            Assert(module.Lines == null);

            module.Source = source;
            module.Lines = lexer.ToList();

            if (Ambience.Config.WriteTheLines)
            {
                using (var writer = MakeWriter(source.Display + "-lines.txt"))
                {
                    foreach (var line in module.Lines)
                    {
                        WriteLine(writer, line);
                        writer.WriteLine();
                    }
                }
            }

            if (!Errors.Ok)
            {
                return;
            }

            Collector.NumberOfLines += source.Lines.Count;
        }

        private void WriteLine(Writer writer, Tokens line)
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
    }
}
