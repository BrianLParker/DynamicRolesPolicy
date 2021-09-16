using DynamicRolesPolicy.Client;
using DynamicRolesPolicy.Shared.Policies;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("DynamicRolesPolicy.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("DynamicRolesPolicy.ServerAPI"));

builder.Services.AddApiAuthorization().AddAccountClaimsPrincipalFactory<CustomUserFactory>();
builder.Services.AddPolicies(builder.Configuration);
await builder.Build().RunAsync();
