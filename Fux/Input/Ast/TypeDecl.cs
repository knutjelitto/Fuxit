using Fux.Building;

namespace Fux.Input.Ast
{
    internal class Constructors : ListOf<Type.Constructor>
    {
        public Constructors(IEnumerable<Type.Constructor> items)
            : base(items)
        {
        }

        public Constructors(params Type.Constructor[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return string.Join(" | ", this);
        }
    }

}
