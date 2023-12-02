namespace Bai4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number a: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b: ");
            int b = int.Parse(Console.ReadLine());

            Func<int, int, int> res = delegate (int a, int b)
            {
                return a + b;
            };
           
            Console.Write("Result: ");
            Console.WriteLine(res?.Invoke(a, b));
        }


    }
}