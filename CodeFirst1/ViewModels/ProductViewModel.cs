using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class ProductsViewModel
    {
        public IPagedList<ProductViewModel> Products { get; set;}
        public List<ProductViewModel> Product { get; set;}
        public List<ManufactureProduct> ManufactureProducts { get; set; }
        public List<Accessories> Accessories { get; set; }
        public List<ProductViewModel> favorateProduct = new List<ProductViewModel>();
    }

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public string FrontCamera { get; set; }

        public string RearCamera { get; set; }

        public string Ram { get; set; }

        public string CPU { get; set; }

        public string InternalMemory { get; set; }

        public int? Quantity { get; set; }

        public string Sim { get; set; }

        public string Battery { get; set; }

        public string OperatingSystem { get; set; }

        public int? PromotionId { get; set; }

        public decimal Price { get; set; }

        public decimal? PriceKM { get;set; }

        public DateTime? DateSubmitted { get; set; }

        public int? Guarantee { get; set; }

        public string Manufacturer { get; set; }

        public int? NumberOfView { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public string Described { get; set; }

        public int? GiftId { get; set; }

        public DateTime? FromDay { get; set; }

        public DateTime? ToDay { get; set; }

        public int? Ratio { get; set; }

        public string Content { get; set; }

        public bool IsKM { get; set; }

        public string PriceOut
        {
            get
            {
                return $"{Price.ToString("#,###")} VNĐ";
            }
        }
        public bool isGift { get; set; }
        
        public string InfoGift { get; set; }

        public bool Favorive { get; set; }

        public string TenKM { get; set; }
    }
    public class ManufactureProduct
    {
        public string Name { get; set; }
        public int? NumberProduct { get; set; }
        public string image { get; set; }
    }
    public class DetailsProduct
    {
        public int Id { get; set; }
        public string TouchGlass { get; set; }
        public string ScreenTechnology { get; set; }
        public string ScreenSize { get; set; }
        public string TheResolution { get; set; }
        public string CameraFeature { get; set; }
        public string FlashLight { get; set; }
        public string VideoCall { get; set; }
        public string Film { get; set; }
        public string ExternalMemoryCardSupport { get; set; }
        public string MaximumCardSupport {get;set;}
        public string Weight { get; set; }
        public string BatteryType { get; set; }
        public string FMRadio { get; set; }
        public string ImageDetial { get; set; }
    }
    public class Accessories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Keyword { get; set; }
        public string Manufacture { get; set; }
        public int? CategoryId { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string Description6 { get; set; }
        public string Description7 { get; set; }
        public int Quantity { get; set; }
        public string PriceOut
        {
            get
            {
                return $"{Price.ToString("#,###")} VNĐ";
            }
        }
        public bool isYT { get; set; }

        public HttpPostedFileBase file { get; set; }
        public int? IdCategoryAccessories { get; set; }
    }
}