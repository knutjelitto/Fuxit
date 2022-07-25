namespace Fux.Building.Typing
{
    public sealed class ExprBuilder
    {
        const string GenTuple2Prefix = "_tuple2";
        const string GenVarPrefix = "_var";
        const string GenMatchPrefix = "_match";
        const string GenParamPrefix = "_param";

        private TypeBuilder typeBuilder;
        private readonly BindBuilder bind2;
        private readonly IdGenerator idGenerator;

        public ExprBuilder(Module module)
        {
            Module = module;
            typeBuilder = new TypeBuilder(new W.TypeVarGenerator(), false);
            bind2 = new BindBuilder(Module, this);
            idGenerator = new(Module);
        }

        public Module Module { get; }
        public bool Investigated { get; set; }
        public W.Environment Env { get; private set; } = W.Environment.Empty();

        public (W.Environment, W.Expr) Build(A.Decl.Var var, bool investigated)
        {
            Env = W.Environment.Empty();
            typeBuilder = new TypeBuilder(Env.Generator, false);
            Investigated = investigated;
            idGenerator.Clear();

            if (Investigated)
            {
                Assert(true);
            }

            var wType = typeBuilder.Build(var.Type);

            var variable = var.FullName();
            Env = Env.Insert(variable.Term, wType);

            var wExpr = BuildVarLambda(var);

            var expression = new W.Expr.Unify(wExpr, wType);

            return (Env, expression);
        }

        private W.Expr Build(A.Expr expr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            switch (expr)
            {
                case A.Identifier identifier:
                    {
                        return BuildIdentifier(identifier);
                    }

                case A.Expr.If ifExpr:
                    {
                        var condition = Build(ifExpr.Condition);
                        var ifTrue = Build(ifExpr.IfTrue);
                        var ifFalse = Build(ifExpr.IfFalse);

                        return new W.Expr.Iff(condition, ifTrue, ifFalse);
                    }

                case A.Expr.Application seqExpr:
                    {
                        Assert(seqExpr.Count >= 2);

                        return Apply(seqExpr, seqExpr.Count - 1);
                    }

                case A.Expr.Tuple tupleExpr:
                    {
                        if (tupleExpr.Count == 2)
                        {
                            return new W.Expr.Tuple2(
                                Build(tupleExpr[0]),
                                Build(tupleExpr[1]));
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

                        var first = Build(ctorExpr.Name);

                        var arguments = new List<W.Expr>();
                        foreach (var arg in ctorExpr.Arguments)
                        {
                            var argument = Build(arg);
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
                        return Build(chain.Resolved);
                    }

                case A.Expr.Infix infix:
                    {
                        var infixDecl = infix.Op.InfixDecl;
                        Assert(infixDecl != null);
                        var op = Build(infixDecl.Expression);
                        var arg1 = Build(infix.Lhs.Resolved);
                        var arg2 = Build(infix.Rhs.Resolved);

                        return new W.Expr.Application(new W.Expr.Application(op, arg1), arg2);
                    }

                case A.Expr.Let let:
                    {
                        return BuildLetExpr(let);
                    }

                case A.Expr.Matcher caseMatch:
                    {
                        return BuildMatcher(caseMatch);
                    }

                case A.Expr.Lambda lambda:
                    {
                        return BuildLambdaExpr(lambda);
                    }

                case A.Expr.List list:
                    {
                        return Cons(list, 0);
                    }

                case A.Expr.Ref reference:
                    {
                        return BuildReference(reference);
                    }

                case A.Pattern pattern:
                    {
                        return BuildPattern(pattern);
                    }

                case A.Expr.Record record:
                    {
                        Assert(record.BaseRecord == null);

                        var fields = new List<W.Expr.Field>();

                        foreach (var f in record.Fields)
                        {
                            var name = f.Name.Text;
                            var field = f.Expression == null
                                ? new W.Expr.Field(name, null)
                                : new W.Expr.Field(name, Build(f.Expression));
                            fields.Add(field);
                        }

                        var baseName = record.BaseRecord?.Text;

                        return new W.Expr.Record(baseName, fields);
                    }
            
                default:
                    break;
            }

            throw NotImplemented(expr);

            W.Expr.List Cons(A.Expr.List list, int index)
            {
                if (index == list.Count)
                {
                    return new W.Expr.Empty();
                }
                else
                {
                    return new W.Expr.Cons(Build(list[index]), Cons(list, index + 1));
                }
            }

            W.Expr Apply(A.Expr.Application seq, int index)
            {
                if (index == 1)
                {
                    return new W.Expr.Application(
                        Build(seq[0]),
                        Build(seq[1]));
                }
                else
                {
                    Assert(index > 1);
                    return new W.Expr.Application(
                        Apply(seq, index - 1),
                        Build(seq[index]));
                }
            }
        }

        private W.Expr BuildIdentifier(A.Identifier identifier)
        {
            Assert(identifier.Resolved is A.Expr.Ref);

            var reference = (A.Expr.Ref)identifier.Resolved!;

            return BuildReference(reference);
        }

        private W.Expr BuildReference(A.Expr.Ref reference)
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

                        var polytype = Env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            var args = custom.Parameters.Select(p => (A.Type)new A.Type.Parameter(p.Name)).ToList();

                            var type = new A.Type.Custom(custom.Name, args).With(custom);

                            foreach (var x in ctor.Arguments.AsEnumerable().Reverse())
                            {
                                type = new A.Type.Function(x, type);
                            }

                            polytype = typeBuilder.Build(type);

                            Env = Env.Insert(variable.Term, polytype);
                        }

                        return variable;
                    }

                case A.Expr.Ref.Var varRef:
                    {
                        var var = varRef.Decl;

                        Assert(var.InModule != null);

                        var variable = var.FullName();

                        var polytype = Env.TryGet(variable.Term);

                        if (polytype == null)
                        {
                            polytype = typeBuilder.Build(var.Type);
                            Env = Env.Insert(variable.Term, polytype);
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

                        return Build(infix.Expression.Resolved);
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(reference);

        }

        private W.Expr BuildPattern(A.Pattern pattern)
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

                        var first = Build(upper.Identifier);

                        return first;
                    }

                case A.Pattern.Ctor deCtor:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        Assert(deCtor.Name.Resolved is A.Expr.Ref.Ctor);

                        var first = Build(deCtor.Name);

                        var arguments = new List<W.Expr>();
                        foreach (var arg in deCtor.Arguments)
                        {
                            var argument = BuildPattern(arg);
                            arguments.Add(argument);
                        }

                        var expr = new W.Expr.DeCtor(first, arguments);

                        return expr;
                    }

                case A.Pattern.Cons deCons:
                    {
                        var x = new W.Expr.DeCons(
                            BuildPattern(deCons.First),
                            BuildPattern(deCons.Rest));

                        return x;
                    }

                case A.Pattern.Tuple2 tuple2:
                    {
                        return new W.Expr.Tuple2(
                            BuildPattern(tuple2.Pattern1),
                            BuildPattern(tuple2.Pattern2));
                    }

                case A.Pattern.Tuple3 tuple3:
                    {
                        return new W.Expr.Tuple3(
                            BuildPattern(tuple3.Pattern1),
                            BuildPattern(tuple3.Pattern2),
                            BuildPattern(tuple3.Pattern3));
                    }

                case A.Pattern.Literal.Integer integer:
                    {
                        return new W.Expr.Literal.Integer(integer.Value);
                    }
                case A.Pattern.WithAlias withAlias:
                    {
                        var x = new W.Expr.WithAlias(
                            BuildPattern(withAlias.Pattern),
                            new W.Expr.DeVariable(new W.Expr.Variable(withAlias.Alias.Identifier)));

                        return x;
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(pattern);

        }

        private W.Expr Destruct(A.Pattern pattern, W.Expr expr, W.Expr inExpr)
        {
            switch (pattern)
            {
                case A.Pattern.Tuple2(var pattern1, var pattern2):
                    {
                        if (expr is W.Expr.Variable variable)
                        {
                            var x = Destruct(pattern1, Select(variable, 0),
                                        Destruct(pattern2, Select(variable, 1),
                                            inExpr));
                            return x;
                        }
                        else
                        {
                            var temp = GenVariable(GenVarPrefix);

                            var x = new W.Expr.Let(
                                temp.Term,
                                expr,
                                Destruct(pattern1, Select(temp, 0),
                                    Destruct(pattern2, Select(temp, 1),
                                        inExpr)));
                            return x;
                        }

                        [DebuggerStepThrough]
                        static W.Expr Select(W.Expr.Variable variable, int index)
                        {
                            return new W.Expr.GetValue(variable, typeGen, index);

                            static W.Polytype typeGen(W.Environment env) => new(new W.Type.Tuple2(env.GetNextTypeVar(), env.GetNextTypeVar()));
                        }
                    }

                case A.Pattern.LowerId(var lower):
                    {
                        var x = new W.Expr.Let(
                            new W.TermVariable(lower),
                            expr,
                            inExpr);

                        return x;
                    }

                case A.Pattern.Wildcard:
                    {
                        return inExpr;
                    }

                case A.Pattern.Ctor ctorPattern:
                    {
                        if (ctorPattern.Name.Resolved is A.Expr.Ref.Ctor ctorRef && ctorRef.Decl is A.Decl.Ctor ctor)
                        {
                            Assert(ctorPattern.Arguments.Count == ctor.Arguments.Count);

                            var name = ctor.FullName();
                            var args = typeBuilder.BuildMulti(ctor.Arguments);

                            for (var i = ctorPattern.Arguments.Count - 1; i >= 0; i--)
                            {
                                var arg = ctorPattern.Arguments[i];

                                var variable = GenVariable(GenVarPrefix);

                                var select = Select(expr, i, args[i]);

                                inExpr = new W.Expr.Let(
                                    variable.Term,
                                    select,
                                    Destruct(arg, variable, inExpr));
                            }

                            return inExpr;

                            W.Expr.GetValue2 Select(W.Expr expr, int i, W.Polytype type)
                            {
                                var select = new W.Expr.GetValue2(expr, (env, i) => type, i);

                                return select;
                            }
                        }

                        Assert(false);
                        throw NotImplemented(ctorPattern);
                    }

                default:
                    break;
            }

            Assert(false);
            throw new NotImplementedException();
        }

        private W.Expr BuildDestructure(A.Pattern pattern, W.Expr expr, W.Expr inExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            switch (pattern)
            {
                case A.Pattern.Wildcard:
                    {
                        return inExpr;
                    }

                case A.Pattern.List list when list.Patterns.Count == 0:
                    {
                        return inExpr;
                    }

                case A.Pattern.Literal.Integer integer:
                    {
                        return inExpr;
                    }

                case A.Pattern.UpperId upper:
                    {
                        return inExpr;
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

                            return new W.Expr.Let(variable.Term, expr, inExpr);
                        }

                        Assert(false);
                        break;
                    }

                case A.Pattern.LowerId lower:
                    {
                        var variable = new W.Expr.Variable(lower.Identifier);

                        return new W.Expr.Let(variable.Term, expr, inExpr);
                    }

                case A.Pattern.Ctor deCtor:
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
                            args.Add(typeBuilder.Build(arg));
                        }

                        W.Polytype genType(W.Environment env, int index)
                        {
                            Assert(index < ctor.Arguments.Count);
                            return args![index];
                        }

                        var result = GenDestruct(0);

                        return result;

                        W.Expr GenDestruct(int index)
                        {
                            if (index == deCtor.Arguments.Count)
                            {
                                return inExpr;
                            }
                            else
                            {
                                var variable = GenVariable(GenVarPrefix);

                                var select = new W.Expr.GetValue2(expr, genType, index);

                                return new W.Expr.Let(variable.Term, select, 
                                    BuildDestructure(deCtor.Arguments[index], variable, GenDestruct(index + 1)));
                            }
                        }
                    }

                case A.Pattern.Cons deCons:
                    {
                        var var1 = GenVariable(GenVarPrefix);
                        var select1 = new W.Expr.GetValue(expr, genType, 0);
                        var var2 = GenVariable(GenVarPrefix);
                        var select2 = new W.Expr.GetValue(expr, genType, 1);

                        var let =
                            new W.Expr.Let(var1.Term, select1,
                                new W.Expr.Let(var2.Term, select2,
                                    BuildDestructure(deCons.First, var1,
                                        BuildDestructure(deCons.Rest, var2, inExpr))));

                        return let;

                        W.Polytype genType(W.Environment env)
                        {
                            return new W.Polytype(new W.Type.List(env.GetNextTypeVar()));
                        }
                    }

                case A.Pattern.Tuple2 tuple2:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var var1 = GenVariable(GenVarPrefix);
                        var select1 = new W.Expr.GetValue(expr, genType, 0);
                        var var2 = GenVariable(GenVarPrefix);
                        var select2 = new W.Expr.GetValue(expr, genType, 1);

                        var let =
                            new W.Expr.Let(var1.Term, select1,
                                new W.Expr.Let(var2.Term, select2,
                                    BuildDestructure(tuple2.Pattern1, var1,
                                        BuildDestructure(tuple2.Pattern2, var2, inExpr))));

                        return let;

                        W.Polytype genType(W.Environment env)
                        {
                            return new W.Polytype(new W.Type.Tuple2(env.GetNextTypeVar(), env.GetNextTypeVar()));
                        }
                    }

                case A.Pattern.Tuple3 tuple3:
                    {
                        return new W.Expr.Tuple3(
                            BuildDestructure(tuple3.Pattern1, expr, inExpr),
                            BuildDestructure(tuple3.Pattern2, expr, inExpr),
                            BuildDestructure(tuple3.Pattern3, expr, inExpr));
                    }

                case A.Pattern.WithAlias withAlias:
                    {
                        var variable = new W.Expr.Variable(withAlias.Alias.Identifier);

                        var let = new W.Expr.Let(
                            variable.Term,
                            expr,
                            BuildDestructure(withAlias.Pattern, variable, inExpr));

                        return let;
                    }

                default:
                    Assert(false);
                    break;
            }

            throw NotImplemented(pattern);

        }

        private W.Expr BuildVarLambda(A.Decl.Var var)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var expr = Build(var.Expression);
            var parameters = var.Parameters.Select(p => p.Pattern).ToList();

            for (var i = parameters.Count - 1; i >= 0; i--)
            {
                var pattern = parameters[i];

                var name = GenVariable(GenParamPrefix);

                expr = Destruct(pattern, name, expr);
                expr = new W.Expr.Lambda(name.Term, expr);
            }

            return Shorten(expr);
        }

        private W.Expr BuildLambdaExpr(A.Expr.Lambda lambda)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var expr = Build(lambda.Expression);
            var parameters = lambda.Parameters;

            for (var i = parameters.Count - 1; i >= 0; i--)
            {
                var pattern = parameters[i];

                var name = GenVariable(GenParamPrefix);

                expr = Destruct(pattern, name, expr);
                expr = new W.Expr.Lambda(name.Term, expr);
            }

            return Shorten(expr);
        }

        private W.Expr Shorten(W.Expr expr)
        {
            if (expr is W.Expr.Lambda lambda)
            {
                if (lambda.Expr is W.Expr.Let let)
                {
                    Assert(true);

                    if (let.Expr1 is W.Expr.Variable variable)
                    {
                        if (lambda.Term == variable.Term)
                        {
                            var result = new W.Expr.Lambda(let.Term, Shorten(let.Expr2));

                            return result;
                        }
                    }
                }
                else
                {
                    var result = new W.Expr.Lambda(lambda.Term, Shorten(lambda.Expr));

                    return result;
                }
            }

            return expr;
        }

        private W.Expr BuildMatcher(A.Expr.Matcher matcher)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var matchExpr = Build(matcher.Expression);

            if (matchExpr is W.Expr.Variable variable)
            {
                return GenMatcher(variable);
            }
            else
            {
                variable = GenVariable(GenMatchPrefix);

                return new W.Expr.Let(variable.Term, matchExpr, GenMatcher(variable));
            }

            W.Expr.Matcher GenMatcher(W.Expr.Variable variable)
            {
                var cases = new List<W.Expr.Case>();
                foreach (var caseExpr in matcher.Cases)
                {
                    var abstraction = BuildCaseExpr(variable, caseExpr);
                    cases.Add(abstraction);
                }

                return new W.Expr.Matcher(variable, cases.ToArray());
            }
        }

        private W.Expr.Case BuildCaseExpr(W.Expr.Variable matchExpr, A.Expr.Case cheese)
        {
            if (Investigated)
            {
                Assert(true);
            }

            var caseExpr = Build(cheese.Expression);
            var pattern = BuildPattern(cheese.Pattern);
            var destructure = BuildDestructure(cheese.Pattern, matchExpr, caseExpr);

            return new W.Expr.Case(Env, pattern, destructure);
        }

        private W.Expr BuildLetExpr(A.Expr.Let letExpr)
        {
            if (Investigated)
            {
                Assert(true);
            }

            W.Expr inExpr = Build(letExpr.InExpression);

            for (var i = letExpr.LetDecls.Count - 1; i >= 0; i--)
            {
                inExpr = BuildLet(letExpr.LetDecls[i], inExpr);
            }

            return inExpr;
        }

        private W.Expr BuildLet(A.Decl let, W.Expr inExpr)
        {
            switch (let)
            {
                case A.Decl.LetAssign assign:
                    {
                        return Destruct(assign.Pattern, Build(assign.Expression), inExpr);
                    }

                case A.Decl.Var var:
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var name = new W.TermVariable(var.Name);
                        var expr = Build(var.Expression);

                        foreach (var pattern in var.Parameters.Reverse().Select(p => p.Pattern))
                        {
                            expr = Decompose(pattern, expr);
                        }

                        return new W.Expr.Let(name, expr, inExpr);
                    }
                default:
                    break;
            }

            Assert(true);
            throw NotImplemented(let);
        }

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
                        if (Investigated)
                        {
                            Assert(true);
                        }
                        var variable = GenVariable(GenTuple2Prefix);
                        var get1 = new W.Expr.GetValue(variable, typeGen, 0);
                        var get2 = new W.Expr.GetValue(variable, typeGen, 1);
                        expr = Let(tuple2.Pattern2, get2, expr);
                        expr = Let(tuple2.Pattern1, get1, expr);
                        expr = new W.Expr.Lambda(variable.Term, expr);
                        return expr;

                        static W.Polytype typeGen(W.Environment env) => new(new W.Type.Tuple2(env.GetNextTypeVar(), env.GetNextTypeVar()));
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
