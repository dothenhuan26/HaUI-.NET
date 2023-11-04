namespace Bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("123", "nhuan", 9);
            Console.WriteLine(student.Id+"\t"+student.Name+"\t"+student.Mark+"\t"+student.Scholarship);
        }
    }
}