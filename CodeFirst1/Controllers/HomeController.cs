using CodeFirst1.Database;
using CodeFirst1.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CodeFirst1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult T()
        {
            return View("Test");
        }

        public ActionResult Index(int? page)
        {
            // Hello I am here.
            // get database
            var db = new Model1();
            var products = db.Products.ToList();
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
                sp.Image1 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image1;
                sp.Image2 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image2;
                sp.Image3 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image3;
                sp.Image4 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image4;
                sp.Image5 = product.Product_Image.FirstOrDefault(x => x.IdProducts == sp.Id)?.Image5;
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
            //get favorate
            var spcaonhathoadon = (from a in db.FavoriteProducts
                                   where a.Status == 1 && a.CategoryId == 1
                                   group a by a.ProductId into result
                                   select new
                                   {
                                       id = result.FirstOrDefault().ProductId,
                                       solanyt = result.Count(),

                                   })
                                   .OrderByDescending(x => x.solanyt)
                                   .Take(4).ToList();
            var listid = spcaonhathoadon.Select(x => x.id).ToList();
            var lkcanlay = db.Products.Where(x => listid.Contains(x.Id)).ToList();
            var modelProducts = new List<ProductViewModel>();
            foreach (var item in lkcanlay)
            {
                var spyt1 = new ProductViewModel();
                spyt1.Id = item.Id;
                spyt1.Name = item.Name;
                spyt1.Image1 = item.Product_Image.FirstOrDefault(x => x.IdProducts == item.Id).Image1;
                if (item.PromotionId != null && item.Promotion.FromDay < DateTime.Now && item.Promotion.ToDay > DateTime.Now)
                {
                    spyt1.Price = item.Price - Convert.ToDecimal(Convert.ToDecimal(item.Promotion.Ratio) / 100) * item.Price;
                }
                else
                {
                    spyt1.Price = item.Price;
                }
                modelProducts.Add(spyt1);
            }
            //get Accessories
            var dataAccessories = db.Accessories.ToList().Take(8);
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
            var pageNumber = page ?? 1;
            var onePageOfProducts = productViewMosels.ToPagedList(pageNumber, 8);
            // get manufactureProduct 
            var manufacturerProducts = db.Manufacturers.ToList().Select(x => new ManufactureProduct
            {
                Name = x.Name,
                NumberProduct = x.Products.Select(y => y.Quantity).Sum(),
                image = x.image
            }).ToList();
            //Lấy Bộ nhớ trong từ những sản phẩm giống nhau
            var viewModel = new ProductsViewModel();
            viewModel.Accessories = Accessories;
            viewModel.Products = onePageOfProducts;
            viewModel.ManufactureProducts = manufacturerProducts;
            viewModel.favorateProduct = modelProducts;
            return View(viewModel);
        }

        public ActionResult GetDataAutocomplete(string query)
        {
            var db = new Model1();
            // Dùng LINQ để search sản phẩm cần  tìm
            var dataProduct = db.Products.Where(x => x.Name.ToLower().Contains(query.ToLower())
                //|| x.CPU.Contains("abc")
                ).ToList().Select(x => new // DataAutoCompleteViewModel
                {
                    id = x.Id,
                    name = x.Name,
                    Manufacturer = x.Manufacturer.Name,
                    img = x.Product_Image.FirstOrDefault(y => y.IdProducts == x.Id).Image1,
                    status = x.PromotionId != null && x.Promotion.FromDay < DateTime.Now && DateTime.Now < x.Promotion.ToDay ? "  (Discount " + x.Promotion.Ratio + "%)" : "",
                    price = x.PromotionId != null && x.Promotion.FromDay < DateTime.Now && DateTime.Now < x.Promotion.ToDay ? (x.Price - Convert.ToDecimal(Convert.ToDecimal(x.Promotion.Ratio) / 100) * x.Price).ToString("#,###") : x.Price.ToString("#,###")
                });
            var dataAccessories = db.Accessories.Where(x => x.Name.ToLower().Contains(query.ToLower())
                                  ).ToList().Select(x => new
                                  {
                                      id = x.Id,
                                      name = x.Name,
                                      Manufacturer = x.Manufacture,
                                      img = x.Image,
                                      status = "Dành riêng cho: " + x.KeyWord,
                                      price = x.Price.ToString("#,###")
                                  });
            var data = dataProduct.Union(dataAccessories);
            return Json(data, JsonRequestBehavior.AllowGet); ;
        }

        public ActionResult SearchProduct(InputSearchViewModel inputSearchViewModel, int? page)
        {
            var db = new Model1();
            if (inputSearchViewModel.Manufacture == null)
            {
                var HSX = db.Manufacturers.Select(x => x.Name).ToList();
                inputSearchViewModel.Manufacture = HSX;
            }
            var products = db.Products.Where(x => inputSearchViewModel.Manufacture.Contains(x.Manufacturer.Name)
                                        && x.Price >= inputSearchViewModel.giaMin
                                    && x.Price <= inputSearchViewModel.giaMax).ToList();
            var productViewModel = new List<ProductViewModel>();
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
                    if (product.FavoriteProducts != null && product.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1).Count() >= 1)
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
                productViewModel.Add(sp);
            }
            var dataAccessories = db.Accessories.ToList().Take(8);
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
            var pageNumber = page ?? 1;
            var onePageOfProducts = productViewModel.ToPagedList(pageNumber, 8);
            // get manufactureProduct 
            var manufacturerProducts = db.Manufacturers.ToList().Select(x => new ManufactureProduct
            {
                Name = x.Name,
                NumberProduct = x.Products.Select(y => y.Quantity).Sum(),
                image = x.image
            }).ToList();
            //get favorate
            var spcaonhathoadon = (from a in db.FavoriteProducts
                                   where a.Status == 1 && a.CategoryId == 1
                                   group a by a.ProductId into result
                                   select new
                                   {
                                       id = result.FirstOrDefault().ProductId,
                                       solanyt = result.Count(),

                                   })
                                   .OrderByDescending(x => x.solanyt)
                                   .Take(4).ToList();
            var listid = spcaonhathoadon.Select(x => x.id).ToList();
            var lkcanlay = db.Products.Where(x => listid.Contains(x.Id)).ToList();
            var modelProducts = new List<ProductViewModel>();
            foreach (var item in lkcanlay)
            {
                var spyt1 = new ProductViewModel();
                spyt1.Id = item.Id;
                spyt1.Name = item.Name;
                spyt1.Image1 = item.Product_Image.FirstOrDefault(x => x.IdProducts == item.Id).Image1;
                if (item.PromotionId != null && item.Promotion.FromDay < DateTime.Now && item.Promotion.ToDay > DateTime.Now)
                {
                    spyt1.Price = item.Price - Convert.ToDecimal(Convert.ToDecimal(item.Promotion.Ratio) / 100) * item.Price;
                }
                else
                {
                    spyt1.Price = item.Price;
                }
                modelProducts.Add(spyt1);
            }
            var viewModel = new ProductsViewModel();
            viewModel.Accessories = Accessories;
            viewModel.favorateProduct = modelProducts;
            viewModel.Products = onePageOfProducts;
            viewModel.ManufactureProducts = manufacturerProducts;
            if (inputSearchViewModel.a == "js")
            {
                return PartialView("_Products", productViewModel);
            }
            else
            {
                return View("Index", viewModel);
            }
        }

        public ActionResult Detail(int id)
        {
            var db = new Model1();
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            //Tăng lượt xem
            product.NumberOfView += 1;
            db.SaveChanges();

            var Model = new ProductDetailViewModel();
            // Lấy thông tin 
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
            sp.CategoryId = product.CategoryId;
            sp.Battery = product.Battery;
            sp.OperatingSystem = product.OperatingSystem;
            sp.DateSubmitted = product.DateSubmitted;
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
                if (product.FavoriteProducts != null && product.FavoriteProducts.Where(x => x.CustomerId == idUser && x.Status == 1).Count() >= 1)
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
            Model.ProductDetail = sp;
            // Lấy chi tiết của sản phẩm
            var detailProduct = db.DetailsProducts.FirstOrDefault(x => x.Id == id);
            var detls = new CodeFirst1.ViewModels.DetailsProduct();
            detls.TouchGlass = detailProduct.TouchGlass;
            detls.ScreenTechnology = detailProduct.ScreenTechnology;
            detls.ScreenSize = detailProduct.ScreenSize;
            detls.TheResolution = detailProduct.TheResolution;
            detls.CameraFeature = detailProduct.CameraFeature;
            detls.FlashLight = detailProduct.FlashLight;
            detls.VideoCall = detailProduct.VideoCall;
            detls.Film = detailProduct.Film;
            detls.ExternalMemoryCardSupport = detailProduct.ExternalMemoryCardSupport;
            detls.MaximumCardSupport = detailProduct.MaximumCardSupport;
            detls.Weight = detailProduct.Weight;
            detls.BatteryType = detailProduct.BatteryType;
            detls.FMRadio = detailProduct.FMRadio;
            detls.ImageDetial = detailProduct.ImageDetial;
            Model.DetailsProduct = detls;

            //Lấy những linh kiện dành riêng cho sản phẩm
            var accessorys = new List<Accessories>();
            var dataAccessories = db.Accessories.Where(x => x.KeyWord.Contains(product.Manufacturer.Name)).ToList();
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
                accessorys.Add(lk);
            }
            Model.relatedAccessories = accessorys;
            //Lấy sản phẩm liên quan
            var priceMin = product.Price - 2000000;
            var priceMax = product.Price + 2000000;
            var relatedProducts = db.Products.Where(x => x.Id != id && x.Price > priceMin && x.Price < priceMax).ToList();
            foreach (var relatedProduct in relatedProducts)
            {
                var sp1 = new ProductViewModel();
                sp1.Id = relatedProduct.Id;
                sp1.Name = relatedProduct.Name;
                sp1.Image1 = relatedProduct.Product_Image.FirstOrDefault(x => x.IdProducts == sp1.Id).Image1;
                if (relatedProduct.PromotionId != null && relatedProduct.Promotion.FromDay < DateTime.Now && DateTime.Now < relatedProduct.Promotion.ToDay)
                {
                    sp1.IsKM = true;
                    sp1.Price = relatedProduct.Price;
                    sp.PriceKM = relatedProduct.Price - Convert.ToDecimal(Convert.ToDecimal(relatedProduct.Promotion.Ratio) / 100) * relatedProduct.Price;
                }
                else
                {
                    sp.Price = relatedProduct.Price;
                }
                Model.RelatedProducts.Add(sp);
            }

            // Lấy sản phẩm có số lượt xem cao nhất
            var topViewproducts = db.Products.OrderByDescending(x => x.NumberOfView).Take(5).ToList();
            foreach (var topViewproduct in topViewproducts)
            {
                var sp2 = new ProductViewModel();
                sp2.Name = topViewproduct.Name;
                sp2.Id = topViewproduct.Id;
                sp2.Image1 = topViewproduct.Product_Image.FirstOrDefault(x => x.IdProducts == sp2.Id).Image1;
                if (topViewproduct.PromotionId != null && topViewproduct.Promotion.FromDay < DateTime.Now && DateTime.Now < topViewproduct.Promotion.ToDay)
                {
                    sp2.Price = topViewproduct.Price - Convert.ToDecimal(Convert.ToDecimal(topViewproduct.Promotion.Ratio) / 100) * topViewproduct.Price;
                }
                else
                {
                    sp2.Price = product.Price;
                }
                Model.TopViewOfProducts.Add(sp2);
            }
            //Lấy bộ nhớ trong từ những sản phẩm giống nhau
            var internalMemorys = db.Products.Where(x => x.Name == product.Name).ToList().Select(y => new internalMemorys
            {
                internalMemoryName = y.InternalMemory,
                Price = y.PromotionId != null && y.Promotion.FromDay < DateTime.Now && DateTime.Now < y.Promotion.ToDay ? (y.Price - Convert.ToDecimal(Convert.ToDecimal(y.Promotion.Ratio) / 100) * y.Price).ToString("#,###") : y.Price.ToString("#,###"),
                Id = y.Id,
                isGn = y.InternalMemory == product.InternalMemory ? true : false
            }).ToList();

            Model.internalMemorys = internalMemorys;
            // Lấy comment
            var comments = db.Comments.Where(x => x.ProductId == id).OrderByDescending(x => x.Time).ToList();
            foreach (var comment in comments)
            {
                var cmt = new CodeFirst1.ViewModels.Comment();
                cmt.Name = comment.Name;
                cmt.Phone = comment.Phone;
                cmt.Time = comment.Time;
                cmt.Content = comment.Contains;
                Model.Comments.Add(cmt);
            }

            //Thêm vào sản phẩm đã xem
            if (Session["UserId"] != null)
            {
                var daxem = new Watched();
                daxem.CustomerId = Convert.ToInt32(Session["UserId"].ToString());
                daxem.ProductId = id;
                daxem.CategoryId = 1;
                daxem.DateTime = DateTime.Today;
                db.Watcheds.Add(daxem);
                db.SaveChanges();
            }
            return View("Detail", Model);
        }

        public ActionResult ThemDaXemLinhKien(int id)
        {
            if (Session["UserId"] != null)
            {
                var db = new Model1();
                var daxem = new Watched();
                daxem.CustomerId = Convert.ToInt32(Session["UserId"].ToString());
                daxem.ProductId = id;
                daxem.CategoryId = 2;
                daxem.DateTime = DateTime.Today;
                db.Watcheds.Add(daxem);
                db.SaveChanges();
                return Json("ok");
            }
            else
            {
                return Json("chuadangnhap");
            }
        }
        [HttpPost]
        public ActionResult Comment(CodeFirst1.ViewModels.Comment comment)
        {
            var db = new Model1();
            var cmt = new CodeFirst1.Database.Comment();
            if (Session["UserId"] != null)
            {
                cmt.Name = Session["UserName"].ToString();
                cmt.Phone = Convert.ToDouble(Session["Phone"]);
                cmt.Email = Session["Email"].ToString();
            }
            else
            {
                cmt.Name = comment.Name;
                cmt.Phone = comment.Phone;
                cmt.Email = comment.Email;
            }
            cmt.ProductId = comment.ProductId;
            cmt.Time = DateTime.Now;
            cmt.Contains = comment.Content;
            db.Comments.Add(cmt);
            db.SaveChanges();
            return Detail(comment.ProductId);
        }

        public ActionResult AddDeleteFavoriteProducts(int id, int status, int IdCategrory)
        {
            var db = new Model1();
            if (Session["UserId"] != null)
            {
                var iduser = Convert.ToInt32(Session["UserId"]);
                //xác định loại sản phẩm 
                if (IdCategrory == 1)
                {
                    var search = db.FavoriteProducts.Where(x => x.CustomerId == iduser && x.ProductId == id && x.CategoryId == 1).ToList();
                    //status = 1 : thêm vào sản phẩm yêu thích
                    if (status == 1)
                    {
                        if (search.Count() == 0)
                        {
                            var favorite = new FavoriteProduct();
                            favorite.ProductId = id;
                            favorite.Status = 1;
                            favorite.CustomerId = iduser;
                            favorite.CategoryId = 1;
                            db.FavoriteProducts.Add(favorite);
                            db.SaveChanges();
                        }
                        else
                        {
                            foreach (var item in search)
                            {
                                item.Status = 1;
                            }
                            db.SaveChanges();
                        }
                        return Json("ThemThanhCong");
                    }
                    //status = 2: Xóa sản phẩm yêu thích
                    else
                    {
                        foreach (var item in search)
                        {
                            item.Status = 0;
                        }
                        db.SaveChanges();
                        return Json("XoaThanhCong");
                    }
                }
                else
                {
                    var search = db.FavoriteProducts.Where(x => x.CustomerId == iduser && x.AccessoriesId == id && x.CategoryId == 2).ToList();
                    //status = 1 : thêm vào sản phẩm yêu thích
                    if (status == 1)
                    {
                        if (search.Count() == 0)
                        {
                            var favorite = new FavoriteProduct();
                            favorite.AccessoriesId = id;
                            favorite.Status = 1;
                            favorite.CustomerId = iduser;
                            favorite.CategoryId = 2;
                            db.FavoriteProducts.Add(favorite);
                            db.SaveChanges();
                        }
                        else
                        {
                            foreach (var item in search)
                            {
                                item.Status = 1;
                            }
                            db.SaveChanges();
                        }
                        return Json("ThemThanhCongLinhKien");
                    }
                    //status = 2: Xóa sản phẩm yêu thích
                    else
                    {
                        foreach (var item in search)
                        {
                            item.Status = 0;
                        }
                        db.SaveChanges();
                        return Json("XoaThanhCongLinhKien");
                    }
                }
            }
            else
            {
                return Json("ChuaDangNhap");
            }
        }

        public ActionResult SearchAccessories(int id)
        {
            var db = new Model1();
            var Model = new List<Accessories>();
            var sp = db.Accessories.Where(x => x.IdCategoryAccessories == id).ToList();
            foreach (var accessory in sp)
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
                Model.Add(lk);
            }
            var spcaonhathoadon = (from a in db.FavoriteProducts
                                   where a.Status == 1 && a.CategoryId == 1
                                   group a by a.ProductId into result
                                   select new
                                   {
                                       id = result.FirstOrDefault().ProductId,
                                       solanyt = result.Count(),

                                   })
                                  .OrderByDescending(x => x.solanyt)
                                  .Take(4).ToList();
            var listid = spcaonhathoadon.Select(x => x.id).ToList();
            var lkcanlay = db.Products.Where(x => listid.Contains(x.Id)).ToList();
            var modelProducts = new List<ProductViewModel>();
            foreach (var item in lkcanlay)
            {
                var spyt1 = new ProductViewModel();
                spyt1.Id = item.Id;
                spyt1.Name = item.Name;
                spyt1.Image1 = item.Product_Image.FirstOrDefault(x => x.IdProducts == item.Id).Image1;
                if (item.PromotionId != null && item.Promotion.FromDay < DateTime.Now && item.Promotion.ToDay > DateTime.Now)
                {
                    spyt1.Price = item.Price - Convert.ToDecimal(Convert.ToDecimal(item.Promotion.Ratio) / 100) * item.Price;
                }
                else
                {
                    spyt1.Price = item.Price;
                }
                modelProducts.Add(spyt1);
            }
            var manufacturerProducts = db.Manufacturers.ToList().Select(x => new ManufactureProduct
            {
                Name = x.Name,
                NumberProduct = x.Products.Select(y => y.Quantity).Sum(),
                image = x.image
            }).ToList();
            var viewModel = new ProductsViewModel();
            viewModel.Accessories = Model;
            viewModel.ManufactureProducts = manufacturerProducts;
            viewModel.favorateProduct = modelProducts;
            return View("TimPhuKien", viewModel);
        }

        public ActionResult HienThiKhuyenMai()
        {
            var db = new Model1();
            var products = db.Promotions.Select(x => new CTKhuyenMaiViewModel
            {
                Id = x.Id,
                fromday = x.FromDay,
                today = x.ToDay,
                ratio = x.Ratio,
                Content = x.Content,
                Ttsanphams = x.Products.Select(y => new ttsanpham { id = y.Id, Name = y.Name, Manufacture = y.Manufacturer.Name, image = y.Product_Image.FirstOrDefault().Image1 }).ToList()
            }).ToList();

            return View("ThongTinKhuyenMai",products);
        }
    }
}