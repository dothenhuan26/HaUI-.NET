using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Nhun_381
{
    internal class Customer
    {
        private string _fullname;
        private string _gender;
        private int _amount;
        private double _price;
        private double _total;

        public Customer()
        {
        }

        public Customer(string fullname, string gender, int amount, double price)
        {
            _fullname = fullname;
            _gender = gender;
            _amount = amount;
            _price = price;
        }

        public double Total
        {
            get { return this._amount * this._price; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
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
    }
}
