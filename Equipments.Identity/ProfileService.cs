using Equipments.Identity.Models;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity
{
    public class ProfileClaimsService : IProfileService
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileClaimsService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //Класс для установки притензий в токен
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", context.Subject.GetSubjectId())
            };

            context.IssuedClaims.AddRange(claims);

        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
