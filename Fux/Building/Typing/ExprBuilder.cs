using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    public sealed class ExprBuilder
    {
        const string GenTuple2 = "_tuple2_";

        private readonly TypeBuilder typeBuilder;
        private int wildcardNumber = 0;
        private int idNumber = 0;

        public ExprBuilder(Module module, TypeBuilder typeBuilder)
        {
            Module = module;
            this.typeBuilder = typeBuilder;
        }

        public Module Module { get; }
        public bool Investigated { get; set; }

        public W.Expr Build(ref W.Environment env, A.Expr expr, bool investigated)
        {
            Investigated = investigated;

            return Build(ref env, expr);
        }

        private W.Expr Build(ref W.Environment env, A.Expr expr)
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
                                        if (Investigated)
                                        {
                                            Assert(true);
                                        }

                                        var infix = infixRef.Decl;

                                        Assert(identifier.IsSingleOp);
                                        Assert(infix.Expression.Resolved is A.Ref.Var);

                                        return Build(ref env, infix.Expression.Resolved);
                                    }

                                case A.Ref.Var varRef:
                                    {
                                        var var = varRef.Decl;

                                        var variable = new W.Expr.Variable(identifier);

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
                                        if (Investigated)
                                        {
                                            Assert(true);
                                        }

                                        var ctor = ctorRef.Decl;

                                        var variable = new W.Expr.Variable(ctor.Name);

                                        var type = typeBuilder.Build(env, ctor.Type);

                                        env = env.Insert(variable.Term, type);

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
                        var condition = Build(ref env, ifExpr.Condition);
                        var ifTrue = Build(ref env, ifExpr.IfTrue);
                        var ifFalse = Build(ref env, ifExpr.IfFalse);

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
                                Build(ref env, tupleExpr[0]),
                                Build(ref env, tupleExpr[1])
                                );
                        }
                        break;
                    }

                case A.Expr.Literal.Integer literal:
                    {
                        return new W.Expr.Literal.Integer(literal.Value);
                    }

                case A.Expr.Literal.String literal:
                    {
                        return new W.Expr.Literal.String(literal.Value);
                    }

                case A.OpChain chain:
                    {
                        Assert(chain.Resolved is A.Expr.Infix);
                        return Build(ref env, chain.Resolved);
                    }

                case A.Expr.Infix infix:
                    {
                        var infixDecl = infix.Op.InfixDecl;
                        Assert(infixDecl != null);
                        var op = Build(ref env, infixDecl.Expression);
                        var arg1 = Build(ref env, infix.Lhs.Resolved);
                        var arg2 = Build(ref env, infix.Rhs.Resolved);

                        return new W.Expr.Application(new W.Expr.Application(op, arg1), arg2);
                    }

                case A.Ref.Ctor ctorRef:
                    {
                        var ctor = ctorRef.Decl;

                        var variable = new W.Expr.Variable(ctor.Name);

                        var polytype = env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            polytype = typeBuilder.Build(env, ctor.Type);

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

                case A.Ref.Parameter parameterRef:
                    {
                        var parameter = parameterRef.Decl;

                        Assert(parameter.Expression is A.Identifier);

                        var variable = new W.Expr.Variable((A.Identifier)parameter.Expression);

                        return variable;
                    }

                case A.Expr.Let let:
                    {
                        return BuildLetExpr(ref env, let);
                    }

                case A.Expr.Matcher caseMatch:
                    {
                        return BuildMatcher(ref env, caseMatch);
                    }

                case A.Expr.Case cheese:
                    {
                        return BuildCaseExpr(ref env, cheese);
                    }

                case A.Expr.Lambda lambda:
                    {
                        return BuildLambdaExpr(ref env, lambda);
                    }

                case A.Expr.List list:
                    {
                        return Cons(ref env, list, 0);
                    }

                case A.Pattern.Wildcard:
                    {
                        var id = GenWildcard();

                        var wildcard = new W.Expr.Wildcard(id.Text);

                        return wildcard;
                    }

                case A.Pattern.List list:
                    {
                        if (list.Patterns.Count == 0)
                        {
                            return new W.Expr.Empty();
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
                        return Build(ref env, lower.Identifier);
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
                                var first = Build(ref env, list[index]);
                                var rest = Build(ref env, list[index + 1]);

                                return new W.Expr.Decons(first, rest);
                            }
                            else
                            {
                                var first = Build(ref env, list[index]);
                                var rest = destructure(ref env, list, index + 1);

                                return new W.Expr.Decons(first, rest);
                            }
                        }
                    }

                case A.Pattern.Ctor ctorPattern:
                    {
                        Assert(ctorPattern.Name.Resolved is A.Ref.Ctor);

                        var first = Build(ref env, ctorPattern.Name);

                        if (ctorPattern.Arguments.Count == 0)
                        {
                            return first;
                        }
                        else
                        {
                            return apply(ref env, first, ctorPattern.Arguments.Count - 1);
                        }

                        W.Expr apply(ref W.Environment env, W.Expr first, int index)
                        {
                            if (index < 0)
                            {
                                return first;
                            }
                            else
                            {
                                return new W.Expr.Application(first, apply(ref env,Build(ref env, ctorPattern.Arguments[index]), index - 1));
                            }
                        }
                    }

                case A.Pattern.Tuple2 tuple2:
                    {
                        return new W.Expr.Tuple2(Build(ref env, tuple2.Pattern1), Build(ref env, tuple2.Pattern2));
                    }

                case A.Pattern.Literal.Integer:
                    {
                        // TODO: value
                        return new W.Expr.Literal.Integer(0);
                    }
                case A.Pattern.WithAlias withAlias:
                    {
                        var x = Build(ref env, withAlias.Pattern);

                        break;
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
                    return new W.Expr.Cons(Build(ref env, list[index]), Cons(ref env, list, index + 1));
                }
            }

            W.Expr Apply(ref W.Environment env, A.Expr.Sequence seq, int index)
            {
                if (index == 1)
                {
                    return new W.Expr.Application(
                        Build(ref env, seq[0]),
                        Build(ref env, seq[1]));
                }
                else
                {
                    Assert(index > 1);
                    return new W.Expr.Application(
                        Apply(ref env, seq, index - 1),
                        Build(ref env, seq[index]));
                }
            }
        }

        private W.Expr BuildLambdaExpr(ref W.Environment env, A.Expr.Lambda lambdaExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }
            var expr = Build(ref env, lambdaExpr.Expression);

            foreach (var x in lambdaExpr.Parameters.Flatten(GenWildcard).Reverse())
            {
                var var = new W.TermVariable(x);
                var type = env.Generator.GetNext();
                env = env.Insert(var, new W.Polytype(type));

                expr = new W.Expr.Lambda(var, expr);
            }

            return expr;
        }

        private W.Expr BuildMatcher(ref W.Environment env, A.Expr.Matcher matcher)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, matcher.Expression);
            var abstractions = new List<W.Expr.Case>();
            foreach (var caseExpr in matcher.Cases)
            {
                var abstraction = BuildCaseExpr(ref env, caseExpr);
                abstractions.Add(abstraction);
            }

            return new W.Expr.Matcher(expr, abstractions.ToArray());
        }

        private W.Expr.Case BuildCaseExpr(ref W.Environment env, A.Expr.Case caseExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, caseExpr.Expression);
            var pttn = Build(ref env, caseExpr.Pattern);
            var cenv = env.NewEmpty();

            foreach (var identifier in caseExpr.Pattern.Flatten().Reverse())
            {
                var var = new W.TermVariable(identifier);
                var type = env.Generator.GetNext();
                cenv = cenv.Insert(var, new W.Polytype(type));

                expr = new W.Expr.Application(new W.Expr.Lambda(var, expr), new W.Expr.Variable(var));
            }

            return new W.Expr.Case(cenv, pttn, expr);
        }

        private W.Expr BuildLetExpr(ref W.Environment env, A.Expr.Let letExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(ref env, letExpr.InExpression);

            foreach (var let in letExpr.LetDecls.Reverse())
            {
                inExpr = BuildLet(ref env, let, inExpr);
            }

            return inExpr;
        }

        private W.Expr.Let BuildLet(ref W.Environment env, A.Decl let, W.Expr inExpr)
        {
            switch (let)
            {
                case A.Decl.LetAssign assign when assign.Pattern is A.Pattern.Tuple2 tuple2:
                    {
                        var name = new W.TermVariable(GenIdentifier());
                        var expr = Build(ref env, assign.Expression);

                        var name1 = new W.TermVariable(tuple2.Pattern1.ExractMatchIds().First());
                        var name2 = new W.TermVariable(tuple2.Pattern2.ExractMatchIds().First());

                        var var = new W.Expr.Variable(name);
                        var first = new W.Expr.Get21(var);
                        var second = new W.Expr.Get22(var);

                        return new W.Expr.Let(name, expr, new W.Expr.Let(name1, first, new W.Expr.Let(name2, second, inExpr)));
                    }
                case A.Decl.LetAssign assign when assign.Pattern is A.Pattern.Tuple3 tuple3:
                    {
                        Assert(assign.Pattern is A.Pattern.Tuple);
                        Assert(false);
                        break;
                    }
                case A.Decl.Var var when var.Parameters.Count == 0:
                    {
                        var name = new W.TermVariable(var.Name);
                        var expr = Build(ref env, var.Expression);

                        return new W.Expr.Let(name, expr, inExpr);
                    }
                case A.Decl.Var var:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var name = new W.TermVariable(var.Name);
                        var expr = Build(ref env, var.Expression);

                        foreach (var parameter in var.Parameters.Reverse())
                        {
                            Assert(parameter.Expression is A.Pattern);

                            var pattern = (A.Pattern)parameter.Expression;

                            expr = Decompose(pattern, expr);

                            W.Expr Decompose(A.Pattern pattern, W.Expr expr)
                            {
                                switch (pattern)
                                {
                                    case A.Pattern.LowerId lower:
                                        {
                                            var term = new W.TermVariable(lower.Identifier);
                                            return new W.Expr.Lambda(term, expr);
                                        }
                                    case A.Pattern.Tuple2 tuple2:
                                        {
                                            var term = new W.TermVariable(GenIdentifier(GenTuple2));
                                            var variable = new W.Expr.Variable(term);
                                            var get1 = new W.Expr.Get21(variable);
                                            var get2 = new W.Expr.Get22(variable);
                                            expr = Let(tuple2.Pattern2, get2, expr);
                                            expr = Let(tuple2.Pattern1, get1, expr);
                                            expr = new W.Expr.Lambda(term, expr);
                                            return expr;
                                        }
                                    default:
                                        Assert(false);
                                        throw new NotImplementedException();
                                }
                            }

                            W.Expr Let(A.Pattern pattern, W.Expr get, W.Expr expr)
                            {
                                switch (pattern)
                                {
                                    case A.Pattern.LowerId lower:
                                        {
                                            var term = new W.TermVariable(lower.Identifier);
                                            return new W.Expr.Let(term, get, expr);
                                        }
                                    case A.Pattern.Signature signature when signature.Parameters.Count == 0:
                                        {
                                            var term = new W.TermVariable(signature.Name);
                                            return new W.Expr.Let(term, get, expr);
                                        }
                                }
                                Assert(false);
                                throw new NotImplementedException();
                            }
                        }

                        return new W.Expr.Let(name, expr, inExpr);
                    }
                default:
                    break;
            }

            Assert(true);
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

        public A.Identifier GenIdentifier()
        {
            return GenIdentifier("_id_");
        }

        public A.Identifier GenIdentifier(string prefix)
        {
            return A.Identifier.Artificial(Module, $"{prefix}{++idNumber}");
        }
    }
}
