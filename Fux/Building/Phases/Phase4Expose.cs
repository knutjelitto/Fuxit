﻿#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.Phases
{
    public sealed class Phase4Expose : Phase
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

                if (module.IsBuiltin)
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

#if false
            if (Package.IsCore && module.Name == Lex.Primitive.List)
            {
                var exposing = FakeList.MakeExposing(module);

                Exposing(module, exposing);
            }
#endif

            if (header.Exposing != null)
            {
                Exposing(module, header.Exposing);
            }
        }

        private void Exposing(Module module, A.Exposing exposing)
        {
            switch (exposing)
            {
                case A.ExposingAll:
                    ExposeAll(module);
                    break;
                case A.ExposingSome some:
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
                    case A.Decl.Custom type:
                        var exposedType = new A.Exposed.Type(type.Name, true);
                        foreach (var constructor in type.Ctors)
                        {
                            if (module.Scope.LookupConstructor(constructor.Name, out var ctor))
                            {
                                exposedType.Add(ctor);
                            }
                        }
                        module.Exposed.Add(exposedType);
                        break;
                    case A.Decl.Alias alias:
                        var exposedAlias = new A.Exposed.Type(alias.Name, false);
                        module.Exposed.Add(exposedAlias);
                        break;
                    case A.Decl.Var var:
                        var exposedVar = new A.Exposed.Var(var.Name);
                        module.Exposed.Add(exposedVar);
                        break;
                    case A.Decl.Infix infix:
                        var exposedInfix = new A.Exposed.Var(infix.Name);
                        module.Exposed.Add(exposedInfix);
                        break;
                    default:
                        break; ;
                }
            }
        }

        private A.Exposed Exposed(Module module, A.Exposed exposed)
        {
            switch (exposed)
            {
                case A.Exposed.Type exposedType:
                    if (module.Scope.LookupType(exposed.Name, out var type))
                    {
                        if (exposedType.Inclusive)
                        {
                            foreach (var constructor in type.Ctors)
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
                    else
                    {
                        Assert(false);
                        throw new NotImplementedException();
                    }
                case A.Exposed.Var exposedVar:
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
        }
    }
}
