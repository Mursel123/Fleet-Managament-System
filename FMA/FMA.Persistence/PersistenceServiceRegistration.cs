using FMA.Contracts.Persistence;
using FMA.Domain.Config;
using FMA.Domain.Entities;
using FMA.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace FMA.Persistence
{
    public static class PersistenceServiceRegistration
    {
        
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<FMADbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableDetailedErrors();
                options.ConfigureWarnings(warningAction =>
                {
                    warningAction.Log(
                            CoreEventId.FirstWithoutOrderByAndFilterWarning,
                            CoreEventId.RowLimitingOperationWithoutOrderByWarning
                        );
                });

                options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:FleetManagementConnectionString"), options => 
                {
                    options.EnableRetryOnFailure(maxRetryCount: 3);
                });
                
            });

            services.AddScoped<IWriteDbContext, FMADbContext>();
            services.AddScoped<IReadDbContext, FMADbContext>();
            services.AddScoped<IBaseRepository<Voertuig>,VoertuigRepository>();
            services.AddScoped<IVoertuigRepository, VoertuigRepository>();
            services.AddScoped<SeedData>();
            services.Configure<Connection>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }

}
