using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                    new Client
                   {
                        ClientId = "catalog.client",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "catalog.api" }
                   },
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] 
            {
                new ApiScope("catalog.api","catalog API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] { };

        public static List<TestUser> TestUsers => new List<TestUser>
                  {
                        new TestUser
                        {
                            SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                            Username = "ottar",
                            Password = "ottar",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.GivenName, "ottar"),
                                new Claim(JwtClaimTypes.FamilyName, "aune")
                            }
                        }
                  };

    }
}
