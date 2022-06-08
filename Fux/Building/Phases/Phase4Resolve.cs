#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase4Resolve : Phase
    {
        public Collector Collector { get; }

        public Phase4Resolve(ErrorBag errors, Collector collector, Package package)
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
            Collector.ResolveTime.Stop();
        }
    }
}
