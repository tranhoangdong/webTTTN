namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Image
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Image1 { get; set; }

        [StringLength(200)]
        public string Image2 { get; set; }

        [StringLength(200)]
        public string Image3 { get; set; }

        [StringLength(200)]
        public string Image4 { get; set; }

        [StringLength(200)]
        public string Image5 { get; set; }

        public int? IdProducts { get; set; }

        public virtual Product Product { get; set; }
    }
}
