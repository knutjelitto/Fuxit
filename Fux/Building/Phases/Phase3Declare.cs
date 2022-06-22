#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0063 // Use simple 'using' statement

using Fux.Input;
using Fux.Tools;

namespace Fux.Building.Phases
{
    internal class Phase3Declare : Phase
    {
        private List<Declaration> collector = new();

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
                    if (!module.Scope.LookupType(Identifier.Artificial(module, "List"), out _))
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

            void Declare(Declaration declaration)
            {
                switch (declaration)
                {
                    case ImportDecl import:
                        Import(module.Scope, import);
                        break;
                    case InfixDecl infix:
                        Infix(module.Scope, infix);
                        break;
                    case UnionDecl type:
                        Type(module.Scope, type);
                        break;
                    case AliasDecl alias:
                        Alias(module.Scope, alias);
                        break;
                    case VarDecl varDecl:
                        VarDecl(module.Scope, varDecl);
                        break;
                    case TypeHint hint:
                        TypeHint(module.Scope, hint);
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                        break;
                }
            }
        }

        private void TypeHint(Scope scope, TypeHint hint)
        {
            Collector.DeclareHint.Add(hint);

            collector.Add(hint);

            scope.AddHint(hint);
        }

        private void VarDecl(Scope scope, VarDecl var)
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

        private void Import(ModuleScope scope, ImportDecl import)
        {
            Collector.Import.Add(import);

            collector.Add(import);

            scope.ImportAddImport(import);
        }

        private void Infix(ModuleScope scope, InfixDecl infix)
        {
            Collector.DeclareInfix.Add(infix);

            collector.Add(infix);

            scope.AddInfix(infix);

            ScopeExpr(scope, infix.Expression);
        }

        private void Type(ModuleScope scope, UnionDecl type)
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

        private void Alias(ModuleScope scope, AliasDecl alias)
        {
            Collector.DeclareAlias.Add(alias);

            collector.Add(alias);

            scope.AddAlias(alias);
        }

        private void ScopeExpr(Scope scope, Expression expression)
        {
            switch (expression)
            {
                case Identifier:
                case Literal:
                case Unit:
                case NativeDecl:
                    break;
                case DotExpr: //TODO: what to do here?
                    break;
                case IfExpr iff:
                    ScopeExpr(scope, iff.Condition);
                    ScopeExpr(scope, iff.IfTrue);
                    ScopeExpr(scope, iff.IfFalse);
                    break;
                case MatchExpr match:
                    ScopeExpr(scope, match.Expression);
                    foreach (var matchCase in match.Cases)
                    {
                        ScopeExpr(scope, matchCase);
                        Assert(matchCase.Scope.Parent != null);
                    }
                    break;
                case MatchCase matchCase:
                    Assert(matchCase.Scope.Parent == null);
                    matchCase.Scope.Parent = scope;
                    foreach (var identifier in ExplodePattern(matchCase.Pattern))
                    {
                        matchCase.Scope.Add(identifier);
                    }
                    ScopeExpr(matchCase.Scope, matchCase.Expression);
                    break;
                case SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case ListExpr list:
                    foreach (var expr in list)
                    {
                        ScopeExpr(scope, expr);
                    }
                    break;
                case PrefixExpr prefix:
                    ScopeExpr(scope, prefix.Rhs);
                    break;
                case InfixExpr infix:
                    ScopeExpr(scope, infix.Lhs);
                    ScopeExpr(scope, infix.Rhs);
                    break;
                case OpChain opChain:
                    ScopeExpr(scope, opChain.First);
                    foreach (var rest in opChain.Rest)
                    {
                        ScopeExpr(scope, rest.Expression);
                    }
                    break;
                case LetExpr let:
                    let.Scope.Parent = scope;
                    ScopeLet(let);
                    break;
                case LambdaExpr lambda:
                    lambda.Scope.Parent = scope;
                    ScopeLambda(lambda);
                    break;
                case RecordExpr record:
                    foreach (var field in record.Fields)
                    {
                        ScopeExpr(scope, field.Expression);
                    }
                    break;
                case SelectExpr select:
                    ScopeExpr(scope, select.Lhs);
                    ScopeExpr(scope, select.Rhs);
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ScopeLet(LetExpr let)
        {
            var hints = new Dictionary<Identifier, TypeHint>();
            Assert(let.Scope.HintsAreEmpty);

            foreach (var expr in let.LetExpressions)
            {
                switch (expr)
                {
                    case VarDecl var:
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
                    case LetAssign assign:
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
                    case TypeHint hint:
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

        private void ScopeLambda(LambdaExpr lambda)
        {
            foreach (var identifier in ExplodePattern(lambda.Parameters))
            {
                lambda.Scope.Add(identifier);
            }

            ScopeExpr(lambda.Scope, lambda.Expression);
        }

        private IEnumerable<Parameter> ExplodePattern(Expression pattern)
        {
            switch (pattern)
            {
                case Identifier identifier when identifier.IsMultiUpper:
                case Wildcard:
                case Literal:
                case Unit:
                    break;

                case Identifier identifier when identifier.IsSingleLower:
                    yield return new Parameter(identifier);
                    break;
                case SequenceExpr sequence:
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
                case TupleExpr tuple:
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
                case ListExpr list:
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
                case OpChain opChain:
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
                case InfixExpr infix:
                    foreach (var parameter in ExplodePattern(infix.Lhs))
                    {
                        yield return parameter;
                    }
                    foreach (var parameter in ExplodePattern(infix.Rhs))
                    {
                        yield return parameter;
                    }
                    break;
                case RecordPattern recordPattern:
                    foreach (var field in recordPattern.Fields)
                    {
                        foreach (var parameter in ExplodePattern(field.Pattern))
                        {
                            yield return parameter;
                        }
                    }
                    break;
                case Parameter parameterer:
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
                yield return new Parameter(pattern.Alias.SingleLower());
            }
        }

#if false
        static void ScopeParameter(LetScope scope, Expression expression)
        {
            switch (expression)
            {
                case Identifier identifier when identifier.IsSingleLower:
                    scope.Add(identifier);
                    break;
                case SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        ScopeParameter(scope, expr);
                    }
                    break;
                case TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        ScopeParameter(scope, expr);
                    }
                    break;
                case Identifier identifier when identifier.IsMultiUpper:
                case Wildcard:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
#endif
    }
}
