using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_DoTheNhuan_381
{
    internal class KhachHangVIP : KhachHang
    {
        public KhachHangVIP()
        {
        }

        public KhachHangVIP(string id, string fullname, int quantity, double price) : base(id, fullname, quantity, price)
        {
        }

        public string coupon()
        {
            return this.total() < 1000 ? "Coupon 100" : (this.total() > 5000 ? "Coupon 500" : "Coupon 200");
        }

        public override string? ToString()
        {
            return $"{this.Id}\t{this.Fullname}\t{this.Quantity}\t{this.Price}\t{this.total()}\t{this.coupon()}";

        }
    }
}
