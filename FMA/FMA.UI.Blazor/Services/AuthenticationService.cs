using FMA.UI.Blazor.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace FMA.UI.Blazor.Services
{
    public class AuthenticationService : IAuthenticationService    
    {
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private IAccessTokenProvider TokenProvider { get; set; }
        public AuthenticationService(AuthenticationStateProvider authenticationStateProvider, IAccessTokenProvider tokenProvider)
        {
            AuthenticationStateProvider = authenticationStateProvider;
            TokenProvider = tokenProvider;
        }

        public async Task<bool> IsAuthenticated()
        {
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            return authenticationState.User.Identity.IsAuthenticated;
        }

        public async Task AddAuthorizationHeader(IClient client)
        {
            var accessTokenResult = await TokenProvider.RequestAccessToken();

            if (accessTokenResult.Status == AccessTokenResultStatus.Success)
            {
                if (accessTokenResult.TryGetToken(out var token))
                {
                    client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                }
                
            }
        }
    }
}
