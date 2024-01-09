using FMA.Identity;
using FMA.IDP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FMA.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<FMAIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FleetManagementIdentityConnectionString")));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FMAIdentityDbContext>();

        builder.Services.AddIdentityServer(options =>
            {

                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryInformation(builder.Configuration);


        builder.Services.AddScoped<SeedData>();
        builder.Services.AddScoped<ILocalUserService, LocalUserService>();

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();
            
        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
