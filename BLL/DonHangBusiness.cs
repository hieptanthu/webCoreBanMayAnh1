using BLL.Interfaces;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DonHangBusiness : IDonHangBusiness
    {


        private IDonHangRepository _res;
        public DonHangBusiness(IDonHangRepository res)
        {
            _res = res;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public DonHang GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    

        public List<DonHang> Search(int pageIndex, int pageSize, out long total, string TaiKhoanId, string NgayTao, string NgayThanhToan, string TrangThai, string SanPhamId)
        {
            return _res.Search(pageIndex, pageSize, out total, TaiKhoanId, NgayTao, NgayThanhToan, TrangThai, SanPhamId);
        }

        

        public bool Update(DonHang model)
        {
            throw new NotImplementedException();
        }
    }
}
