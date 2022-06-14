namespace Fux.Tools
{
    public static class Terminal
    {
        public static void Write(string s)
        {
            Console.Write(s);
        }

        public static void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void GoHome()
        {
            CSI("H");
        }

        public static void ClearHome()
        {
            CSI("2J");
            CSI("H");
        }

        public static void ClearToEol()
        {
            CSI("K");
        }

        private static void CSI(string seq)
        {
            Write($"\u001B[{seq}");
        }
    }
}
