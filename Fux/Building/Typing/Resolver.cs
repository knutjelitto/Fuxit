namespace Fux.Building.Typing
{
    public sealed class Resolver
    {
        private readonly TypeBuilder typeBuilder;
        private readonly ExprBuilder exprBuilder;

        public Resolver(Writer writer, Package package, Module module)
        {
            Writer = writer;
            Package = package;
            Module = module;
            Pretty = new W.Pretty(Writer);

            typeBuilder = new();
            exprBuilder = new(module, typeBuilder);
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
                    if (investigated)
                    {
                        Writer.WriteLine($"<<<investigated>>>");
                        Writer.WriteLine();
                    }
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

                Collector.Instance.NumberOfExceptions++;
            }
        }

        private void Resolve(A.Decl.Var var, bool investigated)
        {
            var inferrer = new W.Inferrer();
            var env = inferrer.GetEmptyEnvironment();

            Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var expression = exprBuilder.Build(ref env, var, investigated);

            Writer.Indent(() =>
            {
                Resolve(inferrer, env, expression, investigated);
            });
        }

        private void PrintEnv(W.Environment env)
        {
            Writer.WriteLine();
            foreach (var (var, polytype) in env.Enumerate().OrderBy(v => v.var.Name))
            {
                Writer.WriteLine($"{var}: {polytype}");
            }
        }

        private void Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression, bool investigated)
        {
            Pretty.PP(expression);
            Writer.EndLine();
            PrintEnv(env);
            Writer.WriteLine();
            var type = inferrer.Run(env, expression, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
        }
    }
}
