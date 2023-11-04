namespace CauTruc
{
    internal class Program
    {
        static string fullname;
        static int age;
        static bool gender;
        static int x;
        struct HocSinh
        {
            public string _fullname;
            public int _age;
            public bool _gender;
            public HocSinh(string fullname, int age, bool gender)
            {
                _fullname = fullname;
                _age = age;
                _gender = gender;
            }
        }


        static void Main(string[] args)
        {
            HocSinh[] hs = new HocSinh[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nhap vao ho ten: ");
                fullname = Console.ReadLine();
                Console.WriteLine("Nhap vao tuoi:");
                age = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap vao gioi tinh:\n1.Nam.\n2.Nu.");
                x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    gender = true;
                }
                else
                {
                    gender = false;
                }

                hs[i] = new HocSinh(fullname, age, gender);
            }

            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                sum += hs[i]._age;
            }
            Console.WriteLine(sum);
        }
    }
}