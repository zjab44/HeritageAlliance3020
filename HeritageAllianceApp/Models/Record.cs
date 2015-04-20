using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class Record
    {
        [Key]
        [Column("Record_Id")]
        public int RecordId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Record_Type")]
        public string RecordType { get; set; }

        [Required]
        [Column("Record")]
        public string RecordR { get; set; }

        [Required]
        [Column("Date_Entered")]
        public DateTime DateEntered { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Entered_By")]
        public string EnteredBy { get; set; }

        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }

        [ForeignKey("DeceasedId")]
        public Deceased Deceased { get; set; }

        public virtual RecordLink RecordLink { get; set; }
    }
}