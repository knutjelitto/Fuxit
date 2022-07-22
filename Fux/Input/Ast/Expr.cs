using System.Globalization;

using Fux.Building;

#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Input.Ast
{
    public interface Expr : Node
    {
        Expr Resolved { get; set; }

        public abstract class ExprImpl : NodeImpl, Expr
        {
            protected const int WhatIsLong = 60;

            public ExprImpl()
            {
                Alias = null;
                Resolved = this;
            }

            public Identifier? Alias { get; set; }

            public Expr Resolved { get; set; }
        }

        public sealed class Arrow : ExprImpl
        {
            public Arrow(Expr lhs, Expr rhs)
            {
                Lhs = lhs;
                Rhs = rhs;
            }

            public Expr Lhs { get; }
            public Expr Rhs { get; }

            public override string ToString()
            {
                return $"{Lhs} {Lex.Arrow} {Rhs}";
            }

            public override void PP(Writer writer)
            {
                Lhs.PP(writer);
                writer.Write($" {Lex.Arrow} ");
                Rhs.PP(writer);
            }
        }

        public sealed class Dot : ExprImpl
        {
            public Dot(Expr rhs)
            {
                Rhs = rhs;
            }

            public Expr Rhs { get; }

            public override string ToString()
            {
                return $"{Lex.Dot}{Rhs}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.Dot}{Rhs}");
            }
        }

        public sealed class If : ExprImpl
        {
            public If(Expr condition, Expr ifTrue, Expr ifFalse)
            {
                Condition = condition;
                IfTrue = ifTrue;
                IfFalse = ifFalse;
            }

            public Expr Condition { get; set; }
            public Expr IfTrue { get; set; }
            public Expr IfFalse { get; set; }

            public override string ToString()
            {
                return $"{Lex.KwIf} {Condition} {Lex.KwThen} {IfTrue} {Lex.KwElse} {IfFalse}";
            }

            public override void PP(Writer writer)
            {
                var line = ToString();

                if (ToString().Length > WhatIsLong)
                {
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                        writer.Indent(Write);
                    }
                    else
                    {
                        Write();
                    }
                }
                else
                {
                    writer.Write(line);
                }

                void Write()
                {
                    writer.WriteLine($"{Lex.KwIf}");
                    writer.Indent(() =>
                    {
                        Condition.PP(writer);
                    });
                    writer.EndLine();
                    writer.WriteLine($"{Lex.KwThen}");
                    writer.Indent(() =>
                    {
                        IfTrue.PP(writer);
                    });
                    writer.EndLine();
                    writer.WriteLine($"{Lex.KwElse}");
                    writer.Indent(() =>
                    {
                        IfFalse.PP(writer);
                    });
                    writer.EndLine();
                }
            }
        }

        public sealed class Infix : ExprImpl
        {
            public Infix(OperatorSymbol op, Expr lhs, Expr rhs)
            {
                Op = op;
                Lhs = lhs;
                Rhs = rhs;
            }

            public OperatorSymbol Op { get; }
            public Expr Lhs { get; }
            public Expr Rhs { get; }

            public override string ToString()
            {
                return Protected($"{Lhs} {Op.Text} {Rhs}");
            }

            public override void PP(Writer writer)
            {
                Lhs.PP(writer);
                writer.Write($" {Op.Text} ");
                Rhs.PP(writer);
            }
        }
        public sealed class Lambda : ExprImpl
        {
            public Lambda(Pattern.Lambda parameters, Expr expr)
            {
                Parameters = parameters;
                Expression = expr;
            }

            public Pattern.Lambda Parameters { get; set; }
            public Expr Expression { get; set; }

            public LetScope Scope { get; } = new();

            public override string ToString()
            {
                return Protected($"{Lex.Lambda}{Parameters} {Lex.Arrow} {Expression}");
            }

            public override void PP(Writer writer)
            {
                writer.Write(ToString());
            }
        }

        public sealed class Case : ExprImpl
        {
            public Case(Pattern pattern, Expr expression)
            {
                Pattern = pattern;
                Expression = expression;

                Collector.Instance.MatchPattern.Add(Pattern);
            }

            public Pattern Pattern { get; set; }
            public Expr Expression { get; set; }

            public LetScope Scope { get; } = new();

            public override string ToString()
            {
                return $"{Pattern} {Lex.Arrow} {Expression}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Pattern} {Lex.Arrow} ");
                Expression.PP(writer);
                writer.EndLine();
            }
        }

        public sealed class Let : ExprImpl
        {
            public Let(List<Decl> letExpressions, Expr inExpression)
            {
                LetDecls = letExpressions;
                InExpression = inExpression;
            }

            public List<Decl> LetDecls { get; }
            public Expr InExpression { get; set; }

            public LetScope Scope { get; set; } = new();

            public override string ToString()
            {
                string joined = string.Join(" ", LetDecls.Select(x => $"{Lex.GroupOpen} {x} {Lex.GroupClose}"));

                return $"let {joined} in {InExpression}";
            }

            public override void PP(Writer writer)
            {
                if (writer.LinePending)
                {
                    writer.WriteLine();
                    writer.Indent(Write);
                }
                else
                {
                    Write();
                }

                void Write()
                {
                    writer.WriteLine(Lex.KwLet);
                    writer.Indent(() =>
                    {
                        foreach (var expr in LetDecls)
                        {
                            expr.PP(writer);
                            if (writer.LinePending)
                            {
                                writer.WriteLine();
                            }
                        }
                    });
                    writer.WriteLine(Lex.KwIn);
                    writer.Indent(() =>
                    {
                        InExpression.PP(writer);
                    });
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                    }
                }
            }
        }

        public sealed class List : ListOf<Expr>
        {
            public List(IReadOnlyList<Expr> expressions)
                : base(expressions)
            {
            }

            public override string ToString()
            {
                var joined = string.Join(", ", this);
                return $"{Lex.LeftSquareBracket}{joined}{Lex.RightSquareBracket}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LeftSquareBracket}");
                var more = false;
                foreach (var expression in this)
                {
                    if (more)
                    {
                        writer.Write($"{Lex.Comma} ");
                    }
                    more = true;
                    expression.PP(writer);
                }
                writer.Write($"{Lex.RightSquareBracket}");
            }
        }

        public sealed class Matcher : ExprImpl
        {
            public Matcher(Expr expression, List<Case> cases)
            {
                Expression = expression;
                Cases = cases;
            }

            public Expr Expression { get; set; }
            public List<Case> Cases { get; }

            public override string ToString()
            {
                var cases = string.Join(" ", Cases.Select(@case => $"{Lex.GroupOpen} {@case} {Lex.GroupClose}"));
                return $"case {Expression} of {cases}";
            }

            public override void PP(Writer writer)
            {
                if (writer.LinePending)
                {
                    writer.WriteLine();
                    writer.Indent(Write);
                }
                else
                {
                    Write();
                }

                void Write()
                {
                    writer.Write($"{Lex.KwCase} ");
                    Expression.PP(writer);
                    writer.WriteLine($" {Lex.KwOf}");
                    writer.Indent(() =>
                    {
                        foreach (var casee in Cases)
                        {
                            casee.PP(writer);
                            if (writer.LinePending)
                            {
                                writer.WriteLine();
                            }
                        }
                    });
                }
            }
        }

        public sealed class Prefix : ExprImpl
        {
            public Prefix(OperatorSymbol op, Expr rhs)
            {
                Op = op;
                Rhs = rhs;
            }

            public OperatorSymbol Op { get; }
            public Expr Rhs { get; set; }

            public override string ToString()
            {
                return $"{Op.Text} {Rhs}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{this}");
            }
        }

        public sealed class Field : ExprImpl
        {
            public Field(Identifier name, Expr? expression)
            {
                Name = name;
                Expression = expression;
            }

            public Identifier Name { get; }
            public Expr? Expression { get; set; }

            public override string ToString() => Name.OptJoin(" = ", Expression);

            public override void PP(Writer writer)
            {
                writer.Write($"{this}");
            }
        }

        public sealed class Record : ExprImpl
        {
            public Record(Identifier? baseRecord, IEnumerable<Field> fields)
            {
                Fields = fields.ToList();
                BaseRecord = baseRecord;
            }

            public Identifier? BaseRecord { get; }
            public List<Field> Fields { get; }

            public LetScope Scope { get; } = new();

            public override string ToString()
            {
                var joined = string.Join(", ", Fields);
                var baser = BaseRecord == null ? "" : $" {BaseRecord}, ";
                return $"{Lex.LeftCurlyBracket} {baser}{joined} {Lex.RCurlyBracket}";
            }

            public override void PP(Writer writer)
            {
                var line = ToString();

                if (line.Length > WhatIsLong)
                {
                    if (writer.LinePending)
                    {
                        writer.WriteLine();
                        writer.Indent(Write);
                    }
                    else
                    {
                        Write();
                    }
                }
                else
                {
                    writer.Write(line);
                }

                void Write()
                {
                    writer.Write($"{Lex.LeftCurlyBracket} ");
                    var more = false;
                    if (BaseRecord != null)
                    {
                        writer.Write($"{BaseRecord}");
                        more = true;
                    }
                    foreach (var expression in Fields)
                    {
                        if (more)
                        {
                            writer.WriteLine();
                            writer.Write($"{Lex.Comma} ");
                        }
                        more = true;
                        expression.PP(writer);
                    }
                    writer.EndLine();
                    writer.Write($"{Lex.RCurlyBracket}");
                }
            }
        }

        public sealed class Select : ExprImpl
        {
            public Select(Expr lhs, Expr rhs)
            {
                Lhs = lhs;
                Rhs = rhs;
            }

            public Expr Lhs { get; set; }
            public Expr Rhs { get; set; }

            public override string ToString()
            {
                return $"{Lhs}{Lex.Dot}{Rhs}";
            }

            public override void PP(Writer writer)
            {
                Lhs.PP(writer);
                writer.Write($"{Lex.Dot}{Rhs}");
            }
        }

        public sealed class Application : ListOf<Expr>
        {
            public Application(IEnumerable<Expr> expressions)
                : base(expressions)
            {
                Assert(Count >= 1);
            }

            public Application(params Expr[] expressions)
                : this(expressions.AsEnumerable())
            {
            }

            public bool IsApplication => Count >= 2;
            public bool IsSingle => Count == 1;

            public Expr Single
            {
                get
                {
                    Assert(IsSingle);
                    return this[0];
                }
            }

            public override string ToString()
            {
                var joined = string.Join(" ", this);

                return Protected($"{joined}");
            }

            public override void PP(Writer writer)
            {
                writer.Write(ToString());
            }
        }

        public sealed class Ctor : ExprImpl
        {
            public Ctor(Identifier name, IEnumerable<Expr> arguments)
            {
                Name = name.MultiUpper();
                Arguments = arguments.ToList();
            }

            public Identifier Name { get; set; }
            public List<Expr> Arguments { get; }

            public override string ToString()
            {
                return $"{Name}{Arguments.SpaceJoin()}";
            }
        }

        public sealed class Tuple : ListOf<Expr>
        {
            public Tuple(IEnumerable<Expr> expressions)
                : base(expressions)
            {
                Assert(Count >= 1 && Count <= 3);
            }

            public override string ToString()
            {
                return $"{Lex.LeftRoundBracket}{string.Join(", ", this)}{Lex.RightRoundBracket}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LeftRoundBracket}");
                var more = false;
                foreach (var expression in this)
                {
                    if (more)
                    {
                        writer.Write($"{Lex.Comma} ");
                    }
                    more = true;
                    expression.PP(writer);
                }
                writer.Write($"{Lex.RightRoundBracket}");
            }
        }

        public sealed class Unit : ExprImpl
        {
            public override string ToString()
            {
                return "()";
            }

            public override void PP(Writer writer)
            {
                writer.Write("()");
            }
        }
        public abstract class Literal : ExprImpl
        {
            public Literal(Token token)
            {
                Token = token;
            }

            public Token Token { get; }

            public override string ToString()
            {
                return $"{Token}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Token}");
            }

            public sealed class Integer : Literal
            {
                public Integer(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.Integer);

                    var text = Token.Text;

                    if (text.StartsWith("0x"))
                    {
                        Value = long.Parse(text[2..], NumberStyles.HexNumber);
                    }
                    else
                    {
                        Value = long.Parse(text, NumberStyles.Integer);
                    }
                }

                public long Value { get; }
            }

            public sealed class Float : Literal
            {
                public Float(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.Float);
                }
            }

            public sealed class Char : Literal
            {
                public Char(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.Char);
                }
            }

            public sealed class String : Literal
            {
                public String(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.String);

                    var text = token.Text;

                    Assert(text.StartsWith('\"') && !text.StartsWith("\"\"\""));
                    Assert(text.EndsWith('\"') && !text.EndsWith("\"\"\""));

                    Value = text[1..^1];
                }

                public string Value { get; }
            }

            public sealed class LongString : Literal
            {
                public LongString(Token token)
                    : base(token)
                {
                    Assert(token.Lex == Lex.LongString);

                    var text = token.Text;

                    Assert(text.StartsWith("\"\"\""));
                    Assert(text.EndsWith("\"\"\""));

                    Value = text[3..^3];
                }

                public string Value { get; }
            }
        }

        public abstract class Ref : Expr.ExprImpl
        {
            public Ref(Decl decl)
            {
                Declaration = decl;
            }

            public Decl Declaration { get; }

            public override void PP(Writer writer)
            {
                writer.Write($"{Declaration}");
            }

            public abstract class RefImpl<T> : Ref
                where T : Decl
            {
                public RefImpl(T declaration)
                    : base(declaration)
                {
                }

                public T Decl => (T)Declaration;
            }

            public sealed class Parameter : RefImpl<Decl.Parameter>
            {
                public Parameter(Decl.Parameter decl) : base(decl) { }
            }

            public sealed class Var : RefImpl<Decl.Var>
            {
                public Var(Decl.Var decl) : base(decl) { }
            }

            public sealed class Ctor : RefImpl<Decl.Ctor>
            {
                public Ctor(Decl.Ctor decl) : base(decl) { }
            }

            public sealed class Infix : RefImpl<Decl.Infix>
            {
                public Infix(Decl.Infix decl) : base(decl) { }
            }

            public sealed class Type : RefImpl<Decl.Custom>
            {
                public Type(Decl.Custom decl) : base(decl) { }
            }

            public sealed new class Alias : RefImpl<Decl.Alias>
            {
                public Alias(Decl.Alias decl) : base(decl) { }
            }

            public sealed class Native : RefImpl<Decl.Native>
            {
                public Native(Decl.Native decl) : base(decl) { }
            }
        }

    }
}
