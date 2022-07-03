namespace Fux.Input.Ast
{
    public abstract class Ref : Expr.ExprImpl
    {
        public Ref(Decl decl)
        {
            Declaration = decl;
        }

        public Decl Declaration { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public abstract class RefImpl<T> : Ref
            where T : Decl
        {
            public RefImpl(T declaration)
                : base(declaration)
            {
            }

            public T Decl => (T)Declaration;
        }

        public sealed class Parameter : RefImpl<Decl.Parameter>
        {
            public Parameter(Decl.Parameter decl) : base(decl) { }
        }

        public sealed class Var : RefImpl<Decl.Var>
        {
            public Var(Decl.Var decl) : base(decl) { }
        }

        public sealed class Ctor : RefImpl<Decl.Ctor>
        {
            public Ctor(Decl.Ctor decl) : base(decl) { }
        }

        public sealed class Infix : RefImpl<Decl.Infix>
        {
            public Infix(Decl.Infix decl) : base(decl) { }
        }

        public sealed class Type : RefImpl<Decl.Custom>
        {
            public Type(Decl.Custom decl) : base(decl) { }
        }

        public sealed new class Alias : RefImpl<Decl.Alias>
        {
            public Alias(Decl.Alias decl) : base(decl) { }
        }

        public sealed class Native : RefImpl<A.Decl.Native>
        {
            public Native(A.Decl.Native decl) : base(decl) { }
        }
    }
}
