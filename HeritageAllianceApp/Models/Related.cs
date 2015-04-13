using System;
using System.Collections.Generic;
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
        public int RelatedId { get; set; }
                
        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }
        
        [ForeignKey("DeceasedId")]
        [Column(Order = 1)] 
        public Deceased Deceased { get; set; }
                
        [Column("Deceased_Relative_Id")]        
        public int DeceasedRelativeId { get; set; }

        [ForeignKey("DeceasedRelativeId")]
        [Column(Order = 2)] 
        public Deceased DeceasedRelative { get; set; }

        [Required]
        [MaxLength(32)]
        public string Relationship { get; set; }
    }
}