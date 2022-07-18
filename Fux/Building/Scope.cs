using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    public class Scope
    {
        private readonly Dictionary<A.Identifier, A.Decl.Var> vars = new();
        private readonly Dictionary<A.Identifier, A.Decl.TypeAnnotation> annotations = new();
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

        public void AddHint(A.Decl.TypeAnnotation annotation)
        {
            var name = annotation.Name.SingleLower();

            Assert(!annotations.ContainsKey(name));

            annotations.Add(name, annotation);
        }

        public void AddVar(A.Decl.Var decl)
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

        public bool ImportAddVar(A.Decl.Var decl)
        {
            return vars.TryAdd(decl.Name.SingleLower(), decl);
        }

        public bool LookupVar(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Var var)
        {
            return vars.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public virtual bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl decl)
        {
            if (identifier.IsSingleLower && LookupVar(identifier, out var var))
            {
                decl = var;
                return true;
            }
            else if (Parent != null)
            {
                return Parent.Resolve(identifier, out decl);
            }
            decl = null;
            return false;
        }
    }
}
