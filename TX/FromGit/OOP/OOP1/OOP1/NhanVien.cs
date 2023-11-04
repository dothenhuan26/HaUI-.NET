using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class NhanVien : TinhLuong
    {
        private string _manv;
        private string _chucvu;

        public NhanVien()
        {
        }

        public NhanVien(string hoten, string diachi, double heso, string manv, string chucvu) : base(hoten, diachi, heso)
        {
            this._manv = manv;
            this._chucvu = chucvu;
        }

        public override double Luong()
        {
            return (double)(this.Heso);
        }

        public double HeSo()
        {
            return (this.Heso * this.PhuCap()) * LuongCB;
        }



        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Nhập vào mã nhân viên:");
            this._manv = Console.ReadLine();
            Console.WriteLine("Nhập vào chức vụ:");
            this._chucvu = Console.ReadLine();
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Mã nhân viên: {this._manv}");
            Console.WriteLine($"Chức vụ: {this._chucvu}");
        }

        public double PhuCap()
        {
            string s = (this._chucvu).Trim().ToLower();
            return s.Equals("giám đốc") ? 0.5 : (s.Equals("trưởng phòng") || s.Equals("phó giám đốc")) ? 0.4 : (s.Equals("phó phòng") ? 0.3 : 0);
        }

        public string Chucvu
        {
            get { return _chucvu; }
            set { _chucvu = value; }
        }

        public string Manv
        {
            get { return _manv; }
            set { _manv = value; }
        }

        public static void InTieuDe()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}", "Họ tên", "Địa chỉ", "Hệ số", "Mã nhân viên", "Chức vụ");
        }

        public void XuatNoiDung()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}", this.Hoten, this.Diachi, this.HeSo, this.Manv, this.Chucvu);

        }

        public override bool Equals(object? obj)
        {
            return obj is NhanVien vien &&
                   _manv == vien._manv;
        }
    }
}
