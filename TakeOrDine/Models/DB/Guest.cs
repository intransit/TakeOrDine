namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Guest")]
    public partial class Guest
    {
        public Guest()
        {
            Attendees = new HashSet<Attendee>();
        }

        public int GuestId { get; set; }

        public string Email { get; set; }

        public int? PhoneNumber { get; set; }

        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual Event Event { get; set; }
    }
}
