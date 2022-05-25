namespace Fux.Tools
{
    public class Writer : IDisposable
    {
        public Writer(TextWriter sink, int? indent = null, bool owns = false)
        {
            this.sink = sink;
            this.owns = owns;
            prefix = new string(' ', indent ?? 4);
        }

        public Writer(int? indent = null)
            : this(new StringWriter(), indent, true)
        {
        }

        public Writer(string filename, int? indent = null)
            : this(new StreamWriter(filename), indent, true)
        {
        }

        public static Writer Console()
        {
            return new Writer(System.Console.Out);
        }

        public void WriteLine()
        {
            sink.WriteLine();
            pending = true;
        }

        public void WriteLine(string text)
        {
            Write(text);
            WriteLine();
        }

        public void Write(string text)
        {
            if (pending)
            {
                for (var i = 0; i < level; i++)
                {
                    sink.Write(prefix);
                    pending = false;
                }
            }

            sink.Write(text);
        }

        public int Indentation => prefix.Length * level;

        public void Plus()
        {
            level += 1;
        }

        public void Minus()
        {
            level = Math.Max(0, level - 1);
        }

        public IDisposable Indent()
        {
            return new Undenter(this);
        }

        public void Indent(Action content)
        {
            using (Indent())
            {
                content();
            }
        }

        public override string ToString()
        {
            if (sink is StringWriter stringWriter)
            {
                return stringWriter.ToString();
            }
            return "-content-lost-in-outer-space-";
        }

        public void Clear()
        {
            if (sink is StringWriter stringWriter)
            {
                stringWriter.GetStringBuilder().Clear();
            }
        }

        public void Dispose()
        {
            if (owns && sink != null)
            {
                sink.Dispose();
            }
        }

        private class Undenter : IDisposable
        {
            private readonly Writer writer;

            public Undenter(Writer writer)
            {
                this.writer = writer;
                writer.Plus();
            }
            public void Dispose()
            {
                writer.Minus();
            }
        }

        private readonly TextWriter sink;
        private readonly bool owns;
        private int level;
        private bool pending = true;
        private readonly string prefix;
    }
}
