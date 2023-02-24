using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int? MaHang { get; set; }
        public string TinhTrangSanPham { get; set; }
        public string UudaiTraGop { get; set; }
        public string UuDaiThem { get; set; }
        public string MoTa { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
