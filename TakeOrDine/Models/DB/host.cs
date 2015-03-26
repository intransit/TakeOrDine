namespace TakeOrDine.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("host")]
    public partial class host
    {
        public host()
        {
            Events = new HashSet<Event>();
        }

        public int HostId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string specialityInCsv { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
