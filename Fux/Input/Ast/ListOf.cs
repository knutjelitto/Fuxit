using System.Collections;

namespace Fux.Input.Ast
{
    internal class ListOf<T> : Expression, IReadOnlyList<T>
    {
        protected readonly List<T> items;

        public ListOf(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString()!);
        }

        public T this[int index] => items[index];
        public int Count => items.Count;
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)items).GetEnumerator();
    }
}
