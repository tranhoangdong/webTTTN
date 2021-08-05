using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductViewModel ProductDetail = new ProductViewModel();
        public List<ProductViewModel> RelatedProducts = new List<ProductViewModel>();
        public List<ProductViewModel> TopViewOfProducts = new List<ProductViewModel>();
        public Comment Comment = new Comment();
        public List<Comment> Comments = new List<Comment>();
        public List<Accessories> relatedAccessories = new List<Accessories>();
        public List<internalMemorys> internalMemorys = new List<internalMemorys>();
        public DetailsProduct DetailsProduct { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Tên")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn!")]
        public string Name { get; set; }

        public DateTime? Time { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng điền địa chỉ Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Content { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng điền số điện thoại")]
        public double? Phone { get; set; }
    }
    public class internalMemorys
    {
        public string internalMemoryName { get; set; }
        public string Price { get; set; }
        public int Id { get; set; }
       public bool isGn { get; set; }
    }

}