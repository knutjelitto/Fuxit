namespace Fux.Building.Typing
{
    public sealed class Resolver
    {
        private readonly ExprBuilder exprBuilder;

        public Resolver(Writer writer, Package package, Module module)
        {
            Writer = writer;
            Package = package;
            Module = module;
            Pretty = new W.Pretty(Writer);

            exprBuilder = new(module);
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
            if (investigated)
            {
                Assert(true);
            }

            var inferrer = new W.Inferrer();

            //Assert(var.Type != null);
            Assert(var.Parameters.Count >= 0);

            var (env, expression) = exprBuilder.Build(var, investigated);

            Writer.Indent(() =>
            {
                if (investigated)
                {
                    Assert(true);
                }
                var type = Resolve(inferrer, env, expression, investigated);
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

        private W.Type Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression, bool investigated)
        {
            Pretty.PP(expression);
            Writer.EndLine();
            PrintEnv(env);
            Writer.WriteLine();
            var type = inferrer.Run(env, expression, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
            return type;
        }
    }
}
