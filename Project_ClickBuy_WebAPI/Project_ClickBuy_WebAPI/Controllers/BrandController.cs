using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Project_ClickBuy_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandBusiness _sanphamBusiness;
        public BrandController(IBrandBusiness SanPhamBus)
        {
            _sanphamBusiness = SanPhamBus;
        }
        [Route("GetAllBrands")]
        [HttpGet]
        public List<BrandModel> GetAllBrand()
        {
            return _sanphamBusiness.GetAllBrand();
        }
        [Route("CreateBrand")]
        [HttpPost]
        public IActionResult AddBrand(BrandModel brand)
        {
           var result =  _sanphamBusiness.CreateBrand(brand);
            return Ok("Thêm thành công");
        }
        [Route("UpdateBrand")]
        [HttpPost]
        public IActionResult UpdateBrand(BrandModel brand)
        {
            var result = _sanphamBusiness.UpdateBrand(brand);
            return Ok("Sửa thành công");
        }
        [Route("DeleteBrand/{id}")]
        [HttpPost]
        public IActionResult DeleteBrand(int id)
        {
            var result = _sanphamBusiness.DeleteBrand(id);
            return Ok("Xóa thành công");
        }
        [Route("GetASCProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetProductASCBrand(int BrandID)
        {
            var result = _sanphamBusiness.GetProductASC(BrandID);
            return result;
            
        }
        [Route("GetDESCProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetProductDESCBrand(int BrandID)
        {
            var result = _sanphamBusiness.GetProductDesc(BrandID);
            return result;

        }
        [Route("GetAllProductBrand/{BrandID}")]
        [HttpGet]
        public List<SanPhamModel> GetAllProductBrand(int BrandID)
        {
            var result = _sanphamBusiness.GetSanPhamByBrandID(BrandID);
            return result;
        }
        [Route("GetAllProductBrand/{BrandID}_bonhotrong/{memory}")]
        [HttpGet]
        public List<SanPhamModel> GetAllProductBrandByMeMoRy(int BrandID, int memory)
        {
            var result = _sanphamBusiness.GetProductMeMory(BrandID , memory);
            return result;
        }
        [Route("GetProductBrand/{BrandID}_MinPrice/{min}_MaxPrice/{max}")]
        [HttpGet]
        public List<SanPhamModel> GetProductMinAndMaxBrand (int BrandID , int min , int max)
        {
            var result = _sanphamBusiness.GetProductPrice(BrandID, min, max);
            return result;
        }
        [Route("GetProductBrand/{BrandName}")]
        [HttpGet]
        public List<BrandModel> SearchBrand(string BrandName)
        {
            var result = _sanphamBusiness.SearchBrand(BrandName);
            return result;
        }
        [Route("GetProductByBrand/{BrandID}/{PageSize}/{PageNumber}")]
        [HttpGet]
        public List<SanPhamModel> GetProductByBrandPage(int BrandID, int PageSize, int PageNumber)
        {
            var result = _sanphamBusiness.GetProductByPageBrand(BrandID, PageSize, PageNumber);
            return result;
        }    

    }
}
