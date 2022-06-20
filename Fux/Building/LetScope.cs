using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class LetScope : Scope
    {
        private readonly Dictionary<Identifier, Identifier> identifiers = new();

        public void Add(Identifier parameter)
        {
            var name = parameter.SingleLower();

            Assert(!identifiers.ContainsKey(name));

            identifiers.Add(name, parameter);
        }

        public bool LookupIdentifier(Identifier identifier, [MaybeNullWhen(false)] out Identifier var)
        {
            return identifiers.TryGetValue(identifier.SingleLowerOrOp(), out var);
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
