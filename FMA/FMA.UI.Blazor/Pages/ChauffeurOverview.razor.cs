using FMA.UI.Blazor.Contracts;
using FMA.UI.Blazor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace FMA.UI.Blazor.Pages
{
    [Authorize]
    public partial class ChauffeurOverview
    {
        [Inject]
        public IClient Client { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        private HubConnection? _hubConnection;
        public ICollection<ChauffeurListDTO> Chauffeurs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await StartConnectionAsync();
            await AuthenticationService.AddAuthorizationHeader(Client);
            Chauffeurs = await Client.ReadAllChauffeursAsync();

        }

        private async Task StartConnectionAsync()
        {
            var hub = await Client.ReadSignalRConfigAsync();
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"https://localhost:7162{hub.Hub.Endpoint}")
                .Build();

            _hubConnection.On<string>(hub.Hub.Method.Name, async message =>
            {
                Chauffeurs = await Client.ReadAllChauffeursAsync();
                StateHasChanged();
            });

            await _hubConnection.StartAsync();
        }

    }
}
