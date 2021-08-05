using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class PromotionModel
    {
        public int Id { get; set; }
        public DateTime? tuNgay { get; set; }
        public DateTime? denNgay { get; set; }
        public int? ratio { get; set; }
        public string Content { get; set; }
    }
}