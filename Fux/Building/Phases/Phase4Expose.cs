#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using Fux.Input.Ast;
using static Fux.Input.Ast.Type;

namespace Fux.Building.Phases
{
    internal class Phase4Expose : Phase
    {
        public Phase4Expose(Ambience ambience, Package package)
            : base("expose", ambience, package)
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

                Make(module);
            }
        }

        private void Make(Module module)
        {
            Collector.ExposeTime.Start();
            Expose(module);
            Collector.ExposeTime.Stop();
        }

        private void Expose(Module module)
        {
            var ast = module.Ast ?? throw new InvalidOperationException();

            var header = ast.Header;

            if (Package.IsCore && module.Name == Lex.Primitive.List)
            {
                var exposing = FakeList.MakeExposing(module);

                Exposing(module, exposing);
            }

            if (header.Exposing != null)
            {
                Exposing(module, header.Exposing);
            }
        }

        private void Exposing(Module module, Exposing exposing)
        {
            switch (exposing)
            {
                case ExposingAll:
                    ExposeAll(module);
                    break;
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

        private void ExposeAll(Module module)
        {
            foreach (var element in module.Ast!.Declarations)
            {
                switch (element)
                {
                    case UnionDecl type:
                        var exposedType = new ExposedType(type.Name, true);
                        foreach (var constructor in type.Constructors)
                        {
                            if (module.Scope.LookupConstructor(constructor.Name, out var ctor))
                            {
                                exposedType.Add(ctor);
                            }
                        }
                        module.Exposed.Add(exposedType);
                        break;
                    case AliasDecl alias:
                        var exposedAlias = new ExposedType(alias.Name, false);
                        module.Exposed.Add(exposedAlias);
                        break;
                    case VarDecl var:
                        var exposedVar = new ExposedVar(var.Name);
                        module.Exposed.Add(exposedVar);
                        break;
                    case InfixDecl infix:
                        var exposedInfix = new ExposedVar(infix.Name);
                        module.Exposed.Add(exposedInfix);
                        break;
                    default:
                        break; ;
                }
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
