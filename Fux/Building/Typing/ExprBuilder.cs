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

        public W.Expr Build(ref W.Environment env, A.Expr expr, bool investigated)
        {
            switch (expr)
            {
                case A.Identifier identifier:
                    {
                        Assert(identifier.Resolved != null);

                        if (identifier.Resolved != null)
                        {
                            Assert(identifier.Resolved is A.Ref);

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

                                        var variable = new W.Expr.Variable(identifier.Text);

                                        var polytype = env.TryGet(variable.Term);

                                        if (polytype == null)
                                        {
                                            polytype = typeBuilder.Build(env, var.Type);
                                            env = env.Insert(variable.Term, polytype);
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
                                        var ctor = ctorRef.Decl;

                                        var variable = new W.Expr.Variable(ctor.Name);
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

                        return Apply(ref env, seqExpr, seqExpr.Count - 1);
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

                        return new W.Expr.Usage(new W.Expr.Usage(op, arg1), arg2);
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

                case A.Ref.Parameter parameterRef:
                    {
                        var parameter = parameterRef.Decl;

                        Assert(parameter.Expression is A.Identifier);

                        var variable = new W.Expr.Variable((A.Identifier)parameter.Expression);

                        return variable;
                    }

                case A.Expr.Let let:
                    {
                        return BuildLetExpr(ref env, let, investigated);
                    }

                case A.Expr.Matcher caseMatch:
                    {
                        return Matcher(ref env, caseMatch, investigated);
                    }

                case A.Expr.Case @case:
                    {
                        return BuildCaseExpr(ref env, @case, investigated);
                    }

                case A.Expr.Lambda lambda:
                    {
                        return BuildLambdaExpr(ref env, lambda, investigated);
                    }

                case A.Expr.List list:
                    {
                        return Cons(ref env, list, 0);
                    }

                case A.Pattern.Wildcard:
                    {
                        var id = GenWildcard();

                        var variable = new W.Expr.Variable(id.Text);

                        return variable;
                    }

                case A.Pattern.List list:
                    {
                        if (list.Patterns.Count == 0)
                        {
                            return new W.Expr.List.Empty();
                        }
                        Assert(false);
                        break;
                    }

                case A.Pattern.Signature sign:
                    {
                        if (sign.Parameters.Count == 0)
                        {
                            var variable = new W.Expr.Variable(sign.Name);

                            return variable;
                        }

                        Assert(false);
                        break;
                    }

                case A.Pattern.LowerId lower:
                    {
                        return Build(ref env, lower.Identifier, investigated);
                    }

                case A.Pattern.Destruct destruct:
                    {
                        Assert(destruct.Patterns.Count >= 2);

                        var list = destructure(ref env, destruct.Patterns, 0);

                        return list;

                        W.Expr.List destructure(ref W.Environment env, IReadOnlyList<A.Pattern> list, int index)
                        {
                            if (index + 2 == list.Count)
                            {
                                var first = Build(ref env, list[index], investigated);
                                var rest = Build(ref env, list[index + 1], investigated);

                                return new W.Expr.Decons(first, rest);
                            }
                            else
                            {
                                var first = Build(ref env, list[index], investigated);
                                var rest = destructure(ref env, list, index + 1);

                                return new W.Expr.Decons(first, rest);
                            }
                        }
                    }

                case A.Pattern.Ctor ctor:
                    {
                        var first = Build(ref env, ctor.Name, investigated);

                        if (ctor.Arguments.Count == 0)
                        {
                            return first;
                        }
                        else
                        {
                            return apply(ref env, first, ctor.Arguments.Count - 1);
                        }
                        break;

                        W.Expr apply(ref W.Environment env, W.Expr first, int index)
                        {
                            if (index < 0)
                            {
                                return first;
                            }
                            else
                            {
                                return new W.Expr.Usage(first, apply(ref env,Build(ref env, ctor.Arguments[index], investigated), index - 1));
                            }
                        }
                    }
                default:
                    Assert(false);
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

            W.Expr Apply(ref W.Environment env, A.Expr.Sequence seq, int index)
            {
                if (index == 1)
                {
                    return new W.Expr.Usage(
                        Build(ref env, seq[0], investigated),
                        Build(ref env, seq[1], investigated));
                }
                else
                {
                    Assert(index > 1);
                    return new W.Expr.Usage(
                        Apply(ref env, seq, index - 1),
                        Build(ref env, seq[index], investigated));
                }
            }
        }

        private W.Expr BuildLambdaExpr(ref W.Environment env, A.Expr.Lambda lambdaExpr, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }
            var expr = Build(ref env, lambdaExpr.Expression, investigated);

            foreach (var x in lambdaExpr.Parameters.Flatten(GenWildcard).Reverse())
            {
                var var = new W.TermVariable(x.Text);
                var type = env.Generator.GetNext();
                env = env.Insert(var, new W.Polytype(type));

                expr = new W.Expr.Lambda(var, expr);
            }

            return expr;
        }

        private W.Expr Matcher(ref W.Environment env, A.Expr.Matcher matcher, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, matcher.Expression, investigated);
            var abstractions = new List<W.Expr.Case>();
            foreach (var caseExpr in matcher.Cases)
            {
                var abstraction = BuildCaseExpr(ref env, caseExpr, investigated);
                abstractions.Add(abstraction);
            }

            return new W.Expr.Matcher(expr, abstractions.ToArray());
        }

        private W.Expr.Case BuildCaseExpr(ref W.Environment env, A.Expr.Case caseExpr, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, caseExpr.Expression, investigated);
            var pttn = Build(ref env, caseExpr.Pattern, investigated);

            foreach (var x in caseExpr.Pattern.Flatten(GenWildcard).Reverse())
            {
                var var = new W.TermVariable(x.Text);
                var type = env.Generator.GetNext();
                env = env.Insert(var, new W.Polytype(type));

                expr = new W.Expr.Lambda(var, expr);
            }

            return new W.Expr.Case(pttn, expr);
        }

        private W.Expr BuildLetExpr(ref W.Environment env, A.Expr.Let letExpr, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(ref env, letExpr.InExpression, investigated);

            foreach (var let in letExpr.LetDecls.Reverse())
            {
                var (name, expr) = BuildLet(ref env, let, investigated);

                inExpr = new W.Expr.Let(name, expr, inExpr);
            }

            return inExpr;
        }

        private (W.TermVariable name, W.Expr expr) BuildLet(ref W.Environment env, A.Decl let, bool investigated)
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
