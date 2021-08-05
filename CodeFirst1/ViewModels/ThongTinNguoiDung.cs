using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class ThongTinNguoiDung
    {
        
    }
    public class ThongTin
    {
        public int? Id { get; set; }
        public string Account { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? status{ get; set; }
        public int? Point{ get; set; }
        public string LoiDangNhap { get; set; }
    }
    public class ThongTinHoaDon
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string ThanhPho { get; set; }
        public string Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Total { get; set; }
        public int? ID_xuli { get; set; }
        public string LyDo { get; set; }
        public string TenSanPham { get; set; }
        public int? SoLuongSP { get; set; }
    }
}