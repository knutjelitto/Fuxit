#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace Fux.Building.Phases
{
    internal class Phase5Type : Phase
    {
        public Phase5Type(ErrorBag errors, Package package)
            : base("type", errors, package)
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
            Collector.TypeTime.Start();
            Type(module);
            Collector.TypeTime.Stop();
        }

        private void Type(Module module)
        {
            Assert(module.Parsed && module.Ast != null);

            Collector.TypeTime.Start();
            foreach (var declaration in module.Ast.Declarations.OfType<VarDecl>())
            {
                Type(module, declaration);
            }
            Collector.TypeTime.Stop();
        }

        private void Type(Module module, VarDecl var)
        {
            Resolve(module, var);
        }

        private void Resolve(Module module, VarDecl var)
        {
            ResolveExpr(var.Scope, var.Expression);

            if (var.Expression.Resolved is NativeDecl native)
            {
                native.TypeHint = var.Name.TypeHint;
            }
        }

        private void ResolveExpr(Scope scope, Expression expression)
        {
            switch (expression)
            {
                case NumberLiteral:
                case StringLiteral:
                case CharLiteral:
                case Unit:
                case TypeHint:
                case DotExpr:
                    break; //TODO: what to do here
                case Identifier identifier:
                    {
                        Assert(identifier.Resolved != null);
                        if (identifier.Type == null)
                        {
                            identifier.Type = identifier.Resolved.Type;

                            if (identifier.Type == null)
                            {

                            }
                        }
                        break;
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
