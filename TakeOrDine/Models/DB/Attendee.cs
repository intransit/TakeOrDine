namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attendee
    {
        [Key]
        public int AttendeeId { get; set; }

        public int GuestId { get; set; }

        public int ListingId { get; set; }

        public virtual Guest Guests { get; set; }

        public virtual ManageListing ManageListings { get; set; }
    }
}
