namespace Fux.Tools
{
    public static class WriterExtensions
    {
        private const string top = "Fux";

        public static string File(string filename)
        {
            var path = Path.Combine(Temp.TempPath(top), filename);
            var dir = Path.GetDirectoryName(path)!;
            Directory.CreateDirectory(dir);

            return path;
        }

        public static Writer Writer(this string filename, int? indent = null)
        {
            return new Writer(File(filename), indent);
        }
    }
}
