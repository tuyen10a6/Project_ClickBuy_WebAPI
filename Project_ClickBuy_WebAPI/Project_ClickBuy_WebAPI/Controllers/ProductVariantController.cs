using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
