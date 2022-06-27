using Fux.Building;

namespace Fux.Input.Ast
{
    internal abstract class Node
    {
        public Tokens? Span { get; set; } = null;

        public Module? Module { get; set; } = null;

        public T With<T>(Module module)
            where T : Node
        {
            Module = module;

            return (T)this;
        }

        public ILocation Location
        {
            get
            {
                Assert(Span != null);

                return Span[0].Location;
            }
        }

        public abstract void PP(Writer writer);

        public bool Protect { get; set; } = false;

        protected string Protected(string text)
        {
            return Protect ? $"({text})" : text;
        }
    }
}
