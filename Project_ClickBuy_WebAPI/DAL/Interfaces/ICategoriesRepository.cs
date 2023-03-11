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
        List<CategoriesModel> GetAllCate();
        bool CreateSanPham(CategoriesModel model);
        bool UpdateSanPham( CategoriesModel model);

        bool DeleteCategory(int CategoryID);

        List<SanPhamModel> GetSanPhamByCategoryID(int CategoryID);
        List<SanPhamModel> GetProductPrice(int CategoryID , int min , int max);
        List<SanPhamModel> GetProductMeMory(int CategoryID, int Memory);
        List<SanPhamModel> GetProductASC(int CategoryID);
        List<SanPhamModel> GetProductDesc(int CategoryID);  
        List<SanPhamModel> PagingByCategory(int CategoryID , int PageSize , int PageNumber);
        
    }
}
