using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst1.Database;
using CodeFirst1.ViewModels;

namespace CodeFirst1.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Xemgiohang()
        {
          
            List<Cart> lstGiohang = (List<Cart>)Session["GioHang"] as List<Cart>;
            if (lstGiohang == null)
            {
                //Neu chua co gio hang thi tao moi 1 gio hang
                lstGiohang = new List<Cart>();
                Session["GioHang"] = lstGiohang;
            }
            return View("Index", lstGiohang);
        }

        public ActionResult KhongTK()
        {
            var viewModel = new CheckOutViewModel();
            //Lấy thông tin của Khách Hàng
            var idUser = Convert.ToInt32(Session["UserId"]);
            var User = new CustomerViewModel();
            User.Name ="";
            User.Account ="";
            User.Password ="";
            User.Email = "";
            User.Phone = "0";
            User.Point = 0;
            //Thêm vào Model
            viewModel.CustomerViewModel = User;
            //Lấy giỏ hàng
            List<Cart> lstGiohang = (List<Cart>)Session["GioHang"] as List<Cart>;
            viewModel.Carts = lstGiohang;
            return View("KhongTKCheckOut", viewModel);
        }

        public ActionResult CheckOut()
        {
            var viewModel = new CheckOutViewModel();
            //Lấy thông tin của Khách Hàng
            var idUser = Convert.ToInt32(Session["UserId"]);
            var userInfo = db.Customers.FirstOrDefault(x => x.Id == idUser);
            var User = new CustomerViewModel();
            User.Name = userInfo.Name;
            User.Email = userInfo.Email;
            User.Phone = userInfo.Phone;
            User.Point = userInfo.Points;
            //Thêm vào Model
            viewModel.CustomerViewModel = User;
            //Lấy giỏ hàng
            List<Cart> lstGiohang = (List<Cart>)Session["GioHang"] as List<Cart>;
            viewModel.Carts = lstGiohang;
            return View("CheckOut" , viewModel);
        }

        public List<Cart> LayGioHang()
        {
            List<Cart> lstGiohang = (List<Cart>)Session["GioHang"] as List<Cart>;
            if (lstGiohang == null)
            {
                //Neu chua co gio hang thi tao moi 1 gio hang
                lstGiohang = new List<Cart>();
                Session["GioHang"] = lstGiohang;
            }
            return lstGiohang;
        }
        //Them gio hang
        public ActionResult ThemGioHang(int masanpham, int sl, int CategoryId)
        {
            if(CategoryId == 1)
            {
                Product product = db.Products.SingleOrDefault(n => n.Id == masanpham);
                db.SaveChanges();
                if (product == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<Cart> lstGiohang = LayGioHang();
                //Kiem tra san pham co ton tai trong session gio hang chua
                Cart gh = lstGiohang.Find(n => n.IdProduct == masanpham && n.CategoryID == 1);
                if (gh == null)
                {
                    gh = new Cart(masanpham, sl , CategoryId);
                    lstGiohang.Add(gh);
                }
                else
                {
                    gh.Quantity = sl;
                }
                return Json("ThanhCong");
            }
            else
            {
                CodeFirst1.Database.Accessory  accessory= db.Accessories.SingleOrDefault(x => x.Id == masanpham);
                db.SaveChanges();
                if (accessory == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<Cart> lstGiohang = LayGioHang();
                //Kiem tra san pham co ton tai trong session gio hang chua
                Cart gh = lstGiohang.Find(n => n.IdProduct == masanpham && n.CategoryID == 2);
                if (gh == null)
                {
                    gh = new Cart(masanpham, sl, CategoryId);
                    lstGiohang.Add(gh);
                }
                else
                {
                    gh.Quantity = sl;
                }
                return Json("ThanhCong");
            }
            //var slht = sanpham.SoLuong;
            //sanpham.SoLuong = slht - 1;
       
          
            //lay ra session gio hang
          
        }
        //Cap nhat gio hang

        public ActionResult CapNhatgiohang(int masanpham, int txtsoluong , int categoryId)
        {
            //Kiểm tra Loại
            if(categoryId == 1)
            {
                Product sp = db.Products.SingleOrDefault(n => n.Id == masanpham);
                if (sp == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<Cart> lstGiohang = LayGioHang();
                Cart gh = lstGiohang.SingleOrDefault(n => n.IdProduct == masanpham && n.CategoryID == 1);
                if (gh != null)
                {
                    Cart ghang = lstGiohang.SingleOrDefault(n => n.IdProduct == masanpham && n.CategoryID ==1);
                    gh.Quantity = txtsoluong;
                }
                var thanhtien = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(gh.Quantity * gh.Price), 0)));
                var toTal = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(lstGiohang.Sum(x => x.Price * x.Quantity)), 0)));
                var tongSL = lstGiohang.Sum(x => x.Quantity);
                var data = new { txtsoluong, thanhtien, toTal, tongSL };
                return Json(data);
            }
            else
            {
                CodeFirst1.Database.Accessory sp = db.Accessories.SingleOrDefault(n => n.Id == masanpham);
                if (sp == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<Cart> lstGiohang = LayGioHang();
                Cart gh = lstGiohang.SingleOrDefault(n => n.IdProduct == masanpham && n.CategoryID == 2);
                if (gh != null)
                {
                    Cart ghang = lstGiohang.SingleOrDefault(n => n.IdProduct == masanpham && n.CategoryID == 2);
                    gh.Quantity = txtsoluong;
                }
                var thanhtien = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(gh.Quantity * gh.Price), 0)));
                var toTal = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(lstGiohang.Sum(x => x.Price * x.Quantity)), 0)));
                var tongSL = lstGiohang.Sum(x => x.Quantity);
                var data = new { txtsoluong, thanhtien, toTal, tongSL };
                return Json(data);
            }
          
        }
        //Xóa giỏ hàng
        public ActionResult Xoagiohang(int masanpham , int categoryId)
        {
            ////Kiểm tra mã sản phẩm
            //Product sp = db.Products.SingleOrDefault(n => n.Id == masanpham);
            ////Nếu có lỗi sẽ trả về trang lỗi 404
            //if (sp == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            List<Cart> lstGiohang = LayGioHang();
            if(lstGiohang.Count != 0)
            {
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa
                Cart gh = lstGiohang.SingleOrDefault(n => n.IdProduct == masanpham && n.CategoryID == categoryId);
                //Nếu tồn tại thì sửa số lượng lại
                if (gh != null)
                {
                    lstGiohang.RemoveAll(n => n.IdProduct == masanpham && n.CategoryID == categoryId);
                }
                //cập nhật lại giỏ hàng qua js
                var toTal = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(lstGiohang.Sum(x => x.Price * x.Quantity)), 0)));
                var tongSL = lstGiohang.Sum(x => x.Quantity);
                var data = new { toTal, tongSL };
                return Json(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // Xây dựng trang giỏ hàng
        public ActionResult giohang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Cart> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        // Tính tổng sô lượng và tổng tiền
        //Tính tổng số lượng của từng món
        private int Tongsoluong()
        {
            int tongsoluong = 0;
            List<Cart> lstGioHang = Session["GioHang"] as List<Cart>;
            if (lstGioHang != null)
            {
                tongsoluong = lstGioHang.Sum(n => n.Quantity);
            }
            return tongsoluong;
        }
        //Tính tổng thành tiền
        private decimal? Tongtien()
        {
            decimal? tongtien = 0;
            List<Cart> lstGioHang = Session["GioHang"] as List<Cart>;
            if (lstGioHang != null)
            {
                tongtien = lstGioHang.Sum(n => n.IntoMoney);

            }

            return tongtien;
        }

        public ActionResult Luudonhang(SaveCheckOutViewModel model)
        {
            List<Cart> gh = (List<Cart>)Session["GioHang"];
            Order DonHang = new Order();
            DonHang.Address = model.Address;
            DonHang.ProvisionalAmount = model.ProvisionalAmount;
            DonHang.Phone = model.Phone;
            DonHang.City = model.City;
            DonHang.Email = model.Email;
            DonHang.OrderDate = DateTime.Now;
            DonHang.Total = model.Total;
            DonHang.Status = 0;
            DonHang.ReasonCancel = null;
            DonHang.CustomerId = model.CustomerId;
            DonHang.DateProcessing = null;
            DonHang.PointsUse = model.PointsUse;
            db.Orders.Add(DonHang);
            db.SaveChanges();
            foreach (Cart item in gh)
            {
                OrderDetail chitiet = new OrderDetail();
                chitiet.OrderId = DonHang.Id;
                if(item.CategoryID == 1)
                {
                    chitiet.Quantity = item.Quantity;
                    chitiet.CategoryId = item.CategoryID;
                    var spham = db.Products.Where(x => x.Id == item.IdProduct).FirstOrDefault();
                    spham.Quantity = spham.Quantity - item.Quantity;
                    chitiet.ProductId = Convert.ToInt32(item.IdProduct);
                    chitiet.UnitPrice = item.Price;
                    db.OrderDetails.Add(chitiet);
                    db.SaveChanges();
                }
                else
                {
                    chitiet.Quantity = item.Quantity;
                    chitiet.CategoryId = item.CategoryID;
                    var spham = db.Accessories.Where(x => x.Id == item.IdProduct).FirstOrDefault();
                    spham.Quantity = spham.Quantity - item.Quantity;
                    chitiet.ProductId = Convert.ToInt32(item.IdProduct);
                    chitiet.UnitPrice = item.Price;
                    db.OrderDetails.Add(chitiet);
                    db.SaveChanges();
                }
            }
            //Trừ điểm người dùng đã sử dụng
            var user = db.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            user.Points = user.Points - model.PointsUse;
            db.SaveChanges();
            Session.Remove("giohang");
            var data = DonHang.Id;
            return Json(data, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("DatHangThanhCong", new {id = DonHang.Id });
        }

        public ActionResult KiemTraTK( string tk)
        {
            var db = new Model1();
            var user = db.Customers.Where(x => x.Account == tk).FirstOrDefault();
            var data = "";
            if (user == null)
            {
                data = "";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                data = "Tên này đã tồn tại";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult DangKyValuuDonhang(SaveCheckOutViewModel model)
        {
            //Tạo Tài Khoản
            var customerModel = new Customer();
            customerModel.Account = model.Account;
            customerModel.Password = "123";
            customerModel.Name = model.Name;
            customerModel.Email = model.Email;
            customerModel.Phone = model.Phone;
            customerModel.Status = 1;
            customerModel.Points = 0;
            db.Customers.Add(customerModel);
            db.SaveChanges();
            //Tự đăng nhập
            var iduser = db.Customers.FirstOrDefault(x => x.Account == model.Account && x.Password == "123").Id;
            Session["UserId"] = iduser;
            Session["UserName"] = model.Name;
            Session["Email"] = model.Email;
            Session["Phone"] = model.Phone;
            //Lấy ID Tài khoản
            var idus = db.Customers.FirstOrDefault(x => x.Account == model.Account).Id;

            List<Cart> gh = (List<Cart>)Session["GioHang"];
            Order DonHang = new Order();
            DonHang.Address = model.Address;
            DonHang.ProvisionalAmount = model.ProvisionalAmount;
            DonHang.Phone = model.Phone;
            DonHang.City = model.City;
            DonHang.Email = model.Email;
            DonHang.OrderDate = DateTime.Now;
            DonHang.Total = model.Total;
            DonHang.Status = 0;
            DonHang.ReasonCancel = null;
            DonHang.CustomerId = idus;
            DonHang.DateProcessing = null;
            DonHang.PointsUse = model.PointsUse;
            db.Orders.Add(DonHang);
            db.SaveChanges();
            foreach (Cart item in gh)
            {
                OrderDetail chitiet = new OrderDetail();
                chitiet.OrderId = DonHang.Id;
                if (item.CategoryID == 1)
                {
                    chitiet.Quantity = item.Quantity;
                    chitiet.CategoryId = item.CategoryID;
                    var spham = db.Products.Where(x => x.Id == item.IdProduct).FirstOrDefault();
                    spham.Quantity = spham.Quantity - item.Quantity;
                    chitiet.ProductId = Convert.ToInt32(item.IdProduct);
                    chitiet.UnitPrice = item.Price;
                    db.OrderDetails.Add(chitiet);
                    db.SaveChanges();
                }
                else
                {
                    chitiet.Quantity = item.Quantity;
                    chitiet.CategoryId = item.CategoryID;
                    var spham = db.Accessories.Where(x => x.Id == item.IdProduct).FirstOrDefault();
                    spham.Quantity = spham.Quantity - item.Quantity;
                    chitiet.ProductId = Convert.ToInt32(item.IdProduct);
                    chitiet.UnitPrice = item.Price;
                    db.OrderDetails.Add(chitiet);
                    db.SaveChanges();
                }
            }
            Session.Remove("giohang");
            var iddhh = DonHang.Id;
            var data = new { iddhh, iduser };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DatHangThanhCong(int OrderId , int UserId)
        {
            return View("ThanhCong");
        }

    }
}