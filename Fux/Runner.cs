namespace Fux
{
    public class Runner
    {
        protected static void WaitForKey()
        {
            Console.Write("any key ...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}
