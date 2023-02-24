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
    }
}
