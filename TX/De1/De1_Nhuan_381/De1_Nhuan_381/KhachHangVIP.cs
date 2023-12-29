using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_Nhuan_381
{
    internal class KhachHangVIP : KhachHang
    {
        private string _type;

        public KhachHangVIP()
        {
        }

        public KhachHangVIP(string fullnane, bool gender, int amount, double price, string type) : base(fullnane, gender, amount, price)
        {
            _type = type;
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override double Total()
        {
            return (this._type.Equals("vip") ? 0.8 : (this._type.Equals("vang") ? 0.9 : 0.95)) * (this.Amount * this.Price);
        }
    }
}
