using System;
using System.Collections.Generic;

namespace DemoEFCore.Models
{
    public partial class SanPham
    {
        public string MaSp { get; set; } = null!;
        public string TenSp { get; set; } = null!;
        public string MaLoai { get; set; } = null!;
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public virtual LoaiSanPham MaLoaiNavigation { get; set; } = null!;
    }
}
