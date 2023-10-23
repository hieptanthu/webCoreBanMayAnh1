using System;
using System.Collections.Generic;

namespace MODEL
{


    public  class DonHang
    {
      

        public int Id { get; set; }
        
    
        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        public int? TrangThai { get; set; }

        public decimal? ThanhTien { get; set; }
        public List<DiaChi> list_json_DiaChi { get; set; }

        public List<ChiTietDonHang> list_json_chitiethoadon { get; set; }

    }


    public class ChiTietDonHang
    {
        public int IdDonHang { get; set; }


        public int IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? GiaTien { get; set; }


    }

    public class DiaChi
    {

        public int Id { get; set; }


        public string ThanhPho { get; set; }


        public string Huyen { get; set; }


        public string Xa { get; set; }


        public string GiChu { get; set; }

        public int? IdTaiKhoan { get; set; }


    }





}
