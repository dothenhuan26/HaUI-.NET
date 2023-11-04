using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class ThiSinhA
    {
        static int count = 1;
        private int index;
        private string _id;
        private string _name;
        private string _address;
        private double _math;
        private double _physic;
        private double _chemistry;
        private double _prioritize;
        private double _total;

        public ThiSinhA()
        {
        }

        public ThiSinhA(string id, string name, string address, double math, double physic, double chemistry, double prioritize)
        {
            ++count;
            _id = id;
            _name = name;
            _address = address;
            _math = math;
            _physic = physic;
            _chemistry = chemistry;
            _prioritize = prioritize;
            this.index = count;
            this._total = math + physic + chemistry + prioritize;
        }

        public string Id { get { return _id; } set { this._id = value; } }
        public string Name { get { return _name; } set { this._name = value; } }
        public string Address { get { return _address; } set { this._address = value; } }
        public double Math { get { return _math; } set { _math = value; } }
        public double Physic { get { return _physic; } set { _physic = value; } }
        public double Chemistry { get { return _chemistry; } set { _chemistry = value; } }
        public double Prioritize { get { return this._prioritize; } set { this._prioritize = value; } }
        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                this._total = this.Math + this.Physic + this.Chemistry + this.Prioritize;
            }
        }

        public void input()
        {
            Console.WriteLine("Nhập số báo danh:");
            this.Id = Console.ReadLine();
            Console.WriteLine("Nhập vào họ tên:");
            this.Name = Console.ReadLine();
            Console.WriteLine("Nhập vào địa chỉ:");
            this.Address = Console.ReadLine();
            Console.WriteLine("Nhập vào điểm toán:");
            this.Math = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập vào điểm lý:");
            this.Physic = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập vào điểm hóa:");
            this.Chemistry = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập vào điểm ưu tiên:");
            this.Prioritize = double.Parse(Console.ReadLine());
            this._total = this.Math + this.Physic + this.Chemistry + this.Prioritize;
        }

        public static void outputHeading()
        {
            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-20}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", "STT", "Số báo danh", "Họ tên", "Địa chỉ", "Điểm toán", "Điểm lý", "Điểm hóa", "Điểm cộng", "Tổng điểm");
        }

        public void output()
        {
            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-20}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", this.index, this.Id, this.Name, this.Address, this.Math, this.Physic, this.Chemistry, this.Prioritize, this._total);
        }

    }
}
