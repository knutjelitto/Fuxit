namespace Fux.Input.Ast
{
    public abstract class Ref : Expr.ExprImpl
    {
        public Ref(Declaration decl)
        {
            Declaration = decl;
        }

        public Declaration Declaration { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public abstract class RefImpl<T> : Ref
            where T : Declaration
        {
            public RefImpl(T declaration)
                : base(declaration)
            {
            }

            public T Decl => (T)Declaration;
        }

        public sealed class Parameter : RefImpl<ParameterDecl>
        {
            public Parameter(ParameterDecl decl) : base(decl) { }
        }

        public sealed class Var : RefImpl<VarDecl>
        {
            public Var(VarDecl decl) : base(decl) { }
        }

        public sealed class Ctor : RefImpl<Constructor>
        {
            public Ctor(Constructor decl) : base(decl) { }
        }

        public sealed class Infix : RefImpl<InfixDecl>
        {
            public Infix(InfixDecl decl) : base(decl) { }
        }

        public sealed class Type : RefImpl<TypeDecl>
        {
            public Type(TypeDecl decl) : base(decl) { }
        }

        public sealed new class Alias : RefImpl<AliasDecl>
        {
            public Alias(AliasDecl decl) : base(decl) { }
        }

        public sealed class Native : RefImpl<A.NativeDecl>
        {
            public Native(A.NativeDecl decl) : base(decl) { }
        }
    }
}
