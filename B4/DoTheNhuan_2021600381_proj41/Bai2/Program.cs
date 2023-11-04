using System.Text;

namespace Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập vào bán kính hình tròn: ");
            Circle circle = new Circle(double.Parse(Console.ReadLine()));
            Console.WriteLine("Chu vi hình tròn là: {0:F3}", circle.Perimeter());
            Console.WriteLine("Diện tích hình tròn là: {0:F3}", circle.Area());
        }
    }
}