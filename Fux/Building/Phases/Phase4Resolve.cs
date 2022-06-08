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
            Assert(module.Parsed && module.Ast != null);

            Collector.ResolveTime.Start();
            foreach (var declaration in module.Ast.Declarations)
            {
                Resolve(module, declaration);
            }
            Collector.ResolveTime.Stop();
        }

        private void Resolve(Module module, Declaration declaration)
        {
            if (Collector.ResolveCount == 19)
            {
                Assert(true);
            }
            switch (declaration)
            {
                case ImportDecl:
                    return;
                case InfixDecl infix:
                    Resolve(module, infix);
                    break;
                case TypeDecl type:
                    Resolve(module, type);
                    break;
                case VarDecl var:
                    Resolve(module, var);
                    break;
                case TypeHint hint:
                    Resolve(module, hint);
                    break;
                default:
                    Assert(false);
                    throw new InvalidOperationException();
            }
            
            Collector.ResolveCount += 1;
        }

        private void Resolve(Module module, InfixDecl infix)
        {
            ResolveExpr(module.Scope, infix.Expression);
        }

        private void Resolve(Module module, VarDecl var)
        {
            ResolveExpr(var.Scope, var.Expression);
        }

        private void Resolve(Module module, TypeDecl type)
        {
            Assert(type.Parameters.Count >= 0);
            Assert(type.Constructors.Count >= 1);

            foreach (var ctor in type.Constructors)
            {
                ResolveType(type.Scope, ctor);
            }

        }

        private void Resolve(Module module, TypeHint hint)
        {
            ResolveType(module.Scope, hint.Type);
        }

        private void ResolveType(Scope scope, Type type)
        {
            switch (type)
            {
                case Type.Constructor ctor:
                    foreach (var arg in ctor.Arguments)
                    {
                        ResolveType(scope, arg);
                    }
                    break;
                case Type.Function function:
                    ResolveType(scope, function.Lhs);
                    ResolveType(scope, function.Rhs);
                    break;
                case Type.Number:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ResolveExpr(Scope scope, Expression expression)
        {
            switch (expression)
            {
                case Identifier identifier:
                    if (identifier.IsQualified)
                    {
                        Assert(true);
                    }
                    if (scope.Resolve(identifier, out var expr))
                    {
                        Assert(true);
                        break;
                    }
                    Assert(false);
                    throw new NotImplementedException();
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
