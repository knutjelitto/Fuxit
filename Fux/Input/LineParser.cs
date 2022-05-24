using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class LineParser
    {
        private Token? current = null;

        public LineParser(Lexer lexer)
        {
            Lexer = lexer;
            Error = new ParserErrors();
        }

        public Lexer Lexer { get; }

        public ParserErrors Error { get; }

        public Line? GetLine()
        {
            if (Current.Lex == Lex.EOF)
            {
                return null;
            }

            return CreateLine();
        }

        private Token Current
        {
            get
            {
                if (current == null)
                {
                    current = CreateNext();
                }
                return current;
            }
        }

        private Token Consume()
        {
            var token = Current;

            current = null;

            return token;
        }

        private Line CreateLine()
        {
            var starter = Current;

            var line = new Line();

            while (!Current.EOF && Current.Line == starter.Line)
            {
                line.Add(Consume());
            }

            if (Current.Column > starter.Column)
            {
                CreateLines(line);
            }

            return line;
        }

        private void CreateLines(Line parent)
        {
            var starter = Current;

            while (!Current.EOF && Current.Column == starter.Column)
            {
                parent.Add(CreateLine());
            }
        }

        private Token CreateNext()
        {
            var whites = new Whites();
            var current = Lexer.GetNext();

            while (!current.EOF && current.White)
            {
                whites.Add(current);

                current = Lexer.GetNext();
            }

            return current.TransferWhites(whites);
        }
    }
}
