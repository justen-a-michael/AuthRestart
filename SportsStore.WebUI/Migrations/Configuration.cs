﻿using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsStore.WebUI.Infrastructure;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Migrations
{
    internal sealed class Configuration
    : DbMigrationsConfiguration<AppEFDbContext>
    {
 public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Users.Infrastructure.AppIdentityDbContext";
        }
        protected override void Seed(AppEFDbContext context)
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
            //foreach (AppUser dbUser in userMgr.Users)
            //{
            //    if (dbUser.Country == Countries.NONE)
            //    {
            //        dbUser.SetCountryFromCity(dbUser.City);
            //    }
            //}
            context.SaveChanges();
        }
    }
}