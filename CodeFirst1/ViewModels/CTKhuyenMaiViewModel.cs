using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class CTKhuyenMaiViewModel
    {
        public int Id { get; set; }
        public DateTime? fromday { get; set; }
        public DateTime? today { get; set; }
        public int? ratio { get; set; }
        public string Content { get; set; }
        public List<ttsanpham> Ttsanphams = new List<ttsanpham>();
    }
   
    public class ttsanpham
    {
        public int id { get; set; }
        public string image { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }

    }
}