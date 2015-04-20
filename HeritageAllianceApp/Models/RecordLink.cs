using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class RecordLink
    {
        [Key]
        [Column("Record_Link_Id")]
        public int RecordLinkId { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Link_To")]
        public string LinkTo { get; set; }
                
        [Column("Record_Id")]
        public int RecordId { get; set; }

        [ForeignKey("RecordId")]
        public Record Record { get; set; }
    }
}