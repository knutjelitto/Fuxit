namespace Fux
{
    internal class Runner
    {
        protected static void WaitForKey()
        {
            Console.Write("any key ...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}
