#pragma warning disable IDE0079 // Remove unnecessary suppression
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

        public (List<W.Type>, W.Type) Invert(W.Type type)
        {
            var list = invert(type).ToList();
            var result = list.First();
            var types = list.Skip(1).ToList();

            return (types, result);

            IEnumerable<W.Type> invert(W.Type type)
            {
                if (type is W.Type.Function func)
                {
                    foreach (var ty in invert(func.OutType))
                    {
                        yield return ty;
                    }
                    yield return func.InType;
                }
                else
                {
                    yield return type;
                }
            }
        }

        public (List<W.Type>, W.Type) Flatten(W.Type type)
        {
            var result = new List<W.Type>();

            while (type is W.Type.Function func)
            {
                result.Add(func.InType);

                type = func.OutType;
            }

            return (result, type);
        }

        public W.Type Recombine(List<W.Type> types, int index, W.Type result)
        {
            types.Reverse();

            if (index < types.Count)
            {
                return new W.Type.Function(types[index], Recombine(types, index + 1, result));
            }
            return result;
        }
    }
}
