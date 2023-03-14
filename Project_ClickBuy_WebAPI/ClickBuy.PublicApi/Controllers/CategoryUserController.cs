using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickBuy.Model.ViewModel;
using BLL.Interfaces;
using Model;

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
        [Route("GetAllProductByCategoryID/{CategoryID}")]
        [HttpGet]
        public List<ProductUserModel> GetProductByCategory(int CategoryID)
        {
            var result = _CategoriesBusiness.GetSanPhamByCategoryID(CategoryID);
            return result;
                 
        }
        // Get san pham theo bo nho
        [Route("GetProductByCategory/{CategoryID}_MeMoRy/{MeMoRy}")]
        [HttpGet]
        public List<ProductUserModel> GetProductByCategoryMeMoRy(int CategoryID, int MeMoRy)
        {
            var result = _CategoriesBusiness.GetProductMeMoRy(CategoryID , MeMoRy);
            return result;
        }
        // Lay san pham theo khoang tien 
        [Route("GetProductByCategory/{CategoryID}&min_price/{min}and_Max_Price/{max}")]
        [HttpGet]
        public List<ProductUserModel> GetProductByCategoryMinAndMaxPrice(int CategoryID, int min, int max)
        {
            var result = _CategoriesBusiness.GetProductPrice(CategoryID, min, max);
            return result;
        }
        [Route("GetProductASCByCategory/{CategoryID}")]
        [HttpGet]
        public IActionResult GetProductASC(int CategoryID)
        {
            var result = _CategoriesBusiness.GetProductASC(CategoryID);
            return Ok(result);
        }
        [Route("GetProductByCategory/{CategoryID}")]
        [HttpGet]
        public IActionResult GetProductDesc(int CategoryID)
        {
            var result = _CategoriesBusiness.GetProductDesc(CategoryID);
            return Ok(result);
        }
        [Route("api/productsbyCategory/{CategoryID}/{pagesize}/{pagenumber}")]
        [HttpGet]
        public IActionResult GetProductByCategory(int CategoryID, int pagesize, int pagenumber)
        {
            var result = _CategoriesBusiness.PagingByCategory(CategoryID, pagesize, pagenumber);
            return Ok(result);
        }
        [Route("GetAllBrandByCategory/{CategoryID}")]
        [HttpGet]
        public List<GetAllBrandByCategoryModel> GetAllBrandByCategory(int CategoryID)
        {
            var result = _CategoriesBusiness.GetAllBrandByCategoryID(CategoryID);
            return result;
        }



    }
}
