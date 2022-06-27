﻿using System.Diagnostics.CodeAnalysis;

namespace Fux.Building
{
    internal class TypeScope : Scope
    {
        private readonly Dictionary<A.Identifier, A.Type.Parameter> parameters = new();

        public void Add(A.Type.Parameter parameter)
        {
            var name = parameter.Name.SingleLower();

            Assert(!parameters.ContainsKey(name));

            parameters.Add(name, parameter);
        }

        public bool LookupParameter(A.Identifier identifier, [MaybeNullWhen(false)] out A.Type.Parameter var)
        {
            return parameters.TryGetValue(identifier.SingleLowerOrOp(), out var);
        }

        public override bool Resolve(A.Identifier identifier, [MaybeNullWhen(false)] out A.Expr expr)
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
