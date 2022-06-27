namespace Fux.Input.Ast
{
    internal abstract class Expr : Node
    {
        protected const int WhatIsLong = 60;

        protected Expr()
        {
            Resolved = this;
        }

        public Identifier? Alias { get; set; }

        public Expr Resolved { get; set; }
    }
}
