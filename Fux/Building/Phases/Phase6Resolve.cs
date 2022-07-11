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

            private bool Investigated { get; set; } = false;

            public override void Make()
            {
                if (Module.Ast == null)
                {
                    Assert(false);
                    throw new InvalidOperationException();
                }

                Investigated = false;

                foreach (var declaration in Module.Ast.Declarations)
                {
                    Resolve(declaration);
                }
            }

            private void Resolve(A.Decl declaration)
            {
                if (Investigated)
                {
                    Assert(true);
                }

                switch (declaration)
                {
                    case A.Decl.Import:
                        return;

                    case A.Decl.Infix infix:
                        {
                            ResolveExpr(Module.Scope, infix.Expression);
                            break;
                        }

                    case A.Decl.Custom type:
                        {
                            if (Investigated)
                            {
                                Assert(true);
                            }

                            ResolveType(Module.Scope, type.Type);
                            foreach (var ctor in type.Ctors)
                            {
                                Resolve(ctor);
                            }
                            break;
                        }

                    case A.Decl.Var var:
                        {
                            ResolveExpr(var.Scope, var.Expression);
                            foreach (var parameter in var.Parameters)
                            {
                                ResolveExpr(var.Scope, parameter.Expression);
                            }
                            break;
                        }

                    case A.Decl.LetAssign let:
                        {
                            ResolveExpr(let.Scope, let.Expression);
                            break;
                        }

                    case A.Decl.TypeAnnotation annotation:
                        {
                            ResolveType(Module.Scope, annotation.Type);
                            break;
                        }

                    case A.Decl.Alias alias:
                        {
                            Assert(alias.Parameters.Count >= 0);

                            ResolveType(Module.Scope, alias.Declaration);
                            //Assert(alias.Declaration.Resolved is A.Type.Custom);
                            foreach (var parameter in alias.Parameters)
                            {
                            }

                            break;
                        }

                    case A.Decl.Ctor ctor:
                        {
                            foreach (var argument in ctor.Arguments)
                            {
                                ResolveType(Module.Scope, argument);
                            }
                            break;
                        }

                    default:
                        Assert(false);
                        throw new InvalidOperationException();
                }
            }

            private void ResolveType(Scope scope, A.Type type)
            {
                if (Investigated)
                {
                    Assert(true);
                }

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
                                if (resolved is A.Decl.Custom typeDecl)
                                {
                                    Assert(typeDecl.InModule != null);

                                    if (typeDecl.InModule.IsCore)
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

                    case A.Type.Custom:
                        {
                            break;
                        }

                    case A.Type.Ctor ctor:
                        {
                            Assert(ctor.InModule != null);

                            if (scope.Resolve(ctor.Name, out var resolved))
                            {
                                Assert(resolved.InModule != null);

                                if (resolved is A.Decl.Custom custom)
                                {
                                    ctor.Resolved = custom.Type;

                                    if (resolved.InModule.IsCore)
                                    {
                                        foreach (var argument in ctor.Arguments)
                                        {
                                            ResolveType(scope, argument);
                                        }

                                        if (ctor.Arguments.Count == 0)
                                        {
                                            Assert(ctor.Arguments.Count == 0);
                                            //Assert(union.Name.Text == decl.Name.Text);

                                            switch (ctor.Name.Text)
                                            {
                                                case Lex.Primitive.Int:
                                                    ctor.Resolved = new A.Type.Primitive.Int(ctor.Name);
                                                    break;
                                                case Lex.Primitive.Float:
                                                    ctor.Resolved = new A.Type.Primitive.Float(ctor.Name);
                                                    break;
                                                case Lex.Primitive.Bool:
                                                    ctor.Resolved = new A.Type.Primitive.Bool(ctor.Name);
                                                    break;
                                                case Lex.Primitive.String:
                                                    ctor.Resolved = new A.Type.Primitive.String(ctor.Name);
                                                    break;
                                                case Lex.Primitive.Char:
                                                    ctor.Resolved = new A.Type.Primitive.Char(ctor.Name);
                                                    break;
                                            }
                                        }
                                        else if (ctor.Arguments.Count == 1)
                                        {
                                            switch (ctor.Name.Text)
                                            {
                                                case Lex.Primitive.List:
                                                    ctor.Resolved = new A.Type.Primitive.List(ctor.Name, ctor.Arguments[0]);
                                                    break;
                                            }
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
                            if (identifier.Text == "Node")
                            {
                                Assert(true);
                            }
                            if (scope.Resolve(identifier, out var resolved))
                            {
                                if (resolved is A.Decl.Var var)
                                {
                                    expression.Resolved = new A.Ref.Var(var).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Parameter parameter)
                                {
                                    expression.Resolved = new A.Ref.Parameter(parameter).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Native native)
                                {
                                    expression.Resolved = new A.Ref.Native(native).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Infix infix)
                                {
                                    expression.Resolved = new A.Ref.Infix(infix).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Ctor ctor)
                                {
                                    expression.Resolved = new A.Ref.Ctor(ctor).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Custom type)
                                {
                                    expression.Resolved = new A.Ref.Type(type).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Alias alias)
                                {
                                    expression.Resolved = new A.Ref.Alias(alias).Locate(identifier);
                                    break;
                                }
                                else
                                {
                                    Assert(false);
                                    throw new NotImplementedException();
                                }
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
                    case A.Expr.Matcher match:
                        ResolveExpr(scope, match.Expression);
                        foreach (var matchCase in match.Cases)
                        {
                            ResolveExpr(scope, matchCase);
                        }
                        break;
                    case A.Expr.Case matchCase:
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
                        {
                            foreach (var expr in sequence)
                            {
                                ResolveExpr(scope, expr);
                            }
                            break;
                        }
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

                    case A.Pattern.DeCons destruct:
{
                            ResolveExpr(scope, destruct.First);
                            ResolveExpr(scope, destruct.Rest);
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

                    case A.Pattern.DeCtor ctor:
                        {
                            ResolveExpr(scope, ctor.Name);
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

                    case A.Pattern.LowerId lower:
                        {
                            ResolveExpr(scope, lower.Identifier);
                            break;
                        }

                    case A.Pattern.UpperId upper:
                        {
                            ResolveExpr(scope, upper.Identifier);
                            break;
                        }

                    case A.Pattern.Wildcard:
                    case A.Pattern.Unit:
                    case A.Pattern.Literal:
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
                        if (resolved is A.Decl.Infix infixDecl)
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
