﻿using IdentityModel;
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
                new ApiScope("catalog.api","catalog API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              //new IdentityResources.Address(),
              //new IdentityResources.Email(),
              //new IdentityResource(
              //      "roles",
              //      "Your role(s)",
              //      new List<string>() { "role" })
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
                                new Claim(JwtClaimTypes.GivenName, "ottar"),
                                new Claim(JwtClaimTypes.FamilyName, "aune")
                            }
                        }
                  };

    }
}
