using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;
using System;
using System.Security.Claims;

namespace FMA.IDP;

public static class Config
{
    private static IConfiguration _configuration;
    public static void AddInMemoryInformation(this IIdentityServerBuilder builder, IConfiguration configuration)
    {
        _configuration = configuration;
        builder.AddInMemoryIdentityResources(IdentityResources)
            .AddInMemoryApiScopes(ApiScopes)
            .AddInMemoryApiResources(ApiResources)
            .AddInMemoryClients(Clients);
        
    }
    private static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles",
                "Your role(s)",
                new [] { JwtClaimTypes.Role }),
             new IdentityResource("email",
                "Your email",
                new [] { JwtClaimTypes.Email })
        };

    private static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
            {
                new ApiResource("fleetmanagementapi", "FMA Api", new [] {JwtClaimTypes.Role, JwtClaimTypes.Email})
                {
                    Scopes =
                    {
                        "fleetmanagementapi.write",
                        "fleetmanagementapi.read"
                    }
                },
            };

    private static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { 
                new ApiScope("fleetmanagementapi.write"),
                new ApiScope("fleetmanagementapi.read")
            };

    private static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client()
                {
                    ClientName = "FleetManagement",
                    ClientId = _configuration.GetValue<string>("Client:ClientId"),
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { $"{_configuration.GetValue<string>("Angular:Url")}/signin-callback" },
                    PostLogoutRedirectUris = { $"{_configuration.GetValue<string>("Angular:Url")}/signout-callback" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "fleetmanagementapi.write",
                        "fleetmanagementapi.read",
                        "roles",
                        "email"
                    },
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { $"{_configuration.GetValue<string>("Angular:Url")}" }
                },
                 new Client()
                {
                    ClientName = "FleetManagementBlazor",
                    ClientId = _configuration.GetValue<string>("ClientBlazor:ClientId"),
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "fleetmanagementapi.read",
                        "fleetmanagementapi.write",
                        "roles",
                        "email"
                    },
                    RedirectUris = { "https://localhost:7268/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:7268/authentication/logout-callback" },
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowedCorsOrigins = { "https://localhost:7268" }
                },
                new Client()    
                {
                    ClientName = "FleetManagementSwaggerRead",
                    ClientId = _configuration.GetValue<string>("ClientSwagger:ClientReadId"),
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:7172/swagger/oauth2-redirect.html" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "fleetmanagementapi.read",
                        "roles",
                        "email"
                    },
                    ClientSecrets = { new Secret(_configuration["ClientSwagger:ClientReadSecret"])},
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = { "https://localhost:7172" }
                },
                new Client()
                {
                    ClientName = "FleetManagementSwaggerWrite",
                    ClientId = _configuration.GetValue<string>("ClientSwagger:ClientWriteId"),
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:7162/swagger/oauth2-redirect.html" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "fleetmanagementapi.write",
                        "roles",
                        "email"
                    },
                    ClientSecrets = { new Secret(_configuration["ClientSwagger:ClientWriteSecret"])},
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = { "https://localhost:7162" }
                }

            };
}