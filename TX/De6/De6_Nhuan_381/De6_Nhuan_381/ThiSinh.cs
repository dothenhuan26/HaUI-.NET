using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De6_Nhuan_381
{
    internal class ThiSinh
    {
		private string _sobaodanh;
		private DateTime _ngaysinh;

        public ThiSinh()
        {
        }

        public ThiSinh(string sobaodanh, DateTime ngaysinh)
        {
            _sobaodanh = sobaodanh;
            _ngaysinh = ngaysinh;
        }

        public DateTime NgaySinh
		{
			get { return _ngaysinh; }
			set { _ngaysinh = value; }
		}

		public string SoBaoDanh
		{
			get { return _sobaodanh; }
			set { _sobaodanh = value; }
		}

        public override bool Equals(object? obj)
        {
            return obj is ThiSinh sinh &&
                   _sobaodanh == sinh._sobaodanh;
        }
    }
}
