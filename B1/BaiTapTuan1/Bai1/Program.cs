namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value of integer 'n': ");
            int n = int.Parse(Console.ReadLine());

            //Cau a
            if(!checkNegative(n))
                Console.WriteLine("'n' is the "+(checkOdd(n)?"Odd":"Even")+" Number");
            Console.WriteLine("'n' is the "+(checkNegative(n)?"Negative":"Positive")+" Number");

        }

        static bool checkOdd(int n)
        {
            return (n%2!=0);
        }

        static bool checkNegative(int n)
        {
            return (Math.Abs(n) / n == -1);
        }
    }
}
