
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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new Model1();
            var Model = new List<ProductViewModel>();
            var products = db.Products.ToList();
            foreach (var product in products)
            {
                var sp = new ProductViewModel();
                sp.Id = product.Id;
                sp.Name = product.Name;
                sp.CPU = product.CPU;
                sp.Quantity = product.Quantity;
                sp.Guarantee = product.Guarantee;
                sp.InternalMemory = product.InternalMemory;
                sp.Image1 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image1;
                if (product.PromotionId != null && product.Promotion.FromDay < DateTime.Now && DateTime.Now < product.Promotion.ToDay)
                {
                    sp.TenKM = $"Giảm {product.Promotion.Ratio} % nhân dịp {product.Promotion.Content.ToString()} từ ngày {product.Promotion.FromDay} đến ngày {product.Promotion.ToDay}";
                }
                else
                {
                    sp.TenKM = "";
                }
                Model.Add(sp);
            }
                return View("HienThiSanPham",Model);
        }

        public ActionResult HienThiPhuKien()
        {
            var db = new Model1();
            var dataAccessories = db.Accessories.ToList();
            var Accessories = new List<Accessories>();
            foreach (var accessory in dataAccessories)
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
            return View("LinhKien", Accessories);

        }

        public ActionResult HienThiThemPhuKien()
        {
            var db = new Model1();
            var data = db.CategoryAccessories.Select(x => new CategoryAccessoriesViewModel { id = x.Id, Name = x.Name }).ToList();
            return View("ThemLinhKien",data);
        }

        public ActionResult CodeThemLinhKien(Accessories accessories)
        {
            var db = new Model1();
            var linhKien = new CodeFirst1.Database.Accessory();
            linhKien.Name = accessories.Name;
            linhKien.Price = accessories.Price;
            linhKien.KeyWord = accessories.Keyword;
            linhKien.Manufacture = accessories.Manufacture;
            linhKien.Quantity = accessories.Quantity;
            linhKien.Description1 = accessories.Description1;
            linhKien.Description2 = accessories.Description2;
            linhKien.Description3 = accessories.Description3;
            linhKien.Description4 = accessories.Description4;
            linhKien.Description5 = accessories.Description5;
            linhKien.Description6 = accessories.Description6;
            linhKien.CategoryId = 2;
            linhKien.IdCategoryAccessories = accessories.IdCategoryAccessories;
            string image1 = Path.GetFileName(accessories.file.FileName);
            string _path1 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image1);
            accessories.file.SaveAs(_path1);
            linhKien.Image = image1;
            db.Accessories.Add(linhKien);
            db.SaveChanges();
            return RedirectToAction("HienThiPhuKien", "User");
        }

        public ActionResult Order()
        {
            return View("Order");
        }

        public ActionResult OrderView(int id)
        {
            var db = new Model1();
            var Model = new List<OrderModel>();
            var order = db.Orders.Where(x=>x.Status == id).ToList();
            foreach (var item in order)
            {
                var OrderModel = new OrderModel();
                OrderModel.Id = item.Id;
                OrderModel.Name = item.Customer.Name;
                OrderModel.NgayDat = item.OrderDate;
                OrderModel.TongTien = item.Total;
                Model.Add(OrderModel);
            }
            return PartialView("_DonHang", Model);
        }

        public ActionResult OrderDetails(int id)
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
            var soDonHang = db.Orders.Where(x=>x.CustomerId == Order.CustomerId).Count();
            OrderModel.SoDonHang = soDonHang;
            Model.OrderInOrderDetail = OrderModel;
            var chitietsphoadon = db.OrderDetails.Where(x => x.OrderId == id).OrderBy(y=>y.CategoryId).ToList();
            foreach (var item in chitietsphoadon)
            {
               var OrderDetail = new OrderDetails();
               OrderDetail.OrderId = item.OrderId;
               OrderDetail.ProductId = item.ProductId;
               OrderDetail.Quantity = item.Quantity;
               OrderDetail.UnitPrice = item.UnitPrice;
               OrderDetail.CategoryId = item.CategoryId;
               OrderDetail.Ram = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Ram : ""; 
               OrderDetail.CPU = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).CPU : ""; 
               OrderDetail.InternalMemory = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).InternalMemory : "";
               OrderDetail.Battery = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Battery : "";
               OrderDetail.Mota1 = item.CategoryId == 2 ? db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Description1 : "";
               OrderDetail.Mota2 = item.CategoryId == 2 ? db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Description2 : "";
               OrderDetail.Mota3 = item.CategoryId == 2 ? db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Description3 : "";
               OrderDetail.Mota4 = item.CategoryId == 2 ? db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Description4 : "";
               OrderDetail.Status = db.Orders.FirstOrDefault(x => x.Id == id).Status;
               OrderDetail.image = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Product_Image.FirstOrDefault(y => y.IdProducts == item.ProductId).Image1 : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Image;
               OrderDetail.Name = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Name : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Name;
               OrderDetail.SoLuongKho = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Quantity : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Quantity;
               Model.OrderDetails.Add(OrderDetail);
            }
            return View("OrderDetails",Model);
        }

        public ActionResult Edit_email(string email, int id)
        {
            var db = new Model1();
            var Email = db.Orders.FirstOrDefault(x => x.Id == id);
            Email.Email = email.ToString();
            db.SaveChanges();
            return Json("ThanhCong");
        }

        public ActionResult Edit_DiaChi(string Phone, string DiaChi, string ThanhPho, int id)
        {
            var db = new Model1();
            var DChi = db.Orders.FirstOrDefault(x => x.Id == id);
            DChi.Phone = Phone.ToString();
            DChi.City = ThanhPho.ToString();
            DChi.Address = DiaChi.ToString();
            db.SaveChanges();
            return Json("ThanhCong");
        }

        public ActionResult CapNhatSoLuongSanPhamChiTietHoaDon(int idhd, int idsp, int sl , int idCategory)
        {
            var db = new Model1();
            var HoaDon = db.Orders.FirstOrDefault(x => x.Id == idhd);
            var HoaDonCungID = db.OrderDetails.Where(x => x.OrderId == idhd);
            if(idCategory == 1)
            {
                var updateOrderDetals = db.OrderDetails.FirstOrDefault(x => x.OrderId == idhd && x.ProductId == idsp && x.CategoryId == 1);
                var SanPham = db.Products.FirstOrDefault(x => x.Id == idsp);
                //cập nhật lại số lượng trong kho trước khi thay đổi số lượng trong chi tiết sản phẩm 
                var SoLuong = SanPham.Quantity;
                SanPham.Quantity = SoLuong + updateOrderDetals.Quantity;
                db.SaveChanges();
                //cập nhật lại số lượng trong chi tiết đơn hàng
                updateOrderDetals.Quantity = sl;
                db.SaveChanges();
                // cập nhật tổng tiền trong hóa đơn
                HoaDon.ProvisionalAmount = Convert.ToDecimal(HoaDonCungID.Sum(x => x.Quantity * x.UnitPrice));
                // tính giá trị điểm sử dụng
                HoaDon.Total = HoaDon.ProvisionalAmount - Convert.ToDecimal( ( (HoaDon.PointsUse / 500)* 100000));
                db.SaveChanges();
                // cập nhật số lượng sai khi thay đổi 
                SanPham.Quantity = SanPham.Quantity - sl;
               
                //
                db.SaveChanges();
                // Lấy các chi tiết cần để đưa qua js 
                var SoLuongDatHang = sl;
                var TongGiaMoiSanPham = String.Format("{0:0,0}", (Decimal.Round((Convert.ToDecimal(updateOrderDetals.Quantity) * Convert.ToDecimal(updateOrderDetals.UnitPrice)), 0)));
                var TongGiaTriDonHang = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.Total), 0)));
                var TamTinh = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.ProvisionalAmount), 0)));
                var TenSP = SanPham.Name;
                var IDSP = SanPham.Id;
                var CategoryId = idCategory;
                var data = new { SoLuongDatHang, TongGiaMoiSanPham, TongGiaTriDonHang, TenSP, IDSP ,TamTinh, CategoryId};
                return Json(data);
            }
            else
            {
                var updateOrderDetals = db.OrderDetails.FirstOrDefault(x => x.OrderId == idhd && x.ProductId == idsp && x.CategoryId == 2);
                var SanPham = db.Accessories.FirstOrDefault(x => x.Id == idsp);
                //cập nhật lại số lượng trong kho trước khi thay đổi số lượng trong chi tiết sản phẩm 
                var SoLuong = SanPham.Quantity;
                SanPham.Quantity = Convert.ToInt32(SoLuong + updateOrderDetals.Quantity);
                db.SaveChanges();
                //cập nhật lại số lượng trong chi tiết đơn hàng
                updateOrderDetals.Quantity = sl;
                db.SaveChanges();
                // cập nhật tổng tiền trong hóa đơn
                HoaDon.ProvisionalAmount = Convert.ToDecimal(HoaDonCungID.Sum(x => x.Quantity * x.UnitPrice));
                HoaDon.Total = HoaDon.ProvisionalAmount - Convert.ToDecimal(((HoaDon.PointsUse / 500) * 100000));
                db.SaveChanges();
                // cập nhật số lượng sai khi thay đổi 
                SanPham.Quantity = SanPham.Quantity - sl;
                db.SaveChanges();
                // Lấy các chi tiết cần để đưa qua js 
                var SoLuongDatHang = sl;
                var SoLuongConLai = SanPham.Quantity;
                var TongGiaMoiSanPham = String.Format("{0:0,0}", (Decimal.Round((Convert.ToDecimal(updateOrderDetals.Quantity) * Convert.ToDecimal(updateOrderDetals.UnitPrice)), 0)));
                var TongGiaTriDonHang = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.Total), 0)));
                var TamTinh = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.ProvisionalAmount), 0)));
                var TenSP = SanPham.Name;
                var IDSP = SanPham.Id;
                var CategoryId = idCategory;
                var data = new { SoLuongDatHang, SoLuongConLai, TongGiaMoiSanPham, TongGiaTriDonHang, TenSP,TamTinh ,IDSP , CategoryId };
                return Json(data);
            }
         
        }

        public ActionResult XoaSanPhamTrongChiTietHoaDon(int idhd, int idsp , int IdCategory)
        {
            var db = new Model1();
            var HoaDon = db.Orders.FirstOrDefault(x => x.Id == idhd);
            var HoaDonCungID = db.OrderDetails.Where(x => x.OrderId == idhd);
            if(IdCategory == 1)
            {
                var Chitiethoadoncanxoa = db.OrderDetails.FirstOrDefault(x => x.OrderId == idhd && x.ProductId == idsp && x.CategoryId == IdCategory);
                var SanPham = db.Products.FirstOrDefault(x => x.Id == idsp);
                //cập nhật số lượng trước khi xóa
                var getsl = Chitiethoadoncanxoa.Quantity;
                SanPham.Quantity = SanPham.Quantity + getsl;
                db.SaveChanges();
                //xóa 
                db.OrderDetails.Remove(Chitiethoadoncanxoa);
                db.SaveChanges();
                //cập nhật lại tổng tiền hóa đơn
                HoaDon.ProvisionalAmount = Convert.ToDecimal(HoaDonCungID.Sum(x => x.Quantity * x.UnitPrice));
                HoaDon.Total = HoaDon.ProvisionalAmount - Convert.ToDecimal(((HoaDon.PointsUse / 500) * 100000));
                db.SaveChanges();
                //Lấy thông tin chuyển qua JS
                var TamTinh = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.ProvisionalAmount), 0)));
                var TongTien = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.Total), 0)));
                var IDSanPham = SanPham.Id;
                var TenSanPham = SanPham.Name;
                var idCategorysp = IdCategory;
                var data = new { TongTien, IDSanPham, TenSanPham , idCategorysp , TamTinh };
                return Json(data);
            }
            else
            {
                var Chitiethoadoncanxoa = db.OrderDetails.FirstOrDefault(x => x.OrderId == idhd && x.ProductId == idsp && x.CategoryId == IdCategory);
                var SanPham = db.Accessories.FirstOrDefault(x => x.Id == idsp);
                //cập nhật số lượng trước khi xóa
                var getsl = Chitiethoadoncanxoa.Quantity;
                SanPham.Quantity = Convert.ToInt32(SanPham.Quantity + getsl);
                db.SaveChanges();
                //xóa 
                db.OrderDetails.Remove(Chitiethoadoncanxoa);
                db.SaveChanges();
                //cập nhật lại tổng tiền hóa đơn
                HoaDon.ProvisionalAmount =Convert.ToDecimal(HoaDonCungID.Sum(x => x.Quantity * x.UnitPrice));
                HoaDon.Total = HoaDon.ProvisionalAmount - Convert.ToDecimal(((HoaDon.PointsUse / 500) * 100000));
                db.SaveChanges();

                //Lấy thông tin chuyển qua JS
                var TamTinh = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.ProvisionalAmount), 0)));
                var TongTien = String.Format("{0:0,0}", (Decimal.Round(Convert.ToDecimal(HoaDon.Total), 0)));
                var IDSanPham = SanPham.Id;
                var TenSanPham = SanPham.Name;
                var idCategorysp = IdCategory;
                var data = new { TongTien, IDSanPham, TenSanPham, idCategorysp, TamTinh };
                return Json(data);
            }
           
        }

        public ActionResult XuLyDonHang(int id)
        {
            var db = new Model1();
            var LayDonHang = db.Orders.FirstOrDefault(x => x.Id == id);
            LayDonHang.Status = 1;
            db.SaveChanges();
            return Json("Xong");
        }

        public ActionResult DongYThanhToan(int id)
        {
            var db = new Model1();
            var LayDonHang = db.Orders.FirstOrDefault(x => x.Id == id);
            var User = db.Customers.FirstOrDefault(x => x.Id == LayDonHang.CustomerId);
            User.Points = Convert.ToInt32(User.Points + (LayDonHang.ProvisionalAmount / 10000));
            LayDonHang.Status = 2;
            LayDonHang.DateProcessing = DateTime.Now;
            Session["ADminId"] = 1;
            LayDonHang.AdminId = Convert.ToInt32(Session["ADminId"]);

            db.SaveChanges();
            return Json("Xong");
        }

        public ActionResult HuyDatHang(int id, string LyDo)
        {
            var db = new Model1();
            var LayDonHang = db.Orders.FirstOrDefault(x => x.Id == id);
            var LayChiTiet = db.OrderDetails.Where(x => x.OrderId == id).ToList();
            var User = db.Customers.FirstOrDefault(x => x.Id == LayDonHang.CustomerId);
            foreach (var item in LayChiTiet)
            {
                var IDSPinChiTiet = item.ProductId;
                if(item.CategoryId == 1)
                {
                    var SanPham = db.Products.FirstOrDefault(x => x.Id == IDSPinChiTiet);
                    SanPham.Quantity = SanPham.Quantity + item.Quantity;
                }
                else
                {
                    var SanPham = db.Accessories.FirstOrDefault(x => x.Id == IDSPinChiTiet);
                    SanPham.Quantity =Convert.ToInt32(SanPham.Quantity + item.Quantity);
                }
                db.SaveChanges();
            }
            LayDonHang.Status = 3;
            LayDonHang.DateProcessing = DateTime.Now;
            Session["ADminId"] = 1;
            LayDonHang.AdminId = Convert.ToInt32(Session["ADminId"]);
            User.Points = Convert.ToInt32(User.Points + LayDonHang.PointsUse);
            LayDonHang.ReasonCancel = LyDo.ToString();
            db.SaveChanges();
            return Json("Xong");
        }

        public ActionResult XuatPhieuGiaoHang(int id)
        {
            //Lấy năm hiện tại
            string thoigian = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(thoigian.ToString()));
            ViewBag.Nam = datevalue.Year.ToString();

            var db = new Model1();
            var ListModel = new XuatPhieuViewModel();
            var Order = db.Orders.FirstOrDefault(x => x.Id == id);
            var ThongTinChungDonHang = new OrderInOrderDetail();
            ThongTinChungDonHang.Id = Order.Id;
            ThongTinChungDonHang.Address = Order.Address;
            ThongTinChungDonHang.Phone = Order.Phone;
            ThongTinChungDonHang.City = Order.City;
            ThongTinChungDonHang.Email = Order.Email;
            ThongTinChungDonHang.OrderDate = Order.OrderDate;
            ThongTinChungDonHang.Total = Order.Total;
            ThongTinChungDonHang.status = Order.Status;
            ThongTinChungDonHang.ReasonCancel = Order.ReasonCancel;
            ThongTinChungDonHang.CustomerId = Order.CustomerId;
            ThongTinChungDonHang.ProvisionalAmount = Order.ProvisionalAmount;
            ThongTinChungDonHang.DateProcessing = Order.DateProcessing;
            ThongTinChungDonHang.AdminId = Order.AdminId;
            ThongTinChungDonHang.Name = db.Customers.FirstOrDefault(x => x.Id == Order.CustomerId).Name;
            ThongTinChungDonHang.PointsUse = Order.PointsUse;
            var soDonHang = db.Orders.Where(x => x.CustomerId == Order.CustomerId).Count();
            ListModel.orderInOrderDetail = ThongTinChungDonHang;
            var chitietsphoadon = db.OrderDetails.Where(x => x.OrderId == id).OrderBy(y => y.CategoryId).ToList();
            ThongTinChungDonHang.tongSL = chitietsphoadon.Sum(x => x.Quantity);
            foreach (var item in chitietsphoadon)
            {
                var ct = new SanPhamXuatPhieu();
                ct.Anh = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Product_Image.FirstOrDefault(y => y.IdProducts == item.ProductId).Image1 : db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Image;
                ct.Ten = item.CategoryId == 1 ? db.Products.FirstOrDefault(x => x.Id == item.ProductId).Name: db.Accessories.FirstOrDefault(x => x.Id == item.ProductId).Name;
                ct.Price = item.UnitPrice;
                ct.Quantity =Convert.ToInt32(item.Quantity);
                ListModel.sanPhamXuatPhieus.Add(ct);
            }
            return View("XuatPhieu", ListModel);
        }

        public ActionResult Print(int id)
        {
            return new ActionAsPdf("XuatPhieuGiaoHang", new { id = id }) { FileName = String.Format("Phiếu_{0}.pdf", id) };
        }

        public ActionResult ThongKeSanPhamBanDuoc()
        {

            var db = new Model1();
            var query = db.OrderDetails
            .Where(p => p.Order.Status == 2 && p.CategoryId == 1)
             .GroupBy(m=>m.ProductId)
            .Select(g => new ThongKe()
            {
                tensp = db.Products.FirstOrDefault(u => u.Id == g.FirstOrDefault().ProductId).Name,
                slb = g.Sum(w => w.Quantity),
                tongtien = g.Sum(w => w.Quantity * w.UnitPrice)
            })
            .ToList();
            return View("ThongKeSanPhamBanDuoc", query);
        }
        
        public ActionResult TongLinhKienBanDuoc()
        {
            var db = new Model1();
            var query = db.OrderDetails
            .Where(p => p.Order.Status == 2 && p.CategoryId == 2)
             .GroupBy(m => m.ProductId)
            .Select(g => new ThongKe()
            {
                tensp = db.Accessories.FirstOrDefault(u => u.Id == g.FirstOrDefault().ProductId).Name,
                slb = g.Sum(w => w.Quantity),
                tongtien = g.Sum(w => w.Quantity * w.UnitPrice)
            })
            .ToList();
            return View("ThongKeLinhKienBanDuoc", query);
        }

        public ActionResult GetData()
        {
            var db = new Model1();
            var query = db.OrderDetails.Include("Products")
                .Where(x => x.Order.Status == 2 && x.CategoryId == 1)
                .GroupBy(k=>  db.Products.FirstOrDefault(u => u.Id == k.ProductId).Id)
                .Select(g => new { name = db.Products.FirstOrDefault(i=>i.Id == g.FirstOrDefault().ProductId).Name, count = g.Sum(w => w.Quantity) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataLinhKien()
        {
            var db = new Model1();
            var query = db.OrderDetails.Include("Accessories")
                .Where(x => x.Order.Status == 2 && x.CategoryId == 2)
                .GroupBy(k => db.Accessories.FirstOrDefault(u => u.Id == k.ProductId).Id)
                .Select(g => new { name = db.Products.FirstOrDefault(i => i.Id == g.FirstOrDefault().ProductId).Name, count = g.Sum(w => w.Quantity) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTKLinhKien()
        {
            var db = new Model1();
            var query = db.OrderDetails
                          .Where(x => x.Order.Status == 2 && x.CategoryId == 2)
                          .GroupBy(p => db.Accessories.FirstOrDefault(x => x.Id == p.ProductId).Id)
                          .Select(g => new
                          {
                              name = db.Accessories.FirstOrDefault(i => i.Id == g.FirstOrDefault().ProductId).Name,
                              count = g.Sum(w => w.Quantity)
                          }).ToList();
            var nameList = query.Select(x => x.name).ToList();
            var soluong = query.Select(x => x.count).ToList();
            double tongSL = Convert.ToDouble(query.Sum(x => x.count));

            var listSo = new List<Double?>();
            foreach (var item in soluong)
            {
                var d = Convert.ToDouble(item);
                var c = (item / tongSL) * 100;
                var e = Math.Round(Convert.ToDouble(c), 2);
                listSo.Add(c);
            }
            var listData = new { nameList, listSo };
            return Json(listData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTK()
        {
            var db = new Model1();
            var query = db.OrderDetails
                          .Where(x => x.Order.Status == 2 &&x.CategoryId == 1)
                          .GroupBy(p =>db.Products.FirstOrDefault(x=>x.Id == p.ProductId).Id)
                          .Select(g => new
                          {
                              name = db.Products.FirstOrDefault(i=>i.Id == g.FirstOrDefault().ProductId).Name,
                              count = g.Sum(w => w.Quantity)
                          }).ToList();
            var nameList = query.Select(x => x.name).ToList();
            var soluong = query.Select(x => x.count).ToList();
            double tongSL = Convert.ToDouble(query.Sum(x => x.count));

            var listSo = new List<Double?>();
            foreach (var item in soluong)
            {
                var d = Convert.ToDouble(item);
                var c = (item / tongSL) * 100;
                var e = Math.Round(Convert.ToDouble(c), 2);
                listSo.Add(c);
            }
            var listData = new { nameList, listSo };
            return Json(listData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThongKeDoanhThuChay()
        {
            var db = new Model1();
            var dt = db.Orders.Where(p => p.OrderDate.Value.Year == DateTime.Now.Year && p.Status == 2 )
                .GroupBy(p => p.OrderDate.Value.Month)
                .Select(g => new doanhthuthang()
                {
                    thang = g.Key,
                    tongtien = g.Sum(w => w.Total),
                    sldh = g.Count()
                })
                .ToList();
            return View("DoanhThuThang", dt);
        }

        public ActionResult TKDoanhThuThang()
        {
            var db = new Model1();
            var query = db.Orders
                          .Where(x => x.Status == 2 && x.OrderDate.Value.Year == DateTime.Now.Year )
                          .GroupBy(p => p.OrderDate.Value.Month)
                          .Select(g => new
                          {
                              thang = g.Key,
                              tien = g.Sum(x => x.Total)
                          }).ToList();
            var thang = query.Select(x => x.thang).ToList();
            var tien = query.Select(x => x.tien).ToList();
            var Data = new { thang, tien };
            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InDoanhThu()
        {
            return new ActionAsPdf("PhieuThongKeDoanhThu") { FileName = String.Format("doanhthu.pdf") };
        }

        public ActionResult PhieuThongKeDoanhThu()
        {
            var db = new Model1();
            var nam = DateTime.Now.Year;
            ViewBag.nam = nam;
            var dt = db.Orders.Where(p => p.OrderDate.Value.Year == DateTime.Now.Year && p.Status == 2)
            .GroupBy(p => p.OrderDate.Value.Month)
            .Select(g => new doanhthuthang()
            {
                thang = g.Key,
                tongtien = g.Sum(w => w.Total),
                sldh = g.Count()
            })
            .ToList();
            return View("PhieuThongKeDoanhThu", dt);
        }

        public ActionResult In(int? id)
        {
            return new ActionAsPdf("indonhangtungthang", new { id = id }) { FileName = String.Format("Thang_{0}.pdf", id) };
        }

        public ActionResult indonhangtungthang(int? id)
        {
            var db = new Model1();
            ViewBag.thang = id;
            var query = (from a in db.Orders
                         join b in db.Customers on a.CustomerId equals b.Id
                         where a.OrderDate.Value.Month == id && a.Status == 2 && a.OrderDate.Value.Year == DateTime.Now.Year
                         select new
                         {
                             IDKH = a.Id,
                             ID = a.Id,
                             Ten = b.Name,
                             Ngay = a.OrderDate,
                             TongTien = a.Total
                         }).ToList();
            var ip = new List<InPhieuDonHangTungThang>();
            foreach (var item in query)
            {
                var dh = new InPhieuDonHangTungThang();
                dh.idkh = item.IDKH;
                dh.madonhang = item.ID;
                dh.ngaylap = item.Ngay;
                dh.tongtien = item.TongTien;
                dh.tenkh = item.Ten;
                ip.Add(dh);
            }
            return View("inphieutheothang", ip);
        }

        public ActionResult ThongKeSoLuongTon()
        {
            var db = new Model1();
            var query = db.Products
           .GroupBy(p => p.Name)
           .Select(g => new ThongKe()
           {
               tensp = g.FirstOrDefault().Name,
               slb = g.Sum(w => w.Quantity),
               tongtien = g.Sum(w => w.Quantity * w.Price)
           })
           .ToList();
            return View("ThongKeSoLuongTon", query);
        }

        public ActionResult laysoluongton()
        {
            var db = new Model1();
            var slt = from p in db.Products.GroupBy(i=>i.Name)
                      select new
                      {
                          tensp = p.FirstOrDefault().Name,
                          soluong = p.Sum(w => w.Quantity)
                      };
            return Json(slt, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Inbaobaosanphamtonkho()
        {
            return new ActionAsPdf("Phieuthongkesoluongton") { FileName = String.Format("Baocaosanphamtonkho.pdf") };
        }

        public ActionResult Phieuthongkesoluongton()
        {
            var db = new Model1();
            var query = db.Products
           .GroupBy(p => p.Name)
           .Select(g => new ThongKe()
           {
               tensp = g.FirstOrDefault().Name,
               slb = g.Sum(w => w.Quantity),
               tongtien = g.Sum(w => w.Quantity * w.Price)
           })
           .ToList();
            return View("PhieuTKSoLuongTon", query);
        }

        public ActionResult Comment ()
        {
            var db = new Model1();
            var Comment = db.Comments.ToList();
            var Model = new List<commentModel>();
            foreach (var item in Comment)
            {
                var comment = new commentModel();
                 comment.Id = item.Id ;
                comment.Name = item.Name  ;
                comment.Phone= item.Phone ;
                comment.Time  =item.Time  ;
                comment.NameProducts = db.Products.FirstOrDefault(a => a.Id == item.ProductId)?.Name;
                comment.Contains = item.Contains  ;
                Model.Add(comment);
            }
            return View("Comment",Model);
        }

        public ActionResult DeleteComment(int id)
        {
            var db = new Model1();
            var comment = db.Comments.FirstOrDefault(x => x.Id == id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Comment","User");
        }

        [HttpPost]
        public ActionResult AddProduct(CreateProductViewModel md)
        {
            var db = new Model1();
            //Thêm vào bảng Products
            var products = new Product();
            products.Name = md.Name;
            products.CategoryId = 1;
            products.FrontCamera = md.FrontCamera;
            products.RearCamera = md.RearCamera;
            products.Ram = md.Ram;
            products.CPU = md.CPU;
            products.InternalMemory = md.InternalMemory;
            products.Quantity = md.Quantity;
            products.Sim = md.Sim;
            products.Battery = md.Battery;
            products.OperatingSystem = md.OperatingSystem;
            products.PromotionId = md.PromotionId == "NULL" ? default(int?) : Convert.ToInt32(md.PromotionId) ;
            products.Price = md.Price;
            products.DateSubmitted = DateTime.Now;
            products.GiftId  = md.GiftId == "NULL"? default(int?) :Convert.ToInt32(md.GiftId);
            products.Guarantee = md.Guarantee;
            products.ManufacturerId = md.ManufacturerId;
            products.NumberOfView = 0;
            db.Products.Add(products);
            db.SaveChanges();

            //Thêm vào bảng Product_Image
            var primage = new Product_Image();
            string image1 = Path.GetFileName(md.file1.FileName);
            string _path1 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image1);
            md.file1.SaveAs(_path1);
            primage.Image1 = image1;
            string image2 = Path.GetFileName(md.file2.FileName);
            string _path2 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image2);
            md.file2.SaveAs(_path2);
            primage.Image2 = image2;
            string image3 = Path.GetFileName(md.file3.FileName);
            string _path3 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image3);
            md.file3.SaveAs(_path3);
            primage.Image3 = image3;
            string image4= Path.GetFileName(md.file4.FileName);
            string _path4 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image4);
            md.file4.SaveAs(_path4);
            primage.Image4 = image4;
            string image5 = Path.GetFileName(md.file5.FileName);
            string _path5= Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image5);
            md.file5.SaveAs(_path5);
            primage.Image5 = image5;
            primage.IdProducts = db.Products.OrderByDescending(x => x.DateSubmitted).Take(1).FirstOrDefault().Id;
            db.Product_Image.Add(primage);
            db.SaveChanges();

            //Thêm vào bảng DetailsProducts
            var detailProducts = new CodeFirst1.Database.DetailsProduct();
            detailProducts.Id = db.Products.OrderByDescending(x => x.DateSubmitted).Take(1).FirstOrDefault().Id;
            detailProducts.TouchGlass = md.TouchGlass;
            detailProducts.ScreenTechnology = md.ScreenTechnology;
            detailProducts.TheResolution = md.TheResolution;
            detailProducts.CameraFeature = md.CameraFeature;
            detailProducts.FlashLight = md.FlashLight;
            detailProducts.ScreenSize = md.ScreenSize;
            detailProducts.VideoCall = md.VideoCall;
            detailProducts.Film = md.Film;
            detailProducts.ExternalMemoryCardSupport = md.ExternalMemoryCardSupport;
            detailProducts.MaximumCardSupport = md.MaximumCardSupport;
            detailProducts.Weight = md.Weight;
            detailProducts.BatteryType = md.BatteryType;
            detailProducts.FMRadio = md.FMRadio;
            string image6 = Path.GetFileName(md.file6.FileName);
            string _path6 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image6);
            md.file6.SaveAs(_path6);
            detailProducts.ImageDetial = image6;
            db.DetailsProducts.Add(detailProducts);
            db.SaveChanges();
            return Redirect("Index"); 
        }

        public ActionResult HienThiThemSanPham()
        {
            var db = new Model1();
            //lấy Hãng sản xuất
            var Models = new ThongTins();
            var datahsx = db.Manufacturers.Select(x => new HangSanXuat { Id = x.Id, Name = x.Name }).ToList();
            var datakm = db.Promotions.Select(x => new KhuyenMais { Id = x.Id }).ToList();
            var dataquatang = db.Gifts.Select(x => new QuaTang { Id = x.Id }).ToList();
            Models.HangSanXuats = datahsx;
            Models.KhuyenMais = datakm;
            Models.quaTangs = dataquatang;
            return View("Products", Models);
        }

        public ActionResult Delete (int id)
        {
            var db = new Model1();
            CodeFirst1.Database.Product_Image product_Image = db.Product_Image.FirstOrDefault(x=>x.IdProducts == id);
            db.Product_Image.Remove(product_Image);
            db.SaveChanges();
            CodeFirst1.Database.DetailsProduct detailsProduct = db.DetailsProducts.Find(id);
            db.DetailsProducts.Remove(detailsProduct);
            db.SaveChanges();
            Product sanPham = db.Products.Find(id);
            db.Products.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("HienThiPhuKien", "User");
        }

        public ActionResult DeleteLinhKien(int id)
        {
            var db = new Model1();
            CodeFirst1.Database.Accessory LinhKien = db.Accessories.Find(id);
            db.Accessories.Remove(LinhKien);
            db.SaveChanges();
            return RedirectToAction("HienThiPhuKien", "User");
        }

        public ActionResult HienThiPhanQuyen()
        {
            var db = new Model1();
            var admin = db.Admins.Where(x=>x.Status != 0).ToList();
            var ListModel = new List<CodeFirst1.ViewModels.Admin>();
            foreach (var item in admin)
            {
                var ad = new CodeFirst1.ViewModels.Admin();
                ad.Id = item.Id;
                ad.Name = item.Name;
                ad.Phone = item.Phone;
                ad.Email = item.Email;
                ad.Account = item.Account;
                ad.Password = item.Password;
                ad.Status = item.Status;
                ad.TenQuyen = item.Status == 1 ? "Nhân viên bán hàng":"Nhân viên giao hàng";
                ListModel.Add(ad);
            }
            return View("PhanQuyen", ListModel);
        }

        public ActionResult PhanQuyen(CodeFirst1.ViewModels.Admin admin)
        {
            var db = new Model1();
            var ad = new CodeFirst1.Database.Admin();
            ad.Name = admin.Name;
            ad.Phone = admin.Phone;
            ad.Email = admin.Email;
            ad.Account = admin.Account;
            ad.Password = admin.Password;
            ad.Status = admin.Status;
            db.Admins.Add(ad);
            db.SaveChanges();
            return RedirectToAction("HienThiPhanQuyen","User");
        }

        public ActionResult HienThiTaiKhoanNguoiDung()
        {
            var db = new Model1();
            var customers = db.Customers.ToList();
            var Model = new List<CustomerViewModel>();
            foreach (var item in customers)
            {
                var customer = new CustomerViewModel();
                customer.id = item.Id;
                customer.Name = item.Name;
                customer.Password = item.Password;
                customer.Account = item.Account;
                customer.Phone = item.Phone;
                customer.Email = item.Email;
                customer.Point = item.Points;
                Model.Add(customer);
            }
            return View("ViewTaiKhoanNguoiDung",Model);
        }

        public ActionResult Inbaobaosanphambanduoc()
        {
            return new ActionAsPdf("Phieuthongkesanphambanduoc") { FileName = String.Format("SanPhamDaBan.pdf") };
        }

        public ActionResult Phieuthongkesanphambanduoc()
        {
            var db = new Model1();
            var query = db.OrderDetails
           .Where(x => x.Order.Status == 2 && x.CategoryId == 1)
           .GroupBy(p => db.Products.FirstOrDefault(x => x.Id == p.ProductId).Id)
             .Select(g => new ThongKe()
             {
                 tensp = db.Products.FirstOrDefault(i => i.Id == g.FirstOrDefault().ProductId).Name,
                 slb = g.Sum(w => w.Quantity),
                 tongtien = g.Sum(w => w.Quantity * w.UnitPrice)
             })
             .ToList();
            return View("PhieuThongKeSPBanDuoc", query);
        }

        public ActionResult Inbaobaolinhkienbanduoc()
        {
            return new ActionAsPdf("Phieuthongkelinhkienbanduoc") { FileName = String.Format("SanPhamDaBan.pdf") };
        }

        public ActionResult Phieuthongkelinhkienbanduoc()
        {
            var db = new Model1();
            var query = db.OrderDetails
           .Where(x => x.Order.Status == 2 && x.CategoryId == 2)
           .GroupBy(p => db.Accessories.FirstOrDefault(x => x.Id == p.ProductId).Id)
             .Select(g => new ThongKe()
             {
                 tensp = db.Accessories.FirstOrDefault(i => i.Id == g.FirstOrDefault().ProductId).Name,
                 slb = g.Sum(w => w.Quantity),
                 tongtien = g.Sum(w => w.Quantity * w.UnitPrice)
             })
             .ToList();
            return View("PhieuThongKeSPBanDuoc", query);
        }

        public ActionResult ThongKeTheoKhoangThoiGian()
        {
            var ip = new List<InPhieuDonHangTungThang>();
            return View("ThongKeTheoKhoangThoiGian",ip);
        }

        public ActionResult KQThongKeTheoKhoangThoiGian(DateTime tungay, DateTime denngay)
        {
            if(tungay < denngay)
            {
                var db = new Model1();
                ViewBag.tungay = tungay;
                ViewBag.denngay = denngay;
                var query = (from a in db.Orders
                             join b in db.Customers on a.CustomerId equals b.Id
                             where a.DateProcessing >= tungay && a.DateProcessing <= denngay && a.Status == 2
                             select new
                             {
                                 IDKH = a.Id,
                                 ID = a.Id,
                                 Ten = b.Name,
                                 Ngay = a.OrderDate,
                                 TongTien = a.Total
                             }).ToList();
                var ip = new List<InPhieuDonHangTungThang>();
                foreach (var item in query)
                {
                    var dh = new InPhieuDonHangTungThang();
                    dh.idkh = item.IDKH;
                    dh.madonhang = item.ID;
                    dh.ngaylap = item.Ngay;
                    dh.tongtien = item.TongTien;
                    dh.tenkh = item.Ten;
                    ip.Add(dh);
                }
                return View("ThongKeTheoKhoangThoiGian", ip);
            }
            else
            {
                var ip = new List<InPhieuDonHangTungThang>();
               ViewBag.Loi = "Ngày kết thúc không thể lớn hơn ngày bắt đầu , hãy chọn lại";
                return View("ThongKeTheoKhoangThoiGian", ip);
            }

        }

        public ActionResult ThemHSX()
        {
            var db = new Model1();
            var data = db.Manufacturers.Select(x => new ManufactureModel { Id = x.Id, Name = x.Name, Image = x.image }).ToList();
            return View("ThemHSX",data);
        }

        public ActionResult CodeThemHSX(string name, HttpPostedFileBase file)
        {
            var db = new Model1();
            Manufacturer hsx = new Manufacturer();
            string image1 = Path.GetFileName(file.FileName);
            string _path1 = Path.Combine(Server.MapPath("~/image/AnhDienThoai"), image1);
            file.SaveAs(_path1);
            hsx.Name = name;
            hsx.image = image1;
            db.Manufacturers.Add(hsx);
            db.SaveChanges();
            return RedirectToAction("ThemHSX", "User");
        }

        public ActionResult HienThiKhuyenMai()
        {
            var db = new Model1();
            var data = db.Promotions.Select(x => new PromotionModel { Id = x.Id, tuNgay = x.FromDay, denNgay = x.ToDay, ratio = x.Ratio, Content = x.Content }).ToList();
            return View("KhuyenMai",data);
        }

        public ActionResult CodeThemKhuyenMai(PromotionModel promotionModel)
        {
          if(promotionModel.tuNgay < promotionModel.denNgay)
            {
                var db = new Model1();
                Promotion promotion = new Promotion();
                promotion.FromDay = promotionModel.tuNgay;
                promotion.ToDay = promotionModel.denNgay;
                promotion.Ratio = promotionModel.ratio;
                promotion.Content = promotionModel.Content;
                db.Promotions.Add(promotion);
                db.SaveChanges();
                return RedirectToAction("HienThiKhuyenMai", "User");
            }
            else
            {
                ViewBag.Loi = "Ngày bắt đầu không được nhỏ hơn ngày kết thúc ! Mời nhập lại";
                var db = new Model1();
                var data = db.Promotions.Select(x => new PromotionModel { Id = x.Id, tuNgay = x.FromDay, denNgay = x.ToDay, ratio = x.Ratio, Content = x.Content }).ToList();
                return View("KhuyenMai", data);
            }
        }
        public ActionResult Promotion(int id = 0)
        {
            var db = new Model1();
            var model = new AddPromotionViewModel();
            var data = db.Manufacturers.Select(x => new HSXViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Products = x.Products.Select(y => new ListProductPromotion { Id = y.Id, Name = y.Name }).ToList()
            }).ToList();
            var promotion = db.Promotions.Select(x => new promotio
            {
                Id = x.Id,
                Ratio = x.Ratio.ToString(),
                Content =  x.Content,
                StartDate = x.FromDay,
                EndDate = x.ToDay
            }).ToList();
            var listId = db.Products.Where(x => x.PromotionId == id).Select(y => y.Id).ToList();
            model.hSXViewModels = data;
            model.promotios = promotion;
            model.IdProduct = listId;
            ViewBag.IdPro = id;
            return View("promotion",model);
        }
      
    }
}