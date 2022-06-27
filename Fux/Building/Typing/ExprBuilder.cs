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

        public W.Expr Build(A.Expr expr, ref W.Environment env)
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
                                        Assert(identifier.IsSingleOp);
                                        Assert(infix.Expression.Resolved != infix);
                                        Assert(infix.Expression.Resolved is A.VarDecl);

                                        return Build(infix.Expression.Resolved, ref env);
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
                        var condition = Build(ifExpr.Condition, ref env);
                        var ifTrue = Build(ifExpr.IfTrue, ref env);
                        var ifFalse = Build(ifExpr.IfFalse, ref env);

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
                                Build(tupleExpr[0], ref env),
                                Build(tupleExpr[1], ref env)
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
                    return Build(chain.Resolved, ref env);

                case A.InfixExpr infix:
                    {
                        Assert(infix.Op.Resolved != infix.Op);
                        var infixDecl = infix.Op.Resolved as A.InfixDecl;
                        Assert(infixDecl != null);
                        var op = Build(infixDecl.Expression, ref env);
                        var arg1 = Build(infix.Lhs.Resolved, ref env);
                        var arg2 = Build(infix.Rhs.Resolved, ref env);

                        return new W.Expr.Application(new W.Expr.Application(op, arg1), arg2);
                    }

                case A.Parameter parameter:
                    return Build(parameter.Expression, ref env);

                case A.VarDecl var:
                    {
                        var variable = new W.Expr.Variable(var.Name);
                        var polytype = typeBuilder.Build(env, var.Type);

                        env = env.Insert(variable.Term, polytype);

                        return variable;
                    }

                case A.LetExpr letExpr:
                    return BuildLetExpr(letExpr, ref env);

                case A.ListExpr listExpr:
                    if (listExpr.Count == 0)
                    {
                        return new W.Expr.Empty();
                    }
                    break;

                default:
                    break;
            }

            throw NotImplemented(expr);

            W.Expr Apply(A.SequenceExpr seq, int index, ref W.Environment env)
            {
                if (index == 1)
                {
                    return new W.Expr.Application(Build(seq[0], ref env), Build(seq[1], ref env));
                }
                else
                {
                    Assert(index > 1);
                    return new W.Expr.Application(Apply(seq, index - 1, ref env), Build(seq[index], ref env));
                }
            }
        }

        private W.Expr BuildLetExpr(A.LetExpr letExpr, ref W.Environment env)
        {
            W.Expr inExpr = Build(letExpr.InExpression, ref env);

            foreach (var let in letExpr.LetExpressions.Reverse())
            {
                var (name, expr) = BuildLet(let, ref env);

                inExpr = new W.Expr.Let(name, expr, inExpr);
            }

            return inExpr;
        }

        private (W.TermVariable name, W.Expr expr) BuildLet(A.Expr let, ref W.Environment env)
        {
            switch (let)
            {
                case A.VarDecl var when var.Parameters.Count == 0:
                    {
                        var name = new W.TermVariable(var.Name.Text);
                        var expr = Build(var.Expression, ref env);

                        return (name, expr);
                    }
                default:
                    break;
            }

            Assert(true);
            throw NotImplemented(let);
        }

        private Exception NotImplemented(A.Expr expr)
        {
            return new NotImplementedException($"missing implementation: '{expr.GetType().FullName} - {expr}'");
        }
    }
}
