using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class AddPromotionViewModel
    {
        public List<promotio> promotios { get; set; }
        public List<HSXViewModel> hSXViewModels { get; set; }
        public List<int> IdProduct { get; set; }
       
    }
    public class promotio
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Ratio { get; set; }
        public string Content { get; set; }
    }
    public class HSXViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListProductPromotion> Products { get; set; }
    }
    public class ListProductPromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
