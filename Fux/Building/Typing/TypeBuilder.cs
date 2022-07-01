using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    public sealed class TypeBuilder
    {
        private readonly List<W.TypeVariable> vars = new();
        private readonly Dictionary<string, W.TypeVariable> index = new();

        public W.Polytype Build(W.Environment env, A.Type? type)
        {
            if (type == null)
            {
                return new W.Polytype(env.Generator.GetNext());
            }

            vars.Clear();
            index.Clear();

            var wtype = Resolve(env, type);

            return new W.Polytype(wtype, vars);
        }

        private W.Type Resolve(W.Environment env, A.Type type)
        {
            if (type.ToString() == "a")
            {
                Assert(true);
            }
            switch (type.Resolved)
            {
                case A.Type.Function function:
                    return new W.Type.Function(Resolve(env, function.InType), Resolve(env, function.OutType));

                case A.Type.Tuple2 tuple2:
                    return new W.Type.Tuple2(Resolve(env, tuple2.Type1), Resolve(env, tuple2.Type2));

                case A.Type.Tuple3 tuple3:
                    return new W.Type.Tuple3(Resolve(env, tuple3.Type1), Resolve(env, tuple3.Type2), Resolve(env, tuple3.Type3));

                case A.Type.NumberClass number:
                    return VarType(number.Text);

                case A.Type.ComparableClass comparable:
                    return VarType(comparable.Text);

                case A.Type.AppendableClass appendable:
                    return VarType(appendable.Text);

                case A.Type.Parameter parameter:
                    return VarType(parameter.Text);

                case A.Type.Primitive.Bool:
                    return new W.Type.Bool();

                case A.Type.Primitive.Int:
                    return new W.Type.Integer();

                case A.Type.Primitive.Float:
                    return new W.Type.Float();

                case A.Type.Primitive.String:
                    return new W.Type.String();

                case A.Type.Primitive.Char:
                    return new W.Type.Char();

                case A.Type.Concrete concrete:
                    {
                        Assert(concrete.Name.Text != Lex.Primitive.Char);
                        return new W.Type.Concrete(concrete.Name.Text, Array.Empty<W.Type>());
                    }

                case A.Type.Primitive.List list:
                    return new W.Type.List(Resolve(env, list.Argument));

                case A.Type.Union union:
                    if (union.Arguments.Count > 0)
                    {
                        var args = union.Arguments.Select(t => Resolve(env, t)).ToList();
                        return new W.Type.Concrete(union.Name.Text, args.ToArray());
                    }
                    else
                    {
                        return new W.Type.Concrete(union.Name.Text, Array.Empty<W.Type>());
                    }
            }
            throw new NotImplementedException($"type not implemented: '{type.Resolved.GetType().FullName}({type})'");

            W.Type.Variable VarType(string text)
            {
                if (!index.TryGetValue(text, out var typeVar))
                {
                    typeVar = env.Generator.GetNext(text).TypeVar;
                    index.Add(text, typeVar);
                    vars.Add(typeVar);
                }
                return new W.Type.Variable(typeVar);
            }
        }
    }
}
