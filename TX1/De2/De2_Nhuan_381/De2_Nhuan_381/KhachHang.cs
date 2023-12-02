using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_Nhuan_381
{
    internal class KhachHang
    {
        private string _id;
        private DateTime _birthday;
        private int _amount;
        private double _price;

        public KhachHang()
        {
        }

        public KhachHang(string id, DateTime birthday, int amount, double price)
        {
            _id = id;
            _birthday = birthday;
            _amount = amount;
            _price = price;
        }

        public virtual double total()
        {
            return (double)(this._amount * this._price);
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

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }


    }
}
