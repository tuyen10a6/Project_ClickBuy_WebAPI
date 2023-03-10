using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Project_ClickBuy_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanphamBusiness;
        public SanPhamController(ISanPhamBusiness SanPhamBus)
        {
            _sanphamBusiness = SanPhamBus;
        }
        [Route("GetAllSanPham")]
        [HttpGet]
        public  List<SanPhamModel> getAllSanPham()
        {
            return _sanphamBusiness.GetAllSanPham();
        }
        [Route("SearchProduct/{ProductName}")]
        [HttpGet]
        public IActionResult SearchProduct(string ProductName)
        {
            var listsanpham = _sanphamBusiness.SearchProducts(ProductName);
            return Ok(listsanpham);
        }

        [Route("AddSanPham")]
        [HttpPost]
        public SanPhamModel AddProduct([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.AddSanPham(model);
            return model;

        }
        [Route("EditSanPham")]
        [HttpPost]
        public SanPhamModel Update(SanPhamModel model)
        {
            _sanphamBusiness.UpdateSanPham( model);
            return model;
        }
        [Route("DeleteSanPham/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _sanphamBusiness.DeleteSanPham(id);
            return Ok("Xóa thành công");
           
        }
        //[Route("GetByIdProduct/{productId}")]
        //[HttpGet]
        //public IActionResult GetProductWithVariantsAndAttributes(int productId)
        //{
        //    try
        //    {
        //        var product = _sanphamBusiness.GetIDSanPham(productId);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        [Route("GetMeMoRy/{id}")]
        [HttpGet]
        public IActionResult GetProductMeMoRy(int id)
        {
            var result = _sanphamBusiness.GetProductMeMoRy(id);
            return Ok(result);
         
        }
        [Route("GetMin/{min}_Max/{max}")]
        [HttpGet]
        public IActionResult GetProductsByPriceRange(int min, int max)
        {
            var result = _sanphamBusiness.GetProductsByPriceRange(min, max);
            return Ok(result);
        }

    }
}
