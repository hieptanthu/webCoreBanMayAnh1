﻿using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDonHangBusiness
    {
        DonHang GetDatabyID(string id);
        bool Update(DonHang model);
        bool Delete(string id);
        List<DonHang> Search(int pageIndex, int pageSize, out long total, string TaiKhoanId, string NgayTao, string NgayThanhToan, string TrangThai,
            string SanPhamId);
    }
}
