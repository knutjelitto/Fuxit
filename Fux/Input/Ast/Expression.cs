namespace Fux.Input.Ast
{
    internal abstract class Expression
    {
        protected const int WhatIsLong = 60;

        protected Expression()
        {
            Resolved = this;
        }

        public Identifier? Alias { get; set; }

        public Tokens? Span { get; set; } = null;
        public Expression Resolved { get; set; }
        public Type? Type { get; set; } = null;

        public abstract void PP(Writer writer);

        public bool Protect { get; set; } = false;

        protected string Protected(string text)
        {
            return Protect ? $"({text})" : text;
        }
    }
}
