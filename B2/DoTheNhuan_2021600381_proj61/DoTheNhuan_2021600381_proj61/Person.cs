using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj61
{
    internal class Person
    {
        private static int count = 0;
        private int _id;
        private string _name;
        private string _address;

        public Person()
        {
        }

        public Person(string name, string address)
        {
            _id = ++count;
            _name = name;
            _address = address;
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual void input()
        {
            this._id = ++count;
            Console.WriteLine("Nhap vao name: ");
            this._name = Console.ReadLine();
            Console.WriteLine("Nhap vao dia chi: ");
            this._address = Console.ReadLine();
        }
        public virtual void output()
        {
            Console.WriteLine("*====================*");
            Console.WriteLine($"id: {this._id}");
            Console.WriteLine($"name: {this._name}");
            Console.WriteLine($"dia chi: {this._address}");
        }
    }
}