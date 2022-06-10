#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(ErrorBag errors, Liner liner)
        {
            Error = new ParserErrors(errors);
            Liner = liner;
        }

        public ParserErrors Error { get; }
        public Liner Liner { get; }

        public ModuleAst Module()
        {
            var header = (ModuleDecl)Outer();

            var expressions = new List<Expression>();

            var current = Outer();

            while (current is Expression declaration)
            {
                expressions.Add(declaration);

                current = Outer();

                if (current is Eof)
                {
                    break;
                }
            }

            return new ModuleAst(header, expressions);
        }

        public Expression Outer()
        {
            var line = Liner.GetLine();
            var cursor = new TokensCursor(Error, line);

            return Outer(cursor);
        }

        public Expression Outer(TokensCursor cursor)
        {
            Expression? outer = null;

            if (cursor.Is(Lex.HardKwModule) || cursor.IsWeak(Lex.Weak.Effect) || cursor.IsWeak(Lex.Weak.Port))
            {
                outer = TopHeader(cursor);
            }
            else if (cursor.Is(Lex.HardKwImport))
            {
                outer = TopImport(cursor);
            }
            else if (cursor.Is(Lex.HardKwInfix))
            {
                outer = TopInfixDecl(cursor);
            }
            else if (cursor.Is(Lex.HardKwType))
            {
                outer = TopType(cursor);
            }
            else if (cursor.Is(Lex.EOF))
            {
                outer = new Eof(cursor.Advance());
            }
            else
            {
                outer = Declaration(cursor);
            }

            if (cursor.More())
            {
                throw Error.Internal(cursor.At(), $"can not continue at token '{cursor.At()}'");
            }

            return outer;
        }

        private ModuleDecl TopHeader(TokensCursor cursor)
        {
            var effect = false;
            if (cursor.IsWeak(Lex.Weak.Effect))
            {
                //TODO: what's an effect?
                cursor.Advance();
                effect = true;
            }
            cursor.Swallow(Lex.HardKwModule);

            var path = Identifier(cursor).MultiUpper();

            var where = new List<VarDecl>();

            if (cursor.IsWeak("where"))
            {
                //TODO: what's a where?

                cursor.Advance();

                cursor.Swallow(Lex.LBrace);

                do
                {
                    var name = SingleIdentifier(cursor).SingleLower();
                    cursor.Swallow(Lex.Assign);
                    var expression = Expression(cursor);

                    where.Add(new VarDecl(name, new Parameters(), expression));
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RBrace);
            }

            TupleExpr? tuple = null;

            Exposing? exposing = null;

            if (cursor.IsWeak(Lex.Weak.Exposing))
            {
                exposing = Exposing(cursor);
            }

            return new ModuleDecl(path, effect, where, exposing);
        }

        public ImportDecl TopImport(TokensCursor cursor)
        {
            cursor.Swallow(Lex.HardKwImport);

            var path = Identifier(cursor).MultiUpper();

            Identifier? alias = null;

            if (cursor.SwallowIf(Lex.HardKwAs))
            {
                alias = Identifier(cursor).MultiUpper();
            }

            Exposing? exposing = null;

            if (cursor.IsWeak(Lex.Weak.Exposing))
            {
                exposing = Exposing(cursor);
            }

            return new ImportDecl(path, alias, exposing);
        }

        private Exposing Exposing(TokensCursor cursor)
        {
            Assert(cursor.IsWeak(Lex.Weak.Exposing));
            cursor.Swallow(Lex.LowerId);

            if (cursor.IsWeak(Lex.Weak.ExposeAll))
            {
                cursor.Swallow(Lex.OperatorId);

                return new ExposingAll();
            }

            cursor.Swallow(Lex.LParent);

            var exposed = new List<Exposed>();

            do
            {
                if (cursor.Is(Lex.LowerId))
                {
                    var name = new Identifier(cursor.Swallow(Lex.LowerId));
                    exposed.Add(new ExposedVar(name));
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    var name = new Identifier(cursor.Swallow(Lex.UpperId));
                    var inclusive = false;
                    if (cursor.IsWeak(Lex.Weak.ExposeAll))
                    {
                        cursor.Swallow(Lex.OperatorId);
                        inclusive = true;
                    }
                    exposed.Add(new ExposedType(name, inclusive));
                }
                else if (cursor.Is(Lex.OperatorId))
                {
                    var name = new Identifier(cursor.Swallow(Lex.OperatorId));
                    exposed.Add(new ExposedVar(name));
                }
                else
                {
                    Assert(false);
                    throw Error.Unexpected(cursor.Current);
                }
            }
            while (cursor.SwallowIf(Lex.Comma));

            cursor.Swallow(Lex.RParent);

            return new ExposingSome(exposed);

        }

        public InfixDecl TopInfixDecl(TokensCursor cursor)
        {
            cursor.Swallow(Lex.HardKwInfix);
            var assocTok = cursor.Swallow(Lex.LowerId);
            var assoc = InfixAssoc.From(assocTok.Text);
            if (assoc == null)
            {
                throw Error.IllegalInfixAssoc(assocTok);
            }
            var prioTok = cursor.Swallow(Lex.Number);
            var power = new InfixPower(prioTok);
            var operatorTok = cursor.Swallow(Lex.OperatorId);
            var operatorSymbol = new Identifier(operatorTok);
            var defineTok = cursor.Swallow(Lex.Assign);
            var definition = new Identifier(cursor.Swallow(Lex.LowerId));

            return new InfixDecl(assoc, power, operatorSymbol, definition);
        }

        public Expression TopType(TokensCursor cursor)
        {
            var kwType = cursor.Swallow(Lex.HardKwType);

            var alias = false;
            if (cursor.IsWeak("alias"))
            {
                cursor.Swallow(Lex.LowerId);
                alias = true;
            }

            Assert(cursor.Is(Lex.UpperId));

            var name = new Identifier(cursor.Swallow(Lex.UpperId));

            var parameterList = new List<Identifier>();

            while (cursor.IsNot(Lex.Assign))
            {
                Assert(cursor.Is(Lex.LowerId));

                var parameter = new Identifier(cursor.Swallow(Lex.LowerId));

                parameterList.Add(parameter);
            }

            var assign = cursor.Swallow(Lex.Assign);

            if (alias)
            {
                var def = Type(cursor);

                return new AliasDecl(name, new TypeParameters(parameterList), def);
            }

            var ctors = new List<Type.Constructor>();

            ctors.Add(Constructor(cursor));

            while (cursor.SwallowIf(Lex.Bar))
            {
                ctors.Add(Constructor(cursor));
            }

            return new TypeDecl(name, new TypeParameters(parameterList), new Constructors(ctors));
        }

        public Expression Declaration(TokensCursor cursor)
        {
            var left = Pattern(cursor);

            if (cursor.Is(Lex.Assign))
            {
                if (left[0] is Identifier name && name.IsSingleLower)
                {
                    cursor.Swallow(Lex.Assign);

                    var parameters = new Parameters(left.Skip(1));

                    Assert(name.IsSingleLower);


                    var expression = Expression(cursor);

                    return new VarDecl(name, parameters, expression);
                }
                else
                {
                    cursor.Swallow(Lex.Assign);

                    var expression = Expression(cursor);

                    return new LetAssign(left, expression);
                }
            }
            else if (cursor.SwallowIf(Lex.Colon))
            {
                Assert(left.Count == 1 && left[0] is Identifier);

                var name = (Identifier)left[0];

                Assert(name.IsSingleLower);

                var type = Type(cursor);

                return new TypeHint(name, type);
            }
            else
            {
                throw Error.NotImplemented(cursor.Current);
            }

            throw new NotImplementedException();
        }

        private Type.Constructor Constructor(TokensCursor cursor)
        {
            Assert(cursor.Is(Lex.UpperId));

            var name = Identifier(cursor).MultiUpper();

            var arguments = new List<Type>();

            do
            {
                while (cursor.More()
                    && cursor.IsNot(Lex.Bar)
                    && cursor.IsNot(Lex.RParent)
                    && cursor.IsNot(Lex.Comma)
                    && cursor.IsNot(Lex.RBrace)
                    && cursor.IsNot(Lex.Arrow))
                {
                    var argument = TypeArgument(cursor);

                    arguments.Add(argument);
                }
            }
            while (cursor.More()
                && cursor.IsNot(Lex.Bar)
                && cursor.IsNot(Lex.RParent)
                && cursor.IsNot(Lex.Comma)
                && cursor.IsNot(Lex.RBrace)
                && cursor.IsNot(Lex.Arrow));


            return new Type.Constructor(name, new TypeArguments(arguments));
        }

        private Type TypeArgument(TokensCursor cursor)
        {
            if (cursor.Is(Lex.LowerId))
            {
                var name = Identifier(cursor).SingleLower();

                return new Type.Parameter(name);
            }
            else if (cursor.Is(Lex.UpperId))
            {
                var name = Identifier(cursor).MultiUpper();

                return new Type.Concrete(name);
            }
            else if (cursor.Is(Lex.LParent))
            {
                return Type(cursor);
            }
            else if (cursor.Is(Lex.LBrace))
            {
                return Type(cursor);
            }
            else
            {
                Assert(true);
            }

            Assert(false);
            throw new NotImplementedException();
        }

        private Identifier Identifier(TokensCursor cursor)
        {
            var tokens = new List<Token>();

            do
            {
                if (cursor.IsIdentifier())
                {
                    var token = cursor.Advance();

                    tokens.Add(token);

                    if (token.Lex == Lex.LowerId || token.Lex == Lex.OperatorId)
                    {
                        break;
                    }
                }
                else
                {
                    throw Error.Unexpected(cursor.Current);
                }
            }
            while (cursor.SwallowIf(Lex.Dot));

            return new Identifier(tokens);
        }

        private Identifier SingleIdentifier(TokensCursor cursor)
        {
            cursor.Is(Lex.LowerId, Lex.UpperId, Lex.OperatorId);
            
            return new Identifier(cursor.Advance());
        }

        private Type Type(TokensCursor cursor)
        {
            var type = BaseType(cursor);

            if (cursor.SwallowIf(Lex.Arrow))
            {
                type = new Type.Function(type, Type(cursor));
            }

            return type;
        }

        private Type BaseType(TokensCursor cursor)
        {
            if (cursor.Is(Lex.LParent))
            {
                cursor.Swallow(Lex.LParent);

                var types = new List<Type>();

                if (cursor.IsNot(Lex.RParent))
                {
                    do
                    {
                        var type = Type(cursor);

                        types.Add(type);
                    }
                    while (cursor.SwallowIf(Lex.Comma));
                }

                cursor.Swallow(Lex.RParent);

                if (types.Count == 0)
                {
                    return new Type.Unit();
                }
                else if (types.Count == 1)
                {
                    var type = types[0];
                    type.Protect = true;
                    return type;
                }
                else
                {
                    return new Type.Tuple(types);
                }
            }
            else if (cursor.Is(Lex.LBrace))
            {
                return RecordType(cursor);
            }
            else if (cursor.Is(Lex.UpperId))
            {
                return Constructor(cursor);
            }
            else if (cursor.Is(Lex.LowerId))
            {
                var name = Identifier(cursor).SingleLower();

                if (name.ToString() == "number")
                {
                    return new Type.Number(name);
                }

                if (name.ToString() == "appendable")
                {
                    return new Type.Appendable(name);
                }

                if (name.ToString() == "comparable")
                {
                    return new Type.Comparable(name);
                }

                return new Type.Parameter(name);
            }

            Assert(false);
            throw new NotImplementedException();
        }

        private Expression TupleLiteral(TokensCursor cursor)
        {
            cursor.Swallow(Lex.LParent);

            var expressions = new List<Expression>();

            while (cursor.IsNot(Lex.RParent))
            {
                expressions.Add(Expression(cursor));

                if (cursor.Is(Lex.Comma))
                {
                    cursor.Advance();

                    continue;
                }
            }

            cursor.Swallow(Lex.RParent);

            if (expressions.Count == 0)
            {
                return new Unit();
            }
            else if (expressions.Count == 1)
            {
                var expression = expressions[0];
                expression.Protect = true;
                return expression;
            }
            else
            {
                return new TupleExpr(expressions);
            }
        }

        private Type RecordType(TokensCursor cursor)
        {
            var left = cursor.Swallow(Lex.LBrace);

            var fields = new List<FieldDefine>();

            Type? baseType = null;

            if (cursor.IsNot(Lex.RBrace))
            {
                var state = cursor.State;

                baseType = Type(cursor);

                Assert(baseType is Type.Parameter);

                if (cursor.IsNot(Lex.Bar))
                {
                    baseType = null;
                    cursor.Reset(state);
                }
                else
                {
                    cursor.Swallow(Lex.Bar);
                }

                do
                {
                    fields.Add(Field(cursor));
                }
                while (cursor.SwallowIf(Lex.Comma));
            }

            cursor.Swallow(Lex.RBrace);

            return new RecordDecl(baseType, fields.Cast<FieldDefine>());

            FieldDefine Field(TokensCursor cursor)
            {
                var name = Identifier(cursor);
                cursor.Swallow(Lex.Colon);
                var type = Type(cursor);

                return new FieldDefine(name, type);
            }
        }

        private Expression RecordLiteral(TokensCursor cursor)
        {
            var left = cursor.Swallow(Lex.LBrace);

            var fields = new List<Field>();

            var state = cursor.State;

            if (cursor.Is(Lex.RBrace))
            {
                cursor.Swallow(Lex.RBrace);

                return new RecordPattern(Enumerable.Empty<FieldPattern>());
            }

            Expression? baseName = Sequence(cursor);

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

            cursor.Swallow(Lex.RBrace);

            if (fields.All(f => f is FieldAssign))
            {
                Assert(baseName == null || baseName is Identifier);
                return new RecordExpr((Identifier?)baseName, fields.Cast<FieldAssign>());
            }
            else if (fields.All(f => f is FieldPattern))
            {
                Assert(baseName == null);
                return new RecordPattern(fields.Cast<FieldPattern>());
            }

            Assert(false);
            throw new NotImplementedException();

            Field Field(TokensCursor cursor)
            {
                var name = Sequence(cursor);

                if (cursor.Is(Lex.Assign))
                {
                    Assert(name is Identifier);

                    var assign = cursor.Swallow(Lex.Assign);
                    var value = Expression(cursor);

                    return new FieldAssign((Identifier)name, value);
                }
                else
                {
                    return new FieldPattern(name);
                }
            }
        }

        private ListExpr ListLiteral(TokensCursor cursor)
        {
            var left = cursor.Swallow(Lex.LBracket);

            var expressions = new List<Expression>();

            while (cursor.At().Lex != Lex.RBracket)
            {
                expressions.Add(Expression(cursor));

                if (cursor.IsNot(Lex.RBracket))
                {
                    cursor.Swallow(Lex.Comma);
                }
            }

            var right = cursor.Swallow(Lex.RBracket);

            return new ListExpr(left, right, expressions);
        }
        private Expression InlineIf(TokensCursor cursor)
        {
            var kwIf = cursor.Swallow(Lex.HardKwIf);
            var condition = Expression(cursor);
            var kwThen = cursor.Swallow(Lex.HardKwThen);
            var whenTrue = Expression(cursor);
            var kwElse = cursor.Swallow(Lex.HardKwElse);
            var whenFalse = Expression(cursor);

            return new IfExpr(condition, whenTrue, whenFalse);
        }

        private Expression InlineLet(TokensCursor cursor)
        {
            var kwLet = cursor.Swallow(Lex.HardKwLet);
            var lets = new List<Expression>();
            while (cursor.IsNot(Lex.HardKwIn))
            {
                var subCursor = cursor.Sub();

                var decl = Declaration(subCursor);

                lets.Add(decl);
            }
            var kwIn = cursor.Swallow(Lex.HardKwIn);
            var expression = Expression(cursor);

            return new LetExpr(lets, expression);
        }

        private Expression InlineCase(TokensCursor cursor)
        {
            cursor.Swallow(Lex.HardKwCase);
            var expression = Expression(cursor);
            cursor.Swallow(Lex.HardKwOf);

            var cases = new List<MatchCase>();

            while (cursor.StartsAtomic)
            {
                var subCursor = cursor.Sub();

                var pattern = Pattern(subCursor);

                subCursor.Swallow(Lex.Arrow);

                var expr = Expression(subCursor);

                var matchCase = new MatchCase(pattern, expr);

                cases.Add(matchCase);
            }

            return new MatchExpr(expression, cases);
        }

        private SequenceExpr Pattern(TokensCursor cursor)
        {
            return (SequenceExpr)Sequence(cursor, true);
        }

        private Expression Expression(TokensCursor cursor)
        {
            return Sequence(cursor);
        }

        private Expression Sequence(TokensCursor cursor, bool always = false)
        {
            var expressions = new List<Expression>();

            do
            {
                var expression = OperatorExpr(cursor);

                expressions.Add(expression);
            }
            while (cursor.StartsAtomic);

            Assert(expressions.Count >= 1);

            if (!always && expressions.Count == 1)
            {
                return expressions[0];
            }

            return new SequenceExpr(expressions);
        }


        private Expression OperatorExpr(TokensCursor cursor)
        {
            var expr = PrefixExpr(cursor);

            if (cursor.Is(Lex.Operator))
            {
                var op = new OperatorSymbol(cursor.Swallow(Lex.Operator));

                expr = new InfixExpr(op, expr, OperatorExpr(cursor));
            }

            return expr;
        }

        private Expression PrefixExpr(TokensCursor cursor)
        {
            Expression app;

            if (cursor.IsOperator())
            {
                var op = new OperatorSymbol(cursor.Advance());
                var argument = PrefixExpr(cursor);

                app = new PrefixExpr(op, argument);
            }
            else
            {
                app = Compound(cursor);
            }

            return app;
        }

        private Expression Compound(TokensCursor cursor)
        {
            if (cursor.Is(Lex.HardKwIf))
            {
                return InlineIf(cursor);
            }
            else if (cursor.Is(Lex.HardKwLet))
            {
                return InlineLet(cursor);
            }
            else if (cursor.Is(Lex.HardKwCase))
            {
                return InlineCase(cursor);
            }
            else
            {
                Assert(cursor.StartsAtomic);

                var atom = Atom(cursor);

                if (cursor.SwallowIf(Lex.HardKwAs))
                {
                    var alias = Identifier(cursor).SingleLower();

                    atom.Alias = alias;
                }

                return atom;
            }
        }

        private Expression Atom(TokensCursor cursor)
        {
            Assert(cursor.StartsAtomic);

            Expression atom = ParseAtom(cursor);

            while (cursor.Is(Lex.Dot))
            {
                cursor.Swallow(Lex.Dot);

                atom = new SelectExpr(atom, ParseAtom(cursor));
            }

            return atom;

            Expression ParseAtom(TokensCursor cursor)
            {
                if (cursor.Is(Lex.LowerId))
                {
                    return SingleIdentifier(cursor);
                }
                else if (cursor.Is(Lex.OperatorId))
                {
                    return SingleIdentifier(cursor);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    return Identifier(cursor);
                }
                else if (cursor.Is(Lex.Wildcard))
                {
                    return Wildcard(cursor);
                }
                else if (cursor.Is(Lex.Number))
                {
                    return NumberLiteral(cursor);
                }
                else if (cursor.Is(Lex.String))
                {
                    return StringLiteral(cursor);
                }
                else if (cursor.Is(Lex.Char))
                {
                    return CharLiteral(cursor);
                }
                else if (cursor.Is(Lex.LParent))
                {
                    return TupleLiteral(cursor);
                }
                else if (cursor.Is(Lex.LBrace))
                {
                    return RecordLiteral(cursor);
                }
                else if (cursor.Is(Lex.LBracket))
                {
                    return ListLiteral(cursor);
                }
                else if (cursor.Is(Lex.Lambda))
                {
                    return Lambda(cursor);
                }
                else if (cursor.Is(Lex.Dot))
                {
                    return Dot(cursor);
                }

                throw Error.NotImplemented(cursor.At());
            }
        }

        private Expression Dot(TokensCursor cursor)
        {
            cursor.Swallow(Lex.Dot);
            var expr = SingleIdentifier(cursor);

            return new DotExpr(expr);
        }

        private Expression Wildcard(TokensCursor cursor)
        {
            var token = cursor.Swallow(Lex.Wildcard);

            return new Wildcard(token);
        }

        private Expression CharLiteral(TokensCursor cursor)
        {
            var token = cursor.Swallow(Lex.Char);

            return new CharLiteral(token);
        }

        private Expression StringLiteral(TokensCursor cursor)
        {
            var token = cursor.Swallow(Lex.String);

            return new StringLiteral(token);
        }

        private Expression NumberLiteral(TokensCursor cursor)
        {
            var token = cursor.Swallow(Lex.Number);

            return new NumberLiteral(token);
        }

        private Expression Lambda(TokensCursor cursor)
        {
            return Scope(cursor, cursor =>
            {
                cursor.Swallow(Lex.Lambda);

                var parameters = Pattern(cursor);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new LambdaExpr(parameters, expr);
            });
        }

        private T Scope<T>(TokensCursor cursor, Func<TokensCursor, T> parser)
        {
            var expression = parser(cursor);

            return expression;
        }
    }
}
