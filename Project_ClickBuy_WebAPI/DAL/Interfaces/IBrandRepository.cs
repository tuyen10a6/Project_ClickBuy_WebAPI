using ClickBuy.Model.ViewModel;
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
        List<BrandUserModel> GetAllBrand();
        bool CreateBrand(BrandModel model);
        bool UpdateBrand(BrandModel model);
        bool DeleteBrand(int BrandID);
        List<SanPhamModel> GetSanPhamByBrandID(int BrandID);
        List<SanPhamModel> GetProductPrice(int BrandID, int min, int max);
        List<SanPhamModel> GetProductMeMory(int BrandID, int Memory);
        List<SanPhamModel> GetProductPaging(int BrandID, int PageSize, int PageNumber);
        List<SanPhamModel> GetProductASC(int BrandID);
        List<SanPhamModel> GetProductDesc(int BrandID);
        List<BrandModel> SearchBrandName(string BrandName);
     

    }
}
