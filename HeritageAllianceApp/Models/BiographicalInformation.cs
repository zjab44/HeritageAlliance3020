using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class BiographicalInformation
    {
        [Key]
        [Column("Biographical_Information_Id")]
        public int BiographicalInformationId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Biographical_Information_Type")]
        public string BiographicalInformationType { get; set; }

        [Required]
        [Column("Biographical_Information")]
        public Byte[] BiographicalInfo { get; set; }

        [Required]
        [Column("Date_Entered")]
        public DateTime DateEntered { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Entered_By")]
        public string EnteredBy { get; set; }

        [Column("Person_Id")]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Deceased Deceased { get; set; }

        public Link Link { get; set; }
    }
}