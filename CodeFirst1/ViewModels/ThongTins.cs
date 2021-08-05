using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class ThongTins
    {
        public List<HangSanXuat> HangSanXuats = new List<HangSanXuat>();
        public List<KhuyenMais> KhuyenMais = new List<KhuyenMais>();
        public List<QuaTang> quaTangs = new List<QuaTang>();
    }

    public class HangSanXuat
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class KhuyenMais
    {
        public int Id { get; set; }
    }
    public class QuaTang
    {
        public int Id { get; set; }
    }
}