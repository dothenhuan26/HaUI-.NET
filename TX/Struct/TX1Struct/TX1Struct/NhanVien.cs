using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1Struct
{
    internal class NhanVien : Person, IComparable
    {
        private string _id;
        private string _position;
        private double _salary;
        private double _coef;

        public double Coef
        {
            get { return _coef; }
            set
            {
                string position = this._position.ToLower();
                _coef = position.Equals("giám đốc") ? 10 : (position.Equals("trưởng phòng") || position.Equals("phó giám đốc") ? 6 : (position.Equals("phó phòng") ? 4 : 2));
            }
        }


        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public NhanVien(string name, string address, string id, string position, double salary) : base(name, address)
        {
            this._id = id;
            this._position = position;
            this._salary = salary;
            position = position.ToLower();
            this._coef = position.Equals("giám đốc") ? 10 : (position.Equals("trưởng phòng") || position.Equals("phó giám đốc") ? 6 : (position.Equals("phó phòng") ? 4 : 2));
        }

        public NhanVien()
        {

        }

        public override void input()
        {
            base.input();
            Console.WriteLine("Enter the Id:");
            this._id = Console.ReadLine();
            Console.WriteLine("Enter the Position:");
            this._position = Console.ReadLine();
            Console.WriteLine("Enter the Salary:");
            this._salary = double.Parse(Console.ReadLine());
            string position = this._position.ToLower();
            this._coef = position.Equals("giám đốc") ? 10 : (position.Equals("trưởng phòng") || position.Equals("phó giám đốc") ? 6 : (position.Equals("phó phòng") ? 4 : 2));
        }

        public static void outputHeading()
        {
            Console.WriteLine("{0,-10}{1, -20}{2, -20}{3, -20}{4, -10}{5, -10}", "Họ tên", "Địa chỉ", "Mã nhân viên", "Chức vụ", "Lương", "Hệ số");
        }

        public void output()
        {
            Console.WriteLine("{0,-10}{1, -20}{2, -20}{3, -20}{4, -10}{5, -10}", this.Name, this.Address, this.Id, this.Position, this.Salary, this.Coef);
        }

        public int CompareTo(object? obj)
        {
            NhanVien nhanVien = (NhanVien)obj;
            if (this._coef == nhanVien.Coef)
            {
                return (int)(this._salary - nhanVien.Salary);
            }
            return (int)(this._coef - nhanVien.Coef);

        }
    }
}
