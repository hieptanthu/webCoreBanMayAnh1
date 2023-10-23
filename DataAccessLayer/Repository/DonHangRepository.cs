using DAL;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class DonHangRepository : IDonHangRepository
    {

        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangDelete",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DonHang GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
               

                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangSelectAdmin",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);     

                return dt.ConvertTo<DonHang>().FirstOrDefault();

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<DonHang> Search(int pageIndex, int pageSize, out long total, string TaiKhoanId, string NgayTao, string NgayThanhToan, string TrangThai, string SanPhamId)
        {
            string msgError = "";
            List<DonHang> dh = new List<DonHang>();
            List<ChiTietDonHang> ChiTiet = new List<ChiTietDonHang>();
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangSearch",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TaiKhoanId", TaiKhoanId,
                    "@NgayTao", NgayTao,
                    "@NgayThanhToan", NgayThanhToan,
                    "@trangThai", TrangThai,
                    "@SanPhamId", SanPhamId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];


                dh = dt.ConvertTo<DonHang>().ToList();

               

                return dh;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            

        public bool Update(DonHang model)
        {
            throw new NotImplementedException();
        }
    }
}
