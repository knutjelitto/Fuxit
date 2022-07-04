using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    public sealed class Resolver
    {
        private readonly TypeBuilder typeBuilder;
        private readonly ExprBuilder exprBuilder;
        private readonly BindBuilder bindBuilder;

        public Resolver(Writer writer, Package package, Module module)
        {
            Writer = writer;
            Package = package;
            Module = module;
            Pretty = new W.Pretty(Writer);

            typeBuilder = new();
            exprBuilder = new(module, typeBuilder);
            bindBuilder = new(module, exprBuilder);
        }

        public Writer Writer { get; }
        public Package Package { get; }
        public Module Module { get; }
        public W.Pretty Pretty { get; }

        public void TypeVar(A.Decl.Var var, int numero, bool investigated)
        {
            try
            {
                Writer.WriteLine($"{numero,4}. {Module.NickName}({var.Name.Location.Line})");
                Writer.WriteLine();
                Writer.Indent(() =>
                {
                    Writer.Write($"{var.Name}");
                    if (var.Parameters.Count > 0)
                    {
                        Writer.WriteLine($" {var.Parameters}");
                    }
                    else
                    {
                        Writer.WriteLine();
                    }
                    if (var.Type != null)
                    {
                        Writer.Indent(() => Writer.WriteLine($": {var.Type}"));
                    }
                    Writer.Indent(() =>
                    {
                        Writer.WriteLine($"= {var.Expression}");
                    });
                });

                Writer.WriteLine();
                Resolve(var, investigated);
                Writer.WriteLine();
            }
            catch (Exception any)
            {
                Writer.Indent(() =>
                {
                    Writer.WriteLine("====================================================================================================");
                    Writer.WriteLine($"{any.Message}");
                    Writer.WriteLine();

                    var lines = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    foreach (var line in lines)
                    {
                        Writer.WriteLine($"{line}");
                    }
                });
                Writer.WriteLine();
            }
        }

        private void Resolve(A.Decl.Var var, bool investigated)
        {
            if (var.Name.Text == "radians")
            {
                Assert(true);
            }

            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var varType = typeBuilder.Build(env, var.Type);

            var variable = new W.Expr.Variable(var.Name);
            env = env.Insert(variable.Term, varType);

            var varExpr = exprBuilder.Build(ref env, var.Expression.Resolved, investigated);

            var (wexpr, wtype) = bindBuilder.Bind(varType.Type, varExpr, var.Parameters, ref env, investigated);

            var expression = new W.Expr.Unify(wtype, wexpr);

            Writer.Indent(() =>
            {
                Resolve(inferrer, env, expression, investigated);
            });
        }

        private void PrintEnv(W.Environment env)
        {
            Writer.WriteLine();
            foreach (var (var, polytype) in env.Enumerate())
            {
                Writer.WriteLine($"{var}: {polytype}");
            }
        }

        private void Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression, bool investigated)
        {
            Pretty.Print(expression);
            PrintEnv(env);
            Writer.WriteLine();
            var type = inferrer.Run(env, expression, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
        }
    }
}
