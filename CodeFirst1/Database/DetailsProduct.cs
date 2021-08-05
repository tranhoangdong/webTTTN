namespace CodeFirst1.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetailsProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(400)]
        public string TouchGlass { get; set; }

        [StringLength(400)]
        public string ScreenTechnology { get; set; }

        [StringLength(400)]
        public string ScreenSize { get; set; }

        [StringLength(50)]
        public string TheResolution { get; set; }

        public string CameraFeature { get; set; }

        [StringLength(200)]
        public string FlashLight { get; set; }

        [StringLength(200)]
        public string VideoCall { get; set; }

        [StringLength(200)]
        public string Film { get; set; }

        [StringLength(200)]
        public string ExternalMemoryCardSupport { get; set; }

        [StringLength(200)]
        public string MaximumCardSupport { get; set; }

        [StringLength(50)]
        public string Weight { get; set; }

        [StringLength(200)]
        public string BatteryType { get; set; }

        [StringLength(50)]
        public string FMRadio { get; set; }

        [StringLength(200)]
        public string ImageDetial { get; set; }

        public virtual Product Product { get; set; }
    }
}
