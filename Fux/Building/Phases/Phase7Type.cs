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
        private const int underInvestigation = 90;
        private static int numero = 0;
        private const int numeroFrom = 1;
        private const int numeroTo = 150;

        //private static Func<int, bool> Qualify = (no => no == huntingFor);
        private static readonly Func<int, bool> Qualify = no => true;

        public Phase7Typing(Ambience ambience, Package package)
            : base("typing", ambience, package)
        {
        }

        public override void Make()
        {
            using (var writer = MakeWriter(Package))
            {
                foreach (var module in Package.Modules)
                {
                    Terminal.Write(".");

                    if (module.IsJs)
                    {
                        continue;
                    }

                    if (numero >= numeroTo)
                    {
                        continue;
                    }

                    MakeModule(module, writer);
                }
            }
        }

        private void MakeModule(Module module, Writer writer)
        {
            Collector.TypeTime.Start();
            Make(module, writer);
            Collector.TypeTime.Stop();
        }

        private void Make(Module module, Writer writer)
        {
            Assert(module.Ast != null);

            if (numero > numeroTo)
            {
                return;
            }

            var declarations = module.Ast.Declarations.OfType<A.VarDecl>().ToList();


            if (numero + declarations.Count < numeroFrom)
            {
                numero += declarations.Count;
                return;
            }

            var resolver = new T.Resolver(writer, Package, module);

            foreach (var declaration in declarations)
            {
                numero += 1;

                if (numero < numeroFrom)
                {
                    continue;
                }

                if (Qualify(numero))
                {
                    resolver.TypeVar(declaration, numero, numero == underInvestigation);
                }

                if (numero >= numeroTo)
                {
                    break;
                }
            }
        }
    }
}
