﻿using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuongHieuController : ControllerBase
    {
        private IThuongHieuBusiness _Bll;
        public ThuongHieuController(IThuongHieuBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ThuongHieu GetDatabyID(string id)
        {
            return _Bll.GetDatabyID(id);
        }
        [Route("create-ThuongHieu")]
        [HttpPost]
        public ThuongHieu CreateItem([FromBody] ThuongHieu model)
        {
            _Bll.Create(model);
            return model;
        }

        [Route("delete-ThuongHieu/{id}")]
        [HttpDelete]
        public bool Delete([FromBody] string id)
        {
            
            return _Bll.Delete(id);
        }


        [Route("update-ThuongHieu")]
        [HttpPut]
        public ThuongHieu UpdateItem([FromBody] ThuongHieu model)
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
                long total = 0;
                var data = _Bll.Search(page, pageSize, out total, ten);
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
