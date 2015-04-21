using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Id")]
        public int RecordId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Record_Type")]
        [DisplayName("Type")]
        public string RecordType { get; set; }

        [Required]
        [Column("Record_Description")]
        [DisplayName("Description")]
        public string RecordDescription { get; set; }

        [Required]
        [Column("Date_Entered")]
        [DisplayName("Date Entered")]
        public DateTime DateEntered { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Entered_By")]
        [DisplayName("Entered By")]
        public string EnteredBy { get; set; }

        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }

        [ForeignKey("DeceasedId")]
        public Deceased Deceased { get; set; }

        public virtual RecordLink RecordLink { get; set; }
    }
}