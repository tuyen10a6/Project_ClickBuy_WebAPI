using BLL.Interfaces;
using ClickBuy.Model.ViewModel;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriesBus : ICategoriesBusiness
    {
        private ICategoriesRepository _res;
        public CategoriesBus(ICategoriesRepository res)
        {
            _res = res;
        }
        public bool CreateCategories(CategoriesModel model)
        {
            return _res.CreateSanPham(model);
        }

        public bool DeleteCategory(int CategoryID)
        {
            return _res.DeleteCategory(CategoryID);
        }

        public List<GetAllBrandByCategoryModel> GetAllBrandByCategoryID(int CategoryID)
        {
           return _res.getAllBrandByCategoryModels(CategoryID);
        }

        public List<CategoryUserModel> GetAllCateUser()
        {
            return _res.GetAllCate();
        }

        public List<ProductUserModel> GetProductASC(int CategoryID)
        {
            return _res.GetProductASC(CategoryID);
        }

        public List<ProductUserModel> GetProductDesc(int CategoryID)
        {
            return _res.GetProductDesc(CategoryID);
        }

        public List<ProductUserModel> GetProductMeMoRy(int CategoryID, int MeMoRy)
        {
            return _res.GetProductMeMory(CategoryID, MeMoRy);
        }
        public List<ProductUserModel> GetProductPrice(int CategoryID, int min, int max)
        {
            return _res.GetProductPrice(CategoryID, min, max);
        }

        public List<ProductUserModel> GetSanPhamByCategoryID(int CategoryID)
        {
            return _res.GetSanPhamByCategoryID(CategoryID);
        }

        public List<ProductUserModel> PagingByCategory(int CategoryID, int PageSize, int PageNumber)
        {
            return _res.PagingByCategory(CategoryID, PageSize, PageNumber);
        }

        public bool UpdateCategories(CategoriesModel model)
        {
            return _res.UpdateSanPham(model);
        }
    }
}
