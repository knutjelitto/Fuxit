#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase2Expose : Phase
    {
        public Collector Collector { get; }

        public Phase2Expose(ErrorBag errors, Collector collector, Package package)
            : base("expose", errors, package)
        {
            Collector = collector;
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Console.Write(".");

                if (module.IsJs)
                {
                    continue;
                }

                MakeModule(module);
            }
        }

        private void MakeModule(Module module)
        {
            Collector.ExposeTime.Start();
            MakeExpose(module);
            Collector.ExposeTime.Stop();
        }

        private void MakeExpose(Module module)
        {
            var ast = module.Ast ?? throw new InvalidOperationException();
            var scope = module.Scope;

            var header = ast.Header;

            if (header.Exposing != null)
            {
                Exposing(module, header.Exposing);
            }
        }

        private void Exposing(Module module, Exposing exposing)
        {
            switch (exposing)
            {
                case ExposingAll all:
                    Assert(false);
                    throw new InvalidOperationException();
                case ExposingSome some:
                    foreach (var item in some.Exposed)
                    {
                        module.Exposed.Add(Exposed(module, item));
                    }
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private Exposed Exposed(Module module, Exposed exposed)
        {
            switch (exposed)
            {
                case ExposedType exposedType:
                    if (module.Scope.LookupType(exposed.Name, out var type))
                    {
                        if (exposedType.Inclusive)
                        {
                            foreach (var constructor in type.Constructors)
                            {
                                if (module.Scope.LookupConstructor(constructor.Name, out var ctor))
                                {
                                    exposedType.Add(ctor);
                                }
                                else
                                {
                                    Assert(false);
                                    throw new InvalidOperationException();
                                }
                            }
                        }

                        return exposed;
                    }
                    else if (module.Scope.LookupAlias(exposed.Name, out _))
                    {
                        if (exposedType.Inclusive)
                        {
                            Assert(false);
                            throw new InvalidOperationException();
                        }

                        return exposed;
                    }
                    break;
                case ExposedVar exposedVar:
                    if (module.Scope.LookupVar(exposedVar.Name, out _))
                    {
                        return exposed;
                    }
                    else if (module.Scope.LookupInfix(exposedVar.Name, out _))
                    {
                        return exposed;
                    }
                    else
                    {
                        Assert(false);
                        throw new NotImplementedException();
                    }
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }

            Assert(false);
            throw new InvalidOperationException();
        }
    }
}
