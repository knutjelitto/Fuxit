using W = Fux.Building.AlgorithmW;

#pragma warning disable IDE0051 // Remove unused private members

namespace Fux.Building.Typing
{
    public sealed class BindBuilder
    {
        public BindBuilder(Module module, ExprBuilder exprBuilder)
        {
            Module = module;
            ExprBuilder = exprBuilder;
        }

        public Module Module { get; }
        public ExprBuilder ExprBuilder { get; }

        public W.Type Bind(ref W.Environment env, W.Type type, A.Parameters parameters, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }
            else
            {
                //Assert(parameters.Count == 0);
            }

            var (types, result) = Flatten(type);

            Assert(parameters.Count <= types.Count);

            for (var p = parameters.Count - 1; p >= 0; --p)
            {
                var pr = parameters[p];
                var ty = types[p];

                var parameterNames = BindIdentifiers(pr).ToList();
                List<W.Type> parameterTypes;

                if (parameterNames.Count == 1)
                {
                    parameterTypes = new List<W.Type> { ty };
                }
                else
                {
                    parameterTypes = BindTypes(ty).ToList();
                }

                Assert(parameterNames.Count == parameterTypes.Count);
                var count = parameterNames.Count;

                for (var i = 0; i < count; i++)
                {
                    var parameterName = parameterNames[i];
                    var parameterType = parameterTypes[i];

                    switch (parameterType)
                    {
                        case W.Type.Variable:
                        case W.Type.Primitive:
                        case W.Type.Function:
                        case W.Type.Concrete:
                        case W.Type.Primitive.List:
                            {
                                var term = new W.TermVariable(parameterName);
                                env = env.Insert(term, new W.Polytype(parameterType));
                                break;
                            }
                        case W.Type.Tuple2:
                            {
                                break;
                            }
                        default:
                            Assert(false);
                            throw new NotImplementedException();
                    }
                }
            }

            result = Recombine(types, parameters.Count, result);

            return result;
        }

        private W.Type Recombine(List<W.Type> types, int index, W.Type type)
        {
            if (index < types.Count)
            {
                return new W.Type.Function(types[index], Recombine(types, index + 1, type));
            }
            return type;
        }

        private static (List<W.Type>, W.Type) Flatten(W.Type type)
        {
            var result = new List<W.Type>();

            while (type is W.Type.Function func)
            {
                result.Add(func.InType);

                type = func.OutType;
            }

            return (result, type);
        }

        private IEnumerable<A.Identifier> BindIdentifiers(A.Decl.Parameter parameter)
        {
            Assert(parameter.Expression is A.Pattern);

            if (parameter.Expression is A.Pattern pattern)
            {
                return pattern.Flatten(() =>
                {
                    return ExprBuilder.GenWildcard();
                });
            }
            return BindIdentifiers(parameter.Expression).Where(id => id.IsSingleLower);
        }

        private IEnumerable<A.Identifier> BindIdentifiers(A.Expr expression)
        {
            switch (expression)
            {
                case A.Identifier id:
                    yield return id;
                    break;

                case A.Expr.Tuple tuple:
                    foreach (var expr in tuple)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case A.Expr.Sequence sequence:
                    foreach (var expr in sequence)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case A.Wildcard:
                    yield return ExprBuilder.GenWildcard();
                    break;

                default:
                    Assert(false);
                    throw new NotImplementedException($"{expression}");
            }
        }

        private IEnumerable<W.Type> BindTypes(W.Type type)
        {
            switch (type)
            {
                case W.Type.Variable variableType:
                    yield return variableType;
                    break;
                case W.Type.Primitive primitiveType:
                    yield return primitiveType;
                    break;
                case W.Type.Function functionType:
                    foreach (var ty in BindTypes(functionType.InType))
                    {
                        yield return ty;
                    }
                    break;
                case W.Type.Tuple2 tuple2Type:
                    foreach (var ty in BindTypes(tuple2Type.Type1))
                    {
                        yield return ty;
                    }
                    foreach (var ty in BindTypes(tuple2Type.Type2))
                    {
                        yield return ty;
                    }
                    break;
                case W.Type.Tuple3 tuple3Type:
                    foreach (var ty in BindTypes(tuple3Type.Type1))
                    {
                        yield return ty;
                    }
                    foreach (var ty in BindTypes(tuple3Type.Type2))
                    {
                        yield return ty;
                    }
                    foreach (var ty in BindTypes(tuple3Type.Type3))
                    {
                        yield return ty;
                    }
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
