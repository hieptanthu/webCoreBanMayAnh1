using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IthuongHieuRepository
    {
        public bool Create(ThuongHieu model);
        public bool Delete(string id);
        public ThuongHieu GetDatabyID(string id);
        public List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenThuongHieu);
        public bool Update(ThuongHieu model);
    }
}
