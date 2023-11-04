namespace DoTheNhuan_2021600381_proj63
{
    internal class Program
    {
        static int n = -1;
        static string x = "";
        static Course course;
        static bool flag = false;
        static List<Course> list = new List<Course>();
        static void Main(string[] args)
        {
            while (true)
            {
                getOption();

                switch (n)
                {
                    case 1:
                        {
                            addNewCourse();
                            reset();
                            break;
                        }

                    case 2:
                        {
                            listCourse();
                            reset();
                            break;
                        }

                    case 3:
                        {
                            findCourseById();
                            reset();
                            break;
                        }

                    case 4:
                        {
                            findStudentById();
                            reset();

                            break;
                        }

                    case 5:
                        {
                            deleteCourseById();
                            reset();

                            break;
                        }

                    case 6:
                        {
                            reset();
                            Console.WriteLine("End.");
                            Environment.Exit(0);
                            break;
                        }
                }


            }


        }

        public static void reset()
        {
            n = -1;
            x = "";
            course = null;
            flag = false;
        }

        public static void getOption()
        {
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("1.Add new Course.\n2.List Course.\n3.Find Course by Id.\n4.Find Student by Id.\n5.Delete Course by Id.\n6.End.");
            Console.WriteLine("*===============[MENU]===============*");
            Console.WriteLine("Your Choice: ");
            x = Console.ReadLine();
            flag = int.TryParse(x, out n);
            if (!flag || n < 1 || n > 6)
            {
                Console.WriteLine("N is not valid!");
                getOption();
            }
        }

        public static void addNewCourse()
        {
            course = new Course();
            course.inputCourse();
            list.Add(course);
        }

        public static void listCourse()
        {
            foreach (var c in list)
            {
                c.DisplayCourseAndStudents();
            }
        }

        public static void findCourseById()
        {
            Console.WriteLine("Enter the Course Id: ");
            x = Console.ReadLine();
            course = new Course();
            course.Courseid = x;
            n = list.IndexOf(course);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                list[n].DisplayCourseAndStudents();
            }
        }

        public static void findStudentById()
        {
            Console.WriteLine("Enter the Student Id: ");
            n = int.Parse(Console.ReadLine());
            foreach (var c in list)
            {
                if ((c.findStudentById(n)) != null)
                {
                    Console.WriteLine(c.ToString());
                    Console.WriteLine((c.findStudentById(n)).ToString());
                }
            }
        }

        public static void deleteCourseById()
        {
            Console.WriteLine("Enter the Course Id: ");
            x = Console.ReadLine();
            course = new Course();
            course.Courseid = x;
            n = list.IndexOf(course);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                list.RemoveAt(n);
                Console.WriteLine("Deleted Successfully!");
            }
        }


    }
}