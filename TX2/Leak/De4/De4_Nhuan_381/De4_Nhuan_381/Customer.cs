using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_Nhuan_381
{
    internal class Customer
    {
        private string _fullname;
        private DateTime _date;
        private int _amount;

        public int Bonus
        {
            get
            {
                if (this._amount < 100) return 1000;
                else return 2000;
            }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

    }
}
