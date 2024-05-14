using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Equipments.AvaloniaUI.Services
{
    public static class TokenService
    {
        public static bool ValidToToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.ValidTo > DateTime.UtcNow;
        }
        public static string[] GetRoles(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            return jwtToken.Claims
                .Where(claim => claim.Type == ClaimTypes.Role)
                .Select(claim => claim.Value)
                .ToArray();
        }
    }
}
