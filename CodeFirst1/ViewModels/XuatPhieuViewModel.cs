using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class XuatPhieuViewModel
    {
        public OrderInOrderDetail orderInOrderDetail = new OrderInOrderDetail();
        public List<SanPhamXuatPhieu> sanPhamXuatPhieus = new List<SanPhamXuatPhieu>();
    }

    public class SanPhamXuatPhieu
    {
        public string Anh { get; set; }
        public string Ten { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class ThongKe
    {
        public string tensp { get; set; }
        public int? slb { get; set; }
        public decimal? dongia { get; set; }
        public decimal? tongtien { get; set; }
    }
    public class doanhthuthang
    {
        public int? thang { get; set; }
        public int? sldh { get; set; }
        public Decimal? tongtien { get; set; }
    }
    public class InPhieuDonHangTungThang
    {
        public int? madonhang { get; set; }
        public int? idkh { get; set; }
        public string tenkh { get; set; }
        public DateTime? ngaylap { get; set; }
        public Decimal? tongtien { get; set; }
        public string loi { get; set; }
    }
}