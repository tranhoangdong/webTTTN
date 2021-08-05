namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal Total { get; set; }

        public int? Status { get; set; }

        [StringLength(550)]
        public string ReasonCancel { get; set; }

        public int? CustomerId { get; set; }

        public decimal ProvisionalAmount { get; set; }

        public DateTime? DateProcessing { get; set; }

        public int? AdminId { get; set; }

        public int? PointsUse { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
