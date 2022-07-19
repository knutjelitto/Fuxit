using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public class TypeList : ListOf<Type>
    {
        public TypeList(IEnumerable<Type> items) : base(items)
        {
        }

        new public void Add(Type type)
        {
            base.Add(type);
        }
    }
}
