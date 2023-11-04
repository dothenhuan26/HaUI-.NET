using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_Bai53
{
    internal class Truck : Vehicles
    {
        private int _load;

        public int Load
        {
            get { return _load; }
            set { _load = value; }
        }

        public Truck(string id, string maker, string model, int year, string type, int load) : base(id, maker, model, year, type)
        {
            this._load = load;
        }

        public Truck()
        {

        }

        public override string? ToString()
        {
            return "ID: " + Id + ", Maker: " + Maker + ", Model: " + Model + ", Year: " + Year + ", Type: " + Type + ", Load: " + Load + ", NienHanSuDung: " + NienHanSuDung();
        }

        public override string NienHanSuDung()
        {
            string res = "Chua xac dinh";
            //if (this._load)
            //{

            //}
            //if (this._load)
            //{

            //}
            return res;
        }
    }
}
