using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBrandRepository
    {
        List<BrandModel> GetAllBrand();
        bool CreateBrand(BrandModel model);
        bool UpdateBrand(BrandModel model);
        bool DeleteBrand(int BrandID);

    }
}
