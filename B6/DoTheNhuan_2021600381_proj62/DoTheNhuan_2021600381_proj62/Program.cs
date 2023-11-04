using System.Collections;

namespace DoTheNhuan_2021600381_proj62
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static bool flag = false;
        static List<Vehicle> list = new List<Vehicle>();
        static Vehicle v;
        static void Main(string[] args)
        {
            list.Add(new Vehicle("001", "v1", "honda", 2022, 5000));
            list.Add(new Vehicle("009", "v1", "hond", 21022, 51000));
            list.Add(new Vehicle("007", "v1", "hosds", 20223, 35000));
            list.Add(new Vehicle("008", "v1", "honda", 2022, 25000));
            list.Add(new Vehicle("002", "v2", "samsung", 2018, 6000));
            list.Add(new Car("003", "v3", "Suzuki", 2012, 15000, "Red"));
            list.Add(new Car("004", "v5", "Subaru", 2012, 25000, "Green"));
            list.Add(new Truck("005", "v5", "Huyndai", 2023, 55000, 1000));
            list.Add(new Truck("006", "v6", "Merce", 2023, 65000, 3000));


            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            addNewVehicle();
                            reset();
                            break;
                        }

                    case 2:
                        {
                            listAllData();
                            reset();
                            break;
                        }

                    case 3:
                        {
                            if ((v = findById()) != null)
                                v.Output();
                            reset();
                            break;
                        }

                    case 4:
                        {
                            findByMaker();
                            reset();
                            break;
                        }

                    case 5:
                        {
                            sortByPrice();
                            reset();
                            break;
                        }

                    case 6:
                        {
                            sortByYear();
                            reset();

                            break;
                        }

                    case 7:
                        {
                            deleteById();
                            reset();
                            break;
                        }

                    case 8:
                        {
                            updateById();
                            reset();
                            break;
                        }

                    case 9:
                        {
                            sortByYearThenPrice();
                            reset();
                            break;
                        }

                    case 10:
                        {
                            reset();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }


        public static void getOption()
        {
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("1.Add New Vehicle.\n2.List All Data.\n3.Find by Id.\n4.Find by Maker.\n5.Sort by Price.\n6.Sort by Year.\n7.Delete by Id.\n8.Edit by Id.\n9.Sort by Year(then by Price).\n10.End.");
            Console.WriteLine("*================[MENU]================*");
            Console.WriteLine("Choose: ");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your choice is not valid!");
                Console.ResetColor();
                getOption();
            }
        }

        public static void reset()
        {
            n = -1;
            x = "";
            flag = false;
            v = null;
        }

        public static void addNewVehicle()
        {
        loop:
            Console.Write("Choose the type of Vehicle:\n1.Car.\n2.Truck.");
            n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                v = new Car();
                v.Input();
            }
            else if (n == 2)
            {
                v = new Truck();
                v.Input();
            }
            else
            {
                Console.WriteLine("Your choice is not Valid!");
                goto loop;
            }
            list.Add(v);
        }

        public static void listAllData()
        {
            Console.WriteLine("List All Data:");
            foreach (var obj in list)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        public static Vehicle findById()
        {
            Console.WriteLine("Enter the id: ");
            x = Console.ReadLine();
            v = new Vehicle(x);
            n = list.IndexOf(v);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
                return null;
            }
            return list[n];
        }

        public static void findByMaker()
        {
            Console.WriteLine("Enter the Maker:");
            x = Console.ReadLine();
            n = 0;
            foreach (var obj in list)
            {
                if (obj.Maker.Equals(x))
                {
                    Console.WriteLine(obj.ToString());
                    n++;
                }
            }
            if (n == 0) { Console.WriteLine("Not Found!"); };
        }


        public static void sortByPrice()
        {
            Console.WriteLine("Before sorting: ");
            listAllData();
            list.Sort();
            Console.WriteLine("After sorting: ");
            listAllData();
        }

        public static void sortByYear()
        {
            Console.WriteLine("Before sorting: ");
            listAllData();
            list.Sort(new CompareByYear());
            Console.WriteLine("After sorting: ");
            listAllData();
        }

        public static void sortByYearThenPrice()
        {
            Console.WriteLine("Before sorting: ");
            listAllData();
            list.Sort(new CompareByYearThenPrice());
            Console.WriteLine("After sorting: ");
            listAllData();
        }

        public static void deleteById()
        {
            Console.WriteLine("Enter the id: ");
            x = Console.ReadLine();
            v = new Vehicle(x);
            n = list.IndexOf(v);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                list.RemoveAt(n);
                Console.WriteLine("Success!");
            }

        }

        public static void updateById()
        {
            Console.WriteLine("Update vehicle: ");
            Console.WriteLine("Enter the id: ");
            x = Console.ReadLine();
            v = new Vehicle(x);
            n = list.IndexOf(v);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                v = list[n];
                Console.WriteLine($"Update info of vehicle: {x}");
                Console.WriteLine("Enter the Maker:");
                v.Maker = ((x = Console.ReadLine()) != "") ? x : v.Maker;
                Console.WriteLine("Enter the Model:");
                v.Model = ((x = Console.ReadLine()) != "") ? x : v.Model;
                Console.WriteLine("Enter the Year:");
                v.Year = int.Parse(((x = Console.ReadLine()) != "") ? x : v.Year + "");
                Console.WriteLine("Enter the Price:");
                v.Price = double.Parse(((x = Console.ReadLine()) != "") ? x : v.Price + "");
                if (v is Car)
                {
                    Car car = v as Car;
                    Console.WriteLine("Enter the Color:");
                    car.Color = ((x = Console.ReadLine()) != "") ? x : car.Color;
                }
                else if (v is Truck)
                {
                    Truck truck = v as Truck;
                    Console.WriteLine("Enter the Truckload:");
                    truck.Truckload = int.Parse(((x = Console.ReadLine()) != "") ? x : truck.Truckload + "");
                }
            }
        }

    }

    class CompareByYearThenPrice : IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            if (x.Year == y.Year)
            {
                return (int)(x.Price - y.Price);
            };
            return (int)(x.Year - y.Year);
        }
    }


    class CompareByYear : IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            return x.Year - y.Year;
        }
    }


}