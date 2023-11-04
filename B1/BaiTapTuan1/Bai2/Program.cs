namespace Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n;
            Console.WriteLine("Enter the two Positive Integers 'm' and 'n': ");
            Console.Write("'m': ");
            m = int.Parse(Console.ReadLine());
            if (checkNegativeInteger(m))
            {
                Console.WriteLine("m is invalid!");
                Environment.Exit(0);
            }
            Console.Write("'n': ");
            n = int.Parse(Console.ReadLine());
            if (checkNegativeInteger(n))
            {
                Console.WriteLine("m is invalid!");
                Environment.Exit(0);
            }
            Console.WriteLine($"Perimeter of Rectangle is: {perimeter(n, m)}");
            Console.WriteLine($"Acreage of Rectangle is: {acreage(n, m)}");
        }

        static bool checkNegativeInteger(int a)
        {
            return ((Math.Abs(a) / a == -1));
        }

        static double perimeter(int n, int m)
        {
            return ((m + n) * 2);
        }

        static double acreage(int n, int m)
        {
            return m * n;
        }
    }
}
