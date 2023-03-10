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

        public bool UpdateBrand(BrandModel model)
        {
            return _res.UpdateBrand(model);
        }
    }
}
