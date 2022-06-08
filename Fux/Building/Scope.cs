using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class Scope
    {
        private readonly Dictionary<Identifier, VarDecl> vars = new();
        private readonly Dictionary<Identifier, TypeHint> hints = new();

        public Scope? Parent { get; set; }
        public bool HintEmpty => hints.Count == 0;

        public void AddHint(TypeHint hint)
        {
            var name = hint.Name.SingleLower();

            Assert(!hints.ContainsKey(name));
            
            hints.Add(name, hint);
        }

        public void AddVar(VarDecl decl)
        {
            var name = decl.Name.SingleLower();

            Assert(!vars.ContainsKey(name));

            vars.Add(name, decl);

            if (hints.TryGetValue(name, out var hint))
            {
                decl.Name.TypeHint = hint;
                hints.Remove(name);
            }
        }

        public bool ImportAddVar(VarDecl decl)
        {
            return vars.TryAdd(decl.Name.SingleLower(), decl);
        }

        public bool ResolveVar(Identifier identifier, [MaybeNullWhen(false)] out VarDecl var)
        {
            return vars.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

    }
}
