using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickBuy.Model.ViewModel
{
     public class OrderModel
    {
        public KhachHangModel khach { get; set; }
        public List<ChiTietDonHangModel> listchitiet { get; set; }

    }
    public class KhachHangModel
    {
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }
    public class ChiTietDonHangModel
    {

        public int MaBienTheSanPham { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public double GiaMua { get; set; }
    }
}
