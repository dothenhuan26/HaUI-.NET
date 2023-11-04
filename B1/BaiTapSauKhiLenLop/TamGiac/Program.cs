namespace TamGiac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Enter a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Enter c: ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine("S: {0:F3}", heron(a, b, c));

        }

        static double heron(int a, int b, int c)
        {
            double p = halfCircumference(a, b, c);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static double halfCircumference(int a, int b, int c)
        {
            return ((double)a + b + c) / 2;
        }
    }
}