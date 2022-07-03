using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    public sealed class VarScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Decl.Parameter> parameters = new();

        public void Add(A.Decl.Parameter parameter)
        {
            Assert(parameter.Expression is A.Identifier);
            var name = ((A.Identifier)parameter.Expression).SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(A.Identifier identifier, [MaybeNullWhen(false)] out A.Decl.Parameter var)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public override bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Node expr)
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
