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
            ManageListing = new HashSet<ManageListing>();
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

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string Zipcode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public string Street { get; set; }

        [StringLength(50)]
        public string UnitNumber { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int? ReviewsCount { get; set; }

        public double? Rating { get; set; }

        public virtual ICollection<ManageListing> ManageListing { get; set; }
    }
}
