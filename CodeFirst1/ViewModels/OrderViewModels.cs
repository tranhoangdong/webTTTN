using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class OrderViewModels
    {
        public List<OrderModel> OrderModels = new List<OrderModel>();
    }
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime? NgayDat { get; set; }
        public string Name { get; set; }
        public decimal TongTien { get; set; }
        public int? CustomerId { get; set; }
        public int? status { get; set; }
    }
}