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
        private const int resolvedCountMin = 1;
        private const int resolvedCountMax = resolvedCountMin -1 + 10;

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

            if (resolvedCount + declarations.Count < resolvedCountMax)
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
            var number = resolvedCount;

            writer.WriteLine($"{number,4} {var.Name}");
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
                string text;

                if (var.Expression.Resolved is NativeDecl native)
                {
                    var package = module.Package.Name;
                    var stem = native.ModuleName.Text.Replace("Elm.Kernel.", "_");
                    text = $"({package}){stem}_{native.Name}";
                }
                else
                {
                    text = var.Expression.ToString()!;
                }
                writer.WriteLine($"= {text}");
            });

            Resolve(writer, module, var);
        }

        private void Resolve(Writer writer, Module module, VarDecl var)
        {
            writer.Indent(() =>
            {
                var inferrer = new W.Inferrer();
                var env = inferrer.GetEmptyEnvironment(new W.TypeVarGenerator());

                var polytype = builder.Build(env, var.Type);

                var name = new W.TermVariable(var.Name.Text);
                env = env.Insert(name, polytype);

                var wexpr = ExprFrom(var.Expression, env);

                var variable = new W.Variable(name);
                var def = new W.DefExpression(variable, wexpr);

                writer.WriteLine();
                Resolve(writer, inferrer, env, def);
            });
        }

        private W.Expr ExprFrom(Expression expr, W.Environment env)
        {
            switch(expr)
            {
                case Identifier identifier:
                    Assert(identifier.Resolved != null);
                    if (identifier.Resolved != null)
                    {
                        return ExprFrom(identifier.Resolved, env);
                    }
                    break;
                case NativeDecl native:
                    return new W.NativeExpression(native);
                default:
                    break;
            }

            Assert(false);
            throw new NotImplementedException();
        }


        private static void Resolve(Writer writer, W.Inferrer inferrer, W.Environment env, W.Expr expression)
        {
            try
            {
                writer.WriteLine($"INPUT: {expression}");
                var result = inferrer.Run(expression, env);
                switch (result)
                {
                    case (W.Type type, _):
                        writer.WriteLine($"OUTPUT: {type}");
                        break;
                    case (_, W.Error(string error)):
                        writer.WriteLine($"FAIL: {error}");
                        break;
                }
                writer.WriteLine();
            }
            catch (Exception any)
            {
                writer.WriteLine();
                writer.WriteLine($"{any.Message}");
                writer.WriteLine();
            }
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
                    case A.Type.Function function:
                        return new W.FunctionType(Resolve(env, function.TypeIn), Resolve(env, function.TypeOut));
                    case A.Type.NumberClass number:
                        if (!index.TryGetValue(number.Text, out var typeVar))
                        {
                            typeVar = env.Generator.GetNext().TypeVar;
                            index.Add(number.Text, typeVar);
                            vars.Add(typeVar);
                        }
                        return new W.VariableType(typeVar);
                    case A.Type.Concrete concrete:
                        return new W.PrimitiveType(concrete.Name.Text);
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
                Assert(false);
                throw new NotImplementedException();
            }
        }
    }
}
