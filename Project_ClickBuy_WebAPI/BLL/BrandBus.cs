using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BrandBus : IBrandBusiness
    {
        private IBrandRepository _res;
        public BrandBus(IBrandRepository res)
        {
            _res = res;
        }

        public bool CreateBrand(BrandModel model)
        {
            return _res.CreateBrand(model);
        }

        public bool DeleteBrand(int BrandID)
        {
            return _res.DeleteBrand(BrandID);
        }

        public List<BrandModel> GetAllBrand()
        {
            return _res.GetAllBrand();
        }

        public List<SanPhamModel> GetProductASC(int BrandID)
        {
            return _res.GetProductASC(BrandID);
        }

        public List<SanPhamModel> GetProductDesc(int BrandID)
        {
            return _res.GetProductDesc(BrandID);
        }

        public List<SanPhamModel> GetProductMeMory(int BrandID, int Memory)
        {
            return _res.GetProductMeMory(BrandID, Memory);
        }

        public List<SanPhamModel> GetProductPrice(int BrandID, int min, int max)
        {
           return _res.GetProductPrice(BrandID, min, max);
        }

        public List<SanPhamModel> GetSanPhamByBrandID(int BrandID)
        {
            return _res.GetSanPhamByBrandID(BrandID);
        }

        public List<BrandModel> SearchBrand(string BrandName)
        {
            return _res.SearchBrandName(BrandName);
        }

        public bool UpdateBrand(BrandModel model)
        {
            return _res.UpdateBrand(model);
        }
    }
}
