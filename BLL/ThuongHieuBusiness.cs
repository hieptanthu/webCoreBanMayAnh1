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
    public class ThuongHieuBusiness : IThuongHieuBusiness
    {

        private IthuongHieuRepository _res;
        public ThuongHieuBusiness(IthuongHieuRepository res)
        {
            _res = res;
        }
        public bool Create(ThuongHieu model)
        {
            return _res.Create(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public ThuongHieu GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenThuongHieu)
        {
            return _res.Search(pageIndex, pageSize, out total, tenThuongHieu);
        }

        public bool Update(ThuongHieu model)
        {
            return _res.Update(model);
        }
    }
}
