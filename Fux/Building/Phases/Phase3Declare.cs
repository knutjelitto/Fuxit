#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0063 // Use simple 'using' statement

namespace Fux.Building.Phases
{
    internal class Phase3Declare : Phase
    {
        private readonly List<A.Declaration> collector = new();

        public Phase3Declare(Ambience ambience, Package package)
            : base("declare", ambience, package)
        {
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Terminal.Write(".");

                Make(module);

                Write(module);
            }
        }

        private void Make(Module module)
        {
            Collector.DeclareTime.Start();
            MakeModule(module);
            Collector.DeclareTime.Stop();
        }

        private void Write(Module module)
        {
            if (Ambience.Config.WriteTheDeclarations)
            {
                using (var writer = MakeWriter(module, "declarations"))
                {
                    foreach (var declaration in collector)
                    {
                        writer.Write($"{declaration.GetType().Name} - {declaration.Name}");
                        writer.WriteLine();
                        writer.Indent(() =>
                        {
                            declaration.PP(writer);
                        });
                        writer.EndLine();
                        writer.WriteLine();
                    }
                }
            }
        }

        private void MakeModule(Module module)
        {
            if (module.Ast != null)
            {
                var ast = module.Ast;
                var header = ast.Header;

                Assert(ast.Declarations.Count() == ast.Expressions.Count);

                collector.Add(header);

                foreach (var where in header.Where)
                {
                    module.Scope.AddVar(where);
                }

                if (module.Name == "List")
                {
                    if (!module.Scope.LookupType(A.Identifier.Artificial(module, "List"), out _))
                    {
                        Declare(FakeList.MakeType(module));
                    }
                }

                foreach (var declaration in ast.Declarations)
                {
                    Declare(declaration);
                }
                Assert(module.Scope.HintsAreEmpty);
            }

            void Declare(A.Declaration declaration)
            {
                switch (declaration)
                {
                    case A.ImportDecl import:
                        Import(module.Scope, import);
                        break;
                    case A.InfixDecl infix:
                        Infix(module.Scope, infix);
                        break;
                    case A.UnionDecl type:
                        Type(module.Scope, type);
                        break;
                    case A.AliasDecl alias:
                        Alias(module.Scope, alias);
                        break;
                    case A.VarDecl varDecl:
                        VarDecl(module.Scope, varDecl);
                        break;
                    case A.TypeHint hint:
                        TypeHint(module.Scope, hint);
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                        break;
                }
            }
        }

        private void TypeHint(Scope scope, A.TypeHint hint)
        {
            Collector.DeclareHint.Add(hint);

            collector.Add(hint);

            scope.AddHint(hint);
        }

        private void VarDecl(Scope scope, A.VarDecl var)
        {
            Collector.DeclareVar.Add(var);

            collector.Add(var);

            scope.AddVar(var);

            var.Scope.Parent = scope;

            foreach (var parameter in var.Parameters)
            {
                foreach (var identifier in ExplodePattern(parameter))
                {
                    var.Scope.Add(identifier);
                }
            }

            ScopeExpr(var.Scope, var.Expression);
        }

        private void Import(ModuleScope scope, A.ImportDecl import)
        {
            Collector.Import.Add(import);

            collector.Add(import);

            scope.ImportAddImport(import);
        }

        private void Infix(ModuleScope scope, A.InfixDecl infix)
        {
            Collector.DeclareInfix.Add(infix);

            collector.Add(infix);

            scope.AddInfix(infix);

            ScopeExpr(scope, infix.Expression);
        }

        private void Type(ModuleScope scope, A.UnionDecl type)
        {
            Collector.DeclareType.Add(type);

            collector.Add(type);

            scope.AddType(type);

            type.Scope.Parent = scope;

            foreach (var parameter in type.Parameters)
            {
                type.Scope.Add(parameter);
            }

            foreach (var constructor in type.Constructors)
            {
                scope.AddConstructor(constructor);
            }
        }

        private void Alias(ModuleScope scope, A.AliasDecl alias)
        {
            Collector.DeclareAlias.Add(alias);

            collector.Add(alias);

            scope.AddAlias(alias);
        }

