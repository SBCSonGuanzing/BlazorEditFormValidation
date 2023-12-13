global using Microsoft.AspNetCore.Components.Authorization;
using BlazorPlayGround.Client;
using BlazorPlayGround.Client.Services.DifficultyService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPlayGround.Shared.Models;
using BlazorPlayGround.Client.Services.TeamService;
using BlazorPlayGround.Client.Services.CharacterServices;
using MudBlazor.Services;
using Blazored.LocalStorage;
using BlazorPlayGround.Client.Services.AuthServices;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClientTeamService, ClientTeamService>();
builder.Services.AddScoped<IClientDifficultyService, ClientDifficultyService>();
builder.Services.AddScoped<IClientCharacterService, ClientCharacterService>();
builder.Services.AddScoped<IClientAuthService, ClientAuthService>();
builder.Services.AddMudServices();

// Register the Authentication State Provider 
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
