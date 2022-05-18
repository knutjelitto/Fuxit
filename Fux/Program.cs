using Fux.Input;

namespace Fux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var source = new ConsoleSource();
            var lexer = new Lexer(source);
            var layouter = new Layouter(lexer);

            while (true)
            {
                var token = layouter.Next();
                Console.WriteLine($"{token}");
            }
        }
    }
}