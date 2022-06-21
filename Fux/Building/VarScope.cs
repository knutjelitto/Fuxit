using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class VarScope : Scope
    {
        private readonly Dictionary<Identifier, Parameter> parameters = new();

        public void Add(Parameter parameter)
        {
            Assert(parameter.Expression is Identifier);
            var name = ((Identifier)parameter.Expression).SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(Identifier identifier, [MaybeNullWhen(false)] out Parameter var)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public override bool Resolve(Identifier identifier, [MaybeNullWhen(false)] out Expression expr)
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
