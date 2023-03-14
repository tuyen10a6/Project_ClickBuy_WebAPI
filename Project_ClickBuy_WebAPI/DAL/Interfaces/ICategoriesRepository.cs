using ClickBuy.Model.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoriesRepository
    {
        List<CategoryUserModel> GetAllCate();
        bool CreateSanPham(CategoriesModel model);
        bool UpdateSanPham( CategoriesModel model);

        bool DeleteCategory(int CategoryID);

        List<ProductUserModel> GetSanPhamByCategoryID(int CategoryID);
        List<ProductUserModel> GetProductPrice(int CategoryID , int min , int max);
        List<ProductUserModel> GetProductMeMory(int CategoryID, int Memory);
        List<ProductUserModel> GetProductASC(int CategoryID);
        List<ProductUserModel> GetProductDesc(int CategoryID);  
        List<ProductUserModel> PagingByCategory(int CategoryID , int PageSize , int PageNumber);
        List<GetAllBrandByCategoryModel> getAllBrandByCategoryModels(int CategoryID);

    }
}
