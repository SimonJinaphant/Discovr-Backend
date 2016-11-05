using DiscovrWeb.Models;

namespace DiscovrWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiscovrWeb.Models.DiscovrWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DiscovrWeb.Models.DiscovrWebContext context)
        {
            context.Events.AddOrUpdate(x => x.Id,
                new Event()
                {
                    Id = 1,
                    Name = "Imagine Day Info Session",
                    StartTime = new DateTime(2016, 9, 6, 11, 0, 0),
                    EndTime = new DateTime(2016, 9, 6, 16, 0, 0),
                    Host = "UBC Snowbots",
                    Location = "Outside of Kaiser on Main Mall",
                    Description = "We have a robot..."
                },
                new Event()
                {
                    Id = 2,
                    Name = "Week E^0",
                    StartTime = new DateTime(2016, 9, 6, 0, 0, 0),
                    EndTime = new DateTime(2016, 9, 15, 0, 0, 0),
                    Host = "EUS (Engineering Undergraduate Society)",
                    Location = "Multiple Locations",
                    Description = ""
                },
                new Event()
                {
                    Id = 3,
                    Name = "Movie Night",
                    StartTime = new DateTime(2016, 10, 28, 16, 0, 0),
                    EndTime = new DateTime(2016, 10, 28, 20, 0, 0),
                    Host = "ECESS (Electrical and Computer Engineering Student Society)",
                    Location = "MCLD 418",
                    Description = "What's a better way to get into the Halloween spirit than by snuggling around the Christmas tree with some egg nog?"
                }
            );
        }
    }
}