using System.Text;

namespace De6_Nhuan_381
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static bool flag = false;
        static List<ThiSinh> list = new List<ThiSinh>();
        static ThiSinh ts;

        static void Main(string[] args)
        {
            fakeData();
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
                            findById();
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Kết thúc chương trình!");
                            Environment.Exit(0);
                            break;
                        }

                }

            }

        }

        public static void fakeData()
        {
            list.Add(new ThiSinh("001", DateTime.Parse("10-26-2023")));
            list.Add(new ThiSinh("002", DateTime.Parse("11-21-2023")));
            list.Add(new ThiSinhChinhSach("003", DateTime.Parse("11-21-2023"), "UT1"));
            list.Add(new ThiSinhChinhSach("004", DateTime.Parse("11-21-2023"), "KV2"));
        }

        public static void getOption()
        {
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("1.Nhập thông tin.\n2.Hiển thị danh sách.\n3.Sửa thông tin.\n4.Thoát.");
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("Hãy nhập lựa chọn:");
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
        LoopAddEntry:
            Console.WriteLine("Chọn thí sinh:\n1.Thí sinh.\n2.Thí sinh chính sách.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                goto LoopAddEntry;
            }
            Console.WriteLine("Nhập vào số báo danh: ");
            string sobaodanh = Console.ReadLine();
        LoopBirthday:
            Console.WriteLine("Nhập vào ngày sinh (Nhập đúng định dạng: ngày-tháng-năm [dd-MM-yyyy]): ");
            string ngaysinh = Console.ReadLine();
            DateTime ngaysinhformat = DateTime.Now;
            try
            {
                ngaysinhformat = DateTime.ParseExact(ngaysinh, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Nhập ngày sinh không hợp lệ! Hãy nhập lại!");
                goto LoopBirthday;
            }
            if (n == 1)
            {
                ts = new ThiSinh(sobaodanh, ngaysinhformat);
            }
            else
            {
                Console.WriteLine("Nhập vào đối tượng ưu tiên: ");
                string uutien = Console.ReadLine();
                ts = new ThiSinhChinhSach(sobaodanh, ngaysinhformat, uutien);
            }
            list.Add(ts);
            Console.WriteLine("Thêm thành công!");
        }

        public static void listAllData()
        {
            if (list.Count > 0)
            {
                Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Số báo danh", "Ngày sinh", "Đối tượng ưu tiên", "Điểm ưu tiên");
                foreach (var item in list)
                {
                    if (item is ThiSinhChinhSach tscs)
                    {
                        Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", item.SoBaoDanh, item.NgaySinh.ToString("MM-dd-yyyy"), tscs.UuTien, tscs.DiemUuTien());
                    }
                    else
                    {
                        Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", item.SoBaoDanh, item.NgaySinh.ToString("MM-dd-yyyy"), "-", "-");
                    }
                }

            }
        }

        public static void findById()
        {
        LoopId:
            Console.WriteLine("Nhập vào số báo danh muốn sửa:");
            string sobaodanh = Console.ReadLine();
            ts = new ThiSinh();
            ts.SoBaoDanh = sobaodanh;
            n = list.IndexOf(ts);

            if (n < 0)
            {
                Console.WriteLine("Thí sinh không tồn tại! Hãy nhập lại.");
                goto LoopId;
            }
            ts = list[n];
            Console.WriteLine("Nhập thông tin cần sửa (Nếu không nhập thì thông tin không thay đổi): ");
        LoopBirthday2:
            Console.WriteLine("Nhập vào ngày sinh (Nhập đúng định dạng: ngày-tháng-năm [dd-MM-yyyy]): ");
            string ngaysinh = Console.ReadLine();
            DateTime ngaysinhformat;
            if (ngaysinh != "")
            {
                try
                {
                    ngaysinhformat = DateTime.ParseExact(ngaysinh, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Nhập ngày sinh không hợp lệ! Hãy nhập lại!");
                    goto LoopBirthday2;
                }
            }
            else
            {
                ngaysinhformat = ts.NgaySinh;
            }
            if (ts is ThiSinhChinhSach tscs)
            {
                Console.WriteLine("Nhập vào đối tượng ưu tiên: ");
                string uutien = Console.ReadLine();
                if (uutien != "") tscs.UuTien = uutien;
            }
            ts.NgaySinh = ngaysinhformat;
        }


    }
}