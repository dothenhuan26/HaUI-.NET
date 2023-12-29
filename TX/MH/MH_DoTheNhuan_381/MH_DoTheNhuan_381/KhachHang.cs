using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_DoTheNhuan_381
{
    internal class KhachHang
    {
        private string _id;
        private string _fullname;
        private int _quantity;
        private double _price;

        public KhachHang()
        {
        }

        public KhachHang(string id, string fullname, int quantity, double price)
        {
            _id = id;
            _fullname = fullname;
            _quantity = quantity;
            _price = price;
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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

        //public void input()
        //{
        //    Console.WriteLine("Nhập mã khách hàng:");
        //    this._id = Console.ReadLine();
        //    Console.WriteLine("Nhập vào họ tên:");
        //    this._fullname = Console.ReadLine();
        //    Console.WriteLine("Nhập vào số lượng mua:");
        //    this._quantity = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Nhập vào đơn giá:");
        //    this._price = double.Parse(Console.ReadLine());
        //}

        public double total()
        {
            return (double)(this._price * this._quantity);
        }

        public override string? ToString()
        {
            return $"{this._id}\t{this._fullname}\t{this._quantity}\t{this._price}\t{this.total()}";
        }


    }
}
