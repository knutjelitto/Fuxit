﻿#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.Phases
{
    public sealed class Phase2Parse : Phase
    {
        public Phase2Parse(Ambience ambience, Package package)
            : base("parse", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Exposed)
            {
                Terminal.Write(".");

                Make(module);
            }

            foreach (var module in Package.Intern)
            {
                Terminal.Write(".");

                Make(module);
            }
        }

        private void Make(Module module)
        {
            if (module.IsFux)
            {
                Collector.ParseTime.Start();
                Parse(module);
                Collector.ParseTime.Stop();
            }
        }

        private void Parse(Module module)
        {
            Assert(module.Source != null);
            Assert(module.Lines != null);

            var lexer = new ParseLexer(module.Source, module.Lines);
            var parser = new Parser(module, Errors, lexer);

            try
            {
                module.Ast = parser.ParseModule();

                Assert(module.Ast != null);

                Collector.Module.Add(module.Ast.Header);
                DumpAst(module);

            }
            catch (DiagnosticException diagnostic)
            {
                Errors.Add(diagnostic);

                throw;
            }
        }

        private void DumpAst(Module module)
        {
            Assert(module.Ast != null);

            if (Ambience.Config.WriteTheAst)
            {
                using (var writer = MakeWriter(module, "ast"))
                {
                    module.Ast.PP(writer);
                }
            }
        }
    }
}
