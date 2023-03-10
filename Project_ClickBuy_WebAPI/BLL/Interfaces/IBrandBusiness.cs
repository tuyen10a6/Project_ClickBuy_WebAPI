using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBrandBusiness
    {
        List<BrandModel> GetAllBrand();
        bool CreateBrand(BrandModel model);
        bool UpdateBrand(BrandModel model);
        bool DeleteBrand(int BrandID);
    }
}
