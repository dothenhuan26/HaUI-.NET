using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj63
{
    internal class Student
    {
        private int studentid;
        private string name;
        private string mark;

        public Student(int studentid, string name, string mark)
        {
            studentid = studentid;
            name = name;
            mark = mark;
        }

        public Student()
        {
        }

        public override string? ToString()
        {
            return this.studentid + "\t" + this.name + "\t" + this.mark;
        }

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Studentid
        {
            get { return studentid; }
            set { studentid = value; }
        }

        public void InputStudent()
        {
            Console.WriteLine("Enter the Student Id: ");
            this.studentid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name:");
            this.name = Console.ReadLine();
            Console.WriteLine("Enter the Mark:");
            this.mark = Console.ReadLine();

        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   studentid == student.studentid;
        }
    }
}
