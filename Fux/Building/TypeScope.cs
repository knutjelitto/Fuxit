using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    public sealed class TypeScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Decl.TypeParameter> parameters = new();

        public void Add(A.Decl.TypeParameter parameter)
        {
            var name = parameter.Name.SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.TypeParameter parameter)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out parameter);
        }

        public override bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl expr)
        {
            if (identifier.IsSingleLower)
            {
                if (LookupParameter(identifier, out var item))
                {
                    expr = item;
                    return true;
                }
            }

            return base.Resolve(identifier, out expr);
        }
    }
}
