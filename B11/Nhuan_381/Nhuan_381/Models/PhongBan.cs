using System;
using System.Collections.Generic;

namespace Nhuan_381.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaPb { get; set; } = null!;
        public string? TenPb { get; set; }
        public DateTime? NgayThanhLap { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
