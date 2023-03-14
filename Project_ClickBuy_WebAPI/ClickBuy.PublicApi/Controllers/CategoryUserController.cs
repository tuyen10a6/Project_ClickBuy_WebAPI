using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickBuy.Model.ViewModel;
using BLL.Interfaces;

namespace ClickBuy.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryUserController : ControllerBase
    {
        private ICategoriesBusiness _CategoriesBusiness;
        public CategoryUserController (ICategoriesBusiness CategoriesBusiness)
        {
            _CategoriesBusiness = CategoriesBusiness;   
        }
        [Route("GetAllCategoryUser")]
        [HttpGet]
        public List<CategoryUserModel> GetAllCategoryUser()
        {
            var result = _CategoriesBusiness.GetAllCateUser();
            return result;   
        }
        [Route("GetProductByCategoryID/{CategoryID}")]
        [HttpGet]
        public List<ProductUserModel> GetProductByCategory(int CategoryID)
        {
            var result = _CategoriesBusiness.GetSanPhamByCategoryID(CategoryID);
            return result;
                 
        }
        [Route("GetProduct_Category/{CategoryID}_MeMoRy/{MeMoRy}")]
        [HttpGet]
        public List<ProductUserModel> GetProductByCategoryMeMoRy(int CategoryID, int MeMoRy)
        {
            var result = _CategoriesBusiness.GetProductMeMoRy(CategoryID , MeMoRy);
            return result;
        }
           
            
           
            
    }
}
