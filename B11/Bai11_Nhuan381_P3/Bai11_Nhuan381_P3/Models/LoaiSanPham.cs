using System;
using System.Collections.Generic;

namespace Bai11_Nhuan381_P3.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaLoai { get; set; } = null!;
        public string TenLoai { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
