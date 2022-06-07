namespace Fux.Input.Ast
{
    internal abstract class Expression
    {
        protected const int WhatIsLong = 60;

        public Identifier? Alias { get; set; }

        public abstract void PP(Writer writer);

        public bool Protect { get; set; } = false;

        protected string Protected(string text)
        {
            return Protect ? $"({text})" : text;
        }
    }
}
