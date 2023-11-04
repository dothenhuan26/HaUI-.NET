using System.Numerics;

namespace DoTheNhuan_2021600381_Bai53
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vehicles test = new Vehicles("123", "Honda", "8 banh", 2022, "Xe tai");
            //Console.WriteLine(test.ToString());
            //Car car = new Car("1234", "Honda", "8 banh", 2022, "Xe cho nguoi", 8);
            //Console.WriteLine(car.ToString());
            //Truck trunk = new Truck("12345", "Merc", "4 banh", 2023, "Xe cho nguoi", 1000);
            //Console.WriteLine(trunk.ToString());

            int t;
            List<Vehicles> list = new List<Vehicles>();

            do
            {
                Console.WriteLine("*============ [MENU]============*");
                Console.WriteLine("1.Chon doi tuong muon nhap." +
                    "\n2.Hien thi thong tin vua nhap." +
                    "\n3.Tim doi tuong theo id." +
                    "\n4.Tim doi tuong theo maker." +
                    "\n5.Hien thi danh sach sap xep theo model." +
                    "\n6.Hien thi danh sach sap xep theo nam san xuat." +
                    "\n7.Ket thuc chuong trinh!");

                Console.WriteLine("*============ [MENU]============*");

                Console.Write("Nhap lua chon cua ban: ");
                t = int.Parse(Console.ReadLine());
                Vehicles test = null;

                switch (t)
                {
                    case 1:
                        {
                            int n;
                            Console.WriteLine("Chon loai xe can nhap: ");
                            Console.WriteLine("1.Car\n2.Truck");
                            Console.Write("Ban chon: ");
                            n = int.Parse(Console.ReadLine());
                            Vehicles obj = new Vehicles();
                            //if (n == 1)
                            //{
                            //    obj = new Car();
                            //}
                            //else if (n == 2)
                            //{
                            //    obj = new Truck();
                            //}
                            baseEntry(obj);

                            if (n == 1)
                            {
                                Car car = obj as Car;
                                Console.WriteLine("Nhap vao Seats: ");
                                car.Seats = int.Parse(Console.ReadLine());
                                test = car;

                                list.Add(car);
                            }
                            else if (n == 2)
                            {
                                Truck truck = obj as Truck;
                                Console.WriteLine("Nhap vao Load: ");
                                truck.Load = int.Parse(Console.ReadLine());
                                test = truck;

                                list.Add(truck);
                            }
                            break;
                        };
                    case 2:
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);

                            }
                            break;
                        }
                }



            } while (t >= 0 && t <= 7);



        }

        public static void baseEntry(Vehicles obj)
        {
            Console.WriteLine("Nhap vao Id: ");
            obj.Id = Console.ReadLine();
            Console.WriteLine("Nhap vao Maker: ");
            obj.Maker = Console.ReadLine();
            Console.WriteLine("Nhap vao Model: ");
            obj.Model = Console.ReadLine();
            Console.WriteLine("Nhap vao Year: ");
            obj.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao Type: ");
            obj.Type = Console.ReadLine();
        }


    }
}