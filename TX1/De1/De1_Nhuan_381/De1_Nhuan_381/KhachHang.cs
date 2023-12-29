using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Nhuan_381
{
    internal class KhachHang
    {
		private string _fullnane;
		private bool _gender;
		private int _amount;
		private double _price;

        public KhachHang()
        {
        }

        public KhachHang(string fullnane, bool gender, int amount, double price)
        {
            _fullnane = fullnane;
            _gender = gender;
            _amount = amount;
            _price = price;
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

		public bool Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		public string Fullname
		{
			get { return _fullnane; }
			set { _fullnane = value; }
		}

        public override bool Equals(object? obj)
        {
            return obj is KhachHang hang &&
                   _fullnane == hang._fullnane;
        }

        public virtual double Total()
		{
			return this._price * this._amount;
		}




	}
}
