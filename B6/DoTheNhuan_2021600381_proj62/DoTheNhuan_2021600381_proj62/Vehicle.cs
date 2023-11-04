using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj62
{
    internal class Vehicle : IVehicle, IComparable
    {
        private string _id;
        private string _maker;
        private string _model;
        private int _year;
        private double _price;

        public Vehicle()
        {
        }

        public Vehicle(string id)
        {
            _id = id;
        }

        public Vehicle(string id, string maker, string model, int year, double price)
        {
            _id = id;
            _maker = maker;
            _model = model;
            _year = year;
            _price = price;
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Maker
        {
            get { return _maker; }
            set { _maker = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CompareTo(object? obj)
        {
            return (int)(this.Price - ((Vehicle)obj).Price);
        }

        public override bool Equals(object? obj)
        {
            return obj is Vehicle vehicle &&
                   _id == vehicle._id;
        }

        public virtual void Input()
        {
            Console.WriteLine("Enter the Id:");
            this._id = Console.ReadLine();
            Console.WriteLine("Enter the Maker:");
            this._maker = Console.ReadLine();
            Console.WriteLine("Enter the Model:");
            this._model = Console.ReadLine();
            Console.WriteLine("Enter the Year:");
            this._year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Price:");
            this._price = double.Parse(Console.ReadLine());
        }

        public virtual void Output()
        {
            Console.WriteLine($"Id: {this._id}");
            Console.WriteLine($"Name: {this._maker}");
            Console.WriteLine($"Model: {this._model}");
            Console.WriteLine($"Year: {this._year}");
            Console.WriteLine($"Price: {this._price}");
        }

        public override string? ToString()
        {
            return this._id + "\t" + this._maker + "\t" + this._model + "\t" + this._year + "\t" + this._price;
        }
    }




}
