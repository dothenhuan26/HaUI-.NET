using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_Nhuan_381
{
    internal class NhanVien
    {
		private string _fullname;
		private DateTime _dateapply;

        public NhanVien()
        {
        }

        public NhanVien(string fullname, DateTime dateapply)
        {
            _fullname = fullname;
            _dateapply = dateapply;
        }



        public DateTime Dateapply
		{
			get { return _dateapply; }
			set { _dateapply = value; }
		}

		public string Fullname
		{
			get { return _fullname; }
			set { _fullname = value; }
		}




	}
}
