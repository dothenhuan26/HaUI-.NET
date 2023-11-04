using System.Text;

namespace De2_Nhuan_381
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static bool flag = false;
        static List<KhachHang> list = new List<KhachHang>();
        static KhachHang kh;

        static void Main(string[] args)
        {
            list.Add(new KhachHang("001", DateTime.Parse("12-24-2021"), 20, 200));
            list.Add(new KhachHang("002", DateTime.Parse("05-24-0997"), 20, 200));
            list.Add(new KhachHang("003", DateTime.Parse("06-24-2021"), 20, 200));
            list.Add(new KhachHangVIP("004", DateTime.Parse("07-21-2025"), 210, 2200));
            list.Add(new KhachHang("005", DateTime.Parse("12-24-2021"), 20, 200));
            list.Add(new KhachHangVIP("006", DateTime.Parse("03-21-2035"), 210, 90));
            list.Add(new KhachHangVIP("007", DateTime.Parse("09-21-2012"), 110, 400));
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
                            findMaxAmount();
                            break;
                        }

                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

            }

        }



        public static void getOption()
        {
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("1.Nhập thông tin.\n2.Hiển thị danh sách.\n3.Tìm khách hàng.\n4.Thoát.");
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("Hãy nhập lựa chọn:");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                getOption();
            }
        }

        public static void addNewEntry()
        {
        LoopChoose:
            Console.WriteLine("Chọn khách hàng:\n1.Khách hàng.\n2.Khách hàng vip.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                goto LoopChoose;
            }
            if (n == 1)
            {
                kh = new KhachHang();
            }
            else
            {
                kh = new KhachHangVIP();
            }
            Console.WriteLine("Nhập vào mã khách hàng: ");
            kh.Id = Console.ReadLine();
        LoopBirthday:
            Console.WriteLine("Nhập vào ngày sinh (Theo đúng định dạnh Ngày[dd]-Tháng[MM]-Năm[yyyy]):");
            x = Console.ReadLine();
            DateTime birthday = DateTime.Now;
            try
            {
                birthday = DateTime.ParseExact(x, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Ngày sinh không hợp lệ! Hãy nhập lại.");
                goto LoopBirthday;
            }
            kh.Birthday = birthday;
            Console.WriteLine("Nhập vào số lượng mua: ");
            kh.Amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập vào đơn giá: ");
            kh.Price = double.Parse(Console.ReadLine());
            list.Add(kh);
            Console.WriteLine("Thêm thành công!");
        }


        public static void listAllData()
        {
            if (list != null)
            {
                Console.WriteLine($"{"Mã khách hàng",-20}{"Ngày sinh",-20}{"Số lượng mua",-20}{"Đơn giá",-20}{"Giảm giá",-20}{"Tổng tiền",-20}");

                foreach (var item in list)
                {
                    if (item is KhachHangVIP vip)
                    {
                        Console.WriteLine($"{item.Id,-20}{item.Birthday.ToString("dd-MM-yyyy"),-20}{item.Amount,-20}{item.Price,-20}{vip.percent(),-20}{vip.total(),-20}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Id,-20}{item.Birthday.ToString("dd-MM-yyyy"),-20}{item.Amount,-20}{item.Price,-20}{"-",-20}{item.total(),-20}");

                    }
                }

            }

        }

        public static void findMaxAmount()
        {
            List<KhachHang> test = new List<KhachHang>(list);

            test.Sort((a, b) =>
            {
                return a.Amount.CompareTo(b.Amount);
            });

            int max_amount = test[list.Count() - 1].Amount;
            foreach (var item in test)
            {
                if (item.Amount == max_amount)
                {
                    if (item is KhachHangVIP vip)
                    {
                        Console.WriteLine($"{item.Id,-20}{item.Birthday.ToString("dd-MM-yyyy"),-20}{item.Amount,-20}{item.Price,-20}{vip.percent(),-20}{vip.total(),-20}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Id,-20}{item.Birthday.ToString("dd-MM-yyyy"),-20}{item.Amount,-20}{item.Price,-20}{"-",-20}{item.total(),-20}");

                    }
                }
            }
        }
    }
}