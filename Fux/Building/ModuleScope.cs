using System.Diagnostics.CodeAnalysis;

using Fux.Building.Phases;

#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building
{
    internal class ModuleScope : Scope
    {
        private readonly Dictionary<Identifier, ImportDecl> imports = new();
        private readonly List<InfixDecl> infixes = new();
        private readonly Dictionary<Identifier, InfixDecl> infixesIndex = new();
        private readonly Dictionary<Identifier, TypeDecl> types = new();
        private readonly Dictionary<Identifier, AliasDecl> aliases = new();
        private readonly Dictionary<Identifier, Type.Constructor> constructors = new();
        private readonly Dictionary<Identifier, Module> modules = new();
        private readonly Dictionary<Identifier, NativeDecl> natives = new();

        public Module Module { get; }

        public ModuleScope(Module module)
        {
            Module = module;
        }

        public void AddImport(ImportDecl import)
        {
            var name = import.Name.MultiUpper();

            Assert(!imports.ContainsKey(name));

            imports.Add(name, import);
        }

        public void AddInfix(InfixDecl decl)
        {
            var name = decl.Name.SingleOp();

            Assert(!infixesIndex.ContainsKey(name));

            infixes.Add(decl);
            infixesIndex.Add(name, decl);
        }

        public void AddType(TypeDecl decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!types.ContainsKey(name));

            types.Add(name, decl);
        }

        public void AddAlias(AliasDecl decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!aliases.ContainsKey(name));

            aliases.Add(name, decl);
        }

        public void AddConstructor(Type.Constructor constructor)
        {
            var name = constructor.Name.SingleUpper();

            Assert(!constructors.ContainsKey(name));

            constructors.Add(name, constructor);
        }

        public void AddModule(Identifier name, Module module)
        {
            Assert(!modules.ContainsKey(name));
            modules.Add(name, module);
        }

        public void AddNative(NativeDecl decl)
        {
            var name = decl.Name.SingleLower();

            Assert(!natives.ContainsKey(name));

            natives.Add(name, decl);
        }

        public bool ImportAddImport(ImportDecl import)
        {
            return imports.TryAdd(import.Name.MultiUpper(), import);
        }

        public bool ImportAddAlias(AliasDecl decl)
        {
            return aliases.TryAdd(decl.Name.SingleUpper(), decl);
        }


        public bool ImportAddType(TypeDecl decl)
        {
            return types.TryAdd(decl.Name.SingleUpper(), decl);
        }

        public bool ImportAddInfix(InfixDecl decl)
        {
            var name = decl.Name.SingleOp();

            if (infixesIndex.TryAdd(name, decl))
            {
                infixes.Add(decl);

                return true;
            }
            return false;
        }

        public bool ImportAddConstructor(Type.Constructor constructor)
        {
            return constructors.TryAdd(constructor.Name.SingleUpper(), constructor);
        }

        public bool ImportAddModule(Identifier name, Module module)
        {
            return modules.TryAdd(name, module);
        }

        public bool LookupImport(Identifier identifier, [MaybeNullWhen(false)] out ImportDecl import)
        {
            return imports.TryGetValue(identifier.MultiUpper(), out import);
        }

        public bool LookupImportAlias(Identifier alias, [MaybeNullWhen(false)] out ImportDecl import)
        {
            foreach (var maybe in imports.Values)
            {
                if (alias.Equals(maybe.Alias))
                {
                    import = maybe;
                    return true;
                }
            }

            import = null;
            return false;
        }

        public bool LookupInfix(Identifier identifier, [MaybeNullWhen(false)] out InfixDecl infix)
        {
            return infixesIndex.TryGetValue(identifier.SingleOp(), out infix);
        }

        public bool LookupType(Identifier identifier, [MaybeNullWhen(false)]out TypeDecl type)
        {
            return types.TryGetValue(identifier.SingleUpper(), out type);
        }

        public bool LookupAlias(Identifier identifier, [MaybeNullWhen(false)] out AliasDecl alias)
        {
            return aliases.TryGetValue(identifier.SingleUpper(), out alias);
        }

        public bool LookupConstructor(Identifier identifier, [MaybeNullWhen(false)] out Type.Constructor constructor)
        {
            return constructors.TryGetValue(identifier.SingleUpper(), out constructor);
        }

        public bool LookupNative(Identifier identifier, [MaybeNullWhen(false)] out NativeDecl native)
        {
            return natives.TryGetValue(identifier.SingleLower(), out native);
        }

        public bool LookupModule(Identifier identifier, [MaybeNullWhen(false)] out Module module)
        {
            return modules.TryGetValue(identifier.MultiUpper(), out module);
        }

        public override bool Resolve(Identifier identifier, [MaybeNullWhen(false)] out Expression expr)
        {
            Assert(Parent == null);

            if (identifier.IsSingleUpper)
            {
                if (LookupType(identifier, out var type))
                {
                    expr = type;
                    return true;
                }
                else if (LookupConstructor(identifier, out var ctor))
                {
                    expr = ctor;
                    return true;
                }
                else if (LookupAlias(identifier, out var alias))
                {
                    expr = alias;
                    return true;
                }
                Assert(false);
                throw new NotImplementedException();
            }
            if (identifier.IsSingleOp)
            {
                if (LookupInfix(identifier, out var type))
                {
                    expr = type;
                    return true;
                }
            }
            else if (identifier.IsMulti2Plus)
            {
                var (importName, memberName) = identifier.SplitLast();

                Assert(importName.IsMultiUpper);

                foreach (var importModule in FindModules(importName))
                {
                    if (importModule.IsJs)
                    {
                        if (!importModule.Scope.LookupNative(memberName, out var native))
                        {
                            Assert(importName.Text.StartsWith("Elm.Kernel."));
                            native = new NativeDecl(importName, memberName);
                            Collector.Instance.NativeDecl.Add(native);
                            importModule.Scope.AddNative(native);
                        }

                        expr = native;
                        return true;
                    }
                    else if (importModule.Scope.Resolve(memberName, out var resolved))
                    {
                        expr = resolved;
                        return true;
                    }
                }

                Assert(false);
                throw new InvalidOperationException();
            }

            return base.Resolve(identifier, out expr);

            IEnumerable<Module> FindModules(Identifier importName)
            {
                if (LookupModule(importName, out var importModule))
                {
                    yield return importModule;
                }

                if (LookupImport(importName, out var import))
                {
                    Assert(import.Module != null);

                    yield return import.Module;
                }

                if (LookupImportAlias(importName, out import))
                {
                    Assert(import.Module != null);

                    yield return import.Module;
                }

                foreach (var foreignImport in imports.Values)
                {
                    if (foreignImport.Module!.Scope.LookupModule(importName, out var foreign))
                    {
                        yield return foreign;
                    }
                }
            }
        }
    }
}
