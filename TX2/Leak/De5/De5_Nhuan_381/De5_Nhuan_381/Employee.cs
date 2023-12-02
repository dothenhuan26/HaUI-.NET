using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De5_Nhuan_381
{
    internal class Employee
    {
        private string _fullname;
        private string _gender;
        private int _amount;

        public double Salary
        {
            get
            {
                if (this._amount <= 10) return this._amount * 200000;
                else return this._amount * 300000;
            }
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
