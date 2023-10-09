using DAL.Repository.Interfaces;
using DataAccessLayer;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class thuongHieuRepository : IthuongHieuRepository
    {
        private IDatabaseHelper _dbHelper;
        public thuongHieuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(ThuongHieu model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ThuongHieuInsert",
                "@TenThuongHieu", model.TenThuongHieu);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ThuongHieuDelete",
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

        public ThuongHieu GetDatabyID(string id)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ThuongHieuSelect",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuongHieu>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ThuongHieu> Search(int pageIndex, int pageSize, out long total, string tenThuongHieu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ThuongHieuSearch",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenThuongHieu", tenThuongHieu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThuongHieu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ThuongHieu model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ThuongHieuUpdate",
                     "@Id", model.Id,
                "@TenThuongHieu", model.TenThuongHieu);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
