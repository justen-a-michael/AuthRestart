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
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "MySecret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email },
                    password);
                user = userMgr.FindByName(userName);
            }
            
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
        }
    }
}