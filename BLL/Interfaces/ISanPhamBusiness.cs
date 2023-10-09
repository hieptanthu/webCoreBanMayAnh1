using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISanPhamBusiness
    {

        SanPham GetDatabyID(string id);
        bool Create(SanPham model);
        bool Update(SanPham model);

        bool Delete(string id);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId, int ThuongHieuId, int LoaiSanPham);
    }
}
