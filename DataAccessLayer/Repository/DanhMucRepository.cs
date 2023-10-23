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
    public class DanhMucRepository : IDanhMucRepository
    {
        private IDatabaseHelper _dbHelper;
        public DanhMucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(DanhMuc model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[DanhMucInsert]",
                "@TenDanhMuc", model.TenDanhMuc,
                "@DanhMucConId", model.DanhMucConId
                );
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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DanhMucDelete",
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

        public List<DanhMuc> GetDatabyAll()
        {

            string msgError = "";
            try
            {
                //gọi danh mục con để tìm được câc cấp
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DanhMucSelect"
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhMuc>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        public bool Update(DanhMuc model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DanhMucUpdate",
                     "@Id", model.Id,
                "@TenDanhMuc", model.TenDanhMuc,
                "@DanhMucConId", model.DanhMucConId);
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
