using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class Scope
    {
        private readonly Dictionary<Identifier, VarDecl> vars = new();
        private readonly Dictionary<Identifier, TypeHint> hints = new();
        private Scope? parent;

        public Scope? Parent
        {
            get => parent;
            set
            {
                Assert(value != null);
                parent = value;
            }
        }
        public bool HintsAreEmpty => hints.Count == 0;

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
                decl.Type = hint.Type ;
                hints.Remove(name);
            }
        }

        public bool ImportAddVar(VarDecl decl)
        {
            return vars.TryAdd(decl.Name.SingleLower(), decl);
        }

        public bool LookupVar(Identifier identifier, [MaybeNullWhen(false)] out VarDecl var)
        {
            return vars.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public virtual bool Resolve(Identifier identifier, [MaybeNullWhen(false)] out Expression expr)
        {
            if (identifier.IsSingleLower && LookupVar(identifier, out var var))
            {
                expr = var;
                return true;
            }
            else if (Parent != null)
            {
                return Parent.Resolve(identifier, out expr);
            }
            expr = null;
            return false;
        }
    }
}
