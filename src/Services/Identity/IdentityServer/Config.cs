using IdentityModel;
using IdentityServer4;
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
                       ClientId = "sms.client.local",
                       ClientName = "SMS Blazor",
                    
                       AllowedGrantTypes = GrantTypes.Code,
                       RequireConsent = false,
                       RequirePkce = false,
                       AllowRememberConsent = false,
                       AlwaysIncludeUserClaimsInIdToken = true,
                       AllowOfflineAccess = true,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5000/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5000/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                     

                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.OfflineAccess,
                           "sms",
                           "sms:read",
                           "sms:write",
                           "company_profile",
                           "email"
                       },
                        AccessTokenLifetime = 60*60*2, // 2 hours
                        IdentityTokenLifetime= 60*60*2 // 2 hours
                   },

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
                    new Client
                    {
                        ClientId = "catalog.swagger.client",
                        ClientName = "Swagger UI for demo_api",
                        ClientSecrets = { new Secret("secret".Sha256())}, // change me!

                        AllowedGrantTypes = GrantTypes.Code,
                        RequirePkce = true,
                        RequireClientSecret = false,

                        RedirectUris = {"https://localhost:5000/swagger/oauth2-redirect.html"},
                        AllowedCorsOrigins = {"https://localhost:5000"},
                        AllowedScopes = { "catalog.api" }
                    },
                      new Client
                   {
                       ClientId = "catalog.mvc.client",
                       ClientName = "Catalog MVC Web App",
                       AllowedGrantTypes = GrantTypes.Code,
                       RequirePkce = false,
                       AllowRememberConsent = false,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5800/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5800/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           //IdentityServerConstants.StandardScopes.Address,
                           //IdentityServerConstants.StandardScopes.Email,
                           // "roles",
                           "catalog.api"
                          
                       }
                   }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] 
            {
                new ApiScope("catalog.api","catalog API"),
                new ApiScope("sms:read","SMS API"),
                new ApiScope("sms","SMS API"),
                new ApiScope("sms:write","SMS API"),
                new ApiScope("company_profile","company"),
                new ApiScope("email","company email"),
            };



        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { new ApiResource("sms","sms api") };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              //new IdentityResources("")
              //new IdentityResources.Address(),
              //new IdentityResources.Email(),
             // new IdentityResource("sms","Your role(s)",new List<string>() { "sms:read","sms:write" })
            };

        public static List<TestUser> TestUsers => new List<TestUser>
                  {
                        new TestUser
                        {
                            SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                            Username = "ottar",
                            Password = "ottar",
                            
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Name, "ottar yrjan aune"),
                                //new Claim(JwtClaimTypes.Audience, "sms"),
                                new Claim(JwtClaimTypes.Scope, "sms:write"),
                                new Claim(JwtClaimTypes.Scope, "sms:read"),
                                new Claim(JwtClaimTypes.GivenName, "ottar yrjan"),
                                new Claim(JwtClaimTypes.FamilyName, "aune"),
                                new Claim(JwtClaimTypes.Email, "ottar.yrjan.aune@tietoevry.com"),
                                new Claim(JwtClaimTypes.Profile, "Profile"),
                                new Claim("companyname", "IT"),
                                new Claim("department", "EVRY Card Services AS")
                            }
                        }
                  };

        public static class CustomClaimTypes
        {
            public const string CompanyName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/companyname";
            public const string Department = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/department";

        }

    }
}
