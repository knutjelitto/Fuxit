using W = Fux.Building.AlgorithmW;
using A = Fux.Input.Ast;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building.Phases
{
    internal class Phase7Typing : Phase
    {
        private static int resolvedCount = 0;
        private const int resolvedCountMin = 1 + 40;
        private const int resolvedCountMax = resolvedCountMin - 1 + 20;

        private readonly TypeBuilder builder = new();

        public Phase7Typing(Ambience ambience, Package package)
            : base("typing", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Terminal.Write(".");

                if (module.IsJs)
                {
                    continue;
                }

                if (resolvedCount >= resolvedCountMax)
                {
                    continue;
                }

                Make(module);
            }
        }

        private void Make(Module module)
        {
            Collector.TypeTime.Start();
            Type(module);
            Collector.TypeTime.Stop();
        }

        private void Type(Module module)
        {
            Assert(module.Ast != null);

            if (resolvedCount >= resolvedCountMax)
            {
                return;
            }

            var declarations = module.Ast.Declarations.OfType<VarDecl>().ToList();


            if (resolvedCount + declarations.Count < resolvedCountMin)
            {
                resolvedCount += declarations.Count;
                return;
            }

            if (resolvedCount + declarations.Count > resolvedCountMax)
            {
                resolvedCount += declarations.Count;
                return;
            }

            using (var writer = Ambience.Config.WriteTheTyping ? MakeWriter(module) : MakeWriter())
            {
                foreach (var declaration in declarations)
                {
                    resolvedCount += 1;

                    if (resolvedCount < resolvedCountMin)
                    {
                        continue;
                    }

                    TypeVar(writer, module, declaration);

                    if (resolvedCount >= resolvedCountMax)
                    {
                        break;
                    }
                }
            }
        }

        private void TypeVar(Writer writer, Module module, VarDecl var)
        {
            try
            {
                writer.WriteLine($"{resolvedCount,4} {var.Name}");
                writer.Indent(() =>
                {
                    if (var.Type != null)
                    {
                        writer.WriteLine($": {var.Type}");
                    }
                    if (var.Parameters.Count > 0)
                    {
                        writer.Write($"{var.Parameters} ");
                    }

                    writer.WriteLine($"= {var.Expression}");
                });

                Resolve(writer, module, var);
            }
            catch (Exception any)
            {
                writer.WriteLine();
                writer.WriteLine($"!!!! {any.Message}");
                writer.WriteLine();
            }
        }

        private IEnumerable<Identifier> Identifiers(Parameters parameters)
        {
            foreach (var parameter in parameters)
            {
                foreach (var identifier in ids(parameter.Expression))
                {
                    if (identifier.IsSingleLower)
                    {
                        yield return identifier;
                    }
                }
            }

            IEnumerable<Identifier> ids(Expression expression)
            {
                switch (expression)
                {
                    case A.Identifier id:
                        yield return id;
                        break;

                    case A.TupleExpr tuple:
                        foreach (var expr in tuple)
                        {
                            foreach (var id in ids(expr))
                            {
                                yield return id;
                            }
                        }
                        break;

                    case A.SequenceExpr sequence:
                        foreach (var expr in sequence)
                        {
                            foreach (var id in ids(expr))
                            {
                                yield return id;
                            }
                        }
                        break;

                    case A.Wildcard:
                        break;

                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }
        }

        private void Resolve(Writer writer, Module module, VarDecl var)
        {
            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            if (var.Name.Text == "fromPolar")
            {
                Assert(true);
            }

            Assert(var.Type != null);

            Assert(var.Parameters.Count >= 0);
            //Assert(var.Parameters.All(p => p.Expression is Identifier));

            var polytype = builder.Build(env, var.Type);

            var parameters = Identifiers(var.Parameters).ToList();

            var name = new W.TermVariable(var.Name.Text);
            env = env.Insert(name, polytype);

            var wexpr = Binder(parameters, polytype.Type);

            var variable = new W.Variable(name);
            var def = new W.DefExpression(variable, wexpr);

            writer.WriteLine();

            writer.Indent(() =>
            {
                Resolve(writer, inferrer, env, def);
            });

            W.Expr Binder(List<Identifier> parameters, W.Type type)
            {
                if (parameters.Count > 0)
                {
                    switch (type)
                    {
                        case W.FunctionType:
                            {
                                Assert(type is W.FunctionType);

                                var term = new W.TermVariable(parameters[0].Text);
                                parameters.RemoveAt(0);

                                var func = (W.FunctionType)type;

                                env = env.Insert(term, new W.Polytype(func.InType));

                                return new W.AbstractionExpression(term, Binder(parameters, func.OutType));
                            }
                        case W.Tuple2Type:
                            {
                                break;
                            }

                        default:
                            Assert(false);
                            throw new NotImplementedException();
                    }
                    Assert(false);
                    throw new NotImplementedException();
                }

                return ExprFrom(var.Expression, ref env);
            }
        }

        private W.Expr ExprFrom(Expression expr, ref W.Environment env)
        {
            switch(expr)
            {
                case Identifier identifier:
                    Assert(identifier.Resolved != null);
                    if (identifier.Resolved != null)
                    {
                        switch (identifier.Resolved)
                        {
                            case NativeDecl native:
                                return new W.NativeExpression(native);
                            case VarDecl var:
                                {
                                    Assert(identifier.IsSingleLower);
                                    Assert(var.Type != null);
                                    var variable = new W.Variable(new W.TermVariable(identifier.Text));
                                    var already = env.TryGet(variable.Term);
                                    var wtype = builder.Build(env, var.Type);
                                    if (already != null)
                                    {
                                        Assert(true);
                                        Assert(already.ToString() == wtype.ToString());
                                    }
                                    else
                                    {
                                        env = env.Insert(variable.Term, wtype);
                                    }
                                    return variable;
                                }
                            case Parameter parameter:
                                {
                                    Assert(parameter.Expression is Identifier);
                                    var name = ((Identifier)parameter.Expression);
                                    var termVar = new W.TermVariable(name.Text);
                                    var variable = new W.Variable(termVar);
                                    return variable;
                                }
                            default:
                                break;
                        }
                    }
                    break;
                case NativeDecl native:
                    return new W.NativeExpression(native);
                case IfExpr ifExpr:
                    {
                        var condition = ExprFrom(ifExpr.Condition, ref env);
                        var ifTrue = ExprFrom(ifExpr.IfTrue, ref env);
                        var ifFalse = ExprFrom(ifExpr.IfFalse, ref env);

                        return new W.IffExpression(condition, ifTrue, ifFalse);
                    }
                case SequenceExpr seqExpr:
                    {
                        Assert(seqExpr.Count >= 2);

                        return Apply(seqExpr, seqExpr.Count - 1, ref env);
                    }
                case TupleExpr tupleExpr:
                    {
                        if (tupleExpr.Count == 2)
                        {
                            return new W.Tuple2Expression(
                                ExprFrom(tupleExpr[0], ref env),
                                ExprFrom(tupleExpr[1], ref env)
                                );
                        }
                        break;
                    }
                case IntegerLiteral literal:
                    return new W.IntegerLiteral(literal.Value);
                default:
                    break;
            }

            //Assert(false);
            throw new NotImplementedException($"expression not implemented: '{expr.GetType().FullName} - {expr}'");

            W.Expr Apply(SequenceExpr seq, int index, ref W.Environment env)
            {
                if (index == 1)
                {
                    return new W.ApplicationExpression(ExprFrom(seq[0], ref env), ExprFrom(seq[1], ref env));
                }
                else
                {
                    Assert(index > 1);
                    return new W.ApplicationExpression(Apply(seq, index - 1, ref env), ExprFrom(seq[index], ref env));
                }
            }
        }


        private static void Resolve(Writer writer, W.Inferrer inferrer, W.Environment env, W.Expr expression)
        {
            writer.WriteLine($"INPUT: {expression}");
            var result = inferrer.Run(expression, env);
            switch (result)
            {
                case (W.Type type, _):
                    writer.WriteLine($"OUTPUT: {type}");
                    break;
                case (_, W.Error(string error)):
                    throw new InvalidOperationException($"{error}");
                    writer.WriteLine($"FAIL: {error}");
                    break;
            }
            writer.WriteLine();
        }

        private class TypeBuilder
        {
            private readonly List<W.TypeVariable> vars = new();
            private readonly Dictionary<string, W.TypeVariable> index = new();

            public W.Polytype Build(W.Environment env, Type? type)
            {
                if (type == null)
                {
                    return new W.Polytype(env.Generator.GetNext());
                }

                vars.Clear();
                index.Clear();

                var wtype = Resolve(env, type);

                return new W.Polytype(vars, wtype);
            }

            private W.Type Resolve(W.Environment env, Type type)
            {
                switch (type)
                {
                    case Type.Function function:
                        return new W.FunctionType(Resolve(env, function.InType), Resolve(env, function.OutType));
                    case Type.Tuple2 tuple2:
                        return new W.Tuple2Type(Resolve(env, tuple2.Type1), Resolve(env, tuple2.Type2));
                    case A.Type.NumberClass number:
                        return VarType(number.Text);
                    case A.Type.ComparableClass comparable:
                        return VarType(comparable.Text);
                    case A.Type.AppendableClass appendable:
                        return VarType(appendable.Text);
                    case A.Type.Parameter parameter:
                        return VarType(parameter.Text);
                    case A.Type.Primitive.Bool:
                        return new W.BoolType();
                    case A.Type.Primitive.Int:
                        return new W.IntegerType();
                    case A.Type.Primitive.Float:
                        return new W.FloatType();
                    case A.Type.Primitive.String:
                        return new W.StringType();
                    case A.Type.Concrete concrete:
                        return new W.PrimitiveType(concrete.Name.Text);
                    case A.Type.Union union:
                        break;
                }
                throw new NotImplementedException($"type not implemented: '{type.GetType().FullName} - {type}'");

                W.VariableType VarType(string text)
                {
                    if (!index.TryGetValue(text, out var typeVar))
                    {
                        typeVar = env.Generator.GetNext(text).TypeVar;
                        index.Add(text, typeVar);
                        vars.Add(typeVar);
                    }
                    return new W.VariableType(typeVar);
                }
            }
        }
    }
}
