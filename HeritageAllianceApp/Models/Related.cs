using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class Related
    {
        [Key]
        [Column("Related_Id")]
        [DisplayName("Id")]
        public int RelatedId { get; set; }
                
        [Column("Deceased_Id")]
        [DisplayName("Deceased Id")]
        public int DeceasedId { get; set; }
        
        [ForeignKey("DeceasedId")]
        [Column(Order = 1)]
        public Deceased Deceased { get; set; }
                
        [Column("Deceased_Relative_Id")]
        [DisplayName("Deceased Relative Id")]
        public int DeceasedRelativeId { get; set; }

        [ForeignKey("DeceasedRelativeId")]
        [Column(Order = 2)] 
        public Deceased DeceasedRelative { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("Relationship")]
        public string Relationship { get; set; }
    }
}