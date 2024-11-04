using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiParte;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5101/") });
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AuthenticationStateProviderService>(); // Registro del servicio
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderService>(); // Registro de la implementación
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
