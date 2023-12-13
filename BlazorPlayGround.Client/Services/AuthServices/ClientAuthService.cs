using BlazorPlayGround.Shared.DTOs;
using BlazorPlayGround.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorPlayGround.Client.Services.AuthServices
{

    public class ClientAuthService : IClientAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientAuthService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }


        public List<UserLogin> users { get; set; } = new List<UserLogin>();
        public Token token { get; set; } = new Token();

        public async Task<List<UserLogin>> GetAllUser()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserLogin>>($"api/Auth");
            if (result != null)
            {
                users = result;
            }
            return result; 
        }

        public async Task<string> Login(LoginDTo request)
        {

            
            var result = await _httpClient.PostAsJsonAsync("api/Auth/login", request);

            var data = await SetToken(result);

            return data;
        }

        public async Task Register(UserLoginDto request)
        {
            await _httpClient.PostAsJsonAsync("api/Auth/register", request);
            _navigationManager.NavigateTo("/");
        }

        private async Task<string> SetToken(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                token.Value = await message.Content.ReadAsStringAsync();
                return "success";
            }
            else
            {
                return await message.Content.ReadAsStringAsync();
            }
        }
    }
}
