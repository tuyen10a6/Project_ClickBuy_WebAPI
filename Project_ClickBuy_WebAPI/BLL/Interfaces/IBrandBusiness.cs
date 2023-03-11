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
        List<SanPhamModel> GetSanPhamByBrandID(int BrandID);
        List<SanPhamModel> GetProductPrice(int BrandID, int min, int max);
        List<SanPhamModel> GetProductMeMory(int BrandID, int Memory);
        List<SanPhamModel> GetProductASC(int BrandID);
        List<SanPhamModel> GetProductDesc(int BrandID);
        List<BrandModel> SearchBrand(string BrandName);
        List<SanPhamModel> GetProductByPageBrand(int BrandID, int PageSize, int PageNumber);

    }
}
