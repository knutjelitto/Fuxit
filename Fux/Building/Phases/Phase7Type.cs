using W = Fux.Building.AlgorithmW;
using T = Fux.Building.Typing;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building.Phases
{
    internal class Phase7Typing : Phase
    {
        private const int underInvestigation = 127; //328;
        private static int resolvedCount = 0;
        private const int resolvedCountMin = 1 + 0; //326;
        private const int resolvedCountMax = resolvedCountMin - 1 + 250; //45;

        //private static Func<int, bool> Qualify = (no => no == huntingFor);
        private static readonly Func<int, bool> Qualify = no => true;

        public Phase7Typing(Ambience ambience, Package package)
            : base("typing", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Terminal.Write(".");

                if (module.IsJs)
                {
                    continue;
                }

                if (resolvedCount >= resolvedCountMax)
                {
                    continue;
                }

                MakeModule(module);
            }
        }

        private void MakeModule(Module module)
        {
            Collector.TypeTime.Start();
            Make(module);
            Collector.TypeTime.Stop();
        }

        private void Make(Module module)
        {
            Assert(module.Ast != null);

            if (resolvedCount >= resolvedCountMax)
            {
                return;
            }

            var declarations = module.Ast.Declarations.OfType<A.VarDecl>().ToList();


            if (resolvedCount + declarations.Count < resolvedCountMin)
            {
                resolvedCount += declarations.Count;
                return;
            }

            using (var writer = Ambience.Config.WriteTheTyping ? MakeWriter(module) : MakeWriter())
            {
                var resolver = new T.Resolver(writer, Package, module);

                foreach (var declaration in declarations)
                {
                    resolvedCount += 1;

                    if (resolvedCount < resolvedCountMin)
                    {
                        continue;
                    }

                    if (Qualify(resolvedCount))
                    {
                        resolver.TypeVar(declaration, resolvedCount, resolvedCount == underInvestigation);
                    }

                    if (resolvedCount >= resolvedCountMax)
                    {
                        break;
                    }
                }
            }
        }
    }
}
