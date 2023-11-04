using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_Bai53
{
    internal class Car : Vehicles
    {
        private int _seats;

        public int Seats
        {
            get { return _seats; }
            set { _seats = value; }
        }

        public Car(string id, string maker, string model, int year, string type, int seats) : base(id, maker, model, year, type)
        {
            this._seats = seats;
        }

        public Car()
        {

        }

        public override string NienHanSuDung()
        {
            string res = "Chua xac dinh";
            if (this._seats < 9)
            {
                res = "Khong ap dung";
            }
            if (this._seats >= 9)
            {
                res = "30";
            }
            return res;
        }

        public override string ToString()
        {
            return "ID: " + Id + ", Maker: " + Maker + ", Model: " + Model + ", Year: " + Year + ", Type: " + Type + ", Seats: "+Seats +", NienHanSuDung: " + NienHanSuDung();
        }
    }
}
