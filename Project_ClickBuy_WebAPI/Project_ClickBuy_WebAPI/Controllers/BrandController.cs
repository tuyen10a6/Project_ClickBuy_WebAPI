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
    }
}
