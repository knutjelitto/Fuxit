﻿#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using static Fux.Input.Ast.Type;

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
            Assert(module.Ast != null);

            Collector.ResolveTime.Start();
            foreach (var declaration in module.Ast.Declarations)
            {
                Resolve(module, declaration);
            }
            Collector.ResolveTime.Stop();
        }

        private void Resolve(Module module, Declaration declaration)
        {
            switch (declaration)
            {
                case ImportDecl:
                    return;
                case InfixDecl infix:
                    Resolve(module, infix);
                    break;
                case UnionDecl type:
                    Resolve(module, type);
                    break;
                case VarDecl var:
                    Resolve(module, var);
                    break;
                case TypeHint hint:
                    Resolve(module, hint);
                    break;
                case AliasDecl alias:
                    Resolve(module, alias);
                    break;
                default:
                    Assert(false);
                    throw new InvalidOperationException();
            }
        }

        private void Resolve(Module module, InfixDecl infix)
        {
            ResolveExpr(module.Scope, infix.Expression);
        }

        private void Resolve(Module module, VarDecl var)
        {
            ResolveExpr(var.Scope, var.Expression);
        }

        private void Resolve(Module module, UnionDecl type)
        {
            ResolveType(module.Scope, type.Type);
        }

        private void Resolve(Module module, TypeHint hint)
        {
            ResolveType(module.Scope, hint.Type);
        }

        private void Resolve(Module module, AliasDecl alias)
        {
            Assert(alias.Parameters.Count >= 0);

            ResolveType(module.Scope, alias.Declaration);
        }

        private void ResolveType(Scope scope, Type type)
        {
            switch (type)
            {
                case Type.Function function:
                    ResolveType(scope, function.InType);
                    ResolveType(scope, function.OutType);
                    break;
                case Type.Tuple tuple:
                    foreach (var item in tuple.Types)
                    {
                        ResolveType(scope, item);
                    }
                    break;
                case Type.Record record:
                    if (record.BaseRecord != null)
                    {
                        ResolveType(scope, record.BaseRecord);
                    }
                    foreach (var field in record.Fields)
                    {
                        ResolveType(scope, field.TypeDef);
                    }
                    break;
                case Type.Concrete concrete:
                    if (scope.Resolve(concrete.Name, out _))
                    {
                        Assert(true);
                    }
                    break;
                case Type.Primitive primitive:
                    break;
                case Type.UnionType unionType:
                    {
                        if (unionType.Name.Text == "Int")
                        {
                            Assert(true);
                        }
                    }
                    break;
                case Type.Union union:
                    if (union.Name.Text == "Int")
                    {
                        Assert(true);
                    }
                    if (scope.Resolve(union.Name, out _))
                    {
                        Assert(true);
                    }
                    break;
                case Type.Parameter:
                case Type.NumberClass:
                case Type.AppendableClass:
                case Type.ComparableClass:
                case Type.Unit:
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ResolveExpr(Scope scope, Expression expression)
        {
            switch (expression)
            {
                case Literal:
                case Fux.Input.Ast.Unit:
                case NativeDecl:
                case DotExpr:
                    break; //TODO: what to do here
                case Identifier identifier:
                    {
                        if (scope.Resolve(identifier, out var expr))
                        {
                            if (expr is Identifier)
                            {
                                scope.Resolve(identifier, out expr);
                            }
                            Assert(expr is not Identifier);
                            Assert(expr != null);
                            expression.Resolved = expr;
                            break;
                        }
                        Assert(false);
                        throw new NotImplementedException();
                    }
                case IfExpr iff:
                    ResolveExpr(scope, iff.Condition);
                    ResolveExpr(scope, iff.IfTrue);
                    ResolveExpr(scope, iff.IfFalse);
                    break;
                case MatchExpr match:
                    ResolveExpr(scope, match.Expression);
                    foreach (var matchCase in match.Cases)
                    {
                        ResolveExpr(scope, matchCase);
                    }
                    break;
                case MatchCase matchCase:
                    ResolveExpr(matchCase.Scope, matchCase.Expression);
                    break;
                case LetExpr let:
                    {
                        foreach (var expr in let.LetExpressions)
                        {
                            ResolveExpr(scope, expr);
                        }
                        ResolveExpr(let.Scope, let.InExpression);
                        break;
                    }
                case LetAssign letAssign:
                    ResolveExpr(letAssign.Scope, letAssign.Expression);
                    break;
                case LambdaExpr lambda:
                    ResolveExpr(lambda.Scope, lambda.Expression);
                    break;
                case VarDecl var:
                    ResolveExpr(var.Scope, var.Expression);
                    break;
                case SequenceExpr sequence:
                    foreach (var expr in sequence)
                    {
                        ResolveExpr(scope, expr);
                    }
                    break;
                case TupleExpr tuple:
                    foreach (var expr in tuple)
                    {
                        ResolveExpr(scope, expr);
                    }
                    break;
                case ListExpr list:
                    foreach (var expr in list)
                    {
                        ResolveExpr(scope, expr);
                    }
                    break;
                case RecordExpr record:
                    if (record.BaseRecord != null)
                    {
                        ResolveExpr(scope, record.BaseRecord);
                    }
                    foreach (var field in record.Fields)
                    {
                        ResolveExpr(scope, field);
                    }
                    break;
                case FieldAssign fieldAssign:
                    ResolveExpr(scope, fieldAssign.Expression);
                    break;
                case PrefixExpr prefix:
                    //TODO: prefix operator
                    //ResolveExpr(scope, prefix.Op);
                    ResolveExpr(scope, prefix.Rhs);
                    break;
                case OpChain chain:
                    ResolveInfix(scope, chain);
                    break;
                case SelectExpr select:
                    ResolveExpr(scope, select.Lhs);
                    break;
                case TypeHint typeHint:
                    ResolveType(scope, typeHint.Type);
                    break;
                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }

        private void ResolveInfix(Scope scope, OpChain chain)
        {
            Assert(chain.Rest.Count > 0);

            ResolveExpr(scope, chain.First);

            foreach (var opExpr in chain.Rest)
            {
                if (scope.Resolve(opExpr.Op.Name, out var resolved))
                {
                    if (resolved is InfixDecl op)
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
        }
    }
}