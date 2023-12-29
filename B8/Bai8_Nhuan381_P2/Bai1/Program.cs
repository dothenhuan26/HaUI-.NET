namespace Bai1
{
    internal class Program
    {
        public delegate int Result(int a, int b); 


        static void Main(string[] args)
        {
            Console.WriteLine("Enter number a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b: ");
            int b = int.Parse(Console.ReadLine());

            Result res;
            res = sum;
            Console.Write("Result: ");
            Console.WriteLine(res?.Invoke(a, b));

        }


        public static int sum(int a, int b) => a + b;
    }
}