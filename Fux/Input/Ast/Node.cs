using Fux.Building;

namespace Fux.Input.Ast
{
    public interface Node
    {
        Tokens? Span { get; set; }

        Module? InModule { get; set; }

        ILocation Location { get; }

        void PP(Writer writer);

        string Protected(string text);

        public abstract class NodeImpl : Node
        {
            public Tokens? Span { get; set; } = null;

            public Module? InModule { get; set; } = null;

            public ILocation Location
            {
                get
                {
                    Assert(InModule != null);
                    if (Span == null)
                    {
                        return new Location(InModule.Source!, 0, 0);
                    }

                    Assert(Span != null);
                    return Span[0].Location;
                }
            }

            public virtual void PP(Writer writer)
            {
                writer.Write($"{ToString()}");
            }

            public string Protected(string text)
            {
                return $"({text})";
            }
        }
    }
}
