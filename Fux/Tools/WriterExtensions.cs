namespace Fux.Tools
{
    public static class WriterExtensions
    {
        private const string top = "Fux";

        public static string File(string filename)
        {
            var path = Folder.Combine(Temp.TempPath(top), filename);
            var dir = IO.Path.GetDirectoryName(path)!;
            IO.Directory.CreateDirectory(dir);

            return path;
        }

        public static Writer Writer(this string filename, int? indent = null)
        {
            return new Writer(File(filename), indent);
        }

        public static void Join<T>(this Writer writer, string separator, IEnumerable<T> values)
        {
            var more = false;

            foreach (var value in values)
            {
                if (more)
                {
                    writer.Write(separator);
                }
                more = true;

                writer.Write($"{value}");
            }
        }

        public static void WriteLine(this Writer writer, object obj)
        {
            writer.WriteLine(obj.ToString() ?? throw new ArgumentNullException(nameof(obj)));
        }
    }
}
