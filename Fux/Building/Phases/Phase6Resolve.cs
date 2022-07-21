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

                    case A.Decl.Custom custom:
                        {
                            if (custom.Name.Text == "Array")
                            {
                                Assert(true);
                            }
                            if (Investigated)
                            {
                                Assert(true);
                            }

                            foreach (var ctor in custom.Ctors)
                            {
                                Resolve(ctor);
                            }
                            break;
                        }

                    case A.Decl.Var var:
                        {
                            ResolveExpr(var.Scope, var.Expression);
                            if (var.Type != null)
                            {
                                var.Type = ResolveType(var.Scope, var.Type);
                            }
                            foreach (var parameter in var.Parameters)
                            {
                                ResolvePattern(var.Scope, parameter.Pattern);
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

            private A.Type ResolveType(Scope scope, A.Type type)
            {
                if (Investigated)
                {
                    Assert(true);
                }

                switch (type)
                {
                    case A.Type.Function functionType:
                        {
                            functionType.InType = ResolveType(scope, functionType.InType);
                            functionType.OutType = ResolveType(scope, functionType.OutType);

                            return functionType;
                        }

                    case A.Type.Tuple tupleType:
                        {
                            for (var i = 0; i < tupleType.Types.Count; i++)
                            {
                                tupleType.Types[i] = ResolveType(scope, tupleType.Types[i]);
                            }
                            
                            return tupleType;
                        }

                    case A.Type.Record recordType:
                        {
                            if (recordType.BaseRecord != null)
                            {
                                recordType.BaseRecord = ResolveType(scope, recordType.BaseRecord);
                            }
                            foreach (var field in recordType.Fields)
                            {
                                field.Type = ResolveType(scope, field.Type);
                            }

                            return recordType;
                        }

                    case A.Type.Primitive primitiveType:
                        {
                            return primitiveType;
                        }

                    case A.Type.Custom customType:
                        {
                            Assert(customType.InModule != null);

                            if (!scope.Resolve(customType.Name, out var resolved))
                            {
                                Assert(false); // not found
                                throw new InvalidOperationException();
                            }

                            Assert(resolved.InModule != null);
                            Assert(resolved is A.Decl.Custom || resolved is A.Decl.Alias);

                            switch (resolved)
                            {
                                case A.Decl.Custom custom:
                                    {
                                        for (var i = 0; i < customType.Arguments.Count; i++)
                                        {
                                            customType.Arguments[i] = ResolveType(scope, customType.Arguments[i]);
                                        }

                                        if (resolved.InModule.IsCore)
                                        {
                                            if (customType.Arguments.Count == 0)
                                            {
                                                switch (customType.Name.Text)
                                                {
                                                    case Lex.Primitive.Int:
                                                        return new A.Type.Integer(customType.Name).With(resolved);
                                                    case Lex.Primitive.Float:
                                                        return new A.Type.Float(customType.Name).With(resolved);
                                                    case Lex.Primitive.Bool:
                                                        return new A.Type.Bool(customType.Name).With(resolved);
                                                    case Lex.Primitive.String:
                                                        return new A.Type.String(customType.Name).With(resolved);
                                                    case Lex.Primitive.Char:
                                                        return new A.Type.Char(customType.Name).With(resolved);
                                                }
                                            }
                                            else if (customType.Arguments.Count == 1)
                                            {
                                                switch (customType.Name.Text)
                                                {
                                                    case Lex.Primitive.List:
                                                        return new A.Type.List(customType.Name, customType.Arguments[0])
                                                            .With(resolved);
                                                }
                                            }
                                        }

                                        //customType.Resolver = () => custom.Type;

                                        return customType.With(resolved);
                                    }

                                case A.Decl.Alias aliasType:
                                    {
                                        Assert(true);
                                        customType.Resolver = () => aliasType.Declaration.Resolved;

                                        for (var i = 0; i < customType.Arguments.Count; i++)
                                        {
                                            var argument = customType.Arguments[i];

                                            if (argument is A.Type.Parameter)
                                            {
                                                Assert(true);
                                            }

                                            customType.Arguments[i] = ResolveType(scope, customType.Arguments[i]);
                                        }

                                        var result = new A.Type.Alias(aliasType.Name, aliasType.Parameters, aliasType).With(resolved);

                                        return result;
                                    }

                                default:
                                    {
                                        Assert(false); // not found
                                        throw new NotImplementedException();
                                    }
                            }
                        }

                    case A.Type.Parameter:
                    case A.Type.NumberClass:
                    case A.Type.AppendableClass:
                    case A.Type.ComparableClass:
                    case A.Type.Unit:
                        {
                            return type;
                        }
                }
                
                Assert(false);
                throw new NotImplementedException();
            }

            private void ResolvePattern(Scope scope, A.Pattern expression)
            {
                switch (expression)
                {
                    case A.Pattern.List list:
                        {
                            foreach (var pattern in list.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.DeCons destruct:
{
                            ResolvePattern(scope, destruct.First);
                            ResolvePattern(scope, destruct.Rest);
                            break;
                        }
                    case A.Pattern.Tuple tuple:
                        {
                            foreach (var pattern in tuple.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }
                    case A.Pattern.Record record:
                        {
                            foreach (var pattern in record.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Signature sign:
                        {
                            foreach (var pattern in sign.Parameters)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Lambda lambda:
                        {
                            foreach (var pattern in lambda.Parameters)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.DeCtor ctor:
                        {
                            ResolveExpr(scope, ctor.Name);
                            foreach (var pattern in ctor.Arguments)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.WithAlias with:
                        {
                            ResolvePattern(scope, with.Pattern);
                            ResolvePattern(scope, with.Alias);
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

                    default:
                        Assert(false);
                        throw new NotImplementedException($"{expression}");
                }
            }

            private void ResolveExpr(Scope scope, A.Expr expression)
            {
                switch (expression)
                {
                    case A.Expr.Literal:
                    case A.Expr.Unit:
                    case A.Wildcard:
                    case A.Expr.Dot:
                        {
                            break; //TODO: what to do at DOT
                        }

                    case A.Identifier identifier:
                        {
                            if (scope.Resolve(identifier, out var resolved))
                            {
                                if (resolved is A.Decl.Var var)
                                {
                                    expression.Resolved = new A.Expr.Ref.Var(var).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Parameter parameter)
                                {
                                    expression.Resolved = new A.Expr.Ref.Parameter(parameter).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Native native)
                                {
                                    expression.Resolved = new A.Expr.Ref.Native(native).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Infix infix)
                                {
                                    expression.Resolved = new A.Expr.Ref.Infix(infix).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Ctor ctor)
                                {
                                    expression.Resolved = new A.Expr.Ref.Ctor(ctor).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Custom type)
                                {
                                    expression.Resolved = new A.Expr.Ref.Type(type).Locate(identifier);
                                    break;
                                }
                                else if (resolved is A.Decl.Alias alias)
                                {
                                    expression.Resolved = new A.Expr.Ref.Alias(alias).Locate(identifier);
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
                        {
                            ResolveExpr(scope, iff.Condition);
                            ResolveExpr(scope, iff.IfTrue);
                            ResolveExpr(scope, iff.IfFalse);
                            break;
                        }
                    case A.Expr.Matcher match:
                        {
                            ResolveExpr(scope, match.Expression);
                            foreach (var matchCase in match.Cases)
                            {
                                ResolveExpr(scope, matchCase);
                            }
                            break;
                        }

                    case A.Expr.Case matchCase:
                        {
                            ResolvePattern(matchCase.Scope, matchCase.Pattern);
                            ResolveExpr(matchCase.Scope, matchCase.Expression);
                            break;
                        }

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
                        {
                            ResolvePattern(lambda.Scope, lambda.Parameters);
                            ResolveExpr(lambda.Scope, lambda.Expression);
                            break;
                        }

                    case A.Expr.Application sequence:
                        {
                            foreach (var expr in sequence)
                            {
                                ResolveExpr(scope, expr);
                            }
                            break;
                        }

                    case A.Expr.Tuple tuple:
                        {
                            foreach (var expr in tuple)
                            {
                                ResolveExpr(scope, expr);
                            }
                            break;
                        }

                    case A.Expr.List list:
                        {
                            foreach (var expr in list)
                            {
                                ResolveExpr(scope, expr);
                            }
                            break;
                        }

                    case A.Expr.Record record:
                        {
                            if (record.BaseRecord != null)
                            {
                                ResolveExpr(scope, record.BaseRecord);
                            }
                            foreach (var field in record.Fields)
                            {
                                ResolveExpr(scope, field);
                            }
                            break;
                        }

                    case A.FieldAssign fieldAssign:
                        {
                            ResolveExpr(scope, fieldAssign.Expression);
                            break;
                        }

                    case A.Expr.Prefix prefix:
                        {
                            //TODO: prefix operator
                            //ResolveExpr(scope, prefix.Op);
                            ResolveExpr(scope, prefix.Rhs);
                            break;
                        }

                    case A.OpChain chain:
                        {
                            Assert(chain.Resolved is A.OpChain);
                            ResolveInfix(scope, chain);
                            break;
                        }
                    
                    case A.Expr.Select select:
                        {
                            ResolveExpr(scope, select.Lhs);
                            break;
                        }

                    case A.RecordPattern recordPattern:
                        {
                            foreach (var field in recordPattern.Fields)
                            {
                                ResolveExpr(scope, field);
                            }
                            break;
                        }

                    case A.Expr.Ctor ctor:
                        {
                            ResolveExpr(scope, ctor.Name);
                            foreach (var expr in ctor.Arguments)
                            {
                                ResolveExpr(scope, expr);
                            }
                            break;
                        }

                    case A.FieldPattern fieldPattern:
                        {
                            ResolveExpr(scope, fieldPattern.Name);
                            break;
                        }

                    case A.Parameters parameters:
                        {
                            foreach (var parameter in parameters)
                            {
                                ResolvePattern(scope, parameter.Pattern);
                            }
                            break;
                        }

                    case A.Pattern.List list:
                        {
                            foreach (var pattern in list.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.DeCons destruct:
                        {
                            ResolvePattern(scope, destruct.First);
                            ResolvePattern(scope, destruct.Rest);
                            break;
                        }
                    case A.Pattern.Tuple tuple:
                        {
                            foreach (var pattern in tuple.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }
                    case A.Pattern.Record record:
                        {
                            foreach (var pattern in record.Patterns)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Signature sign:
                        {
                            foreach (var pattern in sign.Parameters)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.Lambda lambda:
                        {
                            foreach (var pattern in lambda.Parameters)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.DeCtor ctor:
                        {
                            ResolveExpr(scope, ctor.Name);
                            foreach (var pattern in ctor.Arguments)
                            {
                                ResolvePattern(scope, pattern);
                            }
                            break;
                        }

                    case A.Pattern.WithAlias with:
                        {
                            ResolvePattern(scope, with.Pattern);
                            ResolvePattern(scope, with.Alias);
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

                    case A.Expr.Ref.Native:
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
