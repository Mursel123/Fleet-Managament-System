using FMA.Application;
using FMA.Domain.Config;
using FMA.Persistence;
using FMA.Startup.Middlewares;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Serilog;

namespace FMA.Startup
{
    public static class StartupExtensions
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder, bool isReadApi)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {

                    options.Authority = $"{builder.Configuration.GetValue<string>("IDP:Url")}";
                    options.Audience = "fleetmanagementapi";
                    options.TokenValidationParameters = new()
                    {
                        NameClaimType = "given_name",
                        ValidTypes = new[] { "at+jwt" },
                        RoleClaimType = JwtClaimTypes.Role
                    };
                });

            builder.Host.UseSerilog((context, loggerConfig) => 
             loggerConfig.ReadFrom.Configuration(context.Configuration));
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var apiScope = new Dictionary<string, string>();

            if (isReadApi)
                apiScope = new Dictionary<string, string>() { { "fleetmanagementapi.read", "Fleet Management Read API" } };
            else
                apiScope = new Dictionary<string, string>() { { "fleetmanagementapi.write", "Fleet Management Write API" } };

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddSwaggerGen(options =>
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Implicit = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{builder.Configuration.GetValue<string>("IDP:Url")}/connect/authorize"),
                                TokenUrl = new Uri($"{builder.Configuration.GetValue<string>("IDP:Url")}/connect/token"),
                                Scopes = apiScope
                            }
                        },
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "oauth2",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                });
            }
            


            builder.Services.AddCors(options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200", "https://localhost:7162", "https://localhost:7172", "https://localhost:7268")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials();


                    });

                }
                else if (builder.Environment.IsProduction())
                {
                    options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("https://fake-angular-app.azurestaticapps.net")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials();

                    });
                }
            });

            builder.Services.AddScoped<ExceptionHandlerMiddleware>();
            builder.Services.AddSignalR();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.Configure<SignalR>(builder.Configuration.GetSection("SignalR"));
            builder.Services.AddApplicationServices();

            return builder.Build();
        }

        public static async Task<WebApplication> ConfigurePipelineAsync(this WebApplication app, WebApplicationBuilder builder, string[] args)
        {
            if (app.Environment.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var id = builder.Configuration.GetValue<string>("ClientSwagger:ClientId");
                    var secret = builder.Configuration["ClientSwagger:ClientSecret"];
                    c.OAuthClientId(id);
                    c.OAuthClientSecret(secret);
                    c.OAuthScopeSeparator(" ");

                });


            }

            if (args.Contains("/seed"))
            {
                await SeedData.EnsurePopulatedAsync(app);
                return app;
            }

            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseSerilogRequestLogging();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.MapHub<NotificationHub>(builder.Configuration.GetValue<string>("SignalR:Hub:Endpoint"));
            app.MapControllers();

            app.Run();

            return app;
        }
    }
}
