namespace Fux.Building.Typing
{
    public sealed class ExprBuilder
    {
        const string GenTuple2Prefix = "_tuple2";
        const string GenListPrefix = "_list";
        const string GenVarPrefix = "_var";
        const string GenMatchPrefix = "_match";
        const string GenParamPrefix = "_param";

        private readonly TypeBuilder typeBuilder;
        private readonly BindBuilder bind2;
        private readonly IdGenerator idGenerator;

        public ExprBuilder(Module module)
        {
            Module = module;
            typeBuilder = new TypeBuilder();
            bind2 = new BindBuilder(Module, this);
            idGenerator = new(Module);
        }

        public Module Module { get; }
        public bool Investigated { get; set; }

        public W.Expr Build(ref W.Environment env, A.Decl.Var var, bool investigated)
        {
            typeBuilder.Investigated = investigated;
            Investigated = investigated;
            idGenerator.Clear();

            if (Investigated)
            {
                Assert(true);
            }

            var varType = typeBuilder.Build(env, var.Type);

            var variable = var.FullName();
            env = env.Insert(variable.Term, varType);

            W.Expr wExpr;
            W.Type wType;

            (wExpr, wType) = BuildVarLambda(ref env, var);

            var expression = new W.Expr.Unify(wType, wExpr);

            return expression;
        }

        private W.Expr Build(ref W.Environment env, A.Expr expr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            switch (expr)
            {
                case A.Identifier identifier:
                    {
                        return BuildIdentifier(ref env, identifier);
                    }

                case A.Expr.If ifExpr:
                    {
                        var condition = Build(ref env, ifExpr.Condition);
                        var ifTrue = Build(ref env, ifExpr.IfTrue);
                        var ifFalse = Build(ref env, ifExpr.IfFalse);

                        return new W.Expr.Iff(condition, ifTrue, ifFalse);
                    }

                case A.Expr.Application seqExpr:
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
                                Build(ref env, tupleExpr[1]));
                        }
                        break;
                    }

                case A.Expr.Ctor ctorExpr:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        Assert(ctorExpr.Name.Resolved is A.Expr.Ref.Ctor);

                        var first = Build(ref env, ctorExpr.Name);

                        var arguments = new List<W.Expr>();
                        foreach (var arg in ctorExpr.Arguments)
                        {
                            var argument = Build(ref env, arg);
                            arguments.Add(argument);
                        }

                        var ctor = new W.Expr.Ctor(first, arguments);

