using Bai11_Nhuan381_P3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai11_Nhuan381_P3
{
    class Render
    {
        public Render()
        {
            
        }

        public string MaSp { get; set; } = null!;
        public string TenSp { get; set; } = null!;
        public string? MaLoai { get; set; }
        public string TenLoai { get; set; } = null!;

        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

    }
}
