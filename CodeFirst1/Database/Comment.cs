namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(400)]
        public string Contains { get; set; }

        public double? Phone { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
