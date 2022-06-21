using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class TypeScope : Scope
    {
        private readonly Dictionary<Identifier, Type.Parameter> parameters = new();

        public void Add(Type.Parameter parameter)
        {
            var name = parameter.Name.SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(Identifier identifier, [MaybeNullWhen(false)] out Type.Parameter var)
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
