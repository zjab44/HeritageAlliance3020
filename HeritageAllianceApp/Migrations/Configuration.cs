namespace HeritageAllianceApp.Migrations
{
    using HeritageAllianceApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<HeritageAllianceApp.Models.HeritageAllianceAppDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HeritageAllianceApp.Models.HeritageAllianceAppDb context)
        {             
            List<Deceased> echDeceased = PopulateDeceasedList();

            context.Locations.AddOrUpdate(l => new { l.City, l.State, l.County, l.Zip },
                new Location { City = "Johnson City", State = "TN", County = "Washington", Zip = "37604" },
                new Location { City = "Johnson City", State = "TN", County = "Washington", Zip = "37601" },
                new Location
                {
                    City = "Jonesborough",
                    State = "TN",
                    County = "Washington",
                    Zip = "37659",
                    Cemeteries = new List<Cemetery>
                    {
                        new Cemetery 
                        { 
                            CemeteryName = "Evergreen - College Hill", 
                            Street1 = "End of Cemetery Lane",
                            GPSCoordinates = "36d17.782N|82d28.092W"
                            //GPSCoordinates = "36d17.782N|82d28.092W",
                            //Deceased = echDeceased
                        },
                        new Cemetery { CemeteryName = "Test Cemetery", Street1 = "123 Test Lane", GPSCoordinates = "36d18.183N|82d21.100W" },
                        new Cemetery { CemeteryName = "Blair Cemetery", Street1 = "Arnold Rd - 8/10th mi from Cherokee Rd", GPSCoordinates = "36d13.070N|82d27.150W" }
                    }
                }
            );                      
        }

        private List<Deceased> PopulateDeceasedList()
        {
            List<Deceased> deceasedList = new List<Deceased>();            
                        
            var reader = new StreamReader(File.OpenRead(@AppDomain.CurrentDomain.BaseDirectory + "Migrations/echstones.csv"));
            while (!reader.EndOfStream)           
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                deceasedList.Add(new Deceased
                {
                    FirstName = values[3].ToString(),
                    LastName = values[2].ToString(),
                    DateOfBirth = values[4].ToString(),
                    DateOfDeath = values[5].ToString(),
                    RowNumber = values[0].ToString(),
                    LocationWithinRow = values[1].ToString(),
                    StoneDescription = "N/A",
                    TypeOfBurial = "In-Ground"
                });
            }
            return deceasedList;
        }
    }
}
