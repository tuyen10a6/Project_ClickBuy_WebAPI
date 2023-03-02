using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBus : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBus(ISanPhamRepository res)
        {
            _res = res;
        }
        public List<SanPhamModel> GetAllSanPham()
        {
           return  _res.GetAllSanPham();
        }
        public bool AddSanPham(SanPhamModel model)
        {
            return _res.AddSanPham(model);
        }
        public bool UpdateSanPham( SanPhamModel model)
        {
            return _res.UpdateSanPham( model);
        }
        public bool DeleteSanPham(int productID)
        {
            return _res.DeteteSanPham(productID);
        }
        public List<SanPhamModel> SearchProducts(string productName)
        {
            return _res.SearchProduct(productName);
        }
        public SanPhamModel GetIDSanPham(int productID)
        {
            return _res.GetIDSanPham(productID);
        }

    }
}
