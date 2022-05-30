namespace Fux.Tools
{
    public class Writer : IDisposable
    {
        private readonly TextWriter sink;
        private readonly bool owns;
        private int level;
        private bool indentPending = true;
        private bool lineRunning = false;
        private readonly string prefix;

        public Writer(TextWriter sink, int? indent = null, bool owns = false)
        {
            this.sink = sink;
            this.owns = owns;
            prefix = new string(' ', indent ?? 4);

            Filename = "<unknown>";
        }

        public Writer(int? indent = null)
            : this(new StringWriter(), indent, true)
        {
        }

        public Writer(string filename, int? indent = null)
            : this(new StreamWriter(filename), indent, true)
        {
            Filename = filename;
        }


        public int Indentation => prefix.Length * level;
        
        public bool LineRunning => lineRunning;

        public string Filename { get; }

        public static Writer Console()
        {
            return new Writer(System.Console.Out);
        }

        public void WriteLine()
        {
            sink.WriteLine();
            indentPending = true;
            lineRunning = false;
        }

        public void WriteLine(string text)
        {
            Write(text);
            WriteLine();
        }

        public void Write(string text)
        {
            if (indentPending)
            {
                for (var i = 0; i < level; i++)
                {
                    sink.Write(prefix);
                }
                indentPending = false;
            }

            sink.Write(text);
            lineRunning = true;
        }

        public void Plus()
        {
            level += 1;
        }

        public void Minus()
        {
            //level = Math.Max(0, level - 1);
            level -= 1;
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
    }
}
