using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    public sealed class ExprBuilder
    {
        private readonly TypeBuilder typeBuilder;
        private int wildcardNumber = 0;

        public ExprBuilder(Module module, TypeBuilder typeBuilder)
        {
            Module = module;
            this.typeBuilder = typeBuilder;
        }

        public Module Module { get; }

        public W.Expr Build(ref W.Environment env, A.Node expr, bool investigated)
        {
            switch (expr)
            {
                case A.Identifier identifier:
                    {
                        Assert(identifier.Resolved != null);

                        if (identifier.Resolved != null)
                        {
                            switch (identifier.Resolved)
                            {
                                case A.Ref.Native nativeRef:
                                    {
                                        var native = nativeRef.Decl;
                                        return new W.Expr.Native(native);
                                    }
                                case A.Ref.Infix infixRef:
                                    {
                                        if (investigated)
                                        {
                                            Assert(true);
                                        }

                                        var infix = infixRef.Decl;

                                        Assert(identifier.IsSingleOp);
                                        Assert(infix.Expression.Resolved is A.Ref.Var);

                                        return Build(ref env, infix.Expression.Resolved, investigated);
                                    }
                                case A.Ref.Var varRef:
                                    {
                                        var var = varRef.Decl;
                                        W.Polytype wtype;
                                        wtype = typeBuilder.Build(env, var.Type);
                                        var variable = new W.Expr.Variable(identifier.Text);
                                        var already = env.TryGet(variable.Term);
                                        if (already != null)
                                        {
                                            Assert(true);
                                            //Assert(already.ToString() == wtype.ToString());
                                        }
                                        else
                                        {
                                            env = env.Insert(variable.Term, wtype);
                                        }
                                        return variable;
                                    }
                                case A.Ref.Parameter parameterRef:
                                    {
                                        var parameter = parameterRef.Decl;
                                        Assert(parameter.Expression is A.Identifier);
                                        var name = (A.Identifier)parameter.Expression;
                                        var variable = new W.Expr.Variable(name);
                                        return variable;
                                    }
                                case A.Ref.Ctor ctorRef:
                                    {
                                        Assert(false);
                                        break;
                                    }
                                case A.Identifier name:
                                    {
                                        var variable = new W.Expr.Variable(name);
                                        return variable;
                                    }
                                default:
                                    Assert(false);
                                    break;
                            }
                        }
                        Assert(false);
                        break;
                    }

                case A.NativeDecl native:
                    return new W.Expr.Native(native);

                case A.Expr.If ifExpr:
                    {
                        var condition = Build(ref env, ifExpr.Condition, investigated);
                        var ifTrue = Build(ref env, ifExpr.IfTrue, investigated);
                        var ifFalse = Build(ref env, ifExpr.IfFalse, investigated);

                        return new W.Expr.Iff(condition, ifTrue, ifFalse);
                    }

                case A.Expr.Sequence seqExpr:
                    {
                        Assert(seqExpr.Count >= 2);

                        return Apply(seqExpr, seqExpr.Count - 1, ref env);
                    }

                case A.Expr.Tuple tupleExpr:
                    {
                        if (tupleExpr.Count == 2)
                        {
                            return new W.Expr.Tuple2(
                                Build(ref env, tupleExpr[0], investigated),
                                Build(ref env, tupleExpr[1], investigated)
                                );
                        }
                        break;
                    }

                case A.Expr.Literal.Integer literal:
                    return new W.Expr.Literal.Integer(literal.Value);

                case A.Expr.Literal.String literal:
                    return new W.Expr.Literal.String(literal.Value);

                case A.OpChain chain:
                    Assert(chain.Resolved is A.Expr.Infix);
                    return Build(ref env, chain.Resolved, investigated);

                case A.Expr.Infix infix:
                    {
                        var infixDecl = infix.Op.InfixDecl;
                        Assert(infixDecl != null);
                        var op = Build(ref env, infixDecl.Expression, investigated);
                        var arg1 = Build(ref env, infix.Lhs.Resolved, investigated);
                        var arg2 = Build(ref env, infix.Rhs.Resolved, investigated);

                        return new W.Expr.Application(new W.Expr.Application(op, arg1), arg2);
                    }

                case A.ParameterDecl parameter:
                    return Build(ref env, parameter.Expression, investigated);

                case A.VarDecl var:
                    {
                        var variable = new W.Expr.Variable(var.Name);

                        var polytype = env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            polytype = typeBuilder.Build(env, var.Type);

                            env = env.Insert(variable.Term, polytype);
                        }

                        return variable;
                    }

                case A.Ref.Var varRef:
                    {
                        var var = varRef.Decl;
                        var variable = new W.Expr.Variable(var.Name);

                        var polytype = env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            polytype = typeBuilder.Build(env, var.Type);

                            env = env.Insert(variable.Term, polytype);
                        }

                        return variable;
                    }

                case A.Ref.Native native:
                    {
                        return new W.Expr.Native(native.Decl);
                    }

                case A.Ref.Parameter parameter:
                    {
                        return Build(ref env, parameter.Decl.Expression, investigated);
                    }

                case A.Expr.Let let:
                    {
                        return BuildLetExpr(let, ref env, investigated);
                    }

                case A.Expr.CaseMatch caseMatch:
                    {
                        return BuildCaseExpr(caseMatch, ref env, investigated);
                    }

                case A.Expr.Lambda lambda:
                    {
                        return BuildLambdaExpr(lambda, ref env, investigated);
                    }

                case A.Expr.List list:
                    {
                        return Cons(ref env, list, 0);
                    }

                case A.Pattern.List list:
                    {
                        if (list.Patterns.Count == 0)
                        {
                            return new W.Expr.List.Empty();
                        }
                        break;
                    }

                case A.Pattern.Destruct destruct:
                    {
                        var first = destruct.Patterns.First();
                        var rest = destruct.Patterns.Skip(1).ToList();

                        var list = destructure(ref env, rest, 0);

                        break;

                        W.Expr.List destructure(ref W.Environment env, List<A.Pattern> list, int index)
                        {
                            if (index == list.Count)
                            {
                                return new W.Expr.Empty();
                            }
                            else
                            {
                                return new W.Expr.Cons(Build(ref env, list[index], investigated), destructure(ref env, list, index + 1));
                            }
                        }
                    }
                default:
                    break;
            }

            throw NotImplemented(expr);

            W.Expr.List Cons(ref W.Environment env, A.Expr.List list, int index)
            {
                if (index == list.Count)
                {
                    return new W.Expr.Empty();
                }
                else
                {
                    return new W.Expr.Cons(Build(ref env, list[index], investigated), Cons(ref env, list, index + 1));
                }
            }

            W.Expr Apply(A.Expr.Sequence seq, int index, ref W.Environment env)
            {
                if (index == 1)
                {
                    return new W.Expr.Application(
                        Build(ref env, seq[0], investigated),
                        Build(ref env, seq[1], investigated));
                }
                else
                {
                    Assert(index > 1);
                    return new W.Expr.Application(
                        Apply(seq, index - 1, ref env),
                        Build(ref env, seq[index], investigated));
                }
            }
        }

        private W.Expr BuildLambdaExpr(A.Expr.Lambda lambdaExpr, ref W.Environment env, bool investigated)
        {
            var expr = Build(ref env, lambdaExpr.Expression, investigated);

            foreach (var x in lambdaExpr.Parameters.Flatten(GenWildcard).Reverse())
            {
                var var = new W.TermVariable(x.Text);
                var type = env.Generator.GetNext();
                env = env.Insert(var, new W.Polytype(type));

                expr = new W.Expr.Abstraction(var, expr);
            }

            return expr;
        }

        private W.Expr BuildCaseExpr(A.Expr.CaseMatch caseMatch, ref W.Environment env, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, caseMatch.Expression, investigated);
            var abstractions = new List<W.Expr>();
            foreach (var lambda in caseMatch.Cases)
            {
                var abstraction = Build(ref env, lambda, investigated);
                abstractions.Add(abstraction);
            }

            return new W.Expr.CaseMatch(expr, abstractions.ToArray());
        }

        private W.Expr BuildLetExpr(A.Expr.Let letExpr, ref W.Environment env, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(ref env, letExpr.InExpression, investigated);

            foreach (var let in letExpr.LetDecls.Reverse())
            {
                var (name, expr) = BuildLet(let, ref env, investigated);

                inExpr = new W.Expr.Let(name, expr, inExpr);
            }

            return inExpr;
        }

        private (W.TermVariable name, W.Expr expr) BuildLet(A.Declaration let, ref W.Environment env, bool investigated)
        {
            switch (let)
            {
                case A.VarDecl var when var.Parameters.Count == 0:
                    {
                        var name = new W.TermVariable(var.Name.Text);
                        var expr = Build(ref env, var.Expression, investigated);

                        return (name, expr);
                    }
                default:
                    break;
            }

            Assert(false);
            throw NotImplemented(let);
        }

        private static Exception NotImplemented(A.Node node)
        {
            return new NotImplementedException($"missing implementation: '{node.GetType().FullName} - {node}'");
        }

        public A.Identifier GenWildcard()
        {
            return A.Identifier.Artificial(Module, $"_{++wildcardNumber}");
        }
    }
}
