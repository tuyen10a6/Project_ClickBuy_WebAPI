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

        [Route("AddSanPham")]
        [HttpPost]
        public SanPhamModel AddProduct([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.AddSanPham(model);
            return model;

        }
        [Route("EditSanPham{id}")]
        [HttpPost]
        public SanPhamModel Update(int id, SanPhamModel model)
        {
            _sanphamBusiness.UpdateSanPham(id, model);
            return model;
        }
    }
}
