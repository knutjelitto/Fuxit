using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class ConstructorList : ListOf<Constructor>
    {
        public ConstructorList(IEnumerable<Constructor> items)
            : base(items)
        {
        }

        public ConstructorList(params Constructor[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return string.Join(" | ", this);
        }
    }

}
