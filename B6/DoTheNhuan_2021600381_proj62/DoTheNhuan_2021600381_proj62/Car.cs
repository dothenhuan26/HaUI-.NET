using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj62
{
    internal class Car : Vehicle
    {
        private string _color;

        public Car()
        {
        }

        public Car(string id, string maker, string model, int year, double price, string color) : base(id, maker, model, year, price)
        {
            this._color = color;
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public override void Input()
        {
            base.Input();
            Console.WriteLine("Enter the color:");
            this._color = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Color: {this._color}");
        }

        public override string? ToString()
        {
            return this.Id + "\t" + this.Maker + "\t" + this.Model + "\t" + this.Year + "\t" + this.Price + "\t" + this._color;
        }
    }
}
