using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class CustomerViewModel
    {
        public int id { get; set; }
        [DisplayName("Tên đăng nhập:")]
        [StringLength(50)]
        [Required(ErrorMessage ="Không được để trống!")]
        public string Account { get; set; }

        [DisplayName("Mật khẩu:")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Vui lòng điền mật khẩu")]
        public string Password { get; set; }

        [DisplayName("Tên")]
        [StringLength(50)]
        [Required(ErrorMessage ="Vui lòng điền tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage ="Vui lòng nhập số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int? Status { get; set; }

        [DisplayName("Địa chỉ đặt hàng")]
        [StringLength(200)]
        [Required(ErrorMessage = "Vui lòng điền địa chỉ")]
        public string Address { get; set; }


        [DisplayName("Thành Phố")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng điền thành phố")]
        public string City { get; set; }

        public int Point { get; set; }
        public string NewLocation { get; set; }
        public string LoginErrorMessage { get; set; }
        public string ErrorAccountExists { get; set; }
    }
   
}