                        return ctor;
                    }

                case A.Expr.Unit unit:
                    {
                        return new W.Expr.Unit();
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

                case A.Expr.Let let:
                    {
                        return BuildLetExpr(ref env, let);
                    }

                case A.Expr.Matcher caseMatch:
                    {
                        return BuildMatcher(ref env, caseMatch);
                    }

                case A.Expr.Lambda lambda:
                    {
                        return BuildLambdaExpr(ref env, lambda);
                    }

                case A.Expr.List list:
                    {
                        return Cons(ref env, list, 0);
                    }

                case A.Expr.Ref reference:
                    {
                        return BuildReference(ref env, reference);
                    }

                case A.Pattern pattern:
                    {
                        return BuildPattern(ref env, pattern);
                    }

                case A.Expr.Record record:
                    {
                        Assert(record.BaseRecord == null);

                        var fields = new List<W.Expr.Field>();

                        foreach (var f in record.Fields)
                        {
                            var name = f.Name.Text;
                            var value = Build(ref env, f.Expression);
                            var field = new W.Expr.Field(name, value);
                            fields.Add(field);
                        }

                        var baseName = record.BaseRecord?.Text;

                        return new W.Expr.Record(baseName, fields);
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
                    return new W.Expr.Cons(Build(ref env, list[index]), Cons(ref env, list, index + 1));
                }
            }

            W.Expr Apply(ref W.Environment env, A.Expr.Application seq, int index)
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

        private W.Expr BuildIdentifier(ref W.Environment env, A.Identifier identifier)
        {
            Assert(identifier.Resolved is A.Expr.Ref);

            var reference = (A.Expr.Ref)identifier.Resolved!;

            return BuildReference(ref env, reference);
        }

        private W.Expr BuildReference(ref W.Environment env, A.Expr.Ref reference)
        {
            switch (reference)
            {
                case A.Expr.Ref.Ctor ctorRef:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var ctor = ctorRef.Decl;
                        var custom = ctor.Custom;

                        var variable = ctor.FullName();

                        var polytype = env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            var args = custom.Parameters.Select(p => (A.Type)new A.Type.Parameter(p.Name)).ToList();

                            var type = new A.Type.Custom(custom.Name, args).With(custom);

                            foreach (var x in ctor.Arguments.AsEnumerable().Reverse())
                            {
                                type = new A.Type.Function(x, type);
                            }

                            polytype = typeBuilder.Build(env, type);

                            env = env.Insert(variable.Term, polytype);
                        }

                        return variable;
                    }

                case A.Expr.Ref.Var varRef:
                    {
                        var var = varRef.Decl;

                        Assert(var.InModule != null);

                        var variable = var.FullName();

                        var polytype = env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            polytype = typeBuilder.Build(env, var.Type);
                            env = env.Insert(variable.Term, polytype);
                        }

                        return variable;
                    }

                case A.Expr.Ref.Native nativeRef:
                    {
                        var native = nativeRef.Decl;
                        return new W.Expr.Native(native);
                    }

                case A.Expr.Ref.Parameter parameterRef:
                    {
                        var parameter = parameterRef.Decl;

                        Assert(parameter.Pattern is A.Pattern.LowerId);

                        var name = ((A.Pattern.LowerId)parameter.Pattern).Identifier;
                        var variable = new W.Expr.Variable(name);

                        return variable;
                    }

                case A.Expr.Ref.Infix infixRef:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var infix = infixRef.Decl;

                        Assert(infix.Name.IsSingleOp);
                        Assert(infix.Expression.Resolved is A.Expr.Ref.Var);

                        return Build(ref env, infix.Expression.Resolved);
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(reference);

        }

        private W.Expr BuildPattern(ref W.Environment env, A.Pattern pattern)
        {
            switch (pattern)
            {
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
                            var variable = new W.Expr.DeVariable(new W.Expr.Variable(sign.Name));

                            return variable;
                        }

                        Assert(false);
                        break;
                    }

                case A.Pattern.LowerId lower:
                    {
                        var variable = new W.Expr.DeVariable(new W.Expr.Variable(lower.Identifier));

                        return variable;
                    }

                case A.Pattern.UpperId upper:
                    {
                        Assert(upper.Identifier.Resolved is A.Expr.Ref.Ctor);

                        var first = Build(ref env, upper.Identifier);

                        return first;
                    }

                case A.Pattern.DeCtor deCtor:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        Assert(deCtor.Name.Resolved is A.Expr.Ref.Ctor);

                        var first = Build(ref env, deCtor.Name);

                        var arguments = new List<W.Expr>();
                        foreach (var arg in deCtor.Arguments)
                        {
                            var argument = BuildPattern(ref env, arg);
                            arguments.Add(argument);
                        }

                        var expr = new W.Expr.DeCtor(first, arguments);

                        return expr;
                    }

                case A.Pattern.DeCons deCons:
                    {
                        var x = new W.Expr.DeCons(
                            BuildPattern(ref env, deCons.First),
                            BuildPattern(ref env, deCons.Rest));

                        return x;
                    }

                case A.Pattern.Tuple2 tuple2:
                    {
                        return new W.Expr.Tuple2(
                            BuildPattern(ref env, tuple2.Pattern1),
                            BuildPattern(ref env, tuple2.Pattern2));
                    }

                case A.Pattern.Tuple3 tuple3:
                    {
                        return new W.Expr.Tuple3(
                            BuildPattern(ref env, tuple3.Pattern1),
                            BuildPattern(ref env, tuple3.Pattern2),
                            BuildPattern(ref env, tuple3.Pattern3));
                    }

                case A.Pattern.Literal.Integer integer:
                    {
                        return new W.Expr.Literal.Integer(integer.Value);
                    }
                case A.Pattern.WithAlias withAlias:
                    {
                        var x = new W.Expr.WithAlias(
                            BuildPattern(ref env, withAlias.Pattern),
                            new W.Expr.DeVariable(new W.Expr.Variable(withAlias.Alias.Identifier)));

                        return x;
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(pattern);

        }

        private bool nonforce = false;

        private W.Expr BuildDestructure(ref W.Environment env, W.Expr.Variable matchVariable, A.Pattern pattern, W.Expr caseExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            switch (pattern)
            {
                case A.Pattern.Wildcard:
                    {
                        return caseExpr;
                    }

                case A.Pattern.List list when list.Patterns.Count == 0:
                    {
                        return caseExpr;
                    }

                case A.Pattern.Literal.Integer integer:
                    {
                        return caseExpr;
                    }

                case A.Pattern.UpperId upper:
                    {
                        return caseExpr;
                    }

                case A.Pattern.List list when list.Patterns.Count > 0:
                    {
                        Assert(false);
                        throw new NotImplementedException();
                    }

                case A.Pattern.Signature sign:
                    {
                        if (sign.Parameters.Count == 0)
                        {
                            var variable = new W.Expr.Variable(sign.Name);

                            return new W.Expr.Let(variable.Term, matchVariable, caseExpr);
                        }

                        Assert(false);
                        break;
                    }

                case A.Pattern.LowerId lower:
                    {
                        var variable = new W.Expr.Variable(lower.Identifier);

                        return new W.Expr.Let(variable.Term, matchVariable, caseExpr);
                    }

                case A.Pattern.DeCtor deCtor:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        if (deCtor.Name.Resolved is not A.Expr.Ref.Ctor ctorRef || ctorRef.Decl is not A.Decl.Ctor ctor)
                        {
                            Assert(false);
                            throw NotImplemented(deCtor);
                        }

                        Assert(deCtor.Arguments.Count == ctor.Arguments.Count);

                        var name = ctor.FullName();
                        var args = new List<W.Polytype>();
                        foreach (var arg in ctor.Arguments)
                        {
                            args.Add(typeBuilder.Build(env, arg));
                        }

                        W.Polytype genType(W.Environment env, int index)
                        {
                            Assert(index < ctor.Arguments.Count);
                            return args![index];
                        }

                        var expr = GenDestruct(ref env, 0);

                        return expr;

                        W.Expr GenDestruct(ref W.Environment env, int index)
                        {
                            if (index == deCtor.Arguments.Count)
                            {
                                return caseExpr;
                            }
                            else
                            {
                                var variable = GenVariable(GenVarPrefix);

                                var select = new W.Expr.GetValue2(matchVariable, genType, index);

                                return new W.Expr.Let(variable.Term, select, 
                                    BuildDestructure(ref env, variable, deCtor.Arguments[index], GenDestruct(ref env, index + 1)));
                            }
                        }
                    }


                case A.Pattern.DeCons deCons:
                    {
                        var var1 = GenVariable(GenVarPrefix);
                        var select1 = new W.Expr.GetValue(matchVariable, genType, 0);
                        var var2 = GenVariable(GenVarPrefix);
                        var select2 = new W.Expr.GetValue(matchVariable, genType, 1);

                        var let =
                            new W.Expr.Let(var1.Term, select1,
                                new W.Expr.Let(var2.Term, select2,
                                    BuildDestructure(ref env, var1, deCons.First,
                                        BuildDestructure(ref env, var2, deCons.Rest, caseExpr))));

                        return let;

                        W.Polytype genType(W.Environment env)
                        {
                            return new W.Polytype(new W.Type.List(env.GetNext()));
                        }
                    }

                case A.Pattern.Tuple2 tuple2:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var var1 = GenVariable(GenVarPrefix);
                        var select1 = new W.Expr.GetValue(matchVariable, genType, 0);
                        var var2 = GenVariable(GenVarPrefix);
                        var select2 = new W.Expr.GetValue(matchVariable, genType, 1);

                        var let =
                            new W.Expr.Let(var1.Term, select1,
                                new W.Expr.Let(var2.Term, select2,
                                    BuildDestructure(ref env, var1, tuple2.Pattern1,
                                        BuildDestructure(ref env, var2, tuple2.Pattern2, caseExpr))));

                        return let;

                        W.Polytype genType(W.Environment env)
                        {
                            return new W.Polytype(new W.Type.Tuple2(env.GetNext(), env.GetNext()));
                        }
                    }

                case A.Pattern.Tuple3 tuple3:
                    {
                        Assert(nonforce);

                        return new W.Expr.Tuple3(
                            BuildDestructure(ref env, matchVariable, tuple3.Pattern1, caseExpr),
                            BuildDestructure(ref env, matchVariable, tuple3.Pattern2, caseExpr),
                            BuildDestructure(ref env, matchVariable, tuple3.Pattern3, caseExpr));
                    }

                case A.Pattern.WithAlias withAlias:
                    {
                        var variable = new W.Expr.Variable(withAlias.Alias.Identifier);

                        var let = new W.Expr.Let(
                            variable.Term,
                            matchVariable,
                            BuildDestructure(ref env, variable, withAlias.Pattern, caseExpr));

                        return let;
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(pattern);

        }

        private (W.Expr, W.Type) BuildVarLambda(ref W.Environment env, A.Decl.Var var)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var varType = typeBuilder.Build(env, var.Type);

            var expr = Build(ref env, var.Expression);

            var (itypes, iresult) = bind2.Invert(varType.Type);
            var (types, result) = bind2.Flatten(varType.Type);

            var patterns = var.Parameters.Select(p => p.Pattern).Cast<A.Pattern>().Reverse().ToList();

            var i = 0;
            for (; i < patterns.Count; i++)
            {
                var pattern = patterns[i];
                var type = itypes[i];

                var name = GenVariable(GenParamPrefix);

                expr = BuildDestructure(ref env, name, pattern, expr);
                expr = new W.Expr.Lambda(name.Term, expr);
            }

            var wtype = bind2.Recombine(itypes, 0, iresult);

            return (expr, varType.Type);
        }

        private W.Expr BuildLambdaExpr(ref W.Environment env, A.Expr.Lambda lambdaExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var expr = Build(ref env, lambdaExpr.Expression);

            foreach (var prm in lambdaExpr.Parameters.Parameters.Reverse())
            {
                switch (prm)
                {
                    case A.Pattern.LowerId lower:
                        {
                            var name = new W.TermVariable(lower.Identifier);
                            var type = env.GetNext();
                            env = env.Insert(name, new W.Polytype(type));

                            expr = new W.Expr.Lambda(name, expr);

                            break;
                        }
                    case A.Pattern.Wildcard:
                        {
                            var name = new W.TermVariable(GenWildcard());
                            var type = env.GetNext();
                            env = env.Insert(name, new W.Polytype(type));

                            expr = new W.Expr.Lambda(name, expr);

                            break;
                        }
                    case A.Pattern.Tuple2 tuple:
                        {
                            var name = GenVariable(GenParamPrefix);
                            var type = env.GetNext();
                            env = env.Insert(name.Term, new W.Polytype(type));

                            expr = BuildDestructure(ref env, name, prm, expr);
                            expr = new W.Expr.Lambda(name.Term, expr);

                            break;
                        }
                    default:
                        {
                            Assert(false);

                            var name = GenVariable(GenParamPrefix);

                            break;
                        }
                }
            }

            return expr;
        }

        private W.Expr BuildMatcher(ref W.Environment env, A.Expr.Matcher matcher)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var matchExpr = Build(ref env, matcher.Expression);

            if (matchExpr is W.Expr.Variable variable)
            {
                return GenMatcher(ref env, variable);
            }
            else
            {
                variable = GenVariable(GenMatchPrefix);

                return new W.Expr.Let(variable.Term, matchExpr, GenMatcher(ref env, variable));
            }

            W.Expr.Matcher GenMatcher(ref W.Environment env, W.Expr.Variable variable)
            {
                var cases = new List<W.Expr.Case>();
                foreach (var caseExpr in matcher.Cases)
                {
                    var abstraction = BuildCaseExpr(ref env, variable, caseExpr);
                    cases.Add(abstraction);
                }

                return new W.Expr.Matcher(variable, cases.ToArray());
            }
        }

        private W.Expr.Case BuildCaseExpr(ref W.Environment env, W.Expr.Variable matchExpr, A.Expr.Case cheese)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var caseExpr = Build(ref env, cheese.Expression);
            var pattern = BuildPattern(ref env, cheese.Pattern);
            var destructure = BuildDestructure(ref env, matchExpr, cheese.Pattern, caseExpr);

            return new W.Expr.Case(env, pattern, destructure);
        }

        private W.Expr BuildLetExpr(ref W.Environment env, A.Expr.Let letExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(ref env, letExpr.InExpression);

            foreach (var let in letExpr.LetDecls.AsEnumerable().Reverse())
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
                        var name = GenVariable(GenVarPrefix);
                        var expr = Build(ref env, assign.Expression);

                        var name1 = new W.TermVariable(tuple2.Pattern1.ExractMatchIds().Single().Identifier);
                        var name2 = new W.TermVariable(tuple2.Pattern2.ExractMatchIds().Single().Identifier);

                        var first = new W.Expr.GetValue(name, typeGen, 0);
                        var second = new W.Expr.GetValue(name, typeGen, 1);

                        return new W.Expr.Let(name.Term, expr,
                            new W.Expr.Let(name1, first,
                                new W.Expr.Let(name2, second, inExpr)));

                        W.Polytype typeGen(W.Environment env) => new W.Polytype(new W.Type.Tuple2(env.GetNext(), env.GetNext()));
                    }

                case A.Decl.LetAssign assign when assign.Pattern is A.Pattern.Tuple3 tuple2:
                    {
                        var name = GenVariable(GenVarPrefix);
                        var expr = Build(ref env, assign.Expression);

                        var name1 = new W.TermVariable(tuple2.Pattern1.ExractMatchIds().Single().Identifier);
                        var name2 = new W.TermVariable(tuple2.Pattern2.ExractMatchIds().Single().Identifier);
                        var name3 = new W.TermVariable(tuple2.Pattern3.ExractMatchIds().Single().Identifier);

                        var first = new W.Expr.GetValue(name, typeGen, 0);
                        var second = new W.Expr.GetValue(name, typeGen, 1);
                        var third = new W.Expr.GetValue(name, typeGen, 2);

                        return new W.Expr.Let(name.Term, expr,
                            new W.Expr.Let(name1, first,
                                new W.Expr.Let(name2, second,
                                    new W.Expr.Let(name3, third, inExpr))));

                        W.Polytype typeGen(W.Environment env) => new W.Polytype(new W.Type.Tuple3(env.GetNext(), env.GetNext(), env.GetNext()));
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
                            Assert(parameter.Pattern is A.Pattern);

                            var pattern = (A.Pattern)parameter.Pattern;

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
                                            var variable = GenVariable(GenTuple2Prefix);
                                            var get1 = new W.Expr.GetValue(variable, typeGen, 0);
                                            var get2 = new W.Expr.GetValue(variable, typeGen, 1);
                                            expr = Let(tuple2.Pattern2, get2, expr);
                                            expr = Let(tuple2.Pattern1, get1, expr);
                                            expr = new W.Expr.Lambda(variable.Term, expr);
                                            return expr;

                                            W.Polytype typeGen(W.Environment env) =>  new W.Polytype(new W.Type.Tuple2(env.GetNext(), env.GetNext()));
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
            return idGenerator.For("_");
        }

        public W.Expr.Variable GenVariable(string prefix)
        {
            return new W.Expr.Variable(idGenerator.For(prefix));
        }
    }
}
