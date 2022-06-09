#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase3Import : Phase
    {
        public Collector Collector { get; }

        public Phase3Import(ErrorBag errors, Collector collector, Package package)
            : base("import", errors, package)
        {
            Collector = collector;
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Console.Write(".");

                MakeModule(module);
            }
        }

        private void MakeModule(Module module)
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

            if (module.Name == "List")
            {
                Assert(true);
            }

            Assert(module.Ast != null);
            var ast = module.Ast ?? throw new InvalidOperationException();

            foreach (var import in ast.Imports)
            {
                import.Module = module.Package.FindImport($"{import.Name}");

                if (import.Module == null)
                {
                    Assert(false);
                    throw new InvalidOperationException();
                }

                if (import.Exposing is Exposing exposing)
                {
                    switch (exposing)
                    {
                        case ExposingAll all:
                            foreach (var exposed in import.Module.Exposed)
                            {
#if true
                                Expose(import, exposed, true);
#else
                                switch (exposed)
                                {
                                    case ExposedType exposedType:
                                        if (import.Module.Scope.LookupType(exposedType.Name, out var type))
                                        {
                                            module.Scope.AddType(type);
                                        }
                                        else if (import.Module.Scope.LookupAlias(exposedType.Name, out var alias))
                                        {
                                            module.Scope.ImportAddAlias(alias);
                                        }
                                        else
                                        {
                                            Assert(false);
                                            throw new InvalidOperationException();
                                        }
                                        break;
                                    case ExposedVar exposedVar:
                                        if (import.Module.Scope.LookupVar(exposedVar.Name, out var var))
                                        {
                                            module.Scope.ImportAddVar(var);
                                        }
                                        else if (import.Module.Scope.LookupInfix(exposedVar.Name, out var infix))
                                        {
                                            module.Scope.AddInfix(infix);
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
#endif
                            }
                            break;
                        case ExposingSome some:
                            foreach (var exposed in some.Exposed)
                            {
                                var found = import.Module.Exposed.Where(e => e.Name.Equals(exposed.Name)).SingleOrDefault();
                                if (found != null)
                                {
                                    Expose(import, found, exposed is ExposedType type && type.Inclusive);
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
                else
                {
                    if (import.Name.ToString().StartsWith("Elm.Kernel.", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    Assert(import.Name.IsMultiUpper);
                    module.Scope.AddModule(import.Name, import.Module);
                }
            }

            void Expose(ImportDecl import, Exposed exposed, bool inclusive)
            {
                Assert(import.Module != null);

                switch (exposed)
                {
                    case ExposedType exposedType:
                        if (import.Module.Scope.LookupType(exposedType.Name, out var type))
                        {
                            module.Scope.AddType(type);

                            if (inclusive)
                            {
                                foreach (var ctor in type.Constructors)
                                {
                                    module.Scope.AddConstructor(ctor);
                                }
                            }
                        }
                        else if (import.Module.Scope.LookupAlias(exposedType.Name, out var alias))
                        {
                            module.Scope.ImportAddAlias(alias);
                        }
                        else
                        {
                            Assert(false);
                            throw new InvalidOperationException();
                        }
                        break;
                    case ExposedVar exposedVar:
                        if (import.Module.Scope.LookupVar(exposedVar.Name, out var var))
                        {
                            module.Scope.ImportAddVar(var);
                        }
                        else if (import.Module.Scope.LookupInfix(exposedVar.Name, out var infix))
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
        }
    }
}
