using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Id")]
        public int BiographicalInformationId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Biographical_Information_Type")]
        [DisplayName("Type")]
        public string BiographicalInformationType { get; set; }

        [Required]
        [Column("Biographical_Information_Description")]
        [DisplayName("Description")]
        public string BiographicalInfoDescription { get; set; }

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

        [Column("Family_Member_Id")]
        public int? FamilyMemberId { get; set; }

        [ForeignKey("FamilyMemberId")]
        public FamilyMember FamilyMember { get; set; }

        public virtual InformationLink InformationLink { get; set; }
    }
}