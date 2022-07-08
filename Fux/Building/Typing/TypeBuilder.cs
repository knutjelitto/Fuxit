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
                return new W.Polytype(env.GetNext());
            }

            vars.Clear();
            index.Clear();

            var wtype = Resolve(env, type);

            return new W.Polytype(wtype, vars);
        }

        private W.Type Resolve(W.Environment env, A.Type type)
        {
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

                case A.Type.Unit:
                    return new W.Type.Unit();

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
                        switch (concrete.Name.Text)
                        {
                            case Lex.Primitive.Int:
                                return new W.Type.Integer();
                            case Lex.Primitive.Float:
                                return new W.Type.Float();
                            case Lex.Primitive.Bool:
                                return new W.Type.Bool();
                            case Lex.Primitive.String:
                                return new W.Type.String();
                            case Lex.Primitive.Char:
                                return new W.Type.Char  ();
                        }
                        return new W.Type.Concrete(concrete, concrete.Name.Text);
                    }

                case A.Type.Primitive.List list:
                    return new W.Type.List(Resolve(env, list.Argument));

                case A.Type.Custom custom:
                    {
                        Assert(custom.InModule != null);

                        switch (custom.Name.Text)
                        {
                            case Lex.Primitive.Int:
                                return new W.Type.Integer();
                            case Lex.Primitive.Float:
                                return new W.Type.Float();
                            case Lex.Primitive.Bool:
                                return new W.Type.Bool();
                            case Lex.Primitive.String:
                                return new W.Type.String();
                            case Lex.Primitive.Char:
                                return new W.Type.Char();
                        }

                        var args = custom.Parameters.Select(t => VarType(t.Text)).ToList();
                        return new W.Type.Concrete(custom, custom.Name.Text, args.ToArray());
                    }
                case A.Type.Ctor ctor:
                    {
                        Assert(ctor.InModule != null);

                        var args = ctor.Arguments.Select(t => Resolve(env, t)).ToList();
                        if (args.Count > 0)
                        {
                            return new W.Type.Concrete(ctor, ctor.Name.Text, args.ToArray());
                        }
                        return new W.Type.Concrete(ctor, ctor.Name.Text);
                    }
            }
            throw new NotImplementedException($"type not implemented: '{type.Resolved.GetType().FullName}({type})'");

            W.Type.Variable VarType(string text)
            {
                if (!index.TryGetValue(text, out var typeVar))
                {
                    typeVar = env.GetNext(text).TypeVar;
                    index.Add(text, typeVar);
                    vars.Add(typeVar);
                }
                return new W.Type.Variable(typeVar);
            }
        }
    }
}
