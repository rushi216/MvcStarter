using MvcStarter.Migrations;
using MvcStarter.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcStarter.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize(IComponentContext componentContext)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            using (var dbContext = componentContext.Resolve<ApplicationDbContext>())
            {
                dbContext.Database.Initialize(false);
            }
        }
    }
}