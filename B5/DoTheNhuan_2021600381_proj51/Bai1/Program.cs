
using System.Collections;
using System.Net;
using System.Text;

namespace Bai1
{
    internal class Program
    {
        static int n = -1;
        static string t = "";
        static bool flag = false;
        static List<ThiSinhA> list = new List<ThiSinhA>();

        static void Main(string[] args)
        {

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                getOptions();
                handle();

            } while (n >= 1 && n <= 6);

        }

        static void getOptions()
        {
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("1.Nhập thông tin 1 thí sinh\n" +
                "2.Hiển thị danh sách các thí sinh\n" +
                "3.Hiển thị các sinh viên theo tổng điểm\n" +
                "4.Hiển thị các sinh viên theo địa chỉ\n" +
                "5.Tìm kiếm theo số báo danh\n" +
                "6.Kết thúc chương trình.");
            Console.WriteLine("*===============[MENU]===============*");
            checkOption();
        }

        static void checkOption()
        {
            Console.WriteLine("Lựa chọn của bạn là: ");
            t = Console.ReadLine();
            flag = int.TryParse(t, out n);
            if (!flag || n < 1 || n > 6)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lựa chọn không hợp lệ!");
                Console.ResetColor();
                getOptions();
            }
            return;
        }

        static void handle()
        {
            switch (n)
            {
                case 1:
                    {
                        ThiSinhA tsa = new ThiSinhA();
                        tsa.input();
                        list.Add(tsa);
                        break;
                    }
                case 2:
                    {
                        ThiSinhA.outputHeading();
                        foreach (var tsa in list)
                        {
                            tsa.output();
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Nhập tổng điểm: ");
                        double total = double.Parse(Console.ReadLine());
                        ThiSinhA.outputHeading();
                        foreach (var tsa in list)
                        {
                            if (tsa.Total >= total)
                            {
                                tsa.output();
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Nhập địa chỉ: ");
                        string address = Console.ReadLine();
                        ThiSinhA.outputHeading();
                        foreach (var tsa in list)
                        {
                            if (tsa.Address.Equals(address))
                            {
                                tsa.output();
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Nhập số báo danh: ");
                        string id = "";
                        id = Console.ReadLine();
                        ThiSinhA.outputHeading();
                        //var tsa = list.Where(tsa => tsa.Id == id).FirstOrDefault();
                        //Console.WriteLine(tsa);

                        foreach (var tsa in list)
                        {
                            if (tsa.Id.Equals(id))
                            {
                                tsa.output();
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Kết thúc chương trình!");
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}