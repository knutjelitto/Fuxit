#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0063 // Use simple 'using' statement

namespace Fux.Building.Phases
{
    public sealed class Phase3Declare : Phase
    {
        private readonly List<A.Decl> declarations = new();

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
            public Maker(Ambience ambience, Package package, Module module, List<A.Decl> delcarations)
                : base("resolve", ambience, package)
            {
                Assert(module.Ast != null);

                Module = module;
                Declarations = delcarations;
            }

            public Module Module { get; }
            public List<A.Decl> Declarations { get; }

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

                void Declare(A.Decl declaration)
                {
                    switch (declaration)
                    {
                        case A.Decl.Import import:
                            Import(module.Scope, import);
                            break;
                        case A.Decl.Infix infix:
                            Infix(module.Scope, infix);
                            break;
                        case A.Decl.Custom type:
                            Type(module.Scope, type);
                            break;
                        case A.Decl.Alias alias:
                            Alias(module.Scope, alias);
                            break;
                        case A.Decl.Var varDecl:
                            VarDecl(module.Scope, varDecl);
                            break;
                        case A.Decl.TypeAnnotation annotation:
                            TypeAnnotation(module.Scope, annotation);
                            break;
                        default:
                            Assert(false);
                            throw new NotImplementedException();
                            break;
                    }
                }
            }

            private void TypeAnnotation(Scope scope, A.Decl.TypeAnnotation annotation)
            {
                Collector.Annotation.Add(annotation);

                Declarations.Add(annotation);

                scope.AddHint(annotation);
            }

            private void VarDecl(Scope scope, A.Decl.Var var)
            {
                if (var.Name.Text == "fromPolar")
                {
                    Assert(true);
                }

                Collector.Var.Add(var);

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
                            var.Scope.Add(new A.Decl.Parameter(identifier));
                        }
                    }
                    else
                    {
                        Assert(false);
                    }
                }

                ScopeExpr(var.Scope, var.Expression);
            }

            private void Import(ModuleScope scope, A.Decl.Import import)
            {
                Collector.Import.Add(import);

                Declarations.Add(import);

                scope.ImportAddImport(import);
            }

            private void Infix(ModuleScope scope, A.Decl.Infix infix)
            {
                Collector.Infix.Add(infix);

                Declarations.Add(infix);

                scope.AddInfix(infix);

                ScopeExpr(scope, infix.Expression);
            }

            private void Type(ModuleScope scope, A.Decl.Custom type)
            {
                Collector.Custom.Add(type);

                Declarations.Add(type);

                scope.AddType(type);

                type.Scope.Parent = scope;

                foreach (var parameter in type.Parameters)
                {
                    type.Scope.Add(parameter);
                }

                foreach (var constructor in type.Ctors)
                {
                    scope.AddConstructor(constructor);
                }
            }

            private void Alias(ModuleScope scope, A.Decl.Alias alias)
            {
                Collector.Alias.Add(alias);

                Declarations.Add(alias);

                scope.AddAlias(alias);
            }

            private void ScopeExpr(Scope scope, A.Expr expression)
            {
                Assert(expression.InModule != null);

                switch (expression)
                {
                    case A.Identifier:
                    case A.Expr.Literal:
                    case A.Expr.Unit:
                    case A.Expr.Dot: //TODO: what to do here?
                        break;
                    case A.Expr.If iff:
                        ScopeExpr(scope, iff.Condition);
                        ScopeExpr(scope, iff.IfTrue);
                        ScopeExpr(scope, iff.IfFalse);
                        break;
                    case A.Expr.Matcher match:
                        ScopeExpr(scope, match.Expression);
                        foreach (var matchCase in match.Cases)
                        {
                            ScopeExpr(scope, matchCase);
                            Assert(matchCase.Scope.Parent != null);
                        }
                        break;
                    case A.Expr.Case matchCase:
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
                    case A.Expr.Sequence sequence:
                        foreach (var expr in sequence)
                        {
                            ScopeExpr(scope, expr);
                        }
                        break;
                    case A.Expr.Tuple tuple:
                        foreach (var expr in tuple)
                        {
                            ScopeExpr(scope, expr);
                        }
                        break;
                    case A.Expr.List list:
                        foreach (var expr in list)
                        {
                            ScopeExpr(scope, expr);
                        }
                        break;
                    case A.Expr.Prefix prefix:
                        ScopeExpr(scope, prefix.Rhs);
                        break;
                    case A.Expr.Infix infix:
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
                    case A.Expr.Let letExpr:
                        letExpr.Scope.Parent = scope;
                        ScopeLet(letExpr);
                        break;
                    case A.Expr.Lambda lambda:
                        lambda.Scope.Parent = scope;
                        ScopeLambda(lambda);
                        break;
                    case A.Expr.Record record:
                        foreach (var field in record.Fields)
                        {
                            ScopeExpr(scope, field.Expression);
                        }
                        break;

                    case A.Expr.Select select:
                        {
                            ScopeExpr(scope, select.Lhs);
                            ScopeExpr(scope, select.Rhs);
                            break;
                        }

                    case A.Ref.Native:
                        {
                            break;
                        }

                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

            private void ScopeLet(A.Expr.Let letExr)
            {
                var hints = new Dictionary<A.Identifier, A.Decl.TypeAnnotation>();
                Assert(letExr.Scope.HintsAreEmpty);

                foreach (var expr in letExr.LetDecls)
                {
                    switch (expr)
                    {
                        case A.Decl.Var var:
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
                                        foreach (var identifier in ExplodePattern(parameter.Expression))
                                        {
                                            var.Scope.Add(identifier);
                                        }
                                    }
                                }

                                letExr.Scope.AddVar(var);

                                ScopeExpr(var.Scope, var.Expression);
                            }
                            break;
                        case A.Decl.LetAssign assign:
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
                        case A.Decl.TypeAnnotation annotation:
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

            private void ScopeLambda(A.Expr.Lambda lambda)
            {
                foreach (var parameter in lambda.Parameters.ExractMatchNames())
                {
                    lambda.Scope.Add(parameter);
                }

                ScopeExpr(lambda.Scope, lambda.Expression);
            }

            private IEnumerable<A.Decl.Parameter> ExplodePattern(A.Expr pattern)
            {
                switch (pattern)
                {
                    case A.Pattern.LowerId identifier:
                        {
                            yield return new A.Decl.Parameter(identifier.Identifier);
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

                    case A.Pattern.Signature sign:
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
                    case A.Expr.Literal:
                    case A.Expr.Unit:
                        break;

                    case A.Identifier identifier when identifier.IsSingleLower:
                        {
                            yield return new A.Decl.Parameter(identifier);
                            break;
                        }
                    case A.Expr.Sequence sequence:
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
                    case A.Expr.Tuple tuple:
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
                    case A.Expr.List list:
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
                    case A.Expr.Infix infix:
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
                    default:
                        Assert(false);
                        throw new NotImplementedException($"{pattern}");
                }

                if (pattern.Alias != null)
                {
                    yield return new A.Decl.Parameter(pattern.Alias.SingleLower());
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
                        var name = declaration is A.NamedDecl named ? named.Name.Text : "<no-name>";
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
