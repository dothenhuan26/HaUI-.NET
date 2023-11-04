using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_Bai53
{
    internal class Vehicles : Ivehicle
    {
        private string _id;
        private string _maker;
        private string _model;
        private int _year;
        private string _type;

        public string Id
        {
            get
            { return _id; }
            set { _id = value; }
        }

        public string Maker
        {
            get { return _maker; }
            set { _maker = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Vehicles()
        {
        }

        public Vehicles(string id, string maker, string model, int year, string type)
        {
            _id = id;
            _maker = maker;
            _model = model;
            _year = year;
            _type = type;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vehicles vehicles &&
                   this._id == vehicles._id;
        }

        public override string? ToString()
        {
            return "ID: " + this._id + ", Maker: " + this._maker + ", Model: " + this._model + ", Year: " + this._year + ", Type: " + this._type + ", NienHanSuDung: " + NienHanSuDung();
        }

        virtual public string NienHanSuDung()
        {
            string res = "Chua xac dinh";
            if (this._type.Equals("Xe tai"))
            {
                res = "20 nam";
            }
            if (this._type.Equals("Xe cho nguoi"))
            {
                res = "30 nam";
            }
            return res;
        }
    }
}
