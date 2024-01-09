using FMA.UI.Blazor.Services;

namespace FMA.UI.Blazor.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated();
        Task AddAuthorizationHeader(IClient client);
    }
}
