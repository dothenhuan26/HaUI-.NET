namespace Bai8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());
            for(int i=1; i<=n; i++)
            {
                if (i % 5 == 0) continue;
                Console.WriteLine(i);
            }
        }
    }
}
