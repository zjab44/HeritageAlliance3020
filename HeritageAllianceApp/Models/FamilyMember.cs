using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class FamilyMember
    {
        [Key]
        [Column("Member_Id")]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(32)]
        public string Relationship { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("First_Name")]
        public string FirstName { get; set; }

        [MaxLength(32)]
        [Column("Middle_Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(32)]
        [Column("Last_Name")]
        public string LastName { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Birth")]
        public string DateOfBirth { get; set; }

        [MaxLength(30)]
        [Column("Date_Of_Death")]
        public string DateOfDeath { get; set; }

        [Column("Deceased_Id")]
        public int DeceasedId { get; set; }

        [ForeignKey("DeceasedId")]
        public Deceased Deceased { get; set; }
    }
}