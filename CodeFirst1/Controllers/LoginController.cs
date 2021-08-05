using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst1.ViewModels;
using CodeFirst1.Database;
namespace CodeFirst1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string newLocation)
        {
            var viewModels = new CustomerViewModel
            {
                NewLocation = newLocation
            };
            return View(viewModels);
        }

        public ActionResult IndexAdmin()
        {
            return View("AdminLogin");
        }

        [HttpPost]
        public ActionResult AdminLogin(CodeFirst1.ViewModels.Admin admin)
        {
            var db = new Model1();
            var user = db.Admins.Where(x => x.Account == admin.Account && x.Password == admin.Password).FirstOrDefault();
            if (user == null)
            {
                admin.LoginErrorMessage = "Sai tên đăng nhập hoặc mật khẩu";
                return View("AdminLogin", admin);
            }
            else
            {
                Session["AdminId"] = user.Id;
                Session["AdminName"] = user.Name;
                Session["Status"] = user.Status;
                Session["ChucVu"] = "";
                if(user.Status == 0)
                {
                    Session["ChucVu"] = "Quản lý";
                }
                else if(user.Status == 1)
                {
                    Session["ChucVu"] = "NV bán hàng";
                }
                else
                {
                    Session["ChucVu"] = "NV giao hàng";
                }
                return RedirectToAction("Index", "User");
            }
        }

        [HttpPost]
        public ActionResult CustomerLogin(CustomerViewModel customer)
        {
            var db = new Model1();
            var user = db.Customers.Where(x => x.Account == customer.Account && x.Password == customer.Password).FirstOrDefault();
            if(user == null)
            {
                customer.LoginErrorMessage = "Sai tên đăng nhập hoặc mật khẩu";
                return View("Index", customer);
            }
            else
            {
                Session["UserId"] = user.Id;
                Session["UserName"] = user.Name;
                Session["Email"] = user.Email;
                Session["Phone"] = user.Phone;
                if(customer.NewLocation != null)
                {
                    return Redirect(customer.NewLocation);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("UserId");
            Session.Remove("UserName");
            Session.Remove("Email");
            Session.Remove("Phone");
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOutAdmin()
        {
            Session.Remove("AdminId");
            Session.Remove("AdminName");
            Session.Remove("Status");
            Session.Remove("ChucVu");
            return RedirectToAction("IndexAdmin", "Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult CustomerRegister(CustomerViewModel customer)
        {
            var db = new Model1();
            var user = db.Customers.Where(x => x.Account == customer.Account).FirstOrDefault();
            if(user == null)
            {
                var customerModel = new Customer();
                customerModel.Account = customer.Account;
                customerModel.Password = customer.Password;
                customerModel.Name = customer.Name;
                customerModel.Email = customer.Email;
                customerModel.Phone = customer.Phone;
                customerModel.Status = 1;
                customerModel.Points = 0;
                db.Customers.Add(customerModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Login",customer);
            }
            else
            {
                customer.ErrorAccountExists = "Tên tài khoản đã tồn tại";
                return View("Register", customer);
            }
            
        }
    }
}