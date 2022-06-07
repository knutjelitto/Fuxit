#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase2Resolve : Phase
    {
        public Collector Collector { get; }

        public Phase2Resolve(ErrorBag errors, Collector collector, Package package)
            : base("resolve", errors, package)
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
            Collector.ResolveTime.Start();
            MakeExpose(module);
            Collector.ResolveTime.Stop();
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
                    break;
                case ExposingSome some:
                    foreach (var exposed in some.Exposed)
                    {
                        Exposed(module, exposed);
                    }
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void Exposed(Module module, Exposed exposed)
        {
            switch (exposed)
            {
                case ExposedType type:
                    var decl = module.Scope.ResolveType(type.Name);
                    Assert(decl != null);
                    break;
                case ExposedVar var:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
