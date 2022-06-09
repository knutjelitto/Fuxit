using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building
{
    internal class LetScope : Scope
    {
        private readonly List<Identifier> identifiers = new();
        private readonly Dictionary<Identifier, Identifier> identifiersIndex = new();

        public void Add(Identifier parameter)
        {
            var name = parameter.SingleLower();

            Assert(!identifiersIndex.ContainsKey(name));

            identifiers.Add(parameter);
            identifiersIndex.Add(name, parameter);
        }

        public void Add(Identifier identifier, Dictionary<Identifier, TypeHint> hints)
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

        public bool LookupIdentifier(Identifier identifier, [MaybeNullWhen(false)] out Identifier var)
        {
            return identifiersIndex.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public override bool Resolve(Identifier identifier, [MaybeNullWhen(false)] out Expression expr)
        {
            if (identifier.IsSingleLower)
            {
                if (LookupIdentifier(identifier, out var item))
                {
                    expr = item;
                    return true;
                }
            }

            return base.Resolve(identifier, out expr);
        }
    }
}
