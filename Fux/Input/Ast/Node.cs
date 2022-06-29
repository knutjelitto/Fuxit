using Fux.Building;

namespace Fux.Input.Ast
{
    public interface Node
    {
        Tokens? Span { get; set; }

        Module? Module { get; set; }

        ILocation Location { get; }

        void PP(Writer writer);

        string Protected(string text);

        public abstract class NodeImpl : Node
        {
            public Tokens? Span { get; set; } = null;

            public Module? Module { get; set; } = null;

            public ILocation Location
            {
                get
                {
                    Assert(Span != null);

                    return Span[0].Location;
                }
            }

            public abstract void PP(Writer writer);

            public string Protected(string text)
            {
                return $"({text})";
            }
        }
    }
}
