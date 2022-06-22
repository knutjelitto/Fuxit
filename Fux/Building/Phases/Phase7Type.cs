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
        private int wildcardNumber = 0;
        private static int resolvedCount = 0;
        private const int resolvedCountMin = 1 + 0;
        private const int resolvedCountMax = resolvedCountMin - 1 + 60;

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

                Module = module;
                Make(module);
            }
        }

        private Module Module { get; set; }

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
                var line = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).First().TrimStart();

                writer.WriteLine();                
                writer.WriteLine($"!!!! {any.Message}");
                writer.WriteLine($"     {line}");
                writer.WriteLine();
            }
        }

        private void Resolve(Writer writer, Module module, VarDecl var)
        {
            wildcardNumber = 0;

            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            if (var.Name.Text == "negate")
            {
                Assert(resolvedCount == 28);
            }

            if (var.Name.Text == "fromPolar")
            {
                Assert(true);
            }

            if (var.Name.Text == "min")
            {
                Assert(true);
            }

            Assert(var.Type != null);

            Assert(var.Parameters.Count >= 0);

            var polytype = builder.Build(env, var.Type);

            var name = new W.TermVariable(var.Name.Text);
            env = env.Insert(name, polytype);

            var parameters = new List<Parameter>(var.Parameters);

            var wexpr = Binder(var.Expression, parameters, polytype.Type, ref env);

            var variable = new W.Variable(name);
            var def = new W.DefExpression(variable, wexpr);

            writer.WriteLine();

            writer.Indent(() =>
            {
                if (var.Name.Text == "negate")
                {
                    Assert(resolvedCount == 28);
                }
                Resolve(writer, inferrer, env, def);
            });

        }

        private IEnumerable<Identifier> BindIdentifiers(Parameter parameter)
        {
            return BindIdentifiers(parameter.Expression).Where(id => id.IsSingleLower);
        }

        private IEnumerable<Identifier> BindIdentifiers(Expression expression)
        {
            switch (expression)
            {
                case A.Identifier id:
                    yield return id;
                    break;

                case A.TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case A.SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        foreach (var id in BindIdentifiers(expr))
                        {
                            yield return id;
                        }
                    }
                    break;

                case A.Wildcard:
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
                case W.VariableType variableType:
                    yield return variableType;
                    break;
                case W.PrimitiveType primitiveType:
                    yield return primitiveType;
                    break;
                case W.FunctionType functionType:
                    foreach (var ty in BindTypes(functionType.InType))
                    {
                        yield return ty;
                    }
                    break;
                case W.Tuple2Type tuple2Type:
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

        private W.Expr Binder(Expression expression, List<Parameter> parameters, W.Type type, ref W.Environment env)
        {
            var expr = ExprFrom(expression, ref env);

            for (var p = parameters.Count - 1; p >= 0; p--)
            {
                switch (type)
                {
                    case W.FunctionType func:
                        {
                            var identifiers = BindIdentifiers(parameters[p]).ToList();
                            var types = BindTypes(func.InType).ToList();
                            Assert(identifiers.Count == types.Count);

                            for (var i = identifiers.Count - 1; i >= 0; i--)
                            {
                                var term = new W.TermVariable(identifiers[i].Text);
                                env = env.Insert(term, new W.Polytype(types[i]));

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
                case A.IntegerLiteral literal:
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
            var type = inferrer.Run(expression, env);
            writer.WriteLine($"OUTPUT: {type}");
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
