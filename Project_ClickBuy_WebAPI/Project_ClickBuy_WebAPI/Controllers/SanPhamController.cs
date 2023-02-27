using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

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
        [Route("EditSanPham/{id}")]
        [HttpPost]
        public SanPhamModel Update(int id, SanPhamModel model)
        {
            _sanphamBusiness.UpdateSanPham(id, model);
            return model;
        }
        [Route("DeleteSanPham/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _sanphamBusiness.DeleteSanPham(id);
            return Ok("Xóa thành công");
           
        }
        [Route("GetByIdProduct/{productId}")]
        [HttpGet]
        public IActionResult GetProductWithVariantsAndAttributes(int productId)
        {
            try
            {
                var product = _sanphamBusiness.GetIDSanPham(productId);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
