using System.Text;
using System.Globalization;

namespace XepLoaiHS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string name;
            double score;
            Console.Write("Full name: ");
            name = Console.ReadLine();
            Console.Write("Score: ");
            score = double.Parse(Console.ReadLine());
            Console.WriteLine("Full name: " + name.ToUpper());
            Console.WriteLine("Classification: " + classification(score));
        }

        static string classification(double score)
        {
            return (score >= 8) ? "Giỏi" :
                ((score < 8 && score >= 6.5) ? "Khá" :
                ((score < 6.5 && score >= 5) ? "Trung bình" : "Yếu"));
        }
    }
}