namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public Event()
        {
            Attendees = new HashSet<Attendee>();
            Guests = new HashSet<Guest>();
        }

        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int HostId { get; set; }

        [Required]
        [StringLength(128)]
        public string DineType { get; set; }

        [Column("Guest Limit")]
        public int Guest_Limit { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string MenuInCsv { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual host host { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
