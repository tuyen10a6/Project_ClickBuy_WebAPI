using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Model;
using ClickBuy.Model.ViewModel;

namespace ClickBuy.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandUserController : ControllerBase
    {
        private IBrandBusiness _BrandBusiness;
        public BrandUserController (IBrandBusiness brandBusiness)
        {
            _BrandBusiness = brandBusiness;
        }
        [Route("GetAllBrands")]
        [HttpGet]
        public List<BrandUserModel> GetAllBrands()
        {
            var result = _BrandBusiness.GetAllBrandz();
            return result;
        }
        [Route("GetASCProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetProductASCBrand(int BrandID)
        {
            var result = _BrandBusiness.GetProductASC(BrandID);
            return result;

        }
        [Route("GetDESCProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetProductDESCBrand(int BrandID)
        {
            var result = _BrandBusiness.GetProductDesc(BrandID);
            return result;

        }
        [Route("GetAllProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetAllProductBrand(int BrandID)
        {
            var result = _BrandBusiness.GetSanPhamByBrandID(BrandID);
            return result;
        }
        [Route("GetAllProductBrand/{BrandID}_bonhotrong/{memory}")]
        [HttpGet]
        public List<SanPhamModel> GetAllProductBrandByMeMoRy(int BrandID, int memory)
        {
            var result = _BrandBusiness.GetProductMeMory(BrandID, memory);
            return result;
        }
        [Route("GetProductBrand/{BrandID}_MinPrice/{min}_MaxPrice/{max}")]
        [HttpGet]
        public List<SanPhamModel> GetProductMinAndMaxBrand(int BrandID, int min, int max)
        {
            var result = _BrandBusiness.GetProductPrice(BrandID, min, max);
            return result;
        }
        [Route("GetProductBrand/{BrandName}")]
        [HttpGet]
        public List<BrandModel> SearchBrand(string BrandName)
        {
            var result = _BrandBusiness.SearchBrand(BrandName);
            return result;
        }
        [Route("GetProductByBrand/{BrandID}/{PageSize}/{PageNumber}")]
        [HttpGet]
        public List<SanPhamModel> GetProductByBrandPage(int BrandID, int PageSize, int PageNumber)
        {
            var result = _BrandBusiness.GetProductByPageBrand(BrandID, PageSize, PageNumber);
            return result;
        }
    }
}
