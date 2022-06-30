using System.Globalization;

using Fux.Building;

namespace Fux.Input.Ast
{
    public interface Expr : Node
    {
        Identifier? Alias { get; set; }
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

        public sealed class Arrow : Expr.ExprImpl
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

        public sealed class Dot : Expr.ExprImpl
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

        public sealed class If : Expr.ExprImpl
        {
            public If(Expr condition, Expr ifTrue, Expr ifFalse)
            {
                Condition = condition;
                IfTrue = ifTrue;
                IfFalse = ifFalse;
            }

            public Expr Condition { get; }
            public Expr IfTrue { get; }
            public Expr IfFalse { get; }

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

        public sealed class Infix : Expr.ExprImpl
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
        public sealed class Lambda : Expr.ExprImpl
        {
            public Lambda(Pattern parameters, Expr expr)
            {
                Parameters = parameters;
                Expression = expr;
            }

            public Pattern Parameters { get; }
            public Expr Expression { get; }

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
        public sealed class Let : Expr.ExprImpl
        {
            public Let(List<Declaration> letExpressions, Expr inExpression)
            {
                LetDecls = letExpressions.ToArray();
                InExpression = inExpression;
            }

            public IReadOnlyList<Declaration> LetDecls { get; }
            public Expr InExpression { get; }

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
                return $"{Lex.LBracket}{joined}{Lex.RBracket}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LBracket}");
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
                writer.Write($"{Lex.RBracket}");
            }
        }

        public sealed class CaseMatch : Expr.ExprImpl
        {
            public CaseMatch(Expr expression, IEnumerable<Case> cases)
            {
                Expression = expression;
                Cases = cases.ToArray(); ;
            }

            public Expr Expression { get; }
            public IReadOnlyList<Case> Cases { get; }

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

        public sealed class Prefix : Expr.ExprImpl
        {
            public Prefix(OperatorSymbol op, Expr rhs)
            {
                Op = op;
                Rhs = rhs;
            }

            public OperatorSymbol Op { get; }
            public Expr Rhs { get; }

            public override string ToString()
            {
                return $"{Op.Text} {Rhs}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{this}");
            }
        }

        public sealed class Record : Expr.ExprImpl
        {
            public Record(Identifier? baseRecord, IEnumerable<FieldAssign> fields)
            {
                Fields = fields.ToArray();
                BaseRecord = baseRecord;
            }

            public Identifier? BaseRecord { get; }

            public IReadOnlyList<FieldAssign> Fields { get; }

            public override string ToString()
            {
                var joined = string.Join(", ", Fields);
                var baser = BaseRecord == null ? "" : $" {BaseRecord}, ";
                return $"{Lex.LBrace} {baser}{joined} {Lex.RBrace}";
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
                    writer.Write($"{Lex.LBrace} ");
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
                    writer.Write($"{Lex.RBrace}");
                }
            }
        }

        public sealed class Select : Expr.ExprImpl
        {
            public Select(Expr lhs, Expr rhs)
            {
                Lhs = lhs;
                Rhs = rhs;
            }

            public Expr Lhs { get; }
            public Expr Rhs { get; }

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

        public sealed class Sequence : ListOf<Expr>
        {
            public Sequence(IEnumerable<Expr> expressions)
                : base(expressions)
            {
                Assert(Count >= 1);
            }

            public Sequence(params Expr[] expressions)
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

        public sealed class Tuple : ListOf<Expr>
        {
            public Tuple(IEnumerable<Expr> expressions)
                : base(expressions)
            {
                Assert(this.Count >= 1 && this.Count <= 3);
            }

            public override string ToString()
            {
                return $"{Lex.LParent}{string.Join(", ", this)}{Lex.RParent}";
            }

            public override void PP(Writer writer)
            {
                writer.Write($"{Lex.LParent}");
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
                writer.Write($"{Lex.RParent}");
            }
        }

        public sealed class Unit : Expr.ExprImpl
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
        public abstract class Literal : Expr.ExprImpl
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
                        Value = long.Parse(text.Substring(2), NumberStyles.HexNumber);
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
    }
}
