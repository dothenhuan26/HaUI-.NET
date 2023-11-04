namespace Bai4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bacLuong;
            int ngayCong;
            double phuCap;

            Console.Write("Enter the 'BacLuong': ");
            bacLuong = double.Parse(Console.ReadLine());
            Console.Write("Enter the 'NgayCong': ");
            ngayCong = int.Parse(Console.ReadLine());
            Console.Write("Enter the 'PhuCap': ");
            phuCap = double.Parse(Console.ReadLine());

            Console.Write("TienLinh: " + tienLinh(bacLuong, ngayCong, phuCap));

        }

        static double tienLinh(double a, double b, double c)
        {
            if (b < 25)
            {
                return a * 1490000 * b + c;
            }
            return a * 1490000 * (25 + (b - 25) * 2) + c;
        }
    }
}
