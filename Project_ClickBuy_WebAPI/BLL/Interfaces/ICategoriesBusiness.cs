using ClickBuy.Model.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriesBusiness
    {
        List<CategoryUserModel> GetAllCateUser();
        bool CreateCategories (CategoriesModel model);
        bool UpdateCategories(CategoriesModel model);
        bool DeleteCategory(int CategoryID);
        List<ProductUserModel> GetSanPhamByCategoryID(int CategoryID);
        List<ProductUserModel> GetProductPrice(int CategoryID, int min, int max);
        List<ProductUserModel> GetProductMeMoRy(int CategoryID, int MeMoRy);
        List<ProductUserModel> GetProductASC(int CategoryID);
        List<ProductUserModel> GetProductDesc(int CategoryID);
        List<ProductUserModel> PagingByCategory(int CategoryID, int PageSize, int PageNumber);
        List<GetAllBrandByCategoryModel> GetAllBrandByCategoryID(int CategoryID);

    }
}
