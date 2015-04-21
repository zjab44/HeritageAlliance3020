using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class FamilyMember
    {
        [Key]
        [Column("Family_Member_Id")]
        [DisplayName("Id")]
        public int FamilyMemberId { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("Relationship")]
        public string Relationship { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("First_Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [MaxLength(32)]
        [Column("Middle_Name")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Last_Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Birth")]
        [DisplayName("Date of Birth")]
        public string DateOfBirth { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Death")]
        [DisplayName("Date of Death")]
        public string DateOfDeath { get; set; }

        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }

        [ForeignKey("DeceasedId")]
        public Deceased Deceased { get; set; }

        public virtual ICollection<BiographicalInformation> BiographicalInformation { get; set; }
    }
}