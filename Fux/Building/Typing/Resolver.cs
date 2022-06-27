﻿using static Fux.Building.AlgorithmW.Expr;

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
            Pretty = new W.Pretty(Writer);

            typeBuilder = new();
            exprBuilder = new(typeBuilder);
            bindBuilder = new(module, exprBuilder);
        }

        public Writer Writer { get; }
        public Package Package { get; }
        public Module Module { get; }
        public W.Pretty Pretty { get; }

        public void TypeVar(A.VarDecl var, int no, bool investigated)
        {
            try
            {
                Writer.Write($"{no,4}. {var.Name}");
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
                var lines = any.StackTrace!.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                Writer.WriteLine($"!!!! {any.Message}");
                foreach (var line in lines)
                {
                    Writer.WriteLine($"     {line}");
                    if (line.LastIndexOf(":line ") > 0)
                    {
                        break;
                    }
                }
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

            var variable = new W.Expr.Variable(var.Name);
            env = env.Insert(variable.Term, varType);

            var varExpr = exprBuilder.Build(var.Expression, ref env);

            var (wexpr, wtype) = bindBuilder.Bind(varType.Type, varExpr, var.Parameters, ref env, investigated);

            var def = new W.Expr.Def(variable, wexpr);
            var unify = new W.Expr.Unify(wtype, wexpr);

            Writer.Indent(() =>
            {
                Resolve(inferrer, env, unify, investigated);
            });
        }

        private void More(bool investigated, W.Expr expr, W.Environment env)
        {
            if (investigated)
            {
                foreach (var (var, polytype) in env.Enumerate())
                {
                    Writer.WriteLine($"{var}: {polytype}");
                }
                Writer.WriteLine();

                Pretty.Print(expr);
                Writer.WriteLine();
            }
        }

        private void Resolve(W.Inferrer inferrer, W.Environment env, W.Expr expression, bool investigated)
{
            More(investigated, expression, env);

            Writer.WriteLine($"INPUT: {expression}");
            var type = inferrer.Run(expression, env, investigated);
            Writer.WriteLine($"OUTPUT: {type}");
        }
    }
}
