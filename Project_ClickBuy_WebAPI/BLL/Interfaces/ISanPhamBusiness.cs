using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL.Interfaces
{
    public  interface ISanPhamBusiness
    {
        List<SanPhamModel> GetAllSanPham();
        bool AddSanPham(SanPhamModel model);
        bool UpdateSanPham( SanPhamModel model);
        bool DeleteSanPham(int productID);
        List<SanPhamModel> SearchProducts(string productName);
        List<SanPhamModel> GetMeMory(int value);
        List<SanPhamModel> GetProductsByPriceRange(int min, int max);
        List<SanPhamModel> GetProductMeMoRy(int Value);

    }
}
