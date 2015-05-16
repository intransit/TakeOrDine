namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guest
    {
        public Guest()
        {
            Attendees = new HashSet<Attendee>();
        }

        [Key]
        public int GuestId { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
