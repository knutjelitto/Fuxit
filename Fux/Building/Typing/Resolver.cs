using W = Fux.Building.AlgorithmW;

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

        public void TypeVar(A.VarDecl var, int no, bool investigated)
        {
            try
            {
                Writer.Write($"{no,4} {var.Name}");
                if (var.Parameters.Count > 0)
                {
                    Writer.Write($" {var.Parameters}");
                }
                if (var.Type != null)
                {
                    Writer.Write($" : {var.Type}");
                }
                Writer.WriteLine();

                Writer.Indent(() =>
                {
                    Writer.WriteLine($"{var.Expression}");
                });

                Writer.WriteLine();
                Resolve(var, investigated);
                Writer.WriteLine();
            }
            catch (Exception any)
            {
                var line = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).First().TrimStart();

                Writer.WriteLine($"!!!! {any.Message}");
                Writer.WriteLine($"     {line}");
                Writer.WriteLine();
            }
        }

        private void Resolve(A.VarDecl var, bool investigated)
        {
            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var varType = typeBuilder.Build(env, var.Type);

            var name = new W.TermVariable(var.Name.Text);
            env = env.Insert(name, varType);

            var varExpr = exprBuilder.Build(var.Expression, ref env);

            var (wexpr, wtype) = bindBuilder.Bind(varType.Type, varExpr, var.Parameters, ref env, investigated);

            var variable = new W.Variable(name);
            var def = new W.DefExpression(variable, wexpr);
            var unify = new W.UnifyExpression(wtype, wexpr);

            Writer.Indent(() =>
            {
                if (investigated)
                {
                    foreach (var (var, polytype) in env.Enumerate())
                    {
                        Writer.WriteLine($"{var}: {polytype}");
                    }
                    Writer.WriteLine();
                }
                Resolve(inferrer, env, unify, investigated);
            });

        }

        private void Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression, bool investigated)
        {
            Writer.WriteLine($"INPUT: {expression}");
            var type = inferrer.Run(expression, env, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
        }
    }
}
