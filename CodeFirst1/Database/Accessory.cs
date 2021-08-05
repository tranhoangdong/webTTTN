namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accessory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accessory()
        {
            FavoriteProducts = new HashSet<FavoriteProduct>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        public string Description6 { get; set; }

        public string Description7 { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(200)]
        public string KeyWord { get; set; }

        [StringLength(50)]
        public string Manufacture { get; set; }

        public int Quantity { get; set; }

        public int? IdCategoryAccessories { get; set; }

        public virtual Category Category { get; set; }

        public virtual CategoryAccessorie CategoryAccessorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }
    }
}
