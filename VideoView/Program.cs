global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VideoView;
using VideoView.Services.AuthService;
using VideoView.Services.CatsService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ICatsService, CatsService>();
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
