using BLL.Interfaces;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanQuanLyController : ControllerBase
    {
        private ITaiKhoanQuanLyBusiness _Bll;
        public TaiKhoanQuanLyController(ITaiKhoanQuanLyBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("Login/")]
        [HttpGet]
        public TaiKhoanQuanLy Login([FromQuery] string userName, [FromQuery] string password)
        {
            return _Bll.Login(userName, password);
        }
        [Route("create-TaiKhoanQuanLy")]
        [HttpPost]
        public TaiKhoanQuanLy CreateItem([FromBody] TaiKhoanQuanLy model)
        {
            _Bll.Create(model);
            return model;
        }

        [Route("delete-TaiKhoanQuanLy/{id}")]
        [HttpDelete]
        public bool Delete([FromBody] string id)
        {
            
            return _Bll.Delete(id);
        }


        [Route("update-TaiKhoanQuanLy")]
        [HttpPost]
        public TaiKhoanQuanLy UpdateItem([FromBody] TaiKhoanQuanLy model)
        {
            _Bll.Update(model);
            return model;
        }
        
    }
}
