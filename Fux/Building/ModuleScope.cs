using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0017 // Simplify object initialization

namespace Fux.Building
{
    public sealed class ModuleScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Decl.Import> imports = new();
        private readonly Dictionary<A.Identifier, A.Decl.Infix> infixesIndex = new();
        private readonly Dictionary<A.Identifier, A.Decl.Custom> types = new();
        private readonly Dictionary<A.Identifier, A.Decl.Alias> aliases = new();
        private readonly Dictionary<A.Identifier, A.Decl.Ctor> constructors = new();
        private readonly Dictionary<A.Identifier, Module> modules = new();
        private readonly Dictionary<A.Identifier, A.Decl.Native> natives = new();

        public Module Module { get; }

        public ModuleScope(Module module)
        {
            Module = module;
        }

        public void AddImport(A.Decl.Import import)
        {
            var name = import.Name.MultiUpper();

            Assert(!imports.ContainsKey(name));

            imports.Add(name, import);
        }

        public void AddInfix(A.Decl.Infix decl)
        {
            var name = decl.Name.SingleOp();

            Assert(!infixesIndex.ContainsKey(name));

            infixesIndex.Add(name, decl);
        }

        public void AddType(A.Decl.Custom decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!types.ContainsKey(name));

            types.Add(name, decl);
        }

        public void AddAlias(A.Decl.Alias decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!aliases.ContainsKey(name));

            aliases.Add(name, decl);
        }

        public void AddConstructor(A.Decl.Ctor constructor)
        {
            var name = constructor.Name.SingleUpper();

            Assert(!constructors.ContainsKey(name));

            constructors.Add(name, constructor);
        }

        public void AddModule(A.Identifier name, Module module)
        {
            Assert(!modules.ContainsKey(name));
            modules.Add(name, module);
        }

        public void AddNative(A.Decl.Native decl)
        {
            var name = decl.Name.SingleLower();

            Assert(!natives.ContainsKey(name));

            natives.Add(name, decl);
        }

        public bool ImportAddImport(A.Decl.Import import)
        {
            return imports.TryAdd(import.Name.MultiUpper(), import);
        }

        public bool ImportAddAlias(A.Decl.Alias decl)
        {
            return aliases.TryAdd(decl.Name.SingleUpper(), decl);
        }


        public bool ImportAddType(A.Decl.Custom decl)
        {
            return types.TryAdd(decl.Name.SingleUpper(), decl);
        }

        public bool ImportAddInfix(A.Decl.Infix decl)
        {
            return infixesIndex.TryAdd(decl.Name.SingleOp(), decl);
        }

        public bool ImportAddConstructor(A.Decl.Ctor constructor)
        {
            return constructors.TryAdd(constructor.Name.SingleUpper(), constructor);
        }

        public bool ImportAddModule(A.Identifier name, Module module)
        {
            return modules.TryAdd(name, module);
        }

        public bool LookupImport(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Import import)
        {
            return imports.TryGetValue(identifier.MultiUpper(), out import);
        }

        public bool LookupImportAlias(A.Identifier alias, [MaybeNullWhen(false)] out A.Decl.Import import)
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

        public bool LookupInfix(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Infix infix)
        {
            return infixesIndex.TryGetValue(identifier.SingleOp(), out infix);
        }

        public bool LookupType(A.Identifier identifier, [MaybeNullWhen(false)]out A.Decl.Custom type)
        {
            return types.TryGetValue(identifier.SingleUpper(), out type);
        }

        public bool LookupAlias(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Alias alias)
        {
            return aliases.TryGetValue(identifier.SingleUpper(), out alias);
        }

        public bool LookupConstructor(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Ctor constructor)
        {
            return constructors.TryGetValue(identifier.SingleUpper(), out constructor);
        }

        public bool LookupNative(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Native native)
        {
            return natives.TryGetValue(identifier.SingleLower(), out native);
        }

        public bool LookupModule(A.Identifier identifier, [MaybeNullWhen(false)] out Module module)
        {
            return modules.TryGetValue(identifier.MultiUpper(), out module);
        }

        public override bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl decl)
        {
            Assert(Parent == null);

            if (identifier.IsSingleUpper)
            {
                if (LookupType(identifier, out var typeDecl))
                {
                    decl = typeDecl;
                    return true;
                }
                else if (LookupAlias(identifier, out var aliasDecl))
                {
                    decl = aliasDecl;
                    return true;
                }
                else if (LookupConstructor(identifier, out var ctorDecl))
                {
                    decl = ctorDecl;
                    return true;
                }
            }
            if (identifier.IsSingleOp)
            {
                if (LookupInfix(identifier, out var infixDecl))
                {
                    decl = infixDecl;
                    return true;
                }
            }
            else if (identifier.IsMulti2Plus)
            {
                var (importName, memberName) = identifier.SplitLast();

                Assert(importName.IsMultiUpper);

                foreach (var importModule in FindModules(importName))
                {
                    if (importModule.IsBuiltin)
                    {
                        if (!importModule.Scope.LookupNative(memberName, out var native))
                        {
                            Assert(importName.Text.StartsWith("Fux.Core."));
                            native = new A.Decl.Native(importName, memberName);
                            native.InModule = importModule;
                            Collector.Instance.Native.Add(native);
                            importModule.Scope.AddNative(native);
                        }

                        decl = native;
                        return true;
                    }
                    else if (importModule.Scope.Resolve(memberName, out var resolved))
                    {
                        decl = resolved;
                        return true;
                    }
                }

                decl = null;
                return false;
            }

            return base.Resolve(identifier, out decl);

            IEnumerable<Module> FindModules(A.Identifier importName)
            {
                if (LookupModule(importName, out var importModule))
                {
                    yield return importModule;
                }

                if (LookupImport(importName, out var import))
                {
                    Assert(import.InModule != null);

                    yield return import.InModule;
                }

                if (LookupImportAlias(importName, out import))
                {
                    Assert(import.InModule != null);

                    yield return import.InModule;
                }

                foreach (var foreignImport in imports.Values)
                {
                    if (foreignImport.InModule!.Scope.LookupModule(importName, out var foreign))
                    {
                        yield return foreign;
                    }
                }
            }
        }
    }
}
