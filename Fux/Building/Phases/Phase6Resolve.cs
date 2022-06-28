#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase6Resolve : Phase
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
                        Resolve(infix);
                        break;
                    case A.UnionDecl type:
                        Resolve(type);
                        break;
                    case A.VarDecl var:
                        Resolve(var);
                        break;
                    case A.TypeAnnotation annotation:
                        Resolve(annotation);
                        break;
                    case A.AliasDecl alias:
                        Resolve(alias);
                        break;
                    default:
                        Assert(false);
                        throw new InvalidOperationException();
                }
            }

            private void Resolve(A.InfixDecl infix)
            {
                ResolveExpr(Module.Scope, infix.Expression);
            }

            private void Resolve(A.VarDecl var)
            {
                ResolveExpr(var.Scope, var.Expression);
            }

            private void Resolve(A.UnionDecl type)
            {
                ResolveType(Module.Scope, type.Type);
            }

            private void Resolve(A.TypeAnnotation annotation)
            {
                ResolveType(Module.Scope, annotation.Type);
            }

            private void Resolve(A.AliasDecl alias)
            {
                Assert(alias.Parameters.Count >= 0);

                ResolveType(Module.Scope, alias.Declaration);
            }

            private void ResolveType(Scope scope, A.Type type)
            {
                switch (type)
                {
                    case A.Type.Function function:
                        ResolveType(scope, function.InType);
                        ResolveType(scope, function.OutType);
                        break;
                    case A.Type.Tuple tuple:
                        foreach (var item in tuple.Types)
                        {
                            ResolveType(scope, item);
                        }
                        break;
                    case A.Type.Record record:
                        if (record.BaseRecord != null)
                        {
                            ResolveType(scope, record.BaseRecord);
                        }
                        foreach (var field in record.Fields)
                        {
                            ResolveType(scope, field.TypeDef);
                        }
                        break;
                    case A.Type.Concrete concrete:
                        if (scope.Resolve(concrete.Name, out _))
                        {
                            Assert(true);
                        }
                        break;
                    case A.Type.Primitive primitive:
                        if (scope.Resolve(primitive.Name, out _))
                        {

                        }
                        break;
                    case A.Type.UnionType unionType:
                        {
                            break;
                        }
                    case A.Type.Union union:
                        if (scope.Resolve(union.Name, out var resolved))
                        {
                            Assert(resolved.Module != null);

                            if (resolved.Module.IsCore && resolved is A.UnionDecl decl)
                            {
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
                    case A.Literal:
                    case A.Unit:
                    case A.NativeDecl:
                    case A.Wildcard:
                        break;
                    case A.DotExpr:
                        break; //TODO: what to do here
                    case A.Identifier identifier:
                        {
                            if (scope.Resolve(identifier, out var expr))
                            {
                                if (expr is A.Identifier)
                                {
                                    scope.Resolve(identifier, out expr);
                                }
                                Assert(expr is not A.Identifier);
                                Assert(expr != null);
                                expression.Resolved = expr;
                                break;
                            }
                            Assert(false);
                            throw new NotImplementedException();
                        }
                    case A.IfExpr iff:
                        ResolveExpr(scope, iff.Condition);
                        ResolveExpr(scope, iff.IfTrue);
                        ResolveExpr(scope, iff.IfFalse);
                        break;
                    case A.MatchExpr match:
                        ResolveExpr(scope, match.Expression);
                        foreach (var matchCase in match.Cases)
                        {
                            ResolveExpr(scope, matchCase);
                        }
                        break;
                    case A.MatchCase matchCase:
                        ResolveExpr(matchCase.Scope, matchCase.Pattern);
                        ResolveExpr(matchCase.Scope, matchCase.Expression);
                        break;
                    case A.LetExpr let:
                        {
                            foreach (var expr in let.LetExpressions)
                            {
                                ResolveExpr(scope, expr);
                            }
                            ResolveExpr(let.Scope, let.InExpression);
                            break;
                        }
                    case A.LetAssign letAssign:
                        ResolveExpr(letAssign.Scope, letAssign.Pattern);
                        ResolveExpr(letAssign.Scope, letAssign.Expression);
                        break;
                    case A.LambdaExpr lambda:
                        ResolveExpr(lambda.Scope, lambda.Parameters);
                        ResolveExpr(lambda.Scope, lambda.Expression);
                        break;
                    case A.VarDecl var:
                        ResolveExpr(var.Scope, var.Parameters);
                        ResolveExpr(var.Scope, var.Expression);
                        break;
                    case A.SequenceExpr sequence:
                        foreach (var expr in sequence)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.TupleExpr tuple:
                        foreach (var expr in tuple)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.ListExpr list:
                        foreach (var expr in list)
                        {
                            ResolveExpr(scope, expr);
                        }
                        break;
                    case A.RecordExpr record:
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
                    case A.PrefixExpr prefix:
                        //TODO: prefix operator
                        //ResolveExpr(scope, prefix.Op);
                        ResolveExpr(scope, prefix.Rhs);
                        break;
                    case A.OpChain chain:
                        Assert(chain.Resolved is A.OpChain);
                        ResolveInfix(scope, chain);
                        break;
                    case A.SelectExpr select:
                        ResolveExpr(scope, select.Lhs);
                        break;
                    case A.TypeAnnotation annotation:
                        ResolveType(scope, annotation.Type);
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
                                ResolveExpr(scope, parameter);
                            }
                            break;
                        }
                    case A.Parameter parameter:
                        {
                            ResolveExpr(scope, parameter.Expression);
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

                    case A.Pattern.Sign sign:
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
                        if (resolved is A.InfixDecl op)
                        {
                            opExpr.Op.Resolved = op;

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

                Assert(chain.Resolved is A.InfixExpr);
            }
        }
    }
}
