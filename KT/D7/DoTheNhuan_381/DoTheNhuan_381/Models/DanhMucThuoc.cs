using System;
using System.Collections.Generic;

namespace DoTheNhuan_381.Models
{
    public partial class DanhMucThuoc
    {
        public DanhMucThuoc()
        {
            Thuocs = new HashSet<Thuoc>();
        }

        public string MaDm { get; set; } = null!;
        public string? TenDm { get; set; }

        public virtual ICollection<Thuoc> Thuocs { get; set; }
    }
}
