using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1Struct
{
    internal class Person
    {
        private string _name;
        private string _address;

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

        public Person()
        {
        }

        public Person(string name, string address)
        {
            _name = name;
            _address = address;
        }

        virtual public void input()
        {
            Console.WriteLine("Enter the name:");
            this._name = Console.ReadLine();
            Console.WriteLine("Enter the address:");
            this._address = Console.ReadLine();
        }

    }
}
