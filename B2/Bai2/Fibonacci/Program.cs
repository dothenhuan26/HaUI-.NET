using System.Text;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int n;
            Console.WriteLine("Nhập vào số nguyên n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Dãy Fibonacci của {n} số nguyên đầu tiên là: ");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"{fibonacci(i)}\t");
            }
        }

        public static int fibonacci(int x)
        {
            if (x <= 2 && x >= 0)
            {
                return 1;
            }
            return fibonacci(x - 1) + fibonacci(x - 2);
        }
    }



}



