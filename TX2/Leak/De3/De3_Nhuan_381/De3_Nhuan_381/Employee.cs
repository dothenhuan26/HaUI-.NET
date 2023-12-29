using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_Nhuan_381
{
    internal class Employee
    {
        private string _id;
        private string _fullname;
        private string _gender;
        private double _price;

        public double Bonus
        {
            get { return this._price * 0.1; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }



    }
}
