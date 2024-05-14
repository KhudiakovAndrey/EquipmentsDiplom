using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Equipments.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("EquipmentsWebApi", "Web API"),
                new ApiScope("EquipmentsUI"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //new Client
                //{
                //    ClientId = "equipments-web-api",
                //    ClientName = "Equipments Web API",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "EquipmentsWebApi",
                //        "EquipmentsUI"
                //    },
                //    AllowedCorsOrigins =
                //    {
                //        "http://localhost:3000"
                //    },
                //},

                //new Client
                //{
                //    ClientId = "external",
                //    ClientName = "External Client",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    RequireClientSecret = false,

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "EquipmentsWebApi"
                //    },
                //    AllowedCorsOrigins =
                //    {
                //        "http://localhost:3000"
                //    },
                //}
            };
    }
}
