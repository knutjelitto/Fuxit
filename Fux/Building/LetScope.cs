using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class LetScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Parameter> parameters = new();

        public void Add(A.Parameter parameter)
        {
            Assert(parameter.Expression is A.Identifier);
            var name = ((A.Identifier)parameter.Expression).SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(A.Identifier identifier, [MaybeNullWhen(false)] out A.Parameter var)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public override bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Expression expr)
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
