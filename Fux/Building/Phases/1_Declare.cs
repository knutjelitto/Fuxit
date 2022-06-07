﻿#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using Fux.Input.Ast;

namespace Fux.Building.Phases
{
    internal class Declare : Phase
    {
        public Collector Collector { get; }

        public Declare(ErrorBag errors, Collector collector, Package package)
            : base("declare", errors, package)
        {
            Collector = collector;
        }

        public override void Make()
        {
            foreach (var module in Package.Modules)
            {
                Console.Write(".");

                using (var writer = MakeWriter(module, "decl"))
                {
                    Collector.DeclareTime.Start();
                    MakeModule(writer, module);
                    Collector.DeclareTime.Stop();
                }
            }
        }

        private void MakeModule(Writer writer, Module module)
        {
            if (module.Parsed && module.Ast != null)
            {
                var ast = module.Ast;

                Assert(ast.Declarations.Count() == ast.Expressions.Count);

                ast.Header.PP(writer);

                writer.WriteLine();

                foreach (var expr in ast.Declarations)
                {
                    writer.Write($"{expr.GetType().Name} - {expr.Name}");

                    writer.Indent(() =>
                    {
                        writer.WriteLine();
                        switch (expr)
                        {
                            case ImportDecl import:
                                Import(writer, module.Scope, import);
                                break;
                            case InfixDecl infix:
                                Infix(writer, module.Scope, infix);
                                break;
                            case TypeDecl type:
                                Type(writer, module.Scope, type);
                                break;
                            case AliasDecl alias:
                                Alias(writer, module.Scope, alias);
                                break;
                            case VarDecl varDecl:
                                VarDecl(writer, module.Scope, varDecl);
                                break;
                            case TypeHint hint:
                                TypeHint(writer, module.Scope, hint);
                                break;
                            default:
                                Assert(false);
                                throw new NotImplementedException();
                                break;
                        }
                        writer.EndLine();
                        writer.WriteLine();
                    });
                }
                Assert(module.Scope.HintEmpty);
            }
        }

        private void TypeHint(Writer writer, Scope scope, TypeHint hint)
        {
            Collector.TypeHint.Add(hint);

            hint.PP(writer);

            scope.Add(hint);
        }

        private void VarDecl(Writer writer, Scope scope, VarDecl decl)
        {
            Collector.VarDecl.Add(decl);

            decl.PP(writer);

            scope.Add(decl);

            decl.Scope.Parent = scope;

            ScopeVar(decl);
        }

        private void Import(Writer writer, ModuleScope scope, ImportDecl import)
        {
            Collector.Import.Add(import);

            import.PP(writer);

            scope.Add(import);
        }

        private void Infix(Writer writer, ModuleScope scope, InfixDecl infix)
        {
            Collector.Infix.Add(infix);

            infix.PP(writer);

            scope.Add(infix);

            ScopeExpr(scope, infix.Expression);
        }

        private void Type(Writer writer, ModuleScope scope, TypeDecl type)
        {
            Collector.Type.Add(type);

            type.PP(writer);

            scope.Add(type);
        }

        private void Alias(Writer writer, ModuleScope scope, AliasDecl alias)
        {
            Collector.Alias.Add(alias);

            alias.PP(writer);

            scope.Add(alias);
        }

        private void ScopeExpr(Scope scope, Expression expression)
        {
            switch (expression)
            {
                case Identifier:
                case NumberLiteral:
                case StringLiteral:
                case CharLiteral:
                case Unit:
                    break;
                case IfExpression iff:
                    ScopeExpr(scope, iff.Condition);
                    ScopeExpr(scope, iff.IfTrue);
                    ScopeExpr(scope, iff.IfFalse);
                    break;
                case MatchExpr match:
                    ScopeExpr(scope, match.Expression);
                    foreach (var @case in match.Cases)
                    {
                        ScopeExpr(scope, @case);
                    }
                    break;
                case MatchCase matchCase:
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
                case LetExpr let:
                    let.Scope.Parent = scope;
                    ScopeLet(let);
                    break;
                case LambdaExpr lambda:
                    lambda.Scope.Parent = scope;
                    ScopeLambda(lambda);
                    break;
                case RecordExpression record:
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
            foreach (var expr in let.LetExpressions)
            {
                switch (expr)
                {
                    case LetAssign assign:
                        var scope = new LetScope
                        {
                            Parent = let.Scope
                        };
                        let.Scope = scope;
                        foreach (var identifier in ExplodePattern(assign.Pattern))
                        {
                            let.Scope.Add(identifier);
                        }
                        break;
                    case TypeHint hint:
                        //TODO: ???
                        break;
                    default:
                        Assert(false);
                        throw new NotImplementedException();
                }
            }

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

        private IEnumerable<Identifier> ExplodePattern(Expression pattern)
        {
            switch (pattern)
            {
                case Identifier identifier when identifier.IsSingle(Lex.LowerId):
                    yield return identifier;
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
                case InfixExpr infix:
                    foreach (var identifier in ExplodePattern(infix.Lhs))
                    {
                        yield return identifier;
                    }
                    foreach (var identifier in ExplodePattern(infix.Rhs))
                    {
                        yield return identifier;
                    }
                    break;
                case Identifier identifier when identifier.IsMulti(Lex.UpperId):
                case Wildcard:
                case NumberLiteral:
                case StringLiteral:
                case RecordPattern:
                case Unit:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }

            if (pattern.Alias != null)
            {
                Assert(pattern.Alias.IsSingle(Lex.LowerId));

                yield return pattern.Alias;
            }
        }

        private void ScopeVar(VarDecl decl)
        {
            foreach (var parameter in decl.Parameters)
            {
                foreach (var identifier in ExplodePattern(parameter))
                {
                    decl.Scope.Add(identifier);
                }
            }

            ScopeExpr(decl.Scope, decl.Expression);
        }

        static void ScopeParameter(LetScope scope, Expression expression)
        {
            switch (expression)
            {
                case Identifier identifier when identifier.IsSingle(Lex.LowerId):
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
                case Identifier identifier when identifier.IsMulti(Lex.UpperId):
                case Wildcard:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
