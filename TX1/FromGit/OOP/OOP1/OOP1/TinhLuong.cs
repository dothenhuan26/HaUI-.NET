using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class TinhLuong
    {
        private string _hoten;
        private string _diachi;
        private double _heso;
        public static double LuongCB = 1000000;

        public TinhLuong()
        {
        }

        public TinhLuong(string hoten, string diachi, double heso)
        {
            _hoten = hoten;
            _diachi = diachi;
            _heso = heso;
        }

        public virtual double Luong()
        {
            return (double)(this._heso * LuongCB);
        }

        public double Heso
        {
            get { return _heso; }
            set { _heso = value; }
        }

        public string Diachi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }

        public string Hoten
        {
            get { return _hoten; }
            set { _hoten = value; }
        }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhập vào họ tên:");
            this._hoten = Console.ReadLine();
            Console.WriteLine("Nhập vào địa chỉ:");
            this._hoten = Console.ReadLine();
            Console.WriteLine("Nhập vào hệ số lương:");
            this._heso = double.Parse(Console.ReadLine());
        }

        public virtual void Xuat()
        {
            Console.WriteLine("----------");
            Console.WriteLine($"Họ tên: {this._hoten}");
            Console.WriteLine($"Địa chỉ: {this._diachi}");
            Console.WriteLine($"Hệ số lương: {this._heso}");
        }

    }
}
