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

        public void TypeVar(A.VarDecl var, int numero, bool investigated)
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
                Writer.WriteLine("====================================================================================================");
                Writer.Indent(() =>
                {
                    var lines = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    Writer.WriteLine($"{any.Message}");
                    foreach (var line in lines)
                    {
                        Writer.WriteLine($"{line}");
                        if (line.LastIndexOf(":line ") > 0)
                        {
                            break;
                        }
                    }
                });
                Writer.WriteLine();
            }
        }

        private void Resolve(A.VarDecl var, bool investigated)
        {
            if (var.Name.Text == "radians")
            {
                Assert(true);
            }

            var inferrer = new W.Inferrer();
            var gamma = inferrer.GetEmptyEnvironment();

            Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var varType = typeBuilder.Build(gamma, var.Type);

            var variable = new W.Expr.Variable(var.Name);
            gamma = gamma.Insert(variable.Term, varType);

            var varExpr = exprBuilder.Build(ref gamma, var.Expression.Resolved, investigated);

            var (wexpr, wtype) = bindBuilder.Bind(varType.Type, varExpr, var.Parameters, ref gamma, investigated);

            var def = new W.Expr.Def(variable, wexpr);
            var unify = new W.Expr.Unify(wtype, wexpr);

            Writer.Indent(() =>
            {
                Resolve(inferrer, gamma, unify, investigated);
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
            var type = inferrer.Run(expression, env, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
        }
    }
}
