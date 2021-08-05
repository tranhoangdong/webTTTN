using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class OrderDetailsViewModel
    {
        public List<OrderDetails> OrderDetails = new List<OrderDetails>();
        public OrderInOrderDetail OrderInOrderDetail = new OrderInOrderDetail();
    }
    public class OrderInOrderDetail
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal Total { get; set; }
        public int? status { get; set; }
        public string ReasonCancel { get; set; }
        public int? CustomerId { get; set; }
        public decimal ProvisionalAmount { get; set; }
        public DateTime? DateProcessing { get; set; }
        public int? AdminId { get; set; }
        public int? PointsUse { get; set; }
        public int SoDonHang { get; set; }
        public int? tongSL { get; set; }
    }
    public class OrderDetails
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public string image { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public string Ram { get; set; }
        public string InternalMemory { get; set; }
        public int? SoLuongKho { get; set; }
        public string Battery { get; set; }
        public string CPU { get; set; }
        public string Mota1 { get; set; }
        public string Mota2 { get; set; }
        public string Mota3 { get; set; }
        public string Mota4 { get; set; }
        public int? Status { get; set; }
        public int? Guarantee { get; set; }
    }

}