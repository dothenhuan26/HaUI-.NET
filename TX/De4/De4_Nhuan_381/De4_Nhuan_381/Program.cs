using System.Security.Cryptography;
using System.Text;

namespace De4_Nhuan_381
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static bool flag = false;
        static List<NhanVien> list = new List<NhanVien>();
        static NhanVien nv;
        static DateTime dft = DateTime.Now;
        static void Main(string[] args)
        {

            list.Add(new NhanVien("nhuan", DateTime.Parse("11-23-2023")));
            list.Add(new NhanVien("nhuan1", DateTime.Parse("09-21-2023")));
            list.Add(new NhanVienBanHang("nhuan2", DateTime.Parse("01-11-2013"), 200));
            list.Add(new NhanVienBanHang("nhuan3", DateTime.Parse("07-09-2023"), 599));

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            addNewEntry();
                            break;
                        }

                    case 2:
                        {
                            listAllData();
                            break;
                        }

                    case 3:
                        {
                            sortList();
                            break;
                        }

                    case 4:
                        {
                            break;
                        }
                }
            }
        }

        public static void getOption()
        {
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("1.Nhập thông tin.\n2.Hiển thị danh sách.\n3.Sắp xếp.\n4.Thoát");
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("Nhập lựa chọn: ");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                getOption();
            }
        }

        public static void addNewEntry()
        {
        LoopNewEntry:
            Console.WriteLine("Chọn nhân viên:\n1.Nhân viên.\n2.Nhân viên bán hàng.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                goto LoopNewEntry;
            }

            Console.WriteLine("Nhập vào họ tên nhân viên: ");
            string fullname = Console.ReadLine();
        LoopDateTime:
            Console.WriteLine("Nhập vào ngày tuyển dụng(Bắt buộc nhập theo định \"dạng Ngày-Tháng-Năm\" [dd-MM-yyyyy]): ");
            string datetime = Console.ReadLine();
            DateTime dftformat = DateTime.Now;
            try
            {
                dftformat = DateTime.ParseExact(datetime, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ngày tuyển dụng không hợp lệ! Hãy nhập lại.");
                goto LoopDateTime;
            }
            if (n == 1)
            {
                nv = new NhanVien(fullname, dftformat);
            }
            else
            {
                Console.WriteLine("Nhập vào số lượng bán: ");
                int total = int.Parse(Console.ReadLine());
                nv = new NhanVienBanHang(fullname, dftformat, total);
            }
            list.Add(nv);
            Console.WriteLine("Thêm thành công!");
        }

        public static void listAllData()
        {
            if (list != null)
            {
                Console.WriteLine($"{"Họ tên",-20}{"Ngày tuyển dụng",-20}{"Số lượng",-20}{"Tiền hoa hồng",-20}");
                foreach (var item in list)
                {
                    if (item is NhanVienBanHang nvbh)
                    {
                        Console.WriteLine($"{item.Fullname,-20}{item.Dateapply.ToString("dd-MM-yyyy"),-20}{nvbh.Total,-20}{nvbh.Bonus()}");

                    }
                    else
                    {
                        Console.WriteLine($"{item.Fullname,-20}{item.Dateapply.ToString("dd-MM-yyyy"),-20}{'-',-20}{'-',-20}");
                    }
                }
            }
        }

        public static void sortList()
        {
            list.Sort((a, b) =>
            {
                if (a.Dateapply.Equals(b.Dateapply))
                {
                    return a.Fullname.CompareTo(b.Fullname);
                }
                return a.Dateapply.CompareTo(b.Dateapply);
            });
            Console.WriteLine("Sắp xếp danh sách thành công!");
        }

    }
}