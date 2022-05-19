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
            var parser = new Parser(layouter);

            while (true)
            {
                var expr = parser.Statement();
                Console.WriteLine($"{expr}");
            }
        }
    }
}