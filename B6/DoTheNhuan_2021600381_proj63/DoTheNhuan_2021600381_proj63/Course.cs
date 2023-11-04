using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj63
{
    internal class Course
    {
        private string courseid;
        private string coursename;
        private int free;
        private List<Student> li;

        public Course()
        {
            li = new List<Student>();
        }

        public List<Student> Li
        {
            get { return li; }
            set { }
        }

        public int Free
        {
            get { return free; }
            set { free = value; }
        }

        public string MyProperty
        {
            get { return coursename; }
            set { coursename = value; }
        }

        public string Courseid
        {
            get { return courseid; }
            set { courseid = value; }
        }

        public void inputCourse()
        {
            Console.WriteLine("Enter the Course Id:");
            courseid = Console.ReadLine();
            Console.WriteLine("Enter the Course Name:");
            coursename = Console.ReadLine();
            Console.WriteLine("Enter the Free:");
            free = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of student: ");
            int n = int.Parse(Console.ReadLine());
            Student student;
            for (int i = 1; i <= n; i++)
            {
                student = new Student();
                Console.WriteLine("Enter the info of student " + i);
                student.InputStudent();
                li.Add(student);
                Console.WriteLine("*** ***");
            }
        }

        public void DisplayCourseAndStudents()
        {
            Console.WriteLine("=== Course Info ===");
            Console.WriteLine($"CourseId: {this.courseid}");
            Console.WriteLine($"CourseName: {this.coursename}");
            Console.WriteLine($"free: {this.free}");
            Console.WriteLine("List Student: ");
            Console.WriteLine("=== Student Info ===");
            foreach (var st in li)
            {
                Console.WriteLine(st.ToString());
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   courseid == course.courseid;
        }

        public Student findStudentById(int studentid)
        {
            Student student = new Student();
            student.Studentid = studentid;
            int n = li.IndexOf(student);
            if (n < 0)
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                return li[n];
            }
            return null;
        }

        public override string? ToString()
        {
            return this.courseid + "\t" + this.coursename + "\t" + this.free;
        }
    }
}
