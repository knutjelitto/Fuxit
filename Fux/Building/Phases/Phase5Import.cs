#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using Fux.Input.Ast;

namespace Fux.Building.Phases
{
    public sealed class Phase5Import : Phase
    {
        public Phase5Import(Ambience ambience, Package package)
            : base("import", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Terminal.Write(".");

                Make(module);
            }
        }

        private void Make(Module module)
        {
            Collector.ImportTime.Start();
            Imports(module);
            Collector.ImportTime.Stop();
        }

        private void Imports(Module module)
        {
            if (module.IsJs)
            {
                return;
            }

            if (!Package.IsCore)
            {
                Prelude(module);
            }
            else
            {
                if (module.Name != Lex.Primitive.List)
                {
                    ListPrelude(module);
                }
            }

            Assert(module.Ast != null);
            var ast = module.Ast ?? throw new InvalidOperationException();

            foreach (var import in ast.Imports)
            {
                Import(module, import);
            }
        }


        void Import(Module module, Decl.Import import)
        {
            import.InModule = module.Package.FindImport($"{import.Name}");

            if (import.InModule == null)
            {
                Assert(false);
                throw new InvalidOperationException();
            }

            var importName = import.Alias ?? import.Name;

            if (!importName.Equals(import.Name))
            {
                Assert(true);
            }

            Assert(importName.IsMultiUpper);

            if (import.Exposing is Exposing exposing)
            {
                switch (exposing)
                {
                    case ExposingAll all:
                        foreach (var exposed in import.InModule.Exposed)
                        {
                            Expose(module, import, exposed, true);
                        }
                        break;
                    case ExposingSome some:
                        foreach (var exposed in some.Exposed)
                        {
                            var found = import.InModule.Exposed.Where(e => e.Name.Equals(exposed.Name)).SingleOrDefault();
                            if (found != null)
                            {
                                Expose(module, import, found, exposed is Exposed.Type type && type.Inclusive);
                            }
                            else if (import.InModule.Name == "List" && exposed.Name.ToString() == "List")
                            {
                                Assert(false);
                            }
                            else
                            {
                                Assert(false);
                                throw new InvalidOperationException();
                            }
                        }
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

            if (import.Alias != null || import.Exposing == null || true)
            {
                module.Scope.ImportAddModule(importName, import.InModule);
            }
        }

        void Expose(Module module, Decl.Import import, Exposed exposed, bool inclusive)
        {
            Assert(import.InModule != null);

            switch (exposed)
            {
                case Exposed.Type exposedType:
                    if (import.InModule.Scope.LookupType(exposedType.Name, out var type))
                    {
                        module.Scope.ImportAddType(type);

                        if (inclusive)
                        {
                            foreach (var ctor in type.Ctors)
                            {
                                module.Scope.ImportAddConstructor(ctor);
                            }
                        }
                    }
                    else if (import.InModule.Scope.LookupAlias(exposedType.Name, out var alias))
                    {
                        module.Scope.ImportAddAlias(alias);
                    }
                    else
                    {
                        Assert(false);
                        throw new InvalidOperationException();
                    }
                    break;
                case Exposed.Var exposedVar:
                    if (import.InModule.Scope.LookupVar(exposedVar.Name, out var var))
                    {
                        module.Scope.ImportAddVar(var);
                    }
                    else if (import.InModule.Scope.LookupInfix(exposedVar.Name, out var infix))
                    {
                        module.Scope.ImportAddInfix(infix);
                    }
                    else
                    {
                        Assert(false);
                        throw new InvalidOperationException();
                    }
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ListPrelude(Module module)
        {
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, Lex.Primitive.List), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, Lex.Primitive.List), false),
                        new Exposed.Var(Identifier.Artificial(module, Lex.Symbol.ListCons)))));
        }

        private void Prelude(Module module)
        {
            Assert(Package.FindImport("Basics") != null);
            Import(module,
                new Decl.Import(Identifier.Artificial(module, "Basics"), null,
                new ExposingAll()));
            ListPrelude(module);
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Maybe"), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Maybe"), true))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Result"), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Result"), true))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "String"), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "String"), false))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Char"), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Char"), false))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Tuple"), null, null));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Debug"), null, null));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Platform"), null,
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Program"), false))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Platform.Cmd"), Identifier.Artificial(module, "Cmd"),
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Cmd"), false))));
            Import(module,
                new Decl.Import(
                    Identifier.Artificial(module, "Platform.Sub"), Identifier.Artificial(module, "Sub"),
                    new ExposingSome(
                        new Exposed.Type(Identifier.Artificial(module, "Sub"), false))));
        }
    }
}
