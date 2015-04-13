using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class Cemetery
    {
        [Key]
        [Column("Cemetery_Id")]
        public int CemeteryId { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Cemetery_Name")]
        public string CemeteryName { get; set; }

        [Required]
        [MaxLength(64)]
        public string Street1 { get; set; }

        [MaxLength(64)]
        public string Street2 { get; set; }

        [MaxLength(64)]
        [Column("GPS_Coordinates")]
        public string GPSCoordinates { get; set; }

        [Column("Date_Established")]
        public string DateEstablished { get; set; }

        [Column("Cemetery_Notes")]
        public Byte[] CemeteryNotes { get; set; }

        [Column("Location_Id")]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public virtual ICollection<Deceased> Deceased { get; set; }
    }
}