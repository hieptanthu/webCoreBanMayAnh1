using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IthuongHieuRepository
    {
        ThuongHieu GetDatabyID(string id);
        bool Create(ThuongHieu model);
        bool Update(ThuongHieu model);

        bool Delete(string id);
        List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenThuongHieu);


    }
}
