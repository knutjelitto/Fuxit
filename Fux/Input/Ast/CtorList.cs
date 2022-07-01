using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class CtorList : ListOf<Decl.Constructor>
    {
        public CtorList(IEnumerable<Decl.Constructor> items)
            : base(items)
        {
        }

        public CtorList(params Decl.Constructor[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return string.Join(" | ", this);
        }
    }

}
