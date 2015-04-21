using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class InformationLink
    {
        [Key]
        [Column("Information_Link_Id")]
        [DisplayName("Id")]
        public int InformationLinkId { get; set; }

        [Required]
        [DisplayName("URL")]
        public string URL { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("Link_To")]
        [DisplayName("Link Description")]
        public string LinkTo { get; set; }

        [Column("Information_Id")]
        public int InformationId { get; set; }

        [ForeignKey("InformationId")]
        public BiographicalInformation BiographicalInformation { get; set; }        
    }
}