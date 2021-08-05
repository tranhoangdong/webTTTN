namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            FavoriteProducts = new HashSet<FavoriteProduct>();
            Product_Image = new HashSet<Product_Image>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(200)]
        public string FrontCamera { get; set; }

        [StringLength(200)]
        public string RearCamera { get; set; }

        [StringLength(50)]
        public string Ram { get; set; }

        public string CPU { get; set; }

        public string InternalMemory { get; set; }

        public int? Quantity { get; set; }

        [StringLength(200)]
        public string Sim { get; set; }

        [StringLength(200)]
        public string Battery { get; set; }

        [StringLength(200)]
        public string OperatingSystem { get; set; }

        public int? PromotionId { get; set; }

        public decimal Price { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public int? GiftId { get; set; }

        public int? Guarantee { get; set; }

        public int? ManufacturerId { get; set; }

        public int? NumberOfView { get; set; }

        public virtual Category Category { get; set; }

        public virtual DetailsProduct DetailsProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }

        public virtual Gift Gift { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Image> Product_Image { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
