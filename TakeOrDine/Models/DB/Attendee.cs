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

        public int ProfileId { get; set; }

        public int GuestId { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
