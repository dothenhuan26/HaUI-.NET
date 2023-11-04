using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Person
    {
        private string id;
        private string name;
        private int age;
        private string email;
        private string addrerss;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Addrerss
        {
            get { return addrerss; }
            set { addrerss = value; }
        }

        public Person()
        {
        }

        public Person(string id, string name, int age, string email, string addrerss)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.addrerss = addrerss;
        }



        public void checkAge()
        {
            Console.WriteLine(age >= 18 ? "Bạn đã đủ tuổi bầu cử" : "Bạn còn nhỏ");
        }

        public void input()
        {
            Console.WriteLine("Nhập vào mã định danh:");
            this.Id = Console.ReadLine();
            Console.WriteLine("Nhập vào tên:");
            this.Name = Console.ReadLine();
            Console.WriteLine("Nhập vào tuổi:");
            this.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập vào email:");
            this.Email = Console.ReadLine();
            Console.WriteLine("Nhập vào address:");
            this.Addrerss = Console.ReadLine();
        }

        public void outputHeading()
        {
            //Console.WriteLine("Id\tName\tAge\tEmail\tAddress");
            Console.WriteLine("{0,-10}{1,10}{2,10}{3,30}{4,20}", "Id", "Name", "Age", "Email", "Address");
        }

        public void output()
        {
            //Console.WriteLine(this.Id + "\t" + this.Name + "\t" + this.Age + "\t" + this.Email + "\t" + this.Addrerss);
            Console.WriteLine("{0,-10}{1,10}{2,10}{3,30}{4,20}",this.Id, this.Name, this.Age, this.Email, this.Addrerss);
        }



    }
}
