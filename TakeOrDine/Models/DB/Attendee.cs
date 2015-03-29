namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attendee
    {
        public int AttendeeId { get; set; }

        public int EventId { get; set; }

        public int GuestId { get; set; }

        [Required]
        [StringLength(128)]
        public string State { get; set; }

        [Required]
        [StringLength(128)]
        public string DineType { get; set; }

        public int PartySize { get; set; }

        public virtual Event Event { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
