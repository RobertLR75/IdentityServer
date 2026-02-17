using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityServer.Contracts;

namespace IdentityService
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };


        public static IEnumerable<ApiScope> ApiScopes =>
        [
            new(nameof(ApiScopeNames.ArrangementRead), "Arrangement Read Access"),
            new(nameof(ApiScopeNames.ArrangementWrite), "Arrangement Write Access"),
            new(nameof(ApiScopeNames.NotificationRead), "Notification Read Access"),
            new(nameof(ApiScopeNames.NotificationWrite), "Notification Write Access")
            {
                UserClaims = { "name" }
            }
        ];


        public static IEnumerable<Client> Clients =>
        [
            // new()
            // {
            //     ClientId = "blazorserverclient",
            //     ClientName = "admin",
            //     ClientSecrets = { new Secret("superhemmelig".Sha256()) },
            //     AllowedGrantTypes = GrantTypes.Code,
            //     RequirePkce = true,
            //     RedirectUris = { "https://localhost:5002/signin-oidc" },
            //     // PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
            //     PostLogoutRedirectUris = { "https://localhost:5002" },
            //     AllowedScopes = { nameof(IdentityServerConstants.StandardScopes.OpenId).ToLower(), nameof(IdentityServerConstants.StandardScopes.Profile).ToLower(), nameof(ApiScopeNames.ArrangementRead), nameof(ApiScopeNames.ArrangementWrite) },
            //     AllowOfflineAccess = true
            // },
            new()
            {
                ClientId = "tictactoeclient",
                ClientName = "tictactoe",
                ClientSecrets = { new Secret("superhemmelig".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RedirectUris = { "https://localhost:5003/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc" },
                //PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc2" },
                // PostLogoutRedirectUris = { "https://localhost:5003/" },
                AllowedScopes =
                {
                    nameof(IdentityServerConstants.StandardScopes.OpenId).ToLower(), nameof(IdentityServerConstants.StandardScopes.Profile).ToLower(), nameof(ApiScopeNames.ArrangementRead), nameof(ApiScopeNames.ArrangementWrite)
                },
                AllowOfflineAccess = true,
                AlwaysIncludeUserClaimsInIdToken = true
            },

            new()
            {
                ClientId = "admin",
                ClientName = "admin",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // ingen bruker
                ClientSecrets = { new Secret("superhemmelig".Sha256()) },
                AllowedScopes = { nameof(ApiScopeNames.ArrangementRead), nameof(ApiScopeNames.ArrangementWrite) }
                    
            },
            new()
            {
                ClientId = "tictactoeconsole",
                ClientName = "tictactoeconsole",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // ingen bruker
                ClientSecrets = { new Secret("superhemmelig".Sha256()) },
                AllowedScopes = { nameof(ApiScopeNames.GameRead), nameof(ApiScopeNames.GameWrite) }
                    
            },
            
            new()
            {
                ClientId = "arrangement-service",
                ClientName = "ArrangementService",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // ingen bruker
                ClientSecrets = { new Secret("supersecret".Sha256()) },
                AllowedScopes = { nameof(ApiScopeNames.ArrangementRead), nameof(ApiScopeNames.ArrangementWrite) }
                    
            }
        ];
    }
}