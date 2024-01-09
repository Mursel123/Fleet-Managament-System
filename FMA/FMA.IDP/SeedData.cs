using FMA.Identity;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FMA.IDP
{
    public class SeedData
    {
        private readonly UserManager<IdentityUser> _userManager;

        public SeedData(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedDataAsync(IConfiguration config)
        {
            var adminUser = new IdentityUser
            {
                UserName = config["User2:Email"],
                Email = config["User2:Email"],

            };

            var chauffeurUser = new IdentityUser
            {
                UserName = config["User1:Email"],
                Email = config["User1:Email"],

            };

            if (await _userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                
                await _userManager.CreateAsync(adminUser, config["User2:Password"]);

                // Add claims to the admin user
                await _userManager.AddClaimAsync(adminUser, new Claim("email", adminUser.Email));
                await _userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Role, "Admin"));
            }

            if (await _userManager.FindByEmailAsync(chauffeurUser.Email) == null)
            {
                await _userManager.CreateAsync(chauffeurUser, config["User1:Password"]);

                // Add claims to the admin user
                await _userManager.AddClaimAsync(chauffeurUser, new Claim("email", chauffeurUser.Email));
                await _userManager.AddClaimAsync(chauffeurUser, new Claim(JwtClaimTypes.Role, "Chauffeur"));
            }
        }
    }
}
