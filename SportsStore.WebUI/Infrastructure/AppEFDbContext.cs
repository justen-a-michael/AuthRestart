using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Infrastructure
{
    public class AppEFDbContext : IdentityDbContext<AppUser>
    {
        public AppEFDbContext() : base("EFDbContext") { }

        static AppEFDbContext()
        {
            Database.SetInitializer<AppEFDbContext>(new IdentityDbInit());
        }

        public static AppEFDbContext Create()
        {
            return new AppEFDbContext();
        }
    }

    public class IdentityDbInit
        : DropCreateDatabaseIfModelChanges<AppEFDbContext>
    {
        protected override void Seed(AppEFDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppEFDbContext context)
        {
            //
        }
    }
}