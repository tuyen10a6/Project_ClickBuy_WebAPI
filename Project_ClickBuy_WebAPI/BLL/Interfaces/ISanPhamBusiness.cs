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
        bool UpdateSanPham(int productID, SanPhamModel model);
    }
}
