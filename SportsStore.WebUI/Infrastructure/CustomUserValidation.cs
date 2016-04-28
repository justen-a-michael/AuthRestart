using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Infrastructure
{
    public class CustomUserValidation : UserValidator<AppUser>
    {
        public CustomUserValidation(AppUserManager mgr) : base(mgr)
        {

        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are not allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}