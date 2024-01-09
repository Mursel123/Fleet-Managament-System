using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace FMA.UI.Blazor.Shared
{

    public partial class NavMenu
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private void Login()
        {
            NavigationManager.NavigateToLogin("authentication/login");
        }

        private void Logout()
        {
            NavigationManager.NavigateToLogout("authentication/logout");
        }
    }
}
