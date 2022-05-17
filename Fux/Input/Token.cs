using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Token
    {
        public Token(Lexer lexer, Lex lex, int start, int end)
        {
            Lexer = lexer;
            Lex = lex;
            Start = start;
            End = end;
        }

        public Lexer Lexer { get; }
        public Lex Lex { get; }
        public int Start { get; }
        public int End { get; }

        public override string ToString()
        {
            var value = string.Empty;
            if (End > Start)
            {
                var builder = new StringBuilder();
                builder.Append('(');
                for (var at = Start; at < End; at++)
                {
                    var rune = Lexer.Text[at];
                    if (rune.Value == '\n')
                    {
                        builder.Append("\\n");
                    }
                    else
                    {
                        builder.Append(char.ConvertFromUtf32(rune.Value));
                    }
                }
                builder.Append(')');
                value = builder.ToString();
            }

            return $"{Lex}{value}";
        }
    }
}
