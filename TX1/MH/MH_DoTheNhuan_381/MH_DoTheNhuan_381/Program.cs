using System.Text;

namespace MH_DoTheNhuan_381
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static List<KhachHang> list = new List<KhachHang>();
        static bool flag = false;
        static KhachHang khachHang;
        static string id, fullname;
        static int quantity;
        static double price;
        static int top = 0;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            list.Add(new KhachHang("123", "Nhuan", 10, 1200));
            list.Add(new KhachHangVIP("124", "Nhuan1", 14, 1700));
            list.Add(new KhachHang("125", "Nhuan2", 58, 2200));
            list.Add(new KhachHang("126", "Nhuan3", 21, 4200));
            list.Add(new KhachHangVIP("127", "Nhuan4", 5, 5200));

            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            inputData();
                            break;
                        }

                    case 2:
                        {
                            outputData();
                            break;
                        }

                    case 3:
                        {
                            findRichPersonals();
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
            Console.WriteLine("*===============[MENU]*===============");
            Console.WriteLine("1.Nhập thông tin.\n2.Hiển thị danh sách.\n3.Tìm khách hàng.\n4.Thoát");
            Console.WriteLine("*===============[MENU]*===============");
            Console.WriteLine("Lựa chọn: ");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                getOption();
            }
        }

        public static void inputData()
        {
            Console.WriteLine("Chọn loại khách hàng:\n1.Khách hàng.\n2.Khách hàng VIP.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Chọn lại khách hàng:");
                inputData();
            }
        loop:
            Console.WriteLine("Nhập mã khách hàng: ");
            id = Console.ReadLine();
            foreach (var obj in list)
            {
                if (obj.Id.Equals(id))
                {
                    Console.WriteLine("Mã khách hàng đã tồn tại!");
                    goto loop;
                }
            }
            Console.WriteLine("Nhập họ tên:");
            fullname = Console.ReadLine();
            Console.WriteLine("Nhập số lượng:");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập đơn giá:");
            price = double.Parse(Console.ReadLine());
            if (n == 1) khachHang = new KhachHang(id, fullname, quantity, price); else khachHang = new KhachHangVIP(id, fullname, quantity, price);
            list.Add(khachHang);
        }

        public static void outputData()
        {
            Console.WriteLine("Danh sách khách hàng:");
            foreach (var obj in list)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        public static void findRichPersonals()
        {
            foreach (var obj in list)
            {
                if (top < obj.Quantity)
                {
                    top = obj.Quantity;
                }
            }

            foreach (var obj in list)
            {
                if (obj.Quantity == top)
                {
                    Console.WriteLine(obj.ToString());
                }
            }

        }



    }
}