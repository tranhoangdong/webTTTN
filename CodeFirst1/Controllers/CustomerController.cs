using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst1.Database;
using CodeFirst1.ViewModels;
using Rotativa;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.IO;
namespace CodeFirst1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HoSoNguoiDung()
        {
            var Model = new ThongTin();
            if (Session["UserName"] != null)
            {
                var idnd = Convert.ToInt32(Session["UserId"].ToString());
                var db = new Model1();
                var thongTin = db.Customers.FirstOrDefault(x => x.Id == idnd);
                Model.Id = thongTin.Id;
                Model.Name = thongTin.Name;
                Model.Pass = thongTin.Password;
                Model.Email = thongTin.Email;
                Model.Account = thongTin.Account;
                Model.Phone = thongTin.Phone;
                Model.Point = thongTin.Points;
                Model.status = thongTin.Status;
            }
            else
            {
                Model.LoiDangNhap = "Phiên đăng nhập đã hết hạn";
            }
            return View("HoSoNguoiDung", Model);
        }

        public ActionResult SuaThongTinTaiKhoan(string tk, string em, string sdt, string mk)
        {
            var db = new Model1();
            var id = Convert.ToInt32(Session["UserId"]);
            var suatt = db.Customers.FirstOrDefault(x => x.Id == id);

            suatt.Account = tk;
            suatt.Email = em;
            suatt.Phone = sdt;
            suatt.Password = mk;
            db.SaveChanges();
            return Json("ThanhCong");
        }

        public ActionResult Order()
        {
            return View("OrderCustomer");
        }

        public ActionResult OrderView(int id)
        {
            if(Session["UserId"]!= null)
            {
                var db = new Model1();
                var idkh = Convert.ToInt32(Session["UserId"].ToString());
                var Model = new List<OrderModel>();
                var order = db.Orders.Where(x => x.Status == id && x.CustomerId == idkh).ToList();
                foreach (var item in order)
                {
                    var OrderModel = new OrderModel();
                    OrderModel.Id = item.Id;
                    OrderModel.Name = item.Customer.Name;
                    OrderModel.NgayDat = item.OrderDate;
                    OrderModel.TongTien = item.Total;
                    OrderModel.CustomerId = item.CustomerId;
                    Model.Add(OrderModel);
                }
                return PartialView("_DonHang", Model);
            }
            else
            {
                return Content("Bạn cần đăng nhập");
            }
           
        }

        public ActionResult ThongTinChiTietHoaDonUSer(int id)
        {
            var db = new Model1();
            var Model = new OrderDetailsViewModel();
            var Order = db.Orders.FirstOrDefault(x => x.Id == id);
            var OrderModel = new OrderInOrderDetail();
            OrderModel.Id = Order.Id;
            OrderModel.Address = Order.Address;
            OrderModel.Phone = Order.Phone;
            OrderModel.City = Order.City;
            OrderModel.Email = Order.Email;
            OrderModel.OrderDate = Order.OrderDate;
            OrderModel.Total = Order.Total;
            OrderModel.status = Order.Status;
            OrderModel.ReasonCancel = Order.ReasonCancel;
            OrderModel.CustomerId = Order.CustomerId;
            OrderModel.ProvisionalAmount = Order.ProvisionalAmount;
            OrderModel.DateProcessing = Order.DateProcessing;
            OrderModel.AdminId = Order.AdminId;
            OrderModel.Name = db.Customers.FirstOrDefault(x => x.Id == Order.CustomerId).Name;
            OrderModel.PointsUse = Order.PointsUse;
            var soDonHang = db.Orders.Where(x => x.CustomerId == Order.CustomerId).Count();
            OrderModel.SoDonHang = soDonHang;
            Model.OrderInOrderDetail = OrderModel;
            var chitietsphoadon = db.OrderDetails.Where(x => x.OrderId == id).OrderBy(y => y.CategoryId).ToList();
            foreach (var item in chitietsphoadon)
            {
                var OrderDetail = new OrderDetails();
                OrderDetail.OrderId = item.OrderId;
                OrderDetail.ProductId = item.ProductId;
                OrderDetail.Quantity = item.Quantity;
                OrderDetail.UnitPrice = item.UnitPrice;
                OrderDetail.CategoryId = item.CategoryId;
                OrderDetail.Status = db.Orders.FirstOrDefault(x => x.Id == id).Status;
                OrderDetail.image = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Product_Image.FirstOrDefault(y => y.IdProducts == item.ProductId).Image1 : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Image;
                OrderDetail.Name = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Name : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Name;
                OrderDetail.SoLuongKho = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Quantity : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Quantity;
                Model.OrderDetails.Add(OrderDetail);
            }
            return View("ChiTietHoaDonUser", Model);
        }

        public ActionResult LayDanhSachSanPhamDaXem()
        {
            var idnd = Convert.ToInt32(Session["UserId"].ToString());
            var db = new Model1();
            var ListDT = db.Watcheds.Where(x => x.DateTime == DateTime.Today && x.CustomerId == idnd && x.CategoryId == 1).Select(y=>y.ProductId).Distinct().ToList();
            var products = db.Products.Where(y=>ListDT.Contains(y.Id)).ToList();
            // Map to view model
            var productViewMosels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var sp = new ProductViewModel();
                sp.Id = product.Id;
                sp.Name = product.Name;
                sp.FrontCamera = product.FrontCamera;
                sp.RearCamera = product.RearCamera;
                sp.Ram = product.Ram;
                sp.CPU = product.CPU;
                sp.InternalMemory = product.InternalMemory;
                sp.Quantity = product.Quantity;
                sp.Manufacturer = product.Manufacturer.Name;
                sp.Sim = product.Sim;
                sp.Battery = product.Battery;
                sp.OperatingSystem = product.OperatingSystem;
                sp.DateSubmitted = product.DateSubmitted;
                sp.CategoryId = product.CategoryId;
                sp.Guarantee = product.Guarantee;
                sp.Image1 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image1;
                sp.Image2 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image2;
                sp.Image3 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image3;
                sp.Image4 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image4;
                sp.Image5 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image5;
                sp.NumberOfView = product.NumberOfView;
                if (product.PromotionId != null && product.Promotion.FromDay < DateTime.Now && DateTime.Now < product.Promotion.ToDay)
                {
                    sp.FromDay = product.Promotion.FromDay;
                    sp.ToDay = product.Promotion.ToDay;
                    sp.IsKM = true;
                    sp.Ratio = product.Promotion.Ratio;
                    sp.Content = product.Promotion.Content;
                    sp.Price = product.Price;
                    sp.PriceKM = product.Price - Convert.ToDecimal(Convert.ToDecimal(product.Promotion.Ratio) / 100) * product.Price;
                }
                else
                {
                    sp.Price = product.Price;
                }
                if (product.GiftId != null)
                {
                    sp.InfoGift = product.Gift.Content;
                    sp.isGift = true;
                }
                else
                {
                    sp.isGift = false;
                }
                if (Session["UserId"] != null)
                {
                    var idUser = Convert.ToInt32(Session["UserId"]);
                    if (product.FavoriteProducts != null && product.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1 && x.CategoryId == 1).Count() >= 1)
                    {
                        sp.Favorive = true;
                    }
                    else
                    {
                        sp.Favorive = false;
                    }
                }
                else if (Session["UserId"] == null)
                {
                    sp.Favorive = false;
                }
                productViewMosels.Add(sp);
            }
            //get Accessories
            var ListPK = db.Watcheds.Where(x => x.DateTime == DateTime.Today && x.CustomerId == idnd && x.CategoryId == 2).Select(y => y.ProductId).Distinct().ToList();
            var phukien = db.Accessories.Where(y => ListPK.Contains(y.Id)).ToList();
            var Accessories = new List<Accessories>();
            foreach (var accessory in phukien)
            {
                var lk = new Accessories();
                lk.Id = accessory.Id;
                lk.Image = accessory.Image;
                lk.Keyword = accessory.KeyWord;
                lk.Manufacture = accessory.Manufacture;
                lk.Name = accessory.Name;
                lk.Price = accessory.Price;
                lk.CategoryId = accessory.CategoryId;
                lk.Description1 = accessory.Description1;
                lk.Description2 = accessory.Description2;
                lk.Description3 = accessory.Description3;
                lk.Description4 = accessory.Description4;
                lk.Description5 = accessory.Description5;
                lk.Description6 = accessory.Description6;
                lk.Description7 = accessory.Description7;
                lk.Quantity = accessory.Quantity;
                if (Session["UserId"] != null)
                {
                    var idUser = Convert.ToInt32(Session["UserId"].ToString());
                    if (accessory.FavoriteProducts != null && accessory.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1 && x.CategoryId == 2).Count() >= 1)
                    {
                        lk.isYT = true;
                    }
                    else
                    {
                        lk.isYT = false;
                    }
                }
                else if (Session["UserId"] == null)
                {
                    lk.isYT = false;
                }
                Accessories.Add(lk);
            }
            //Lấy Bộ nhớ trong từ những sản phẩm giống nhau
            var viewModel = new ProductsViewModel();
            viewModel.Product = productViewMosels;
            viewModel.Accessories = Accessories;
            return View("DaXem",viewModel);
        }

        public ActionResult LayDanhSachSanPhamYeuThich()
        {
            var idnd = Convert.ToInt32(Session["UserId"].ToString());
            var db = new Model1();
            var ListDT = db.FavoriteProducts.Where(x => x.CustomerId == idnd && x.Status == 1 && x.CategoryId == 1).Select(y => y.ProductId).ToList();
            var products = db.Products.Where(y => ListDT.Contains(y.Id)).ToList();
            // Map to view model
            var productViewMosels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var sp = new ProductViewModel();
                sp.Id = product.Id;
                sp.Name = product.Name;
                sp.FrontCamera = product.FrontCamera;
                sp.RearCamera = product.RearCamera;
                sp.Ram = product.Ram;
                sp.CPU = product.CPU;
                sp.InternalMemory = product.InternalMemory;
                sp.Quantity = product.Quantity;
                sp.Manufacturer = product.Manufacturer.Name;
                sp.Sim = product.Sim;
                sp.Battery = product.Battery;
                sp.OperatingSystem = product.OperatingSystem;
                sp.DateSubmitted = product.DateSubmitted;
                sp.CategoryId = product.CategoryId;
                sp.Guarantee = product.Guarantee;
                sp.Image1 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image1;
                sp.Image2 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image2;
                sp.Image3 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image3;
                sp.Image4 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image4;
                sp.Image5 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id).Image5;
                sp.NumberOfView = product.NumberOfView;
                if (product.PromotionId != null && product.Promotion.FromDay < DateTime.Now && DateTime.Now < product.Promotion.ToDay)
                {
                    sp.FromDay = product.Promotion.FromDay;
                    sp.ToDay = product.Promotion.ToDay;
                    sp.IsKM = true;
                    sp.Ratio = product.Promotion.Ratio;
                    sp.Content = product.Promotion.Content;
                    sp.Price = product.Price;
                    sp.PriceKM = product.Price - Convert.ToDecimal(Convert.ToDecimal(product.Promotion.Ratio) / 100) * product.Price;
                }
                else
                {
                    sp.Price = product.Price;
                }
                if (product.GiftId != null)
                {
                    sp.InfoGift = product.Gift.Content;
                    sp.isGift = true;
                }
                else
                {
                    sp.isGift = false;
                }
                if (Session["UserId"] != null)
                {
                    var idUser = Convert.ToInt32(Session["UserId"]);
                    if (product.FavoriteProducts != null && product.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1 && x.CategoryId == 1).Count() >= 1)
                    {
                        sp.Favorive = true;
                    }
                    else
                    {
                        sp.Favorive = false;
                    }
                }
                else if (Session["UserId"] == null)
                {
                    sp.Favorive = false;
                }
                productViewMosels.Add(sp);
            }
            //get Accessories
            var ListPK = db.FavoriteProducts.Where(x => x.CustomerId == idnd && x.Status == 1 && x.CategoryId == 2).Select(y => y.AccessoriesId).ToList();
            var phukien = db.Accessories.Where(y => ListPK.Contains(y.Id)).ToList();
            var Accessories = new List<Accessories>();
            foreach (var accessory in phukien)
            {
                var lk = new Accessories();
                lk.Id = accessory.Id;
                lk.Image = accessory.Image;
                lk.Keyword = accessory.KeyWord;
                lk.Manufacture = accessory.Manufacture;
                lk.Name = accessory.Name;
                lk.Price = accessory.Price;
                lk.CategoryId = accessory.CategoryId;
                lk.Description1 = accessory.Description1;
                lk.Description2 = accessory.Description2;
                lk.Description3 = accessory.Description3;
                lk.Description4 = accessory.Description4;
                lk.Description5 = accessory.Description5;
                lk.Description6 = accessory.Description6;
                lk.Description7 = accessory.Description7;
                lk.Quantity = accessory.Quantity;
                if (Session["UserId"] != null)
                {
                    var idUser = Convert.ToInt32(Session["UserId"].ToString());
                    if (accessory.FavoriteProducts != null && accessory.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1 && x.CategoryId == 2).Count() >= 1)
                    {
                        lk.isYT = true;
                    }
                    else
                    {
                        lk.isYT = false;
                    }
                }
                else if (Session["UserId"] == null)
                {
                    lk.isYT = false;
                }
                Accessories.Add(lk);
            }
            //Lấy Bộ nhớ trong từ những sản phẩm giống nhau
            var viewModel = new ProductsViewModel();
            viewModel.Product = productViewMosels;
            viewModel.Accessories = Accessories;
            return View("DaXem", viewModel);
        }
    }
}