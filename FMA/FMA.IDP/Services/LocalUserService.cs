using FMA.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FMA.IDP.Services
{
    public class LocalUserService : ILocalUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly FMAIdentityDbContext _context;

        public LocalUserService(UserManager<IdentityUser> userManager, FMAIdentityDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsByIdAsync(string subject)
        {
            var user = await GetUserByIdAsync(subject);
            var claims = await _userManager.GetClaimsAsync(user);
            return claims;
        }

        public async Task<IdentityUser> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserByIdAsync(subject);

            if (user == null)
            {
                return false;
            }

            return true;

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = await GetUserByNameAsync(userName);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public async Task<IdentityUser> GetUserByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public Task<IEnumerable<IdentityUser>> ReadUsersNotActive()
        {
            throw new NotImplementedException();
        }
    }
}
