using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_Nhuan_381
{
    class Customer
    {
        private string _fullname;
        private DateTime _date;
        private int _amount;


        public int Total
        {
            get { return this.Amount * 1000; }
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
