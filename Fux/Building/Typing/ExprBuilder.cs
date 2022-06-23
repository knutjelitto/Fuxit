using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    internal class ExprBuilder
    {
        private readonly TypeBuilder type;

        public ExprBuilder(TypeBuilder typeBuilder)
        {
            type = typeBuilder;
        }

        public W.Expr Build(A.Expression expr, ref W.Environment env)
        {
            switch (expr)
            {
                case A.Identifier identifier:
                    Assert(identifier.Resolved != null);
                    if (identifier.Resolved != null)
                    {
                        switch (identifier.Resolved)
                        {
                            case A.NativeDecl native:
                                return new W.NativeExpression(native);
                            case A.VarDecl var:
                                {
                                    Assert(identifier.IsSingleLower);
                                    Assert(var.Type != null);
                                    var variable = new W.Variable(new W.TermVariable(identifier.Text));
                                    var already = env.TryGet(variable.Term);
                                    var wtype = type.Build(env, var.Type);
                                    if (already != null)
                                    {
                                        Assert(true);
                                        Assert(already.ToString() == wtype.ToString());
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
                                    var termVar = new W.TermVariable(name.Text);
                                    var variable = new W.Variable(termVar);
                                    return variable;
                                }
                            default:
                                break;
                        }
                    }
                    break;
                case A.NativeDecl native:
                    return new W.NativeExpression(native);
                case A.IfExpr ifExpr:
                    {
                        var condition = Build(ifExpr.Condition, ref env);
                        var ifTrue = Build(ifExpr.IfTrue, ref env);
                        var ifFalse = Build(ifExpr.IfFalse, ref env);

                        return new W.IffExpression(condition, ifTrue, ifFalse);
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
                            return new W.Tuple2Expression(
                                Build(tupleExpr[0], ref env),
                                Build(tupleExpr[1], ref env)
                                );
                        }
                        break;
                    }
                case A.IntegerLiteral literal:
                    return new W.IntegerLiteral(literal.Value);
                case A.StringLiteral literal:
                    return new W.StringLiteral(literal.Value);

                case A.OpChain chain:
                    Assert(chain.Resolved is A.InfixExpr);
                    return Build(chain.Resolved, ref env);
                default:
                    break;
            }

            //Assert(false);
            throw new NotImplementedException($"expression not implemented: '{expr.GetType().FullName} - {expr}'");

            W.Expr Apply(A.SequenceExpr seq, int index, ref W.Environment env)
            {
                if (index == 1)
                {
                    return new W.ApplicationExpression(Build(seq[0], ref env), Build(seq[1], ref env));
                }
                else
                {
                    Assert(index > 1);
                    return new W.ApplicationExpression(Apply(seq, index - 1, ref env), Build(seq[index], ref env));
                }
            }
        }
    }
}
