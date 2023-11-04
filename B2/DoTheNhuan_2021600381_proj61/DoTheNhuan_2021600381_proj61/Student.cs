using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_proj61
{
    internal class Student : Person
    {
        private byte _math;
        private byte _physics;

        public Student()
        {
        }

        public Student(string name, string address, byte math, byte physics) : base(name, address)
        {
            this._math = math;
            this._physics = physics;
        }

        public byte Physics
        {
            get { return _physics; }
            set { _physics = value; }
        }

        public byte Math
        {
            get { return _math; }
            set { _math = value; }
        }

        public override void input()
        {
            base.input();
            Console.WriteLine("Math: ");
            this._math = byte.Parse(Console.ReadLine());
            Console.WriteLine("Physics: ");
            this._physics = byte.Parse(Console.ReadLine());
        }

        public override void output()
        {
            base.output();
            Console.WriteLine($"Math: {this._math}");
            Console.WriteLine($"Physics: {this._physics}");
            Console.WriteLine($"Total: {this.total()}");
        }

        public int total()
        {
            return this._math + this._physics;
        }
    }
}
