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
        List<CategoriesModel> GetAllCate();
        bool CreateCategories (CategoriesModel model);
        bool UpdateCategories(CategoriesModel model);
        bool DeleteCategory(int CategoryID);
        List<SanPhamModel> GetSanPhamByCategoryID(int CategoryID);
        List<SanPhamModel> GetProductPrice(int CategoryID, int min, int max);
        List<SanPhamModel> GetProductMeMoRy(int CategoryID, int MeMoRy);
        List<SanPhamModel> GetProductASC(int CategoryID);
        List<SanPhamModel> GetProductDesc(int CategoryID);
        List<SanPhamModel> PagingByCategory(int CategoryID, int PageSize, int PageNumber);
        List<GetAllBrandByCategoryModel> GetAllBrandByCategoryID(int CategoryID);

    }
}
