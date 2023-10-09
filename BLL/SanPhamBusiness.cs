using BLL.Interfaces;
using DAL.Repository.Interfaces;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public bool Create(SanPham model)
        {
            return _res.Create(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public SanPham GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId, int ThuongHieuId, int LoaiSanPham)
        {
            return _res.Search(pageIndex, pageSize, out total, ten,DanhMucId,ThuongHieuId, LoaiSanPham);
        }

        public bool Update(SanPham model)
        {
            return _res.Update(model);
        }
    }
}
