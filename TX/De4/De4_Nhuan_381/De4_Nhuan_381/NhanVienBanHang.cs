using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_Nhuan_381
{
    internal class NhanVienBanHang : NhanVien
    {

        private int _total;

        public NhanVienBanHang()
        {
        }

        public NhanVienBanHang(string fullname, DateTime dateapply, int total) : base(fullname, dateapply)
        {
            this._total = total;
        }

        public int Bonus()
        {
            return (this._total < 100) ? 1000 : (this._total > 500 ? 3000 : 2000);
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }



    }
}
