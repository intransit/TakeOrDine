namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ManageListing
    {
        public ManageListing()
        {
            Attendees = new HashSet<Attendee>();
        }

        [Key]
        public int ListingId { get; set; }

        public int HostId { get; set; }

        [Required]
        public string DineType { get; set; }

        public double PriceMin { get; set; }

        public double PriceMax { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfAvailability { get; set; }

        public TimeSpan StartTimeOfAvailability { get; set; }

        public TimeSpan EndTimeOfAvailability { get; set; }

        public int GuestLimit { get; set; }

        public string CusineType { get; set; }

        public string Menu { get; set; }

        public int? DeadlineOffsetInHrs { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual Host Hosts { get; set; }
    }
}
