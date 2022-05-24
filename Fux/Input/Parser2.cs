using Fux.Ast;

namespace Fux.Input
{
    internal class Parser2
    {
        private Token? current = null;

        public Parser2(Layout layout)
        {
            Layout = layout;
            Error = new ParserErrors();
        }


        public Layout Layout { get; }
        public Lexer Lexer => Layout.Lexer;
        public ParserErrors Error { get; }

        private Token Current
        { 
            get
            {
                if (current == null)
                {
                    current = Layout.GetNext();
                }
                return current;
            }
        }

        public Module SourceFile()
        {
            var header = ModuleHeader();

            SwallowSemicolons();
 
            var imports = new List<Import>();

            while (Current.Lex == Lex.KwImport)
            {
                var import = Import();

                imports.Add(import);

                SwallowSemicolons();
            }

            var declarations = new List<Expression>();

            while (Current.Lex != Lex.EOF)
            {
                declarations.Add(Declaration());
            }

            return new Module(header, imports, declarations);
        }

        private Expression Declaration()
        {
            if (Current.Lex == Lex.KwType)
            {
                return TypeDeclaraction();
            }

            return AnnotationOrValue();
        }

        private Expression AnnotationOrValue()
        {
            var expression = Expression();

            if (Current.Lex == Lex.Colon)
            {
                return Annotation(expression);
            }
            else if (Current.Lex == Lex.Define)
            {
                return Value(expression, false);
            }

            throw Error.NotImplemented(Current);
        }

        private Expression Annotation(Expression lhs)
        {
            var colon = Swallow(Lex.Colon);

            var rhs = Expression();

            Swallow(Lex.Semicolon);

            return new Annotation(colon, lhs, rhs);
        }

        private Expression Value(Expression lhs, bool inner)
        {
            var define = Swallow(Lex.Define);

            var rhs = Expression();

            if (!inner)
            {
                Swallow(Lex.Semicolon);
            }

            return new Definition(define, lhs, rhs);
        }

        private Expression TypeDeclaraction()
        {
            var typeToken = Swallow(Lex.KwType);

            var lhs = ApplicationExpression();

            var defineToken = Swallow(Lex.Define);

            var rhs = Expression();

            Swallow(Lex.Semicolon);

            return new TypeDefinition(typeToken, lhs, defineToken, rhs);
        }

        private void SwallowSemicolons()
        {
            while (Current.Lex == Lex.Semicolon)
            {
                Swallow();
            }
        }

        public Header ModuleHeader()
        {
            Swallow(Lex.KwModule);
            var name = new Identifier(Swallow(Lex.UpperId));
            Swallow(Lex.KwExposing);

            SwallowSemicolons();

            var tuple = TupleExpression();

            return new Header(name, tuple.Expressions);
        }

        public Import Import()
        {
            Swallow(Lex.KwImport);
            var path = Expression();

            Expression? alias = null;

            if (Current.Text == "as")
            {
                Swallow();

                alias = Expression();
            }

            Expression? exposed = null;

            if (Current.Lex == Lex.KwExposing)
            {
                Swallow(Lex.KwExposing);

                exposed = Expression();
            }

            return new Import(path, alias, exposed);

            throw new NotImplementedException();
        }

        public Expression Statement()
        {
            var expression = Expression();

            return expression;
        }

        private Expression Expression()
        {
            return BasicExpression();
        }

        private Expression BasicExpression()
        {
            if (Current.Lex == Lex.KwIf)
            {
                return IfExpression();
            }
            else if (Current.Lex == Lex.KwLet)
            {
                return LetExpression();
            }
            else if (Current.Lex == Lex.KwCase)
            {
                return CaseExpression();
            }

            return OperatorExpression();
        }

        private Expression CaseExpression()
        {
            var kwCase = Swallow(Lex.KwCase);

            throw Error.NotImplemented(Current);
        }

        private Expression LetExpression()
        {
            var kwLet = Swallow(Lex.KwLet);

            var declarations = new List<Expression>();

            do
            {
                var declaration = AnnotationOrValue();

                declarations.Add(declaration);
            }
            while (Current.Lex != Lex.KwIn);

            var kwIn = Swallow(Lex.KwIn);

            var expression = Expression();

            return new LexExpression(kwLet, declarations, kwIn, expression);
        }

        private IfExpression IfExpression()
        {
            var kwIf = Swallow(Lex.KwIf);
            var condition = OperatorExpression();
            var kwThen = Swallow(Lex.KwThen);
            var ifTrue = Expression();
            var kwElse = Swallow(Lex.KwElse);
            var ifFalse = Expression();

            return new IfExpression(condition, ifTrue, ifFalse);
        }

