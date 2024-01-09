using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FMA.IDP.Services
{
    public interface ILocalUserService
    {
        Task<bool> ValidateCredentialsAsync(
             string userName,
             string password);
        Task<IEnumerable<Claim>> GetUserClaimsByIdAsync(
            string subject);
        Task<IEnumerable<IdentityUser>> ReadUsersNotActive();
        Task<IdentityUser> GetUserByIdAsync(
            string id);
        Task<IdentityUser> GetUserByNameAsync(
            string name);
        Task<bool> IsUserActive(string subject);

        Task SaveChangesAsync();
    }
}
