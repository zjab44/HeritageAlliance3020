using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class Deceased
    {
        [Key]
        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }

        [MaxLength(32)]
        [Column("First_Name")]
        public string FirstName { get; set; }

        [MaxLength(32)]
        [Column("Middle_Name")]
        public string MiddleName { get; set; }

        [MaxLength(32)]
        [Column("Last_Name")]
        public string LastName { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Birth")]
        public string DateOfBirth { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Death")]
        public string DateOfDeath { get; set; }

        [Required]
        [MaxLength(4)]
        [Column("Row_Number")]
        public string RowNumber { get; set; }

        [Required]
        [MaxLength(4)]
        [Column("Location Within Row")]
        public string LocationWithinRow { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("Stone_Description")]
        public string StoneDescription { get; set; }

        [Required]
        [MaxLength(16)]
        [Column("Type_Of_Burial")]
        public string TypeOfBurial { get; set; }

        [MaxLength(1024)]
        [Column("Marker_Text")]
        public string MarkerText { get; set; }
        
        [MaxLength(1024)]
        [Column("Marker_Symbols")]
        public string MarkerSymbols { get; set; }

        [Column("Cemetery_Id")]
        public int CemeteryId { get; set; }

        [ForeignKey("CemeteryId")]
        public Cemetery Cemetery { get; set; }

        public virtual ICollection<Related> DeceasedRelativesI { get; set; }
        public virtual ICollection<Related> DeceasedRelativesO { get; set; }

        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }

        public virtual ICollection<BiographicalInformation> BiographicalInformation { get; set; }

        public virtual ICollection<Record> Records { get; set; }

    }
}