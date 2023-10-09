using DAL.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucBusiness : IDanhMucBusiness
    {

        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        public bool Create(DanhMuc model)
        {
            return _res.Create(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<DanhMuc> GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Update(DanhMuc model)
        {
            return _res.Update(model);
        }
    }
}
