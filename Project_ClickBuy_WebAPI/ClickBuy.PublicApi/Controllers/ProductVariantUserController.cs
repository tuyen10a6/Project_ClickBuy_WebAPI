using BLL.Interfaces;
using ClickBuy.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickBuy.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantUserController : ControllerBase
    {
        private IProductVariantBusiness _ProductVariantBusiness;
        public ProductVariantUserController (IProductVariantBusiness ProductVariantBusiness)
        {
            _ProductVariantBusiness = ProductVariantBusiness;
        }
        [HttpGet]
        [Route("GetAllProductVariantByProduct/{ProductID}")]
        public List<ProductVariantUserModel> GetProductVariantByProductID(int ProductID)
        {
            var result = _ProductVariantBusiness.GetProductVariantIdProduct(ProductID);
            return result;

        }
           
    }
}
