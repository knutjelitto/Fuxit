using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class Scope
    {
        private readonly Dictionary<A.Identifier, A.VarDecl> vars = new();
        private readonly Dictionary<A.Identifier, A.TypeAnnotation> annotations = new();
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
        public bool HintsAreEmpty => annotations.Count == 0;

        public void AddHint(A.TypeAnnotation annotation)
        {
            var name = annotation.Name.SingleLower();

            Assert(!annotations.ContainsKey(name));

            annotations.Add(name, annotation);
        }

        public void AddVar(A.VarDecl decl)
        {
            var name = decl.Name.SingleLower();

            Assert(!vars.ContainsKey(name));

            vars.Add(name, decl);

            if (annotations.TryGetValue(name, out var hint))
            {
                decl.Type = hint.Type ;
                annotations.Remove(name);
            }
        }

        public bool ImportAddVar(A.VarDecl decl)
        {
            return vars.TryAdd(decl.Name.SingleLower(), decl);
        }

        public bool LookupVar(A.Identifier identifier, [MaybeNullWhen(false)] out A.VarDecl var)
        {
            return vars.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public virtual bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Expr expr)
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
