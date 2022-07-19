using System.Collections;

namespace Fux.Input.Ast
{
    public class ListOf<T> : Expr.ExprImpl, IReadOnlyList<T>
    {
        protected readonly List<T> items;
        protected bool frozen = false;

        public ListOf(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString()!);
        }

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        protected void Add(T item)
        {
            if (frozen)
            {
                throw new InvalidOperationException($"ListOf<{typeof(T).Name}> is frozen ({this.GetType().Name})");
            }
            items.Add(item);
        }

        public void Freeze()
        {
            frozen = true;
        }

        public int Count => items.Count;
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)items).GetEnumerator();
    }
}
