using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst1.Database;
using CodeFirst1.ViewModels;
using CodeFirst1.Controllers;

namespace CodeFirst1.Helpers
{
    public static class DataHelper
    {
        public static List<ManufacturerViewModel> GetManufacturers()
        {
            var db = new Model1();

            var products = db.Manufacturers.Select(x => new ManufacturerViewModel
            {
                Name = x.Name,
                ManufacturerProducts = x.Products.OrderByDescending(y => y.NumberOfView).Take(5).Select(y => new ManufacturerProducts { Id = y.Id, Name = y.Name }).ToList()
            }).ToList();
           
            return products;
        }
        public static List<AccessorieViewModel> Getaccessories()
        {
            var db = new Model1();
            var accessories = db.CategoryAccessories.Select(x => new AccessorieViewModel { Id = x.Id ,Name = x.Name }).ToList();
            return accessories;
        }
       public static List<Cart> GetCarts()
        {
            List<Cart> lstGiohang = (List<Cart>)HttpContext.Current.Session["GioHang"] as List<Cart>;
            if (lstGiohang == null)
            {
                //Neu chua co gio hang thi tao moi 1 gio hang
                lstGiohang = new List<Cart>();
                HttpContext.Current.Session["GioHang"] = lstGiohang;
            }
            return lstGiohang;
        }
       
    }
}