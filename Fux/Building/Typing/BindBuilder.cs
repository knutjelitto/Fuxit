using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    internal class BindBuilder
    {
        private int wildcardNumber = 0;

        public BindBuilder(Module module, ExprBuilder exprBuilder)
        {
            Module = module;
            ExprBuilder = exprBuilder;
        }

        public Module Module { get; }
        public ExprBuilder ExprBuilder { get; }

        public W.Expr Bind(W.Type type, W.Expr expr, Parameters parameters, ref W.Environment env, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            var (types, result) = Flatten(type);

            Assert(parameters.Count <= types.Count);

            for (var p = parameters.Count - 1; p >= 0; p--)
            {
                var pr = parameters[p];
                var ty = types[p];

                var identifiers = BindIdentifiers(pr).ToList();
                var types2 = BindTypes(ty).ToList();
                Assert(identifiers.Count == types2.Count);

                switch (ty)
                {
                    case W.Type.Variable:
                        break;
                    case W.Type.Primitive:
                        break;
                    case W.Type.Tuple2:
                        break;
                    case W.Type.Function:
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

            for (var p = parameters.Count - 1; p >= 0; p--)
            {
                switch (type)
                {
                    case W.Type.Function func:
                        {
                            var identifiers = BindIdentifiers(parameters[p]).ToList();
                            var types2 = BindTypes(func.InType).ToList();
                            Assert(identifiers.Count == types2.Count);

                            for (var i = identifiers.Count - 1; i >= 0; i--)
                            {
                                var term = new W.TermVariable(identifiers[i].Text);
                                env = env.Insert(term, new W.Polytype(types2[i]));
                                expr = new W.AbstractionExpression(term, expr);
                            }

                            type = func.OutType;

                            break;
                        }

                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }


            return expr;
        }

        private (List<W.Type>, W.Type) Flatten(W.Type type)
        {
            var result = new List<W.Type>();

            while (type is W.Type.Function func)
            {
                result.Add(func.InType);

                type = func.OutType;
            }

            return (result, type);
        }

        private IEnumerable<Identifier> BindIdentifiers(Parameter parameter)
        {
            return BindIdentifiers(parameter.Expression).Where(id => id.IsSingleLower);
        }

        private IEnumerable<Identifier> BindIdentifiers(Expression expression)
        {
            switch (expression)
            {
                case Identifier id:
                    yield return id;
                    break;

                case TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case Wildcard:
                    yield return Identifier.Artificial(Module, $"_{++wildcardNumber}");
                    break;

                default:
                    Assert(false);
                    throw new NotImplementedException();
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
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
