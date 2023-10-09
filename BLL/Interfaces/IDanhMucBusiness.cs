using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IDanhMucBusiness
    {

        List<DanhMuc> GetDatabyID(string id);

        bool Create(DanhMuc model);
        bool Update(DanhMuc model);

        bool Delete(string id);


    }
}
