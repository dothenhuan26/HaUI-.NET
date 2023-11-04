using System.Text;

namespace DoTheNhuan_2021600381_proj61
{
    internal class Program
    {
        static int n = -1, id = -1;
        static string x = "", address = "";
        static bool flag = false;
        static List<Student> list = new List<Student>();
        static Student st;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            list.Add(new Student("Nhuan", "ha noi", 7, 9));
            list.Add(new Student("Nhuan2", "ha nam", 7, 6));
            list.Add(new Student("Nhuan3", "ha tinh", 3, 9));
            list.Add(new Student("Nhuan4", "vinh phuc", 2, 8));
            list.Add(new Student("Nhuan5", "thai nguyen", 8, 1));

            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            addNewStudent();
                            break;
                        }

                    case 2:
                        {
                            listStudent();
                            break;
                        }

                    case 3:
                        {
                            if ((st = findById()) != null)
                                st.output();
                            st = null;
                            break;
                        }

                    case 4:
                        {
                            if ((st = findByAddress()) != null)
                                findByAddress().output();
                            st = null;
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine(deleteById() ? "success!" : "fail!");
                            st = null;
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine("Ket thuc ctrinh!");
                            break;
                        }
                }

            }


        }
        public static void getOption()
        {
            Console.WriteLine("*====================[MENU]====================*");
            Console.WriteLine("1.Them 1 sinh vien.\n2.Hien thi danh sach sinh vien.\n3.Tim kiem sinh vien theo id.\n4.Tim kiem sinh vien theo address.\n5.Xoa mot sinh vien theo id.\n6.Ket thuc chuong trinh.");
            Console.WriteLine("*====================[MENU]====================*");
            Console.WriteLine("Lựa chọn:");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 6)
            {
                Console.WriteLine("Lụa chọn không hợp lệ! Chọn lại!");
                getOption();
            }
        }

        public static void addNewStudent()
        {
            st = new Student();
            st.input();
            list.Add(st);
        }

        public static void listStudent()
        {
            foreach (Student student in list)
            {
                student.output();
            }
        }

        public static Student findById()
        {
            try
            {
                Console.WriteLine("Nhap vao id muon tim: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var i in list)
            {
                if (i.Id.Equals(id))
                {
                    st = i;
                }
            }
            id = -1;
            if (st != null)
            {
                return st;
            }
            return null;
        }

        public static Student findByAddress()
        {
            try
            {
                Console.WriteLine("Nhap vao address muon tim: ");
                address = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var i in list)
            {
                if (i.Address.Equals(address))
                {
                    st = i;
                }
            }
            id = -1;
            if (st != null)
            {
                return st;
            }
            return null;
        }

        public static bool deleteById()
        {
            try
            {
                Console.WriteLine("Nhap vao id muon xoa: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var i in list)
            {
                if (i.Id.Equals(id))
                {
                    st = i;
                }
            }
            id = -1;
            return list.Remove(st);
        }
    }
}