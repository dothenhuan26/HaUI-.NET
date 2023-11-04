namespace HeCoSo
{
    internal class Program
    {
        static char[] x = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F' , 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
        'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z', 'W'};
        static void Main(string[] args)
        {
            int n, b;
            Console.WriteLine("Nhap vao so nguyen n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao co so b: ");
            b = int.Parse(Console.ReadLine());
            List<char> list = new List<char>();

            while (n >= b)
            {
                list.Add(x[n % b]);
                n = n / b;
            }
            list.Add(x[n]);
            list.Reverse();

            foreach (char c in list)
            {
                Console.Write($"{c}\t");
            }
        }

    }
}