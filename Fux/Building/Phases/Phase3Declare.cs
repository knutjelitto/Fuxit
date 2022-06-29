#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0063 // Use simple 'using' statement

namespace Fux.Building.Phases
{
    public sealed class Phase3Declare : Phase
    {
        private readonly List<A.Declaration> declarations = new();

        public Phase3Declare(Ambience ambience, Package package)
            : base("declare", ambience, package)
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

                Write(module);
            }
        }

        private void Make(Module module)
        {
            var maker = new Maker(Ambience, Package, module, declarations);

            Collector.DeclareTime.Start();
            maker.Make();
            Collector.DeclareTime.Stop();
        }

        private class Maker : Phase
        {
            public Maker(Ambience ambience, Package package, Module module, List<A.Declaration> delcarations)
                : base("resolve", ambience, package)
            {
                Assert(module.Ast != null);

                Module = module;
                Declarations = delcarations;
            }

            public Module Module { get; }
            public List<A.Declaration> Declarations { get; }

            public override void Make()
            {
                Assert(Module.Ast != null);

                var module = Module;

                if (Module.Ast != null)
                {
                    var ast = Module.Ast;
                    var header = ast.Header;

                    var declarations = ast.Declarations.ToList();
                    Assert(declarations.Count == ast.Declarations.Count);

                    Declarations.Add(header);

                    foreach (var where in header.Where)
                    {
                        module.Scope.AddVar(where);
                    }

                    if (module.IsCore && module.Name == Lex.Primitive.List)
                    {
                        if (!module.Scope.LookupType(A.Identifier.Artificial(module, Lex.Primitive.List), out _))
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
                        case A.TypeAnnotation annotation:
                            TypeAnnotation(module.Scope, annotation);
                            break;
                        default:
                            Assert(false);
                            throw new NotImplementedException();
                            break;
                    }
                }
            }

            private void TypeAnnotation(Scope scope, A.TypeAnnotation annotation)
            {
                Collector.DeclareAnnotation.Add(annotation);

                Declarations.Add(annotation);

                scope.AddHint(annotation);
            }

            private void VarDecl(Scope scope, A.VarDecl var)
            {
                if (var.Name.Text == "fromPolar")
                {
                    Assert(true);
                }

                Collector.DeclareVar.Add(var);

                Declarations.Add(var);

                scope.AddVar(var);

                var.Scope.Parent = scope;

                foreach (var parameter in var.Parameters)
                {
                    Assert(parameter.Expression is A.Pattern);

                    if (parameter.Expression is A.Pattern pattern)
                    {
                        foreach (var identifier in pattern.Flatten())
                        {
                            var.Scope.Add(new A.Parameter(identifier));
                        }
                    }
                    else
                    {
                        foreach (var identifier in ExplodePattern(parameter))
                        {
                            var.Scope.Add(identifier);
                        }
                    }
                }

                ScopeExpr(var.Scope, var.Expression);
            }

            private void Import(ModuleScope scope, A.ImportDecl import)
            {
                Collector.Import.Add(import);

                Declarations.Add(import);

                scope.ImportAddImport(import);
            }

            private void Infix(ModuleScope scope, A.InfixDecl infix)
            {
                Collector.DeclareInfix.Add(infix);

                Declarations.Add(infix);

                scope.AddInfix(infix);

                ScopeExpr(scope, infix.Expression);
            }

            private void Type(ModuleScope scope, A.UnionDecl type)
            {
                Collector.DeclareType.Add(type);

                Declarations.Add(type);

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

                Declarations.Add(alias);

                scope.AddAlias(alias);
            }

            private void ScopeExpr(Scope scope, A.Expr expression)
            {
                Assert(expression.Module != null);

                switch (expression)
                {
                    case A.Identifier:
                    case A.Literal:
                    case A.Unit:
                    case A.NativeDecl:
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
                        if (matchCase.Pattern is A.Pattern pattern)
                        {
                            foreach (var parameter in pattern.ExractMatchNames())
                            {
                                matchCase.Scope.Add(parameter);
                            }
                        }
                        else
                        {
                            foreach (var identifier in ExplodePattern(matchCase.Pattern))
                            {
                                matchCase.Scope.Add(identifier);
                            }
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
                    case A.LetExpr letExpr:
                        letExpr.Scope.Parent = scope;
                        ScopeLet(letExpr);
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

            private void ScopeLet(A.LetExpr letExr)
            {
                var hints = new Dictionary<A.Identifier, A.TypeAnnotation>();
                Assert(letExr.Scope.HintsAreEmpty);

                foreach (var expr in letExr.LetDecls)
                {
                    switch (expr)
                    {
                        case A.VarDecl var:
                            {
                                var.Scope.Parent = letExr.Scope;

                                foreach (var parameter in var.Parameters)
                                {
                                    Assert(parameter.Expression is A.Pattern);

                                    if (parameter.Expression is A.Pattern pattern)
                                    {
                                        foreach (var identifier in pattern.ExtractNamedParameters())
                                        {
                                            var.Scope.Add(identifier);
                                        }
                                    }
                                    else
                                    {
                                        foreach (var identifier in ExplodePattern(parameter))
                                        {
                                            var.Scope.Add(identifier);
                                        }
                                    }
                                }

                                letExr.Scope.AddVar(var);

                                ScopeExpr(var.Scope, var.Expression);
                            }
                            break;
                        case A.LetAssign assign:
                            {
                                assign.Scope.Parent = letExr.Scope;

                                Assert(letExr.Scope.HintsAreEmpty);

                                foreach (var identifier in assign.Pattern.ExtractNamedParameters())
                                {
                                    letExr.Scope.Add(identifier);
                                }

                                ScopeExpr(assign.Scope, assign.Expression);
                            }
                            break;
                        case A.TypeAnnotation annotation:
                            {
                                letExr.Scope.AddHint(annotation);
                            }
                            break;
                        default:
                            Assert(false);
                            throw new NotImplementedException();
                    }
                }

                Assert(hints.Count == 0);
                Assert(letExr.Scope.HintsAreEmpty);

                ScopeExpr(letExr.Scope, letExr.InExpression);
            }

            private void ScopeLambda(A.LambdaExpr lambda)
            {
                foreach (var identifier in lambda.Parameters.Flatten())
                {
                    lambda.Scope.Add(new A.Parameter(identifier));
                }

                ScopeExpr(lambda.Scope, lambda.Expression);
            }

            private IEnumerable<A.Parameter> ExplodePattern(A.Expr pattern)
            {
                switch (pattern)
                {
                    case A.Pattern.LowerId identifier:
                        {
                            yield return new A.Parameter(identifier.Identifier);
                            break;
                        }
                    case A.Pattern.Tuple tuple:
                        {
                            foreach (var item in tuple.Patterns)
                            {
                                foreach (var pim in ExplodePattern(item))
                                {
                                    yield return pim;
                                }
                            }
                            break;
                        }

                    case A.Pattern.Sign sign:
                        {
                            foreach (var argument in sign.Parameters)
                            {
                                foreach (var pim in ExplodePattern(argument))
                                {
                                    yield return pim;
                                }
                            }
                            break;
                        }

                    case A.Pattern.Ctor ctor:
                        {
                            foreach (var argument in ctor.Arguments)
                            {
                                foreach (var pim in ExplodePattern(argument))
                                {
                                    yield return pim;
                                }
                            }
                            break;
                        }

                    case A.Pattern.WithAlias with:
                        {
                            foreach (var pim in ExplodePattern(with.Pattern))
                            {
                                yield return pim;
                            }
                            foreach (var pim in ExplodePattern(with.Alias))
                            {
                                yield return pim;
                            }
                            break;
                        }
                    case A.Pattern.Record record:
                        {
                            foreach (var item in record.Patterns)
                            {
                                foreach (var pim in ExplodePattern(item))
                                {
                                    yield return pim;
                                }
                            }
                            break;
                        }

                    case A.Pattern.Wildcard:
                    case A.Pattern.Unit:
                        break;

                    case A.Identifier identifier when identifier.IsMultiUpper:
                    case A.Wildcard:
                    case A.Literal:
                    case A.Unit:
                        break;

                    case A.Identifier identifier when identifier.IsSingleLower:
                        {
                            yield return new A.Parameter(identifier);
                            break;
                        }
                    case A.SequenceExpr sequence:
                        {
                            foreach (var expr in sequence)
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
                        throw new NotImplementedException($"{pattern}");
                }

                if (pattern.Alias != null)
                {
                    yield return new A.Parameter(pattern.Alias.SingleLower());
                }
            }
        }

        private void Write(Module module)
        {
            if (Ambience.Config.WriteTheDeclarations)
            {
                using (var writer = MakeWriter(module, "declarations"))
                {
                    foreach (var declaration in declarations)
                    {
                        var name = declaration is A.NamedDeclaration named ? named.Name.Text : "<no-name>";
                        writer.Write($"{declaration.GetType().Name} - {name}");
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

    }
}
