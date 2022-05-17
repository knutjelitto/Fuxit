using Fux.Input;

namespace Fux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var source = new ConsoleSource();
            var lexer = new Lexer(source);

            while (true)
            {
                lexer.Scan();
            }
        }
    }
}