using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_Bai52
{
    internal class Employee
    {
        const int PRICE = 50;

        private string id { get; set; }
        private string name { get; set; }
        private int age { get; set; }
        private int workingdays {  get; set; }

        private double salary;

        public Employee(string id, string name, int age, int workingdays)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.workingdays = workingdays;
            this.salary = this.workingdays*PRICE;
        }

        public double getSalary()
        {
            return salary;
        }

    }
}
