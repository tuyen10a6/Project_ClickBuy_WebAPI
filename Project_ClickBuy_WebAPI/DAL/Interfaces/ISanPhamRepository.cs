using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Model;

namespace DAL
{
    public interface ISanPhamRepository
    {
        List<SanPhamModel> GetAllSanPham();
        bool AddSanPham(SanPhamModel model);
        bool UpdateSanPham(int productID, SanPhamModel model);
        bool DeteteSanPham(int productID);

        List<SanPhamModel> SearchProduct(string ProductName);
        SanPhamModel GetIDSanPham(int productID);
    }
}
