using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Circle
    {
        private double r;
        public double R { get { return r; } set { r = value; } }

        public Circle(double r)
        {
            this.r = r;
        }

        public Circle()
        {
        }

        public double Area()
        {
            return Math.Pow(this.R, 2)*Math.PI;
        }

        public double Perimeter()
        {
            return Math.PI * 2 * this.R;
        }

    }
}
