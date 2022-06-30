#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    public sealed class Phase6Resolve : Phase
    {
        public Phase6Resolve(Ambience ambience, Package package)
            : base("resolve", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Terminal.Write(".");

                if (module.IsJs)
                {
                    continue;
                }

                Make(module);
            }
        }

        private void Make(Module module)
        {
            var maker = new Maker(Ambience, Package, module);

            Collector.ResolveTime.Start();
            maker.Make();
            Collector.ResolveTime.Stop();
        }

        private class Maker : Phase
        {
            public Maker(Ambience ambience, Package package, Module module)
                : base("resolve", ambience, package)
            {
                Module = module;

                Assert(module.Ast != null);
            }

            public Module Module { get; }

            public override void Make()
            {
                foreach (var declaration in Module.Ast!.Declarations)
                {
                    Resolve(declaration);
                }
            }

            private void Resolve(A.Declaration declaration)
            {
                switch (declaration)
                {
                    case A.ImportDecl:
                        return;
                    case A.InfixDecl infix:
                        ResolveInfix(infix);
                        break;
                    case A.TypeDecl type:
                        ResolveType(type);
                        break;
                    case A.VarDecl var:
                        ResolveVar(var);
                        break;
                    case A.LetAssign let:
                        ResolveLet(let);
                        break;
                    case A.TypeAnnotation annotation:
                        ResolveAnnotation(annotation);
                        break;
                    case A.AliasDecl alias:
                        ResolveAlias(alias);
                        break;
                    default:
                        Assert(false);
                        throw new InvalidOperationException();
                }
            }

            private void ResolveInfix(A.InfixDecl infix)
            {
                ResolveExpr(Module.Scope, infix.Expression);
            }

            private void ResolveLet(A.LetAssign var)
            {
                ResolveExpr(var.Scope, var.Expression);
            }

            private void ResolveVar(A.VarDecl var)
            {
                ResolveExpr(var.Scope, var.Expression);
            }

            private void ResolveType(A.TypeDecl type)
            {
                ResolveType(Module.Scope, type.Type);
            }

            private void ResolveAnnotation(A.TypeAnnotation annotation)
            {
                ResolveType(Module.Scope, annotation.Type);
            }

            private void ResolveAlias(A.AliasDecl alias)
            {
                Assert(alias.Parameters.Count >= 0);

                ResolveType(Module.Scope, alias.Declaration);
            }

            private void ResolveType(Scope scope, A.Type type)
            {
                switch (type)
                {
                    case A.Type.Function function:
                        {
                            ResolveType(scope, function.InType);
                            ResolveType(scope, function.OutType);
                            break;
                        }

                    case A.Type.Tuple tuple:
                        {
                            foreach (var item in tuple.Types)
                            {
                                ResolveType(scope, item);
                            }
                            break;
                        }

                    case A.Type.Record record:
                        {
                            if (record.BaseRecord != null)
                            {
                                ResolveType(scope, record.BaseRecord);
                            }
                            foreach (var field in record.Fields)
                            {
                                ResolveType(scope, field.TypeDef);
                            }
                            break;
                        }

                    case A.Type.Concrete concrete:
                        {
                            if (scope.Resolve(concrete.Name, out var resolved))
                            {
                                if (resolved is A.TypeDecl typeDecl)
                                {
                                    Assert(typeDecl.Module != null);

                                    if (typeDecl.Module.IsCore)
                                    {
                                        switch (concrete.Name.Text)
                                        {
                                            case Lex.Primitive.Int:
                                                concrete.Resolved = new A.Type.Primitive.Int(concrete.Name);
                                                break;
                                            case Lex.Primitive.Float:
                                                concrete.Resolved = new A.Type.Primitive.Float(concrete.Name);
                                                break;
                                            case Lex.Primitive.Bool:
                                                concrete.Resolved = new A.Type.Primitive.Bool(concrete.Name);
                                                break;
                                            case Lex.Primitive.String:
                                                concrete.Resolved = new A.Type.Primitive.String(concrete.Name);
                                                break;
                                            case Lex.Primitive.Char:
                                                concrete.Resolved = new A.Type.Primitive.Char(concrete.Name);
                                                break;

                                        }
                                    }
                                }
                                Assert(true);
                            }
                            break;
                        }

                    case A.Type.Primitive primitive:
                        {
                            if (scope.Resolve(primitive.Name, out _))
                            {

                            }
                            break;
                        }

                    case A.Type.UnionType:
                        {
                            break;
                        }

                    case A.Type.Union union:
                        {
                            if (scope.Resolve(union.Name, out var resolved))
                            {
                                Assert(resolved.Module != null);

                                if (resolved.Module.IsCore && resolved is A.TypeDecl decl)
                                {
                                    foreach (var argument in union.Arguments)
                                    {
                                        ResolveType(scope, argument);
                                    }

                                    if (union.Arguments.Count == 0)
                                    {
                                        Assert(union.Arguments.Count == 0);
                                        //Assert(union.Name.Text == decl.Name.Text);

                                        switch (union.Name.Text)
                                        {
                                            case Lex.Primitive.Int:
                                                union.Resolved = new A.Type.Primitive.Int(union.Name);
                                                break;
                                            case Lex.Primitive.Float:
                                                union.Resolved = new A.Type.Primitive.Float(union.Name);
                                                break;
                                            case Lex.Primitive.Bool:
                                                union.Resolved = new A.Type.Primitive.Bool(union.Name);
                                                break;
                                            case Lex.Primitive.String:
                                                union.Resolved = new A.Type.Primitive.String(union.Name);
                                                break;
                                            case Lex.Primitive.Char:
                                                union.Resolved = new A.Type.Primitive.Char(union.Name);
                                                break;
                                        }
                                    }
                                    else if (union.Arguments.Count == 1)
                                    {
                                        switch (union.Name.Text)
                                        {
                                            case Lex.Primitive.List:
                                                union.Resolved = new A.Type.Primitive.List(union.Name, union.Arguments[0]);
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        }

                    case A.Type.Parameter:
                    case A.Type.NumberClass:
                    case A.Type.AppendableClass:
                    case A.Type.ComparableClass:
                    case A.Type.Unit:
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

            private void ResolveExpr(Scope scope, A.Expr expression)
            {
                switch (expression)
                {
                    case A.Expr.Literal:
                    case A.Expr.Unit:
                    case A.Wildcard:
                        break;
                    case A.Expr.Dot:
                        break; //TODO: what to do here
                    case A.Identifier identifier:
                        {
                            if (identifier.IsSingleLower)
                            {
                                if (scope.Resolve(identifier, out var resolved))
                                {
                                    Assert(resolved is not A.Identifier);
                                    if (resolved is A.VarDecl var)
                                    {
                                        expression.Resolved = new A.Ref.Var(var);
                                        break;
                                    }
                                    else if (resolved is A.ParameterDecl parameter)
                                    {
                                        expression.Resolved = new A.Ref.Parameter(parameter);
                                        break;
                                    }
                                    else
                                    {
                                        Assert(false);
                                    }
                                    break;
                                }
                                Assert(false);
                                throw new NotImplementedException();
                            }
                            else if (identifier.IsQualified)
                            {
                                if (scope.Resolve(identifier, out var resolved))
                                {
                                    if (resolved is A.NativeDecl native)
                                    {
                                        expression.Resolved = new A.Ref.Native(native);
                                        break;
                                    }
                                    else if (resolved is A.VarDecl var)
                                    {
                                        expression.Resolved = new A.Ref.Var(var);
                                        break;
                                    }
                                }

                                Assert(false);
                                throw new NotImplementedException();
                            }
                            else if (identifier.IsSingleOp)
                            {
                                if (scope.Resolve(identifier, out var resolved))
                                {
                                    if (resolved is A.InfixDecl infix)
                                    {
                                        expression.Resolved = new A.Ref.Infix(infix);
                                        break;
                                    }
                                }
                                Assert(false);
                                throw new NotImplementedException();
                            }
                            else if (identifier.IsSingleUpper)
                            {
                                if (scope.Resolve(identifier, out var resolved))
                                {
                                    if (resolved is A.Constructor ctor)
                                    {
                                        expression.Resolved = new A.Ref.Ctor(ctor);
                                        break;
                                    }
                                    else if (resolved is A.TypeDecl type)
                                    {
                                        expression.Resolved = new A.Ref.Type(type);
                                        break;
                                    }
                                    else if (resolved is A.AliasDecl alias)
                                    {
                                        expression.Resolved = new A.Ref.Alias(alias);
                                        break;
                                    }
                                    Assert(false);
                                    throw new NotImplementedException();
                                }
                                Assert(false);
                                throw new NotImplementedException();
                            }
                            else if (identifier.IsMultiUpper)
                            {
                                if (scope.Resolve(identifier, out var resolved))
                                {
                                    if (resolved is A.Constructor ctor)
                                    {
                                        expression.Resolved = new A.Ref.Ctor(ctor);
                                        break;
                                    }
                                    if (resolved is A.TypeDecl type)
                                    {
                                        expression.Resolved = new A.Ref.Type(type);
                                        break;
                                    }
                                }
                                Assert(false);
                                throw new NotImplementedException();
                            }
                            else
                            {
                                Assert(false);
                                throw new NotImplementedException();
                            }
                        }
                    case A.Expr.If iff:
                        ResolveExpr(scope, iff.Condition);
                        ResolveExpr(scope, iff.IfTrue);
                        ResolveExpr(scope, iff.IfFalse);
                        break;
                    case A.Expr.CaseMatch match:
                        ResolveExpr(scope, match.Expression);
                        foreach (var matchCase in match.Cases)
                        {
                            ResolveExpr(scope, matchCase);
                        }
                        break;
                    case A.Case matchCase:
                        ResolveExpr(matchCase.Scope, matchCase.Pattern);
                        ResolveExpr(matchCase.Scope, matchCase.Expression);
                        break;
                    case A.Expr.Let let:
                        {
                            foreach (var expr in let.LetDecls)
                            {
                                Resolve(expr);
                            }
                            ResolveExpr(let.Scope, let.InExpression);
                            break;
                        }
                    case A.Expr.Lambda lambda:
                        ResolveExpr(lambda.Scope, lambda.Parameters);
                        ResolveExpr(lambda.Scope, lambda.Expression);
                        break;
                    case A.Expr.Sequence sequence:
                        foreach (var expr in sequence)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.Expr.Tuple tuple:
                        foreach (var expr in tuple)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.Expr.List list:
                        foreach (var expr in list)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.Expr.Record record:
                        if (record.BaseRecord != null)
                        {
                            ResolveExpr(scope, record.BaseRecord);
                        }
                        foreach (var field in record.Fields)
                        {
                            ResolveExpr(scope, field);
                        }
                        break;
                    case A.FieldAssign fieldAssign:
                        ResolveExpr(scope, fieldAssign.Expression);
                        break;
                    case A.Expr.Prefix prefix:
                        //TODO: prefix operator
                        //ResolveExpr(scope, prefix.Op);
                        ResolveExpr(scope, prefix.Rhs);
                        break;
                    case A.OpChain chain:
                        Assert(chain.Resolved is A.OpChain);
                        ResolveInfix(scope, chain);
                        break;
                    case A.Expr.Select select:
                        ResolveExpr(scope, select.Lhs);
                        break;
                    case A.RecordPattern recordPattern:
                        foreach (var field in recordPattern.Fields)
                        {
                            ResolveExpr(scope, field);
                        }
                        break;
                    case A.FieldPattern fieldPattern:
                        ResolveExpr(scope, fieldPattern.Pattern);
                        break;

                    case A.Parameters parameters:
                        {
                            foreach (var parameter in parameters)
                            {
                                ResolveExpr(scope, parameter.Expression);
                            }
                            break;
                        }

                    case A.Pattern.List list:
                        {
                            foreach (var pattern in list.Patterns)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Destruct destruct:
                        {
                            foreach (var pattern in destruct.Patterns)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }
                    case A.Pattern.Tuple tuple:
                        {
                            foreach (var pattern in tuple.Patterns)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }
                    case A.Pattern.Record record:
                        {
                            foreach (var pattern in record.Patterns)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Signature sign:
                        {
                            foreach (var pattern in sign.Parameters)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Lambda lambda:
                        {
                            foreach (var pattern in lambda.Parameters)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Ctor ctor:
                        {
                            foreach (var pattern in ctor.Arguments)
                            {
                                ResolveExpr(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.WithAlias with:
                        {
                            ResolveExpr(scope, with.Pattern);
                            ResolveExpr(scope, with.Alias);
                            break;
                        }

                    case A.Pattern.LowerId identifier:
                        {
                            ResolveExpr(scope, identifier.Identifier);
                            break;
                        }

                    case A.Pattern.Wildcard:
                    case A.Pattern.Unit:
                    case A.Pattern.Literal:
                    case A.Pattern.UpperId:
                        break;

                    case A.Ref.Native:
                        break;


                    default:
                        Assert(false);
                        throw new NotImplementedException($"{expression}");
                }
            }

            private void ResolveInfix(Scope scope, A.OpChain chain)
            {
                Assert(chain.Rest.Count > 0);

                ResolveExpr(scope, chain.First);

                foreach (var opExpr in chain.Rest)
                {
                    if (scope.Resolve(opExpr.Op.Name, out var resolved))
                    {
                        if (resolved is A.InfixDecl infixDecl)
                        {
                            opExpr.Op.InfixDecl = infixDecl;

                            ResolveExpr(scope, opExpr.Expression);
                        }
                        else
                        {
                            Assert(false);
                            throw new NotImplementedException();
                        }
                    }
                }

                var infix = chain.Resolve();

                chain.Resolved = infix;

                Assert(chain.Resolved is A.Expr.Infix);
            }
        }
    }
}
