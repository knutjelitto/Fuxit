namespace Fux.Input.Ast
{
    public interface Expr : Node
    {
        Identifier? Alias { get; set; }
        Node Resolved { get; set; }

        public abstract class ExprImpl : NodeImpl, Expr
        {
            protected const int WhatIsLong = 60;

            public ExprImpl()
            {
                Alias = null;
                Resolved = this;
            }

            public Identifier? Alias { get; set; }

            public Node Resolved { get; set; }
        }

    }
}
