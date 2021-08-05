using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst1.ViewModels
{
    public class PhanQuyenModel
    {
        
    }
    public class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [DisplayName("Tên đăng nhập:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống!")]
        public string Account { get; set; }

        [DisplayName("Mật khẩu:")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        public string Password { get; set; }

        public int? Status { get; set; }

        public string TenQuyen { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}