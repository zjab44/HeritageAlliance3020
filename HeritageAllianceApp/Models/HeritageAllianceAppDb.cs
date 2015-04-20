using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HeritageAllianceApp.Models
{
    public class HeritageAllianceAppDb : DbContext
    {
        public HeritageAllianceAppDb() : base ("DefaultConnection")
        {
        }

        /// Are these all of the classes ???
        public DbSet<Location> Locations { get; set; }
        public DbSet<Cemetery> Cemeteries { get; set; }
        public DbSet<Deceased> Deceased { get; set; }
        public DbSet<Related> Related { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<BiographicalInformation> BiographicalInformation { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<InformationLink> InformationLinks { get; set; }
        public DbSet<RecordLink> RecordLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cemetery>()
                        .HasRequired(c => c.Location)
                        .WithMany(l => l.Cemeteries)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deceased>()
                        .HasRequired(d => d.Cemetery)
                        .WithMany(c => c.Deceased)
                        .WillCascadeOnDelete(false);           
            
            modelBuilder.Entity<Related>()
                        .HasRequired(r => r.Deceased)
                        .WithMany(d => d.DeceasedRelativesI)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Related>()
                        .HasRequired(r => r.DeceasedRelative)
                        .WithMany(d => d.DeceasedRelativesO)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamilyMember>()
                        .HasRequired(f => f.Deceased)
                        .WithMany(d => d.FamilyMembers)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<BiographicalInformation>()
                        .HasRequired(b => b.Deceased)
                        .WithMany(d => d.BiographicalInformation)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<BiographicalInformation>()
                        .HasOptional(b => b.FamilyMember)
                        .WithMany(f => f.BiographicalInformation)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<BiographicalInformation>()
                        .HasOptional(b => b.InformationLink)
                        .WithOptionalDependent()
                        .Map(b => b.MapKey("Information_Link_Id"))
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Record>()
                        .HasRequired(r => r.Deceased)
                        .WithMany(d => d.Records)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Record>()
                        .HasOptional(r => r.RecordLink)
                        .WithOptionalDependent()
                        .Map(b => b.MapKey("Record_Link_Id"))
                        .WillCascadeOnDelete(false);

            //modelBuilder.Entity<InformationLink>()
            //            .HasKey(i => i.InformationId);

            //modelBuilder.Entity<RecordLink>()
            //            .HasKey(r => r.RecordId);

            //modelBuilder.Entity<InformationLink>()
            //            .HasRequired(i => i.BiographicalInformation)
            //            .WithOptional(b => b.InformationLink)
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<RecordLink>()
            //            .HasRequired(r => r.Record)
            //            .WithOptional(r => r.RecordLink)
            //            .WillCascadeOnDelete(false);
        }
    }
}