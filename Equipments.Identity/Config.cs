using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("EquipmentsWebAPI", "Web API")
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("EquipmentsWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "EquipmentsWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "equipments-web-api",
                    ClientName = "Equipments Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "EquipmentsWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
