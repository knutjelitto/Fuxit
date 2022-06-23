using W = Fux.Building.AlgorithmW;
using T = Fux.Building.Typing;
using A = Fux.Input.Ast;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building.Phases
{
    internal class Phase7Typing : Phase
    {
        private static int resolvedCount = 0;
        private const int resolvedCountMin = 1 + 0;
        private const int resolvedCountMax = resolvedCountMin - 1 + 60;

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

                Make(module);
            }
        }

        private void Make(Module module)
        {
            Collector.TypeTime.Start();
            Type(module);
            Collector.TypeTime.Stop();
        }

        private void Type(Module module)
        {
            Assert(module.Ast != null);

            if (resolvedCount >= resolvedCountMax)
            {
                return;
            }

            var declarations = module.Ast.Declarations.OfType<VarDecl>().ToList();


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

                    resolver.TypeVar(declaration, resolvedCount);

                    if (resolvedCount >= resolvedCountMax)
                    {
                        break;
                    }
                }
            }
        }
    }
}
