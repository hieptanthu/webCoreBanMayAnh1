using BLL.Interfaces;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _Bll;
        public DanhMucController(IDanhMucBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get-DanhMucAll")]
        [HttpGet]
        public List<DanhMuc> GetDatabyAll()
        {
            return _Bll.GetDatabyAll();
        }
        [Route("create-DanhMuc")]
        [HttpPost]
        public DanhMuc CreateItem([FromBody] DanhMuc model)
        {
            _Bll.Create(model);
            return model;
        }

        [Route("delete-DanhMuc/{id}")]
        [HttpDelete]
        public bool Delete([FromBody] string id)
        {
            
            return _Bll.Delete(id);
        }


        [Route("update-DanhMuc")]
        [HttpPut]
        public DanhMuc UpdateItem([FromBody] DanhMuc model)
        {
            _Bll.Update(model);
            return model;
        }
        
        
    }
}
