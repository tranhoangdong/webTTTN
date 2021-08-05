using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class ManufacturerViewModel
    {
        public string Name { get; set; }
        public List<ManufacturerProducts> ManufacturerProducts { get; set; } = new List<ManufacturerProducts>();
       
    }

    public class ManufacturerProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AccessorieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



}