using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface ISanPhamRepository
    {
        SanPham GetDatabyID(string id);
        bool Create(SanPham model);
        bool Update(SanPham model);

        bool Delete(string id);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId , int ThuongHieuId,int LoaiSanPham, string slBan, DateTime NgayTao);
    }
}
