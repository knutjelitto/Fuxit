﻿#pragma warning disable CA1822 // Mark members as static

using Fux.Building;

namespace Fux.Input
{
    public sealed class ExprParser
    {
        public ExprParser(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }
        public Module Module => Parser.Module;
        public ISource Source => Parser.Source;
        public ErrorBag Errors => Parser.Errors;

        public PatternParser Patt => Parser.Patt;
        public DeclParser Decl => Parser.Decl;

        public A.Expr Expression(Cursor cursor)
        {
            return InfixExpr(cursor);
        }

        private A.Expr InfixExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var expr = Sequence(cursor, false);

                if (cursor.StartsInfix)
                {
                    var opExprs = new List<A.OpExpr>();

                    while (cursor.Is(Lex.Operator))
                    {
                        var op = new A.OperatorSymbol(cursor.Swallow(Lex.Operator));

                        opExprs.Add(new A.OpExpr(op, Sequence(cursor, false)));
                    }

                    return new A.OpChain(expr, opExprs);
                }

                return expr;
            });
        }

        private A.Expr Sequence(Cursor cursor, bool always)
        {
            return cursor.Scope(cursor =>
            {
                var expressions = new List<A.Expr>();

                do
                {
                    var expression = PrefixExpr(cursor);

                    expressions.Add(expression);
                }
                while (cursor.StartsAtomic || cursor.StartsPrefix);

                Assert(expressions.Count >= 1);

                if (!always && expressions.Count == 1)
                {
                    return expressions[0];
                }

                return new A.Expr.Application(expressions);
            });
        }

        private A.Expr PrefixExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                A.Expr app;

                if (cursor.StartsPrefix)
                {
                    var op = new A.OperatorSymbol(cursor.Advance());
                    var argument = Compound(cursor);

                    switch (op.Text)
                    {
                        case "-":
                            app = new A.Expr.Application(Fake.NativeNegate(Module, Source), argument);
                            break;
                        default:
                            Assert(false);
                            app = new A.Expr.Prefix(op, argument);
                            break;
                    }
                }
                else
                {
                    app = Compound(cursor);
                }

                return app;
            });
        }

        private A.Expr Compound(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.KwIf))
                {
                    return IfExpr(cursor);
                }
                else if (cursor.Is(Lex.KwLet))
                {
                    return LetExpr(cursor);
                }
                else if (cursor.Is(Lex.KwCase))
                {
                    return CaseExpr(cursor);
                }
                else
                {
                    Assert(cursor.StartsAtomic);

                    var atom = Atom(cursor);

                    if (cursor.SwallowIf(Lex.KwAs))
                    {
                        Assert(false);
                    }

                    return atom;
                }
            });
        }

        private A.Expr IfExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwIf);
                var condition = Expression(cursor);
                cursor.Swallow(Lex.KwThen);
                var whenTrue = Expression(cursor);
                cursor.Swallow(Lex.KwElse);
                var whenFalse = Expression(cursor);

                return new A.Expr.If(condition, whenTrue, whenFalse);
            });
        }

        private A.Expr LetExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var kwLet = cursor.Swallow(Lex.KwLet);

                var lets = new List<A.Decl>();
                while (cursor.IsNot(Lex.KwIn))
                {
                    var decl = Decl.VarDeclOrTypeAnnotationInLet(cursor.Subcursor());

                    lets.Add(decl);
                }

                var kwIn = cursor.Swallow(Lex.KwIn);
                var expression = Expression(cursor);

                return new A.Expr.Let(lets, expression);
            });
        }

        private A.Expr CaseExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Line == 578)
                {
                    Assert(true);
                }
                cursor.Swallow(Lex.KwCase);
                var expression = Expression(cursor);
                cursor.Swallow(Lex.KwOf);

                var cases = new List<A.Expr.Case>();

                while (cursor.StartsAtomic)
                {
                    var subCursor = cursor.Subcursor();

                    var @case = Case(subCursor);

                    cases.Add(@case);
                }

                return new A.Expr.Matcher(expression, cases);
            });
        }

        private A.Expr Atom(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.StartsAtomic);

                var atom = ParseAtom(cursor);

                while (cursor.Is(Lex.Dot) && !cursor.WhitesBefore())
                {
                    atom = SelectExpr(cursor, atom);
                }

                return atom;

                A.Expr.Select SelectExpr(Cursor cursor, A.Expr atom)
                {
                    return cursor.Scope(cursor =>
                    {
                        cursor.Swallow(Lex.Dot);

                        return new A.Expr.Select(atom, ParseAtom(cursor));
                    });
                }

                A.Expr ParseAtom(Cursor cursor)
                {
                    if (cursor.Is(Lex.LowerId))
                    {
                        return Parser.SingleIdentifier(cursor);
                    }
                    else if (cursor.Is(Lex.OperatorId))
                    {
                        return Parser.SingleIdentifier(cursor);
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        return Parser.Identifier(cursor);
                    }
                    else if (cursor.Is(Lex.Integer))
                    {
                        return IntegerLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Float))
                    {
                        return FloatLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Char))
                    {
                        return CharLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.String))
                    {
                        return StringLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LongString))
                    {
                        return LongStringLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LeftRoundBracket))
                    {
                        return TupleLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LeftCurlyBracket))
                    {
                        return RecordLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LeftSquareBracket))
                    {
                        return ListLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Lambda))
                    {
                        return LambdaLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Dot))
                    {
                        return DotSelector(cursor);
                    }

                    throw Errors.Parser.NotImplemented(cursor.At());
                }
            });
        }


        private A.Expr TupleLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LeftRoundBracket);

                var expressions = new List<A.Expr>();

                while (cursor.IsNot(Lex.RightRoundBracket))
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.Is(Lex.Comma))
                    {
                        cursor.Advance();

                        continue;
                    }
                }

                cursor.Swallow(Lex.RightRoundBracket);

                if (expressions.Count == 0)
                {
                    return new A.Expr.Unit();
                }
                else if (expressions.Count == 1)
                {
                    return expressions[0];
                }
                else
                {
                    return new A.Expr.Tuple(expressions);
                }
            });
        }

        private A.Expr RecordLiteral(Cursor cursor)
        {
            return cursor.Scope<A.Expr>(cursor =>
            {
                var left = cursor.Swallow(Lex.LeftCurlyBracket);

                if (cursor.Is(Lex.RCurlyBracket))
                {
                    cursor.Swallow(Lex.RCurlyBracket);

                    return new A.Expr.Record(null, Enumerable.Empty<A.Expr.Field>());
                }

                var fields = new List<A.Expr.Field>();
                var state = cursor.State;
                A.Identifier? baseName = Parser.SingleIdentifier(cursor).SingleLower();

                if (cursor.IsNot(Lex.Bar))
                {
                    baseName = null;
                    cursor.Reset(state);
                }
                else
                {
                    var bar = cursor.Swallow(Lex.Bar);
                }

                do
                {
                    fields.Add(Field(cursor));
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RCurlyBracket);

                return new A.Expr.Record(baseName, fields.Cast<A.Expr.Field>());

                A.Expr.Field Field(Cursor cursor)
                {
                    var name = Parser.SingleIdentifier(cursor).SingleLower();

                    if (cursor.Is(Lex.Assign))
                    {
                        var assign = cursor.Swallow(Lex.Assign);
                        var value = Expression(cursor);

                        return new A.Expr.Field(name, value);
                    }
                    else
                    {
                        return new A.Expr.Field(name, null);
                    }
                }
            });
        }

        private A.Expr.List ListLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LeftSquareBracket);

                var expressions = new List<A.Expr>();

                while (cursor.At().Lex != Lex.RightSquareBracket)
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.IsNot(Lex.RightSquareBracket))
                    {
                        cursor.Swallow(Lex.Comma);
                    }
                }

                cursor.Swallow(Lex.RightSquareBracket);

                return new A.Expr.List(expressions);
            });
        }

        private A.Expr DotSelector(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Dot);
                var expr = Parser.SingleIdentifier(cursor);

                return new A.Expr.Dot(expr);
            });
        }

        public A.Expr.Literal.Char CharLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Char);

                return new A.Expr.Literal.Char(token);
            });
        }

        public A.Expr.Literal.String StringLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.String);

                return new A.Expr.Literal.String(token);
            });
        }

        public A.Expr.Literal.LongString LongStringLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.LongString);

                return new A.Expr.Literal.LongString(token);
            });
        }

        public A.Expr.Literal.Integer IntegerLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Integer);

                return new A.Expr.Literal.Integer(token);
            });
        }

        public A.Expr.Literal.Float FloatLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Float);

                return new A.Expr.Literal.Float(token);
            });
        }

        public A.Expr.Case Case(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var pattern = Patt.Pattern(cursor);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new A.Expr.Case(pattern, expr);
            });
        }

        public A.Expr.Lambda LambdaLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Lambda);

                var parameters = Patt.LambdaParameters(cursor);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new A.Expr.Lambda(parameters, expr);
            });
        }
    }
}
