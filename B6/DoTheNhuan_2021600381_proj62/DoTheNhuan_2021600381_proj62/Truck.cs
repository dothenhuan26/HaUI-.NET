using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj62
{
    internal class Truck : Vehicle
    {
        private int _truckload;

        public int Truckload
        {
            get { return _truckload; }
            set { _truckload = value; }
        }


        public Truck()
        {
        }

        public Truck(string id, string maker, string model, int year, double price, int trunkload) : base(id, maker, model, year, price)
        {
            this._truckload = trunkload;
        }

        public override void Input()
        {
            base.Input();
            Console.WriteLine("Enter the Truckload:");
            this._truckload = int.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
        }

        public override string? ToString()
        {
            return this.Id + "\t" + this.Maker + "\t" + this.Model + "\t" + this.Year + "\t" + this.Price + "\t" + this._truckload;
        }
    }
}
