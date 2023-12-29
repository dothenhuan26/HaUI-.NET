using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH
{
    class Render
    {
        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public int? DonGia { get; set; }
        public int? SoLuongCo { get; set; }
        public string? MaLoai { get; set; }
        public int ThanhTien
        {
            get
            {
                return (int)(this.DonGia * this.SoLuongCo);
            }
        }



    }
}
