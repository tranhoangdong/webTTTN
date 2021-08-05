using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst1.Database;
namespace CodeFirst1.ViewModels
{
    public class Cart
    {
        Model1 db = new Model1();
        public int? IdProduct { get; set; }
        public string Image { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? InventoryNumber { get; set; }
        public int? Status { get; set; }
        public int CategoryID { get; set; }
        public decimal IntoMoney
        {
            get { return Quantity * Price; }
        }
        public Cart(int Id , int sl , int CategoryId)
        {
            if(CategoryId ==1 )
            {
                IdProduct = Id;
                Product product = db.Products.Single(n => n.Id == Id);
                NameProduct = product.Name;
                Image = product.Product_Image.FirstOrDefault(x=>x.IdProducts == Id).Image1;
                CategoryID = CategoryId;
                //Image = product.Product_Image.Where(x=>x.IdProducts ==  Id);
                Price = product.Price; /*double.Parse(SanPham.Gia.ToString());*/
                if (product.PromotionId != null && product.Promotion.FromDay < DateTime.Now && DateTime.Now < product.Promotion.ToDay)
                {
                    Price = product.Price - Convert.ToDecimal((Convert.ToDecimal(product.Promotion.Ratio) / 100)) * product.Price;
                }
                else
                {
                    Price = product.Price;
                }
                Quantity = sl;
                InventoryNumber = db.Products.Single(x => x.Id == Id).Quantity;
            }
            else
            {
                IdProduct = Id;
                CodeFirst1.Database.Accessory accessories = db.Accessories.Single(y => y.Id == Id);
                NameProduct = accessories.Name;
                Image = accessories.Image;
                CategoryID = CategoryId;
                //Image = product.Product_Image.Where(x=>x.IdProducts ==  Id);
                Price = accessories.Price; /*double.Parse(SanPham.Gia.ToString());*/
                Quantity = sl;
                InventoryNumber = db.Accessories.Single(x => x.Id == Id).Quantity;
            }
           
        }
    }
}