using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class Location
    {
        [Key]
        [Column("Location_Id")]
        [DisplayName("Id")]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(2)]
        [DisplayName("State")]
        public string State { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("County")]
        public string County { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [MaxLength(5)]
        [DisplayName("Zip")]
        public string Zip { get; set; }

        public virtual ICollection<Cemetery> Cemeteries { get; set; }
    }
}