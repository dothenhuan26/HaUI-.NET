namespace Bai5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b: ");
            int b = int.Parse(Console.ReadLine());
            Func<int, int, int> res = (a, b) => a-b;
            Console.WriteLine($"Result: {res?.Invoke(a, b)}");


        }
    }
}