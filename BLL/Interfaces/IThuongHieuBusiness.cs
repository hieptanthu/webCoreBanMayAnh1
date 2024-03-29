﻿using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IThuongHieuBusiness
    {

        ThuongHieu GetDatabyID(string id);
        bool Create(ThuongHieu model);
        bool Update(ThuongHieu model);

        bool Delete(string id);
        List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenThuongHieu);

    }
}
