using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class CheckOutViewModel
    {
        public List<Cart> Carts = new List<Cart>();
        public CustomerViewModel  CustomerViewModel= new CustomerViewModel();
    }
    public class SaveCheckOutViewModel
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public string ResonCancel { get; set; }
        public int CustomerId { get; set; }
        public decimal ProvisionalAmount { get; set; }
        public int PointsUse { get; set; }
        public DateTime DateProcessing { get; set; }



    }
}