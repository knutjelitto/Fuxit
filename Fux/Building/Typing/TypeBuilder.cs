#pragma warning disable IDE0066 // Convert switch statement to expression

namespace Fux.Building.Typing
{
    public sealed class TypeBuilder
    {
        private readonly List<W.TypeVariable> vars = new();
        private readonly Dictionary<string, W.TypeVariable> index = new();

        public bool Investigated { get; set; } = false;

        public W.Polytype Build(W.Environment env, A.Type? type)
        {
            if (type == null)
            {
                return new W.Polytype(env.GetNextTypeVar());
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
                        return W.Type.Bool.Instance;
                    }

                case A.Type.Integer:
                    {
                        return W.Type.Integer.Instance;
                    }

                case A.Type.Float:
                    {
                        return W.Type.Float.Instance;
                    }

                case A.Type.String:
                    {
                        return W.Type.String.Instance;
                    }

                case A.Type.Char:
                    {
                        return W.Type.Char.Instance;
                    }

                case A.Type.List list:
                    {
                        return new W.Type.List(Resolve(env, list.Argument));
                    }

                case A.Type.Custom custom:
                    {
                        Assert(custom.Declaration != null);
                        Assert(custom == custom.Resolved);

                        var name = custom.FullName();

                        switch (name)
                        {
                            case $"Int.{Lex.Primitive.Int}":
                                return W.Type.Integer.Instance;
                            case $"Float.{Lex.Primitive.Float}":
                                return W.Type.Float.Instance;
                            case $"Bool.{Lex.Primitive.Bool}":
                                return W.Type.Bool.Instance;
                            case $"String.{Lex.Primitive.String}":
                                return W.Type.String.Instance;
                            case $"Char.{Lex.Primitive.Char}":
                                return W.Type.Char.Instance;
                        }

                        Assert(name != "Bool.Bool");
                        var args = custom.Arguments.Select(t => Resolve(env, t)).ToArray();
                        return new W.Type.Custom(name, args);
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
                    typeVar = env.GetNextTypeVar(text).TypeVar;
                    index.Add(text, typeVar);
                    vars.Add(typeVar);
                }
                return new W.Type.Variable(typeVar);
            }
        }
    }
}
