namespace OOP1
{
    internal class Program
    {
        static int n = -1;
        static string x = "", hoten = "", diachi = "", manv = "", chucvu = "";
        static double heso = 0;
        static bool flag = false;
        static List<NhanVien> list = new List<NhanVien>();
        static NhanVien nv;
        static void Main(string[] args)
        {
            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            themNhanVien();
                            reset();
                            break;
                        }

                    case 2:
                        {
                            break;
                        }

                    case 3:
                        {
                            break;
                        }

                    case 4:
                        {
                            break;
                        }

                }


            }


        }

        public static void reset()
        {
            n = -1;
            x = "";
            flag = false;
            nv = null;
            hoten = ""; diachi = ""; manv = ""; chucvu = "";
            heso = 0;
        }

        public static void getOption()
        {
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("1.Thêm.\n2.Hiển thị danh sách.\n3.Sắp xếp.\n4.Thoát.");
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("Nhập lựa chọn:");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                getOption();
            }
        }
        public static void themNhanVien()
        {
        loop:
            Console.WriteLine("Nhập vào mã nhân viên:");
            manv = Console.ReadLine();
            nv = new NhanVien();
            nv.Manv = manv;
            n = list.IndexOf(nv);
            if (n >= 0)
            {
                Console.WriteLine("Mã nhân viên đã tồn tại!");
                goto loop;
            }
            else
            {
                Console.WriteLine("Nhập vào họ tên nhân viên:");
                hoten = Console.ReadLine();
                Console.WriteLine("Nhập vào địa chỉ nhân viên:");
                diachi = Console.ReadLine();
                Console.WriteLine("Nhập vào hẹ số nhân viên:");
                heso = double.Parse(Console.ReadLine());
                Console.WriteLine("Nhập vào chức vụ nhân viên:");
                chucvu = Console.ReadLine();
                nv.Hoten = hoten;
                nv.Diachi = diachi;
                nv.Chucvu = chucvu;
                nv.Heso = heso;
                list.Add(nv);
            }
        }

    }
}