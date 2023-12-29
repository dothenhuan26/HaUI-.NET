using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De6_Nhuan_381
{
    internal class ThiSinhChinhSach : ThiSinh
    {
        private string _uutien;

        public ThiSinhChinhSach()
        {
        }

        public ThiSinhChinhSach(string sobaodanh, DateTime ngaysinh, string uutien) : base(sobaodanh, ngaysinh)
        {
            this._uutien = uutien;
        }

        public string UuTien
        {
            get { return _uutien; }
            set { _uutien = value; }
        }

        public double DiemUuTien()
        {
            string s = this._uutien;
            return (double)(s.Equals("UT1") ? 2 : (s.Equals("UT2") ? 1.5 : (s.Equals("KV1") ? 1 : 0.5)));
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}
