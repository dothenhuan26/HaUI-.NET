using System.Text;

namespace De1_Nhuan_381
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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            fakeData();
            while (true)
            {
                getOption();
                switch (n)
                {
                    case 1:
                        {
                            addNewCustomer();
                            clearData();
                            break;
                        }
                    case 2:
                        {
                            listData();
                            clearData();
                            break;
                        }
                    case 3:
                        {
                            deleteEntry();
                            clearData();
                            break;
                        }
                    case 4:
                        {
                            clearData();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        public static void clearData()
        {
            n = -1;
            x = "";
            flag = false;
            kh = null;
        }
        public static void fakeData()
        {
            list.Add(new KhachHang("nhuan", true, 121, 204));
            list.Add(new KhachHangVIP("nhuan1", false, 122, 120, "vang"));
            list.Add(new KhachHang("nhuan2", false, 123, 220));
            list.Add(new KhachHangVIP("nhuan3", true, 124, 210, "vip"));
        }
        public static void getOption()
        {
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("1.Nhập thông tin.\n2.Hiển thị danh sách.\n3.Xóa khách hàng.\n4.Thoát");
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("Nhập lựa chọn:");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                getOption();
            }
        }
        public static void addNewCustomer()
        {
        loop:
            Console.WriteLine("Chọn loại khách hàng:\n1.Khách hàng.\n2.Khách hàng VIP.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                goto loop;
            }
        LoopName:
            Console.WriteLine("Nhập thông tin khách hàng: ");
            Console.WriteLine("Nhập vào họ tên: ");
            string fullname = Console.ReadLine();
            kh = new KhachHang();
            kh.Fullname = fullname;
            n = list.IndexOf(kh);
            if (n >= 0)
            {
                Console.WriteLine("Tên khách hàng đã tồn tại! Hãy nhập lại.");
                goto LoopName;
            }

        LoopGender:
            Console.WriteLine("Chọn giới tính:\n1.Nam.\n2.Nữ.");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || (n != 1 && n != 2))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Hãy chọn lại.");
                goto LoopGender;
            }
            bool isGender = n == 1 ? true : false;
            Console.WriteLine("Nhập số lượng mua: ");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập đơn giá: ");
            double price = double.Parse(Console.ReadLine());
            if (n == 1)
                kh = new KhachHang(fullname, isGender, amount, price);
            else
            {
                Console.WriteLine("Nhập vào loại khách hàng: ");
                string type = Console.ReadLine();
                kh = new KhachHangVIP(fullname, isGender, amount, price, type);
            }
            list.Add(kh);
        }
        public static void listData()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0, -20}|{1, -20}|{2, -20}|{3, -20}|{4, -20}|{5, -20}|", "Họ tên", "Giới tính", "Số lượng", "Đơn giá", "Loại khách hàng", "Tổng tiền");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine("|{0, -20}|{1, -20}|{2, -20}|{3, -20}|{4, -20}|{5, -20}|", item.Fullname, item.Gender ? "Nam" : "Nữ", item.Amount, item.Price, "", item.Total());
                if (item is KhachHangVIP kh)
                    Console.WriteLine("|{0, -20}|{1, -20}|{2, -20}|{3, -20}|{4, -20}|{5, -20}|", item.Fullname, item.Gender ? "Nam" : "Nữ", item.Amount, item.Price, kh.Type, item.Total());
            }
        }
        public static void deleteEntry()
        {
        LoopFullname:
            Console.WriteLine("Nhập vào tên khách hàng muốn xóa: ");
            string fullname = Console.ReadLine();
            kh = new KhachHang();
            kh.Fullname = fullname;
            n = list.IndexOf(kh);
            if (n < 0)
            {
                Console.WriteLine("Tên khách hàng không tồn tại! Hãy nhập lại: ");
                goto LoopFullname;
            }
            list.RemoveAt(n);
            Console.WriteLine("Xóa thành công!");
        }
    }
}