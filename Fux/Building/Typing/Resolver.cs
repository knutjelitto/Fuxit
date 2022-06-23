using W = Fux.Building.AlgorithmW;
using A = Fux.Input.Ast;

namespace Fux.Building.Typing
{
    internal class Resolver
    {
        private readonly TypeBuilder typeBuilder;
        private readonly ExprBuilder exprBuilder;
        private readonly BindBuilder bindBuilder;

        public Resolver(Writer writer, Package package, Module module)
        {
            Writer = writer;
            Package = package;
            Module = module;

            typeBuilder = new();
            exprBuilder = new(typeBuilder);
            bindBuilder = new(module, exprBuilder);
        }

        public Writer Writer { get; }
        public Package Package { get; }
        public Module Module { get; }

        public void TypeVar(VarDecl var, int resolvedCount)
        {
            try
            {
                Writer.WriteLine($"{resolvedCount,4} {var.Name}");
                Writer.Indent(() =>
                {
                    if (var.Type != null)
                    {
                        Writer.WriteLine($": {var.Type}");
                    }
                    if (var.Parameters.Count > 0)
                    {
                        Writer.Write($"{var.Parameters} ");
                    }

                    Writer.WriteLine($"= {var.Expression}");
                });

                Resolve(var, resolvedCount);
            }
            catch (Exception any)
            {
                var line = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).First().TrimStart();

                Writer.WriteLine();
                Writer.WriteLine($"!!!! {any.Message}");
                Writer.WriteLine($"     {line}");
                Writer.WriteLine();
            }
        }

        private void Resolve(VarDecl var, int resolvedCount)
        {
            const int huntingFor = 45;

            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            var investigated = resolvedCount == huntingFor;

            Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var varType = typeBuilder.Build(env, var.Type);

            var name = new W.TermVariable(var.Name.Text);
            env = env.Insert(name, varType);

            var varExpr = exprBuilder.Build(var.Expression, ref env);

            var wexpr = bindBuilder.Bind(varType.Type, varExpr, var.Parameters, ref env, investigated);

            var variable = new W.Variable(name);
            var def = new W.DefExpression(variable, wexpr);

            Writer.WriteLine();

            Writer.Indent(() =>
            {
                if (resolvedCount == huntingFor)
                {
                    Assert(true);
                }
                Resolve(inferrer, env, def);
            });

        }

        private void Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression)
        {
            Writer.WriteLine($"INPUT: {expression}");
            var type = inferrer.Run(expression, env);
            Writer.WriteLine($"OUTPUT: {type}");
            Writer.WriteLine();
        }
    }
}
