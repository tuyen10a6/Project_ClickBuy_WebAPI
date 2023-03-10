using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Diagnostics;

namespace Project_ClickBuy_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private IProductVariantBusiness _sanphamBusiness;
        public ProductVariantController(IProductVariantBusiness SanPhamBus)
        {
            _sanphamBusiness = SanPhamBus;
        }
        [Route("GetByIdProductVariant/{productVariantID}")]
        [HttpGet]
        public IActionResult GetProductWithVariantsAndAttributes(int productVariantID)
        {
            try
            {
                var product = _sanphamBusiness.GetIDProductVariant(productVariantID);
                if (product == null)
                {
                    return NotFound("Không tìm thấy ProductVariant với ID trên");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("GetIdProduct/{ProductID}")]
        [HttpGet]
        public IActionResult GetVariantsIDProduct(int ProductID)
        {
            try
            {
                var product = _sanphamBusiness.GetProductVariantIdProduct(ProductID);
                if (product == null)
                {
                    return NotFound("Không tìm thấy ID sản phẩm này");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("AddListProductVariant")]
        [HttpPost]
        public IActionResult AddProductVariants(int productId, [FromBody] List<ProductVariantModel> variants)
        {
            try
            {
                _sanphamBusiness.AddProductVariant(productId, variants);
                return Ok(productId);
              
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("SearchProducVariant/{VariantName}")]
        [HttpGet]
        public IActionResult SearchProductVariant(string VariantName)
        {
           var ListProductVariant = _sanphamBusiness.SearchProductVariant(VariantName);
            return Ok(ListProductVariant);
        }
        [Route("DeleteProductVariant")]
        [HttpGet]
        public IActionResult DeleteProductVariant(int VariantID)
        {
            var result = _sanphamBusiness.DeteteProductVariant(VariantID);
            return Ok("Xóa thành công");
        }
    }
}
