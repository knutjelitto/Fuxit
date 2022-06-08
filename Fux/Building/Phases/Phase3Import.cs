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

            Assert(module.Ast != null);
            var ast = module.Ast ?? throw new InvalidOperationException();

            foreach (var import in ast.Imports)
            {
                var importedModule = module.Package.FindImport($"{import.Name}");

                if (importedModule == null)
                {
                    Assert(false);
                    throw new InvalidOperationException();
                }

                if (import.Exposing is Exposing exposing)
                {
                    switch (exposing)
                    {
                        case ExposingAll all:
                            foreach (var exposed in importedModule.Exposed)
                            {
                                switch (exposed)
                                {
                                    case ExposedType exposedType:
                                        if (importedModule.Scope.LookupType(exposedType.Name, out var type))
                                        {
                                            module.Scope.AddType(type);
                                        }
                                        else if (importedModule.Scope.LookupAlias(exposedType.Name, out var alias))
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
                                        if (importedModule.Scope.LookupVar(exposedVar.Name, out var var))
                                        {
                                            module.Scope.ImportAddVar(var);
                                        }
                                        else if (importedModule.Scope.LookupInfix(exposedVar.Name, out var infix))
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
                            }
                            break;
                        case ExposingSome some:
                            foreach (var exposed in some.Exposed)
                            {

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
                    module.Scope.AddModule(import.Name, importedModule);
                }
            }
        }
    }
}
