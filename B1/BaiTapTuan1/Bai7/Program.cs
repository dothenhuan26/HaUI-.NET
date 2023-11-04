namespace Bai7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            if (check(n)) Console.WriteLine("n is a prime number");
            else Console.WriteLine("n is not a prime number");

        }

        static bool check(int n)
        {
            if (n == 1 || n == 0) return false;         
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
