namespace Bai6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;

            do
            {
                Console.Write("Enter a integer : ");
                n = int.Parse(Console.ReadLine());
            } while (Math.Abs(n)/n == -1);


        }
    }
}
