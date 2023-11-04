using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_Nhuan_381
{
    internal class KhachHangVIP : KhachHang
    {
        public KhachHangVIP()
        {
        }

        public KhachHangVIP(string id, DateTime birthday, int amount, double price) : base(id, birthday, amount, price)
        {
        }

        public override double total()
        {
            double res = base.total();
            return (double)(res > 1000 ? (res * 0.8) : (res * 0.9));
        }

        public virtual string percent()
        {
            return (this.total() > 1000) ? "20%" : "10%";
        }

    }

}