        private Expression OperatorExpression()
        {
            var first = PrefixExpression();

            var rest = new List<OpExpr>();

            while (Current.IsOperator())
            {
                Operator op = Infix.Instance.Create(Swallow());

                var opExpr = new OpExpr(op, PrefixExpression());

                rest.Add(opExpr);
            }

            if (rest.Count == 0)
            {
                return first;
            }

            return new OpChain(first, rest).Resolve();
        }

        private Expression PrefixExpression()
        {
            Expression app;

            if (Current.IsOperator())
            {
                var op = new Operator(Swallow());
                var argument = PrefixExpression();

                app = new ApplicationExpression(op, argument);
            }
            else
            {
                app = ApplicationExpression();
            }

            return app;
        }

        private Expression ApplicationExpression()
        {
            var first = AtomExpression();

            var rest = new List<Expression>();
            while (IsAtomStart())
            {
                rest.Add(AtomExpression());
            }

            if (rest.Count > 0)
            {
                return new ApplicationExpression(first, rest.ToArray());
            }

            return first;
        }

        private bool IsAtomStart()
        {
            return Current.Lex == Lex.Number
                || Current.Lex == Lex.String
                || Current.Lex == Lex.LowerId
                || Current.Lex == Lex.UpperId
                || Current.Lex == Lex.Wildcard
                || Current.Lex == Lex.LParent
                || Current.Lex == Lex.LBracket
                || Current.Lex == Lex.LBrace
                ;
        }

        private bool IsStatementStart()
        {
            return IsAtomStart()
                || Current.Lex == Lex.KwLet
                || Current.Lex == Lex.KwIf
                || Current.Lex == Lex.KwCase
                ;
        }

        private Expression AtomExpression()
        {
            if (Current.Lex == Lex.Number)
            {
                return new NumberLiteral(Swallow());
            }
            else if (Current.Lex == Lex.String)
            {
                return new StringLiteral(Swallow());
            }
            else if (Current.Lex == Lex.LowerId || Current.Lex == Lex.UpperId)
            {
                return new Identifier(Swallow());
            }
            else if (Current.Lex == Lex.Wildcard)
            {
                return new Wildcard(Swallow());
            }
            else if (Current.Lex == Lex.LParent)
            {
                return TupleExpression();
            }
            else if (Current.Lex == Lex.LBracket)
            {
                return ListExpression();
            }
            else if (Current.Lex == Lex.LBrace)
            {
                return RecordExpression();
            }

            throw Error.NotImplemented(Current);
        }

        private TupleExpression TupleExpression()
        {
            var left = Swallow(Lex.LParent);

            var expressions = new List<Expression>();

            while (Current.Lex != Lex.RParent)
            {
                expressions.Add(Expression());

                if (Current.Lex == Lex.Comma)
                {
                    Swallow();

                    continue;
                }
            }

            var right = Swallow(Lex.RParent);

            return new TupleExpression(left, right, expressions);
        }

        private Expression ListExpression()
        {
            var left = Swallow(Lex.LBracket);

            var expressions = new List<Expression>();

            while (Current.Lex != Lex.RBracket)
            {
                var expression = Expression();

                if (Current.Lex == Lex.Define)
                {
                    expression = Value(expression, true);
                }

                expressions.Add(expression);

                if (Current.Lex == Lex.Comma)
                {
                    Swallow();

                    continue;
                }
            }

            var right = Swallow(Lex.RBracket);

            return new ListExpression(left, right, expressions);
        }

        private Expression RecordExpression()
        {
            var left = Swallow(Lex.LBrace);

            var expressions = new List<Expression>();

            while (Current.Lex != Lex.RBrace)
            {
                var expression = Expression();

                if (Current.Lex == Lex.Define)
                {
                    expression = Value(expression, true);
                }

                expressions.Add(expression);

                if (Current.Lex == Lex.Comma)
                {
                    Swallow();

                    continue;
                }
            }

            var right = Swallow(Lex.RBrace);

            return new RecordExpression(left, right, expressions);
        }

        private Token Swallow(Lex lexKind)
        {
            if (Current.Lex == lexKind)
            {
                var current = Current;

                this.current = null;

                return current;
            }

            throw Error.Unexpected(lexKind, Current);
        }

        private Token Swallow()
        {
            var current = Current;

            this.current = null;

            return current;
        }
    }
}
