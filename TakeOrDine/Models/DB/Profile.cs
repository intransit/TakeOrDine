namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        public Profile()
        {
            Attendees = new HashSet<Attendee>();
        }

        public int ProfileId { get; set; }

        [Required]
        [StringLength(50)]
        public string DineType { get; set; }

        public double PriceMin { get; set; }

        public double PriceMax { get; set; }

        public DateTime DateOfAvailability { get; set; }

        public int HostId { get; set; }

        public int GuestLimit { get; set; }

        public double DeadlineOffsetInHrs { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual host host { get; set; }
    }
}
