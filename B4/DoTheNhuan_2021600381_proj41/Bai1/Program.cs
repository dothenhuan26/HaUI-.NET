using System.Text;

namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Person person = new Person();
            person.input();
            person.outputHeading();
            person.output();


        }
    }
}