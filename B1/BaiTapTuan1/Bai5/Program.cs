using System.Text;

namespace Bai5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string[] weeks = new string[] { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };

            Console.Write("Enter a number from 1 to 7: ");
            Console.WriteLine("this is: " + weeks[(int.Parse(Console.ReadLine())) - 1]);

        }
    }
}
