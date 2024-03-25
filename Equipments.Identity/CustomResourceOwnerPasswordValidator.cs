using Equipments.Identity.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<AppUser> _userManager;
        public CustomResourceOwnerPasswordValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByNameAsync(context.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, context.Password))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Неправильный логин или пароль");
                return;
            }
            user.LoginLastDate = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            var principal = await GetClaimsPrincipalAsync(user);

            context.Result = new GrantValidationResult(
                subject: user.Id,
                authenticationMethod: "custom",
                claims: principal.Claims.ToList());
        }
        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                // Добавьте любые другие претензии, которые вам нужны
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var identity = new ClaimsIdentity(claims, "custom");
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
