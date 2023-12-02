using System.Text;

namespace TX1Struct
{
    internal class Program
    {

        static int n = -1;
        static bool flag = false;
        static string x = "";
        double salary;
        static List<NhanVien> list = new List<NhanVien>();
        static NhanVien nhanVien;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            list.Add(new NhanVien("Nhuan 1", "Ha noi", "123","phó giám đốc", 500));
            list.Add(new NhanVien("Nhuan 2", "Ha noi", "123","giám đốc", 2000));
            list.Add(new NhanVien("Nhuan 3", "Ha noi", "123","trưởng phòng", 400));
            while (true)
            {
                getSelection();

                switch (n)
                {
                    case 1:
                        {
                            nhanVien = new NhanVien();
                        loop:
                            nhanVien.input();
                            foreach (var obj in list)
                            {
                                if (obj.Id.Equals(nhanVien.Id))
                                {
                                    Console.WriteLine("Mã nhân viên đã tồn tại! Vui lòng nhập lại:");
                                    goto loop;
                                }
                            }
                            list.Add(nhanVien);
                            break;
                        }
                    case 2:
                        {
                            NhanVien.outputHeading();
                            foreach (var obj in list)
                            {
                                obj.output();
                            }
                            break;
                        }
                    case 3:
                        {
                            List<NhanVien> listCP = new List<NhanVien>(list);
                            NhanVien.outputHeading();
                            listCP.Sort();
                            foreach (var obj in listCP)
                            {
                                obj.output();
                            }
                            listCP.Clear();
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

        public static void getSelection()
        {
            Console.WriteLine("*================[MENU]================");
            Console.WriteLine("1.Thêm nhân viên.\n2.Hiển thị danh sách nhân viên.\n3.Sắp xếp danh sách.\n4.Thoát.");
            Console.WriteLine("*================[MENU]================");
            Console.WriteLine("Chọn: ");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 4)
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                getSelection();
            };
        }




    }
}