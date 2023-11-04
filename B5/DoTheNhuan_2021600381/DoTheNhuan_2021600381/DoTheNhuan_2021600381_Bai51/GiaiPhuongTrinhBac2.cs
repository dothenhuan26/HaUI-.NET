using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTheNhuan_2021600381_Bai51
{
    internal class GiaiPhuongTrinhBac2
    {

        private int a { get; set; }
        private int b { get; set; }
        private int c { get; set; }



        public GiaiPhuongTrinhBac2(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double delta()
        {
            return Math.Pow(this.b, 2) - 4 * this.a * this.c;
        }

        public int check()
        {
            double x = delta();
            return (x < 0) ? -1 : (x == 0 ? 0 : 1);
        }

        public double x1()
        {
            double x = delta();

            if (check() == 1)
            {
                return (-1 * b + Math.Sqrt(x)) / (2 * a);
            }

            if (check() == 0)
            {
                return (-1 * b) / (2 * a);
            }

            return double.NaN;
        }

        public double x2()
        {
            double x = delta();

            if (check() == 1)
            {
                return (-1 * b - Math.Sqrt(x)) / (2 * a);
            }

            if (check() == 0)
            {
                return (-1 * b) / (2 * a);
            }


            return double.NaN;
        }

        public void handle()
        {
            if (check() == -1)
            {
                Console.WriteLine("Phuong trinh vo nghiem!");
                return;

            }
            if (check() == 0)
            {
                Console.WriteLine("Phuong trinh co nghiem kep la: x={0:F3}", x1());
                return;
            }
            Console.WriteLine("Phuong trinh co 2 nghiem la: x1={0:F3}, x2={1:F3}", x1(), x2());
        }

    }
}
