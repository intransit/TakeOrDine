namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManageListing")]
    public partial class ManageListing
    {
        [Key]
        [Column(Order = 0)]
        public int ListingId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HostId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string DineType { get; set; }

        [Key]
        [Column(Order = 3)]
        public double PriceMin { get; set; }

        [Key]
        [Column(Order = 4)]
        public double PriceMax { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime DateOfAvailability { get; set; }

        [Key]
        [Column(Order = 6)]
        public TimeSpan StartTimeOfAvailability { get; set; }

        [Key]
        [Column(Order = 7)]
        public TimeSpan EndTimeOfAvailability { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuestLimit { get; set; }

        public string CusineType { get; set; }

        public string Menu { get; set; }

        public int? DeadlineOffsetInHrs { get; set; }

        public virtual host host { get; set; }
    }
}
