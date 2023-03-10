using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Project_ClickBuy_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesBusiness _sanphamBusiness;
        public CategoriesController(ICategoriesBusiness SanPhamBus)
        {
            _sanphamBusiness = SanPhamBus;
        }
        [Route("GetAllCategories")]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _sanphamBusiness.GetAllCate();
            return Ok(result);
        }
        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(CategoriesModel model)
        {
            var result = _sanphamBusiness.CreateCategories(model);
            return Ok("Thêm thành công");
        }
        [Route("UpdateCategory")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoriesModel model)
        {
            var result = _sanphamBusiness.UpdateCategories(model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int CategoryID)
        {
            var result = _sanphamBusiness.DeleteCategory(CategoryID);
            return Ok("Xóa danh mục thành công");
        }
        [Route("GetAllProductByCategoryID")]
        [HttpGet]
        public IActionResult GetAllProductByCategoryID(int CategoryID)
        {
            var result = _sanphamBusiness.GetSanPhamByCategoryID(CategoryID);
            return Ok(result);
        }
        [Route("GetAllProductPriceByCategoryID")]
        [HttpGet]
        public IActionResult GetAllProductPriceByCategoryID(int CategoryID , int min , int max)
        {
            var result = _sanphamBusiness.GetProductPrice(CategoryID, min, max);
            return Ok(result);
        }
        [Route("GetAllProductMeMoRyByCategoryID")]
        [HttpGet]
        public IActionResult GetAllProductMeMoRyByCategoryID(int CategoryID, int MeMoRy)
        {
            var result  = _sanphamBusiness.GetProductMeMoRy(CategoryID, MeMoRy);
            return Ok(result);
        }
        [Route("GetProductASC")]
        [HttpGet]
        public IActionResult GetProductASC(int CategoryID)
        {
            var result = _sanphamBusiness.GetProductASC(CategoryID);
            return Ok(result);
        }
        [Route("GetProductDESC")]
        [HttpGet]
        public IActionResult GetProductDesc(int CategoryID)
        {
            var result = _sanphamBusiness.GetProductDesc(CategoryID);
            return Ok(result);
        }
        
        
    }
}
