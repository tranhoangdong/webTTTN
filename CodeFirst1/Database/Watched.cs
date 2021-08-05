namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Watched")]
    public partial class Watched
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public DateTime? DateTime { get; set; }

        public int? CategoryId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
