using DAL;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SanPhamRepository : ISanPhamRepository
    {

        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(SanPham model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SanPhamInsert",
                "@TenSanPham", model.TenSanPham,
                "@MotaSp", model.MotaSp,
                "@anh", model.anh,
                "@DanhSachAnh", model.DanhSachAnh,
                "@GiaSanPham", model.GiaSanPham,
                "@BaoHanh", model.BaoHanh,
                "@TomTatSanPham", model.TomTatSanPham,
                "@LoaiSanPham", model.LoaiSanPham,
                "@SoLuong", model.SoLuong,
                "@NgayTao", model.NgayTao,
                "@IdDanhMuc", model.IdDanhMuc,
                "@IdThuongHieu", model.IdThuongHieu

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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamDelete",
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

        public SanPham GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamSelect",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId, int ThuongHieuId, int LoaiSanPham,string slBan,DateTime NgayTao)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ThuongHieuSearch",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Ten", ten,
                     "@DanhMucId", DanhMucId,
                      "@ThuongHieuId", ThuongHieuId,
                       "@LoaiSanPham", LoaiSanPham,
                       "@slBan", slBan,
                        "@NgayTao", NgayTao

                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SanPham model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SanPhamUpdate",
                "@TenSanPham", model.TenSanPham,
                "@MotaSp", model.MotaSp,
                "@anh", model.anh,
                "@DanhSachAnh", model.DanhSachAnh,
                "@GiaSanPham", model.GiaSanPham,
                "@BaoHanh", model.BaoHanh,
                "@TomTatSanPham", model.TomTatSanPham,
                "@LoaiSanPham", model.LoaiSanPham,
                "@SoLuong", model.SoLuong,
                "@NgayTao", model.NgayTao,
                "@IdDanhMuc", model.IdDanhMuc,
                "@IdThuongHieu", model.IdThuongHieu

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
    }
}
