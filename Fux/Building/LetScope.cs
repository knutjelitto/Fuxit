using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    public sealed class LetScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Decl.Parameter> parameters = new();

        public void Add(A.Decl.Parameter parameter)
        {
            Assert(parameter.Pattern is A.Pattern.LowerId);
            var name = ((A.Pattern.LowerId)parameter.Pattern).Identifier.SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Parameter var)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out var);
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
