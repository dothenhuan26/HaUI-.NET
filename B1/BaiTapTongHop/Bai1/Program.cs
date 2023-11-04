namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 'm': ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter 'n': ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: {0:F3}", ((double)m/n));


        }

    }
}
