namespace Fux.Input.Ast
{
    public abstract class Ref : Expr.ExprImpl
    {
        public Ref(Identifier name, Decl decl)
        {
            Name = name;
            Declaration = decl;
        }

        public Identifier Name { get; }
        public Decl Declaration { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{Declaration}");
        }

        public abstract class RefImpl<T> : Ref
            where T : Decl
        {
            public RefImpl(Identifier name, T declaration)
                : base(name, declaration)
            {
            }

            public T Decl => (T)Declaration;
        }

        public sealed class Parameter : RefImpl<Decl.Parameter>
        {
            public Parameter(Identifier name, Decl.Parameter decl) : base(name, decl) { }
        }

        public sealed class Var : RefImpl<Decl.Var>
        {
            public Var(Identifier name, Decl.Var decl) : base(name, decl) { }
        }

        public sealed class Ctor : RefImpl<Decl.Ctor>
        {
            public Ctor(Identifier name, Decl.Ctor decl) : base(name, decl) { }
        }

        public sealed class Infix : RefImpl<Decl.Infix>
        {
            public Infix(Identifier name, Decl.Infix decl) : base(name, decl) { }
        }

        public sealed class Type : RefImpl<Decl.Custom>
        {
            public Type(Identifier name, Decl.Custom decl) : base(name, decl) { }
        }

        public sealed new class Alias : RefImpl<Decl.Alias>
        {
            public Alias(Identifier name, Decl.Alias decl) : base(name, decl) { }
        }

        public sealed class Native : RefImpl<Decl.Native>
        {
            public Native(Identifier name, Decl.Native decl) : base(name, decl) { }
        }
    }
}
