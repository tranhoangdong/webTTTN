using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class CreateProductViewModel
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string FrontCamera { get; set; }
        public string RearCamera { get; set; }
        public string Ram { get; set; }
        public string CPU { get; set; }
        public string InternalMemory { get; set; }
        public int? Quantity { get; set; }
        public string Sim { get; set; }
        public string Battery { get; set; }
        public string OperatingSystem { get; set; }
        public string PromotionId { get; set; }
        public string GiftId { get; set; }
        public int? Guarantee { get; set; }
        public int? ManufacturerId { get; set; }
        public decimal Price { get; set; }


        public string TouchGlass { get; set; }
        public string ScreenTechnology { get; set; }
        public string ScreenSize { get; set; }
        public string TheResolution { get; set; }
        public string CameraFeature { get; set; }
        public string FlashLight { get; set; }
        public string VideoCall { get; set; }
        public string Film { get; set; }
        public string ExternalMemoryCardSupport { get; set; }
        public string MaximumCardSupport { get; set; }
        public string Weight { get; set; }
        public string BatteryType { get; set; }
        public string FMRadio { get; set; }

        public HttpPostedFileBase file1 { get; set; }
        public HttpPostedFileBase file2 { get; set; }
        public HttpPostedFileBase file3 { get; set; }
        public HttpPostedFileBase file4 { get; set; }
        public HttpPostedFileBase file5 { get; set; }
        public HttpPostedFileBase file6 { get; set; }

    }
}