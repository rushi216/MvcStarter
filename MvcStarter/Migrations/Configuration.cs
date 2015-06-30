namespace MvcStarter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcStarter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MvcStarter.Models.ApplicationDbContext";
        }

        protected override void Seed(MvcStarter.Models.ApplicationDbContext context)
        {
            
        }
    }
}
