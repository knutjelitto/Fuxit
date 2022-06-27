using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    internal class ExprBuilder
    {
        private readonly TypeBuilder typeBuilder;

        public ExprBuilder(TypeBuilder typeBuilder)
        {
            this.typeBuilder = typeBuilder;
        }

        public W.Expr Build(ref W.Environment env, A.Expr expr, bool investigated)
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
                                case A.NativeDecl native:
                                    return new W.Expr.Native(native);
                                case A.InfixDecl infix:
                                    {
                                        if (investigated) Assert(true);

                                        Assert(identifier.IsSingleOp);
                                        Assert(infix.Expression.Resolved != infix);
                                        Assert(infix.Expression.Resolved is A.VarDecl);

                                        return Build(ref env, infix.Expression.Resolved, investigated);
                                    }
                                case A.VarDecl var:
                                    {
                                        Assert(identifier.IsSingleLower || identifier.IsQualified);
                                        W.Polytype wtype;
                                        if (var.Type == null)
                                        {
                                            wtype = new W.Polytype(env.Generator.GetNext());
                                        }
                                        else
                                        {
                                            wtype = typeBuilder.Build(env, var.Type);
                                        }
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
                                case A.Parameter parameter:
                                    {
                                        Assert(parameter.Expression is A.Identifier);
                                        var name = (A.Identifier)parameter.Expression;
                                        var variable = new W.Expr.Variable(name);
                                        return variable;
                                    }
                                case A.Identifier name:
                                    {
                                        var variable = new W.Expr.Variable(name);
                                        return variable;
                                    }
                                default:
                                    break;
                            }
                        }
                        break;
                    }

                case A.NativeDecl native:
                    return new W.Expr.Native(native);

                case A.IfExpr ifExpr:
                    {
                        var condition = Build(ref env, ifExpr.Condition, investigated);
                        var ifTrue = Build(ref env, ifExpr.IfTrue, investigated);
                        var ifFalse = Build(ref env, ifExpr.IfFalse, investigated);

                        return new W.Expr.Iff(condition, ifTrue, ifFalse);
                    }

                case A.SequenceExpr seqExpr:
                    {
                        Assert(seqExpr.Count >= 2);

                        return Apply(seqExpr, seqExpr.Count - 1, ref env);
                    }

                case A.TupleExpr tupleExpr:
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

                case A.IntegerLiteral literal:
                    return new W.Expr.Literal.Integer(literal.Value);

                case A.StringLiteral literal:
                    return new W.Expr.Literal.String(literal.Value);

                case A.OpChain chain:
                    Assert(chain.Resolved is A.InfixExpr);
                    return Build(ref env, chain.Resolved, investigated);

                case A.InfixExpr infix:
                    {
                        Assert(infix.Op.Resolved != infix.Op);
                        var infixDecl = infix.Op.Resolved as A.InfixDecl;
                        Assert(infixDecl != null);
                        var op = Build(ref env, infixDecl.Expression, investigated);
                        var arg1 = Build(ref env, infix.Lhs.Resolved, investigated);
                        var arg2 = Build(ref env, infix.Rhs.Resolved, investigated);

                        return new W.Expr.Application(new W.Expr.Application(op, arg1), arg2);
                    }

                case A.Parameter parameter:
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

                case A.LetExpr letExpr:
                    return BuildLetExpr(letExpr, ref env, investigated);

                case A.ListExpr listExpr:
                    return Cons(ref env, listExpr, 0);

                default:
                    break;
            }

            throw NotImplemented(expr);

            W.Expr.List Cons(ref W.Environment env, A.ListExpr list, int index)
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

            W.Expr Apply(A.SequenceExpr seq, int index, ref W.Environment env)
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

        private W.Expr BuildLetExpr(A.LetExpr letExpr, ref W.Environment env, bool investigated)
        {
            if (investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(ref env, letExpr.InExpression, investigated);

            foreach (var let in letExpr.LetExpressions.Reverse())
            {
                var (name, expr) = BuildLet(let, ref env, investigated);

                inExpr = new W.Expr.Let(name, expr, inExpr);
            }

            return inExpr;
        }

        private (W.TermVariable name, W.Expr expr) BuildLet(A.Expr let, ref W.Environment env, bool investigated)
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

            Assert(true);
            throw NotImplemented(let);
        }

        private static Exception NotImplemented(A.Expr expr)
        {
            return new NotImplementedException($"missing implementation: '{expr.GetType().FullName} - {expr}'");
        }
    }
}
