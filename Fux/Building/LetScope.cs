using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building
{
    internal class LetScope : Scope
    {
        private readonly List<Identifier> identifiers = new();
        private readonly Dictionary<string, Identifier> identifiersIndex = new();

        public void Add(Identifier parameter)
        {
            var name = parameter.SingleLower();

            Assert(!identifiersIndex.ContainsKey(name));

            identifiers.Add(parameter);
            identifiersIndex.Add(name, parameter);
        }

        public void Add(Identifier identifier, Dictionary<string, TypeHint> hints)
        {
            var name = identifier.SingleLower();

            Assert(!identifiersIndex.ContainsKey(name));

            if (hints.TryGetValue(name, out var typeHint))
            {
                identifier.TypeHint = typeHint;
                hints.Remove(name);
            }

            identifiers.Add(identifier);
            identifiersIndex.Add(name, identifier);
        }
    }
}
