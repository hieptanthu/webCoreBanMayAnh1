using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _Bll;
        public SanPhamController(ISanPhamBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPham GetDatabyID(string id)
        {
            return _Bll.GetDatabyID(id);
        }
        [Route("create-SanPham")]
        [HttpPost]
        public SanPham CreateItem([FromBody] SanPham model)
        {
            _Bll.Create(model);
            return model;
        }

        [Route("delete-SanPham/{id}")]
        [HttpDelete]
        public bool Delete([FromBody] string id)
        {
            
            return _Bll.Delete(id);
        }


        [Route("update-SanPham")]
        [HttpPut]
        public SanPham UpdateItem([FromBody] SanPham model)
        {
            _Bll.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse( formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"]))) { ten = Convert.ToString(formData["ten"]); }
                string DanhMucId = "";
                if (formData.Keys.Contains("DanhMucId") && !string.IsNullOrEmpty(Convert.ToString(formData["DanhMucId"]))) { DanhMucId = Convert.ToString(formData["DanhMucId"]); }
                string ThuongHieuId = "";
                if (formData.Keys.Contains("ThuongHieuId") && !string.IsNullOrEmpty(Convert.ToString(formData["ThuongHieuId"]))) { DanhMucId = Convert.ToString(formData["ThuongHieuId"]); }
                string LoaiSanPham = "";
                if (formData.Keys.Contains("LoaiSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["LoaiSanPham"]))) { DanhMucId = Convert.ToString(formData["LoaiSanPham"]); }
                string slBan = "";
                if (formData.Keys.Contains("slBan") && !string.IsNullOrEmpty(Convert.ToString(formData["slBan"]))) { slBan = Convert.ToString(formData["slBan"]); }
                string NgayTao = "";
                if (formData.Keys.Contains("NgayTao") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayTao"]))) { NgayTao = Convert.ToString(formData["NgayTao"]); }
                long total = 0;
                var data = _Bll.Search(page, pageSize, out total, ten, int.Parse(DanhMucId), int.Parse(ThuongHieuId), int.Parse(LoaiSanPham),slBan,DateTime.Parse(NgayTao));
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}
