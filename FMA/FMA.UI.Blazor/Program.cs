using FMA.UI.Blazor;
using FMA.UI.Blazor.Contracts;
using FMA.UI.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClient, Client>();

builder.Services.AddMudServices();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri($"{builder.Configuration.GetValue<string>("Api:ReadUrl")}"));
builder.Services.AddOidcAuthentication(options =>
{

    var settings = builder.Configuration.GetSection("oidc");
    builder.Configuration.Bind(settings.Key, options.ProviderOptions);
});


builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();

