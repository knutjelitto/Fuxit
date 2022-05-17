﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Input
{
    internal class Lexer
    {
        public Lexer(Source source)
        {
            Source = source;
            Text = new List<Rune>();
            Offset = 0;
        }

        public Source Source { get; }

        public List<Rune> Text { get; }

        public int Offset { get; private set; }
        public int Length { get; }

        public int This => Ensure(Offset).Value;
        public int Next => Ensure(Offset + 1).Value;

        private Rune Ensure(int offset)
        {
            while (offset >= Text.Count)
            {
                if (Source.GetNext(out var rune))
                {
                    Text.Add(rune);
                }
                else
                {
                    Text.Add(new Rune(0));
                }
            }
            return Text[offset];
        }

        public Lex Scan()
        {
            var start = Offset;
            if (This == 0x0A) // linefeed
            {
                Offset += 1;
                return Lex.Newline;
            }
            if (This == 0x0D && Next == 0x0A) // return linefeed
            {
                Offset += 2;
                return Lex.Newline;
            }

            switch (This)
            {
                case '(':
                    return Swallow(Lex.LParent);
                case ')':
                    return Swallow(Lex.RParent);
                default:
                    break;
            }

            throw new NotImplementedException();
        }

        private Lex Swallow(Lex lex)
        {
            Offset += 1;
            return lex;
        }

        private bool isLower => 'a' <= This && This <= 'z';
        private bool isUpper => 'A' <= This && This <= 'A';
        private bool isLetter => isLower || isUpper;
        private bool isDigit => '0' <= This && This <= '9';
        private bool isPosDigit => '1' <= This && This <= '9';
        private bool isHexDigit => 'a' <= This && This <= 'f' || 'A' <= This && This <= 'F' || isDigit;
        private bool isChar => isUnicode && !isControl && !isSurrogate && !isBidi;
        private bool isUnicode => 0x00 <= This && This <= 0x10FFFF;
        private bool isControl => 0x00 <= This && This <= 0x1F || 0x7F == This || 0x80 <= This && This <= 0x9F;
        private bool isSurrogate => 0xD800 <= This && This <= 0xDFFF;
        private bool isBidi => 0x200E == This || 0x200F == This || 0x202A <= This && This <= 0x202E || 0x2066 <= This && This <= 0x2069;
    }
}
