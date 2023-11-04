namespace TongChuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 'n': ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Result a: " + res1(n));
            Console.WriteLine("Result b: " + res2(n));


        }

        static double res1(int n)
        {
            if (n == 0) return 0;
            return n + res1(n - 1);
        }

        static double res2(int n)
        {
            if (n == 1) return 1;
            return (double)1 / n + res2(n - 1);

        }
    }
}