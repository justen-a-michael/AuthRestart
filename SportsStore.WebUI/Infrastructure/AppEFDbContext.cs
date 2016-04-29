using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsStore.WebUI.Models;
using Microsoft.AspNet.Identity;

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

    public class IdentityDbInit : NullDatabaseInitializer<AppEFDbContext>
    {
    }
}