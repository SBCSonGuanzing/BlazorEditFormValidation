using BlazorPlayGround.Client;
using BlazorPlayGround.Client.Services.DifficultyService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPlayGround.Shared.Models;
using BlazorPlayGround.Client.Services.TeamService;
using BlazorPlayGround.Client.Services.CharacterServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClientTeamService, ClientTeamService>();
builder.Services.AddScoped<IClientDifficultyService, ClientDifficultyService>();
builder.Services.AddScoped<IClientCharacterService, ClientCharacterService>();


await builder.Build().RunAsync();