        private void ScopeExpr(Scope scope, A.Expression expression)
        {
            switch (expression)
            {
                case A.Identifier:
                case A.Literal:
                case A.Unit:
                case A.NativeDecl:
                    break;
                case A.DotExpr: //TODO: what to do here?
                    break;
                case A.IfExpr iff:
                    ScopeExpr(scope, iff.Condition);
                    ScopeExpr(scope, iff.IfTrue);
                    ScopeExpr(scope, iff.IfFalse);
                    break;
                case A.MatchExpr match:
                    ScopeExpr(scope, match.Expression);
                    foreach (var matchCase in match.Cases)
                    {
                        ScopeExpr(scope, matchCase);
                        Assert(matchCase.Scope.Parent != null);
                    }
                    break;
                case A.MatchCase matchCase:
                    Assert(matchCase.Scope.Parent == null);
                    matchCase.Scope.Parent = scope;
                    foreach (var identifier in ExplodePattern(matchCase.Pattern))
                    {
                        matchCase.Scope.Add(identifier);
                    }
                    ScopeExpr(matchCase.Scope, matchCase.Expression);
                    break;
                case A.SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case A.TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case A.ListExpr list:
                    foreach (var expr in list)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case A.PrefixExpr prefix:
                    ScopeExpr(scope, prefix.Rhs);
                    break;
                case A.InfixExpr infix:
                    ScopeExpr(scope, infix.Lhs);
                    ScopeExpr(scope, infix.Rhs);
                    break;
                case A.OpChain opChain:
                    ScopeExpr(scope, opChain.First);
                    foreach (var rest in opChain.Rest)
                    {
                        ScopeExpr(scope, rest.Expression);
                    }
                    break;
                case A.LetExpr let:
                    let.Scope.Parent = scope;
                    ScopeLet(let);
                    break;
                case A.LambdaExpr lambda:
                    lambda.Scope.Parent = scope;
                    ScopeLambda(lambda);
                    break;
                case A.RecordExpr record:
                    foreach (var field in record.Fields)
                    {
                        ScopeExpr(scope, field.Expression);
                    }
                    break;
                case A.SelectExpr select:
                    ScopeExpr(scope, select.Lhs);
                    ScopeExpr(scope, select.Rhs);
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ScopeLet(A.LetExpr let)
        {
            var hints = new Dictionary<A.Identifier, A.TypeHint>();
            Assert(let.Scope.HintsAreEmpty);

            foreach (var expr in let.LetExpressions)
            {
                switch (expr)
                {
                    case A.VarDecl var:
                        {
                            var.Scope.Parent = let.Scope;

                            foreach (var parameter in var.Parameters)
                            {
                                foreach (var identifier in ExplodePattern(parameter))
                                {
                                    var.Scope.Add(identifier);
                                }
                            }

                            let.Scope.AddVar(var);

                            ScopeExpr(var.Scope, var.Expression);
                        }
                        break;
                    case A.LetAssign assign:
                        {
                            assign.Scope.Parent = let.Scope;

                            Assert(let.Scope.HintsAreEmpty);

                            foreach (var identifier in ExplodePattern(assign.Pattern))
                            {
                                let.Scope.Add(identifier);
                            }

                            ScopeExpr(assign.Scope, assign.Expression);
                        }
                        break;
                    case A.TypeHint hint:
                        {
                            let.Scope.AddHint(hint);
                        }
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

            Assert(hints.Count == 0);
            Assert(let.Scope.HintsAreEmpty);

            ScopeExpr(let.Scope, let.InExpression);
        }

        private void ScopeLambda(A.LambdaExpr lambda)
        {
            foreach (var identifier in ExplodePattern(lambda.Parameters))
            {
                lambda.Scope.Add(identifier);
            }

            ScopeExpr(lambda.Scope, lambda.Expression);
        }

        private IEnumerable<A.Parameter> ExplodePattern(A.Expression pattern)
        {
            switch (pattern)
            {
                case A.Identifier identifier when identifier.IsMultiUpper:
                case A.Wildcard:
                case A.Literal:
                case A.Unit:
                    break;

                case A.Identifier identifier when identifier.IsSingleLower:
                    yield return new A.Parameter(identifier);
                    break;
                case A.SequenceExpr sequence:
                    {
                        foreach(var expr in sequence)
                        {
                            foreach (var identifier in ExplodePattern(expr))
                            {
                                yield return identifier;
                            }
                        }
                    }
                    break;
                case A.TupleExpr tuple:
                    {
                        foreach (var expr in tuple)
                        {
                            foreach (var identifier in ExplodePattern(expr))
                            {
                                yield return identifier;
                            }
                        }
                    }
                    break;
                case A.ListExpr list:
                    {
                        foreach (var expr in list)
                        {
                            foreach (var identifier in ExplodePattern(expr))
                            {
                                yield return identifier;
                            }
                        }
                    }
                    break;
                case A.OpChain opChain:
                    foreach (var identifier in ExplodePattern(opChain.First))
                    {
                        yield return identifier;
                    }
                    foreach (var rest in opChain.Rest)
                    {
                        foreach (var identifier in ExplodePattern(rest.Expression))
                        {
                            yield return identifier;
                        }
                    }
                    break;
                case A.InfixExpr infix:
                    foreach (var parameter in ExplodePattern(infix.Lhs))
                    {
                        yield return parameter;
                    }
                    foreach (var parameter in ExplodePattern(infix.Rhs))
                    {
                        yield return parameter;
                    }
                    break;
                case A.RecordPattern recordPattern:
                    foreach (var field in recordPattern.Fields)
                    {
                        foreach (var parameter in ExplodePattern(field.Pattern))
                        {
                            yield return parameter;
                        }
                    }
                    break;
                case A.Parameter parameterer:
                    foreach (var parameter in ExplodePattern(parameterer.Expression))
                    {
                        yield return parameter;
                    }
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }

            if (pattern.Alias != null)
            {
                yield return new A.Parameter(pattern.Alias.SingleLower());
            }
        }
    }
}
