using Fux.Ast;
using Fux.ElmPackages;
using Fux.Input;

namespace Fux.Building
{
    internal class Compiler
    {
        public Compiler(ErrorBag errors)
        {
            Errors = errors;
        }

        public ErrorBag Errors { get; }

        public void Compile(Package package)
        {
            var modules = new List<Module>();

            foreach (var module in package.Exposed)
            {
                Console.WriteLine($"    {module,-20} ({module.NickName})");

                Compile(module);

                modules.Add(module);
            }

            int i = 0;
            while (i < package.Intern.Count)
            {
                var module = package.Intern[i++];

                var js = module.Js ? " [JS]" : "";
                Console.WriteLine($"    {module,-20} ({module.NickName}{js})");

                if (module.Elm)
                {
                    Compile(module);

                    modules.Add(module);
                }
            }

            foreach (var module in modules)
            {
                using (var writer = (module.NickName + "-decl.txt").Writer())
                {
                    Declare(writer, module);
                }
            }
        }

        public void Compile(Module module)
        {
            var source = module.GetSource();

            var ast = ParseModule(source);

            if (ast != null)
            {
                module.Ast = ast;

                using (var writer = (module.NickName + "-ast.txt").Writer())
                {
                    module.Ast.PP(writer);
                }
                if (!Errors.Ok)
                {
                    return;
                }
                using (var writer = (module.NickName + "-log.txt").Writer())
                {
                    ResolveImports(writer, module);
                }
            }
        }

        private void DumpLines1(Source source)
        {
            var lexer = new Lexer(Errors, source);
            var liner = new Liner(Errors, lexer);

            using (var writer = (source.Display + "-lines1.txt").Writer())
            {
                var line = liner.GetLine();

                do
                {
                    writer.WriteLine($"{line}");
                    writer.WriteLine();

                    line = liner.GetLine();
                }
                while (line.Count != 1 || line[0].Lex != Lex.EOF);
            }
        }

        private void DumpLines(Source source)
        {
            var lexer = new Lexer(Errors, source);
            var liner = new Liner2(Errors, lexer);

            using (var writer = (source.Display + "-lines.txt").Writer())
            {
                var line = liner.GetLine();

                do
                {
                    foreach (var token in line)
                    {
                        if (token.Lex == Lex.GroupOpen)
                        {
                            writer.WriteLine();
                            writer.Plus();
                        }
                        else if (token.Lex == Lex.GroupClose)
                        {
                            writer.Minus();
                            if (writer.LineRunning)
                            {
                                writer.WriteLine();
                            }
                        }
                        else
                        {
                            writer.Write($"{token} ");
                        }
                    }
                    if (writer.LineRunning)
                    {
                        writer.WriteLine();
                    }
                    writer.WriteLine();

                    line = liner.GetLine();
                }
                while (line.Count != 1 || line[0].Lex != Lex.EOF);
            }
        }

        public AstModule? ParseModule(Source source)
        {
            DumpLines(source.Clone());
            DumpLines1(source.Clone());

            var lexer = new Lexer(Errors, source);
            var liner = new Liner(Errors, lexer);
            var parser = new Parser(Errors, liner);

            try
            {
                return parser.Module();
            }
            catch (DiagnosticException diagnostic)
            {
                Errors.Add(diagnostic);

                throw;
            }
        }

        private static void ResolveImports(Writer writer, Module module)
        {
            Assert(module.Ast != null);

            foreach (var import in module.Ast.Imports)
            {
                var path = import.Path.ToString()!;

                writer.WriteLine($"import {path}");
                writer.Indent(() =>
                {
                    writer.WriteLine($"path = {path}");

                    var importModule = module.Package.FindImport(path);

                    Assert(importModule != null);

                    writer.WriteLine($"module = {importModule}");

                    if (import.Alias != null)
                    {
                        writer.WriteLine($"alias = {import.Alias}");
                    }
                    if (import.Exposed != null)
                    {
                        writer.WriteLine($"exposed = {import.Exposed}");
                    }
                });
            }
        }

        private static void Declare(Writer writer, Module module)
        {
            if (module.Ast != null)
            {
                var ast = module.Ast;

                foreach (var expr in ast.Expressions)
                {
                    writer.Write($"{expr.GetType().Name} - {expr}");

                    writer.Indent(() =>
                    {
                        switch (expr)
                        {
                            case Import:
                                writer.WriteLine();
                                writer.WriteLine("...");
                                writer.WriteLine();
                                break;
                            case InfixDefinition infix:
                                writer.WriteLine();
                                Infix(writer, infix);
                                writer.WriteLine();
                                break;
                            case AnnotateExpression:
                            default:
                                writer.WriteLine();
                                writer.WriteLine("???");
                                writer.WriteLine();
                                break;
                        }
                    });
                }
            }
        }

        private static void Infix(Writer writer, InfixDefinition infix)
        {
            var assoc = infix.Assoc;
            var power = int.Parse(infix.Power.Number.Text) * 10;
            var impl = infix.Implementation;
            var symbol = infix.Op;

            writer.WriteLine($"infix {assoc} {power} {symbol} {impl}");
        }
    }
}
