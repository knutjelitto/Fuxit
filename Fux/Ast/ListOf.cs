using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class ListOf<T> : IReadOnlyList<T>
    {
        private readonly List<T> items;

        public ListOf(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public T this[int index] => items[index];
        public int Count => items.Count;
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)items).GetEnumerator();
    }
}
