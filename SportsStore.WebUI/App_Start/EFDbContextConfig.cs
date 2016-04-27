using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SportsStore.WebUI.Infrastructure;

namespace SportsStore.WebUI.App_Start
{
    public class EFDbContextConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppEFDbContext>(AppEFDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}