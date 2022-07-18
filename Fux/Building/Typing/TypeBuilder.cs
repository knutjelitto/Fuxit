#pragma warning disable IDE0066 // Convert switch statement to expression

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
                    {
                        return new W.Type.Function(Resolve(env, function.InType), Resolve(env, function.OutType));
                    }

                case A.Type.Tuple2 tuple2:
                    {
                        return new W.Type.Tuple2(Resolve(env, tuple2.Type1), Resolve(env, tuple2.Type2));
                    }

                case A.Type.Tuple3 tuple3:
                    {
                        return new W.Type.Tuple3(Resolve(env, tuple3.Type1), Resolve(env, tuple3.Type2), Resolve(env, tuple3.Type3));
                    }

                case A.Type.NumberClass number:
                    {
                        return VarType(number.Text);
                    }

                case A.Type.ComparableClass comparable:
                    {
                        return VarType(comparable.Text);
                    }

                case A.Type.AppendableClass appendable:
                    {
                        return VarType(appendable.Text);
                    }

                case A.Type.Parameter parameter:
                    {
                        return VarType(parameter.Text);
                    }

                case A.Type.Unit:
                    {
                        return new W.Type.Unit();
                    }

                case A.Type.Bool:
                    {
                        return new W.Type.Bool();
                    }

                case A.Type.Integer:
                    {
                        return new W.Type.Integer();
                    }

                case A.Type.Float:
                    {
                        return new W.Type.Float();
                    }

                case A.Type.String:
                    {
                        return new W.Type.String();
                    }

                case A.Type.Char:
                    {
                        return new W.Type.Char();
                    }

                case A.Type.List list:
                    {
                        return new W.Type.List(Resolve(env, list.Argument));
                    }

                case A.Type.CustomX custom:
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
                        return new W.Type.Custom(custom.FullName(), args.ToArray());
                    }

                case A.Type.Custom ctor:
                    {
                        Assert(ctor.InModule != null);
                        Assert(ctor.Resolved.InModule != null);

                        var args = ctor.Arguments.Select(t => Resolve(env, t)).ToArray();
                        return new W.Type.Custom(ctor.FullName(), args);
                    }

                case A.Type.Record record:
                    {
                        Assert(record.BaseRecord == null);

                        var fields = new List<W.Type.Field>();
                        foreach (var f in record.Fields)
                        {
                            var name = f.Name.Text;
                            var ty = Resolve(env, f.Type);

                            var field = new W.Type.Field(name, ty);
                            fields.Add(field);
                        }

                        var rec = new W.Type.Record(fields);

                        return rec;
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
