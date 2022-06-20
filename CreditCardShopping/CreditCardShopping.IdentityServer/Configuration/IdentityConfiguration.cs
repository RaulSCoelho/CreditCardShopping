using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace CreditCardShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static List<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        public static List<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("creditcardshopping", "CreditCardShopping Server"),
                new ApiScope(name: "read", "Read Data."),
                new ApiScope(name: "write", "Write Data."),
                new ApiScope(name: "delete", "Delete Data.")
            };

        public static List<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "creditcardshopping",
                    ClientSecrets = {new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "creditcardshopping"
                    }
                }
            };
    }
}